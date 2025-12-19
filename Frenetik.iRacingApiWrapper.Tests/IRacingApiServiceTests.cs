using System.Net;
using System.Text.Json;
using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Frenetik.iRacingApiWrapper.Tests;

public class IRacingApiServiceTests
{
    private readonly Mock<ILogger<IRacingApiService>> _loggerMock;
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;

    public IRacingApiServiceTests()
    {
        _loggerMock = new Mock<ILogger<IRacingApiService>>();
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://members-ng.iracing.com")
        };

        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _httpClientFactoryMock
            .Setup(f => f.CreateClient(IRacingApiService.HttpClientName))
            .Returns(_httpClient);
    }

    [Fact]
    public async Task GetAssets_RespectsMaxParallelAssetRequests()
    {
        // Arrange
        const int maxParallel = 3;
        const int totalAssets = 10;
        var settings = Options.Create(new IRacingDataSettings
        {
            MaxParallelAssetRequests = maxParallel
        });

        var service = new IRacingApiService(_httpClientFactoryMock.Object, settings, _loggerMock.Object);

        // Track concurrent requests
        var currentConcurrent = 0;
        var maxConcurrent = 0;
        var lockObject = new object();

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns(async (HttpRequestMessage request, CancellationToken token) =>
            {
                // Increment concurrent counter
                lock (lockObject)
                {
                    currentConcurrent++;
                    if (currentConcurrent > maxConcurrent)
                    {
                        maxConcurrent = currentConcurrent;
                    }
                }

                // Simulate some work
                await Task.Delay(50, token);

                // Return a successful response with mock data
                var responseContent = JsonSerializer.Serialize(new TestAssetResponse { Id = 1, Name = "Test" });
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(responseContent)
                };

                // Decrement concurrent counter
                lock (lockObject)
                {
                    currentConcurrent--;
                }

                return response;
            });

        // Create a list of asset URLs to fetch
        var assets = Enumerable.Range(1, totalAssets).Select(i => $"asset{i}.json").ToList();

        // Act
        // Using reflection to call the private generic GetAssets<T> method
        var getAssetsMethod = typeof(IRacingApiService).GetMethod("GetAssets",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var genericMethod = getAssetsMethod!.MakeGenericMethod(typeof(TestAssetResponse));

        var task = (Task<List<TestAssetResponse>>)genericMethod.Invoke(
            service,
            new object[] { "https://example.com/assets", assets })!;

        var results = await task;

        // Assert
        Assert.Equal(totalAssets, results.Count);
        Assert.True(maxConcurrent <= maxParallel,
            $"Expected max concurrent requests to be <= {maxParallel}, but was {maxConcurrent}");
    }

    [Fact]
    public async Task GetAssets_WithEmptyList_ReturnsEmptyList()
    {
        // Arrange
        var settings = Options.Create(new IRacingDataSettings());
        var service = new IRacingApiService(_httpClientFactoryMock.Object, settings, _loggerMock.Object);

        // Act
        var getAssetsMethod = typeof(IRacingApiService).GetMethod("GetAssets",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var genericMethod = getAssetsMethod!.MakeGenericMethod(typeof(TestAssetResponse));

        var task = (Task<List<TestAssetResponse>>)genericMethod.Invoke(
            service,
            new object[] { "https://example.com/assets", new List<string>() })!;

        var results = await task;

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public async Task GetAssets_WithCustomMaxParallel_RespectsLimit()
    {
        // Arrange
        const int maxParallel = 5;
        const int totalAssets = 20;
        var settings = Options.Create(new IRacingDataSettings
        {
            MaxParallelAssetRequests = maxParallel
        });

        var service = new IRacingApiService(_httpClientFactoryMock.Object, settings, _loggerMock.Object);

        var currentConcurrent = 0;
        var maxConcurrent = 0;
        var lockObject = new object();

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns(async (HttpRequestMessage request, CancellationToken token) =>
            {
                lock (lockObject)
                {
                    currentConcurrent++;
                    maxConcurrent = Math.Max(maxConcurrent, currentConcurrent);
                }

                await Task.Delay(30, token);

                var responseContent = JsonSerializer.Serialize(new TestAssetResponse { Id = 1, Name = "Test" });
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(responseContent)
                };

                lock (lockObject)
                {
                    currentConcurrent--;
                }

                return response;
            });

        var assets = Enumerable.Range(1, totalAssets).Select(i => $"asset{i}.json").ToList();

        // Act
        var getAssetsMethod = typeof(IRacingApiService).GetMethod("GetAssets",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var genericMethod = getAssetsMethod!.MakeGenericMethod(typeof(TestAssetResponse));

        var task = (Task<List<TestAssetResponse>>)genericMethod.Invoke(
            service,
            new object[] { "https://example.com/assets", assets })!;

        var results = await task;

        // Assert
        Assert.Equal(totalAssets, results.Count);
        Assert.True(maxConcurrent <= maxParallel,
            $"Expected max concurrent requests to be <= {maxParallel}, but was {maxConcurrent}");
        // Also verify we actually hit some concurrency (not just serial execution)
        Assert.True(maxConcurrent > 1, "Expected some concurrent execution");
    }

    private class TestAssetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
