using System.Net;
using System.Text;
using System.Text.Json;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Frenetik.iRacingApiWrapper.Tests;

public class PasswordLimitedTokenProviderTests
{
    private readonly Mock<ILogger<PasswordLimitedTokenProvider>> _loggerMock;
    private readonly PasswordLimitedTokenProviderSettings _settings;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly HttpClient _httpClient;

    public PasswordLimitedTokenProviderTests()
    {
        _loggerMock = new Mock<ILogger<PasswordLimitedTokenProvider>>();
        _settings = new PasswordLimitedTokenProviderSettings
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret",
            Username = "testuser",
            Password = "testpassword",
            TokenEndpoint = "https://oauth.iracing.com/token",
            Scope = "test-scope"
        };

        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);

        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(_httpClient);
    }

    [Fact]
    public void Constructor_WithNullSettings_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new PasswordLimitedTokenProvider(null!, _loggerMock.Object, _httpClientFactoryMock.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        var options = Options.Create(_settings);
        Assert.Throws<ArgumentNullException>(() =>
            new PasswordLimitedTokenProvider(options, null!, _httpClientFactoryMock.Object));
    }

    [Fact]
    public void Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException()
    {
        var options = Options.Create(_settings);
        Assert.Throws<ArgumentNullException>(() =>
            new PasswordLimitedTokenProvider(options, _loggerMock.Object, null!));
    }

    [Theory]
    [InlineData("", "secret", "user", "pass", "ClientId")]
    [InlineData("client", "", "user", "pass", "ClientSecret")]
    [InlineData("client", "secret", "", "pass", "Username")]
    [InlineData("client", "secret", "user", "", "Password")]
    public void Constructor_WithInvalidSettings_ThrowsArgumentException(
        string clientId, string clientSecret, string username, string password, string expectedParamName)
    {
        var invalidSettings = new PasswordLimitedTokenProviderSettings
        {
            ClientId = clientId,
            ClientSecret = clientSecret,
            Username = username,
            Password = password,
            TokenEndpoint = "https://oauth.iracing.com/token"
        };

        var options = Options.Create(invalidSettings);
        var ex = Assert.Throws<ArgumentException>(() =>
            new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object));

        Assert.Contains(expectedParamName, ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_FirstCall_ObtainsNewToken()
    {
        // Arrange
        var tokenResponse = new
        {
            access_token = "test-access-token",
            token_type = "Bearer",
            expires_in = 3600,
            refresh_token = "test-refresh-token",
            refresh_token_expires_in = 7200
        };

        SetupHttpResponse(HttpStatusCode.OK, JsonSerializer.Serialize(tokenResponse));

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act
        var token = await provider.GetTokenAsync();

        // Assert
        Assert.Equal("test-access-token", token);
        VerifyHttpRequest(Times.Once());
    }

    [Fact]
    public async Task GetTokenAsync_CalledTwiceWithinExpiry_ReturnsCachedToken()
    {
        // Arrange
        var tokenResponse = new
        {
            access_token = "test-access-token",
            token_type = "Bearer",
            expires_in = 3600,
            refresh_token = "test-refresh-token",
            refresh_token_expires_in = 7200
        };

        SetupHttpResponse(HttpStatusCode.OK, JsonSerializer.Serialize(tokenResponse));

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act
        var token1 = await provider.GetTokenAsync();
        var token2 = await provider.GetTokenAsync();

        // Assert
        Assert.Equal(token1, token2);
        VerifyHttpRequest(Times.Once()); // Should only call HTTP once
    }

    [Fact]
    public async Task GetTokenAsync_WithRefreshToken_RefreshesExpiredToken()
    {
        // Arrange
        var initialTokenResponse = new
        {
            access_token = "initial-token",
            token_type = "Bearer",
            expires_in = 1, // Expire almost immediately
            refresh_token = "test-refresh-token",
            refresh_token_expires_in = 7200
        };

        var refreshedTokenResponse = new
        {
            access_token = "refreshed-token",
            token_type = "Bearer",
            expires_in = 3600,
            refresh_token = "new-refresh-token",
            refresh_token_expires_in = 7200
        };

        var callCount = 0;
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() =>
            {
                callCount++;
                var response = callCount == 1
                    ? JsonSerializer.Serialize(initialTokenResponse)
                    : JsonSerializer.Serialize(refreshedTokenResponse);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(response, Encoding.UTF8, "application/json")
                };
            });

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act
        var token1 = await provider.GetTokenAsync();
        await Task.Delay(1100); // Wait for token to expire
        var token2 = await provider.GetTokenAsync();

        // Assert
        Assert.Equal("initial-token", token1);
        Assert.Equal("refreshed-token", token2);
        Assert.Equal(2, callCount);
    }

    [Fact]
    public async Task GetTokenAsync_WithShortExpiryTime_HandlesGracefully()
    {
        // Arrange - Test the Math.Max fix for tokens that expire in < 60 seconds
        var tokenResponse = new
        {
            access_token = "short-lived-token",
            token_type = "Bearer",
            expires_in = 30, // Less than the 60-second buffer
            refresh_token = "test-refresh-token",
            refresh_token_expires_in = 45
        };

        SetupHttpResponse(HttpStatusCode.OK, JsonSerializer.Serialize(tokenResponse));

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act
        var token = await provider.GetTokenAsync();

        // Assert
        Assert.Equal("short-lived-token", token);
        // Should not throw and should handle the negative expiry calculation
    }

    [Fact]
    public async Task GetTokenAsync_WithRateLimitError_ThrowsInvalidOperationException()
    {
        // Arrange
        var errorResponse = new { error = "too_many_requests" };

        SetupHttpResponse(
            HttpStatusCode.TooManyRequests,
            JsonSerializer.Serialize(errorResponse),
            retryAfterSeconds: 60);

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTokenAsync());
        Assert.Contains("Rate limit exceeded", ex.Message);
        Assert.Contains("60 seconds", ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_WithUnauthorizedClientError_ThrowsRateLimitException()
    {
        // Arrange - Per iRacing spec, 400 + "unauthorized_client" indicates rate limiting
        var errorResponse = new { error = "unauthorized_client" };

        SetupHttpResponse(HttpStatusCode.BadRequest, JsonSerializer.Serialize(errorResponse), retryAfterSeconds: 60);

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTokenAsync());
        Assert.Contains("Rate limit exceeded", ex.Message);
        Assert.Contains("60 seconds", ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_WithUnauthorizedClientInPlainText_ThrowsRateLimitException()
    {
        // Arrange - Test fallback to string matching when JSON parsing fails
        // Per iRacing spec, 400 + "unauthorized_client" indicates rate limiting
        SetupHttpResponse(HttpStatusCode.BadRequest, "Error: unauthorized_client - client not permitted", retryAfterSeconds: 30);

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTokenAsync());
        Assert.Contains("Rate limit exceeded", ex.Message);
        Assert.Contains("30 seconds", ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_WithGenericBadRequest_ThrowsHttpRequestException()
    {
        // Arrange
        var errorResponse = new { error = "invalid_grant", error_description = "Invalid credentials" };

        SetupHttpResponse(HttpStatusCode.BadRequest, JsonSerializer.Serialize(errorResponse));

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<HttpRequestException>(() => provider.GetTokenAsync());
        Assert.Contains("400", ex.Message);
        Assert.Contains("invalid_grant", ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_WithCaseInsensitiveJson_DeserializesCorrectly()
    {
        // Arrange - Test case-insensitive deserialization
        var tokenResponse = @"{
            ""Access_Token"": ""test-token"",
            ""TOKEN_TYPE"": ""Bearer"",
            ""EXPIRES_IN"": 3600
        }";

        SetupHttpResponse(HttpStatusCode.OK, tokenResponse);

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act
        var token = await provider.GetTokenAsync();

        // Assert
        Assert.Equal("test-token", token);
    }

    [Fact]
    public async Task GetTokenAsync_WithCancellationToken_PropagatesCancellation()
    {
        // Arrange
        var cts = new CancellationTokenSource();
        cts.Cancel();

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            provider.GetTokenAsync(cts.Token));
    }

    [Fact]
    public async Task GetTokenAsync_AfterDispose_ThrowsObjectDisposedException()
    {
        // Arrange
        var options = Options.Create(_settings);
        var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);
        provider.Dispose();

        // Act & Assert
        await Assert.ThrowsAsync<ObjectDisposedException>(() => provider.GetTokenAsync());
    }

    [Fact]
    public void Dispose_CalledMultipleTimes_DoesNotThrow()
    {
        // Arrange
        var options = Options.Create(_settings);
        var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        provider.Dispose();
        provider.Dispose(); // Should not throw
    }


    [Fact]
    public async Task GetTokenAsync_WithInvalidJsonResponse_ThrowsInvalidOperationException()
    {
        // Arrange
        SetupHttpResponse(HttpStatusCode.OK, "not valid json");

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<JsonException>(() => provider.GetTokenAsync());
    }

    [Fact]
    public async Task GetTokenAsync_WithNullAccessToken_ReturnsNull()
    {
        // Arrange
        var tokenResponse = new
        {
            access_token = (string?)null,
            token_type = "Bearer",
            expires_in = 3600
        };

        SetupHttpResponse(HttpStatusCode.OK, JsonSerializer.Serialize(tokenResponse));

        var options = Options.Create(_settings);
        using var provider = new PasswordLimitedTokenProvider(options, _loggerMock.Object, _httpClientFactoryMock.Object);

        // Act
        var token = await provider.GetTokenAsync();

        // Assert - When access_token is null in JSON, it deserializes to null
        Assert.Null(token);
    }

    private void SetupHttpResponse(HttpStatusCode statusCode, string content, int? retryAfterSeconds = null)
    {
        var response = new HttpResponseMessage
        {
            StatusCode = statusCode,
            Content = new StringContent(content, Encoding.UTF8, "application/json")
        };

        if (retryAfterSeconds.HasValue)
        {
            response.Headers.RetryAfter = new System.Net.Http.Headers.RetryConditionHeaderValue(
                TimeSpan.FromSeconds(retryAfterSeconds.Value));
        }

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);
    }

    private void VerifyHttpRequest(Times times)
    {
        _httpMessageHandlerMock.Protected()
            .Verify(
                "SendAsync",
                times,
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
    }
}
