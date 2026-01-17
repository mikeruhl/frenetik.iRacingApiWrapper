using System.Net;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Frenetik.iRacingApiWrapper.Tests;

public class PasswordLimitedTokenHandlerTests
{
    private readonly Mock<ITokenProvider> _tokenProviderMock;
    private readonly IRacingDataSettings _settings;
    private readonly Mock<HttpMessageHandler> _innerHandlerMock;

    public PasswordLimitedTokenHandlerTests()
    {
        _tokenProviderMock = new Mock<ITokenProvider>();
        _settings = new IRacingDataSettings
        {
            BaseUrl = "https://members-ng.iracing.com"
        };
        _innerHandlerMock = new Mock<HttpMessageHandler>();
    }

    [Fact]
    public void Constructor_WithNullTokenProvider_ThrowsArgumentNullException()
    {
        // Arrange
        var options = Options.Create(_settings);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new PasswordLimitedTokenHandler(null!, options));
    }

    [Fact]
    public void Constructor_WithNullSettings_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new PasswordLimitedTokenHandler(_tokenProviderMock.Object, null!));
    }

    [Fact]
    public void Constructor_WithValidParameters_DoesNotThrow()
    {
        // Arrange
        var options = Options.Create(_settings);

        // Act
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options);

        // Assert
        Assert.NotNull(handler);
    }

    [Fact]
    public async Task SendAsync_WithIRacingUrl_AddsAuthorizationHeader()
    {
        // Arrange
        const string expectedToken = "test-bearer-token";
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedToken);

        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");

        _innerHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() => new HttpResponseMessage(HttpStatusCode.OK));

        using var invoker = new HttpMessageInvoker(handler);

        // Act
        using (await invoker.SendAsync(request, CancellationToken.None))
        {
            // Assert
            Assert.NotNull(request.Headers.Authorization);
            Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
            Assert.Equal(expectedToken, request.Headers.Authorization.Parameter);
            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }

    [Fact]
    public async Task SendAsync_WithExternalUrl_DoesNotAddAuthorizationHeader()
    {
        // Arrange
        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://images-static.iracing.com/some-image.jpg");

        _innerHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        using var invoker = new HttpMessageInvoker(handler);

        // Act
        using (await invoker.SendAsync(request, CancellationToken.None))
        {
            // Assert
            Assert.Null(request.Headers.Authorization);
            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }

    [Fact]
    public async Task SendAsync_WithS3Url_DoesNotAddAuthorizationHeader()
    {
        // Arrange
        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://scorpio-assets.s3.amazonaws.com/data.json");

        _innerHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        using var invoker = new HttpMessageInvoker(handler);

        // Act
        using (await invoker.SendAsync(request, CancellationToken.None))
        {
            // Assert
            Assert.Null(request.Headers.Authorization);
            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }

    [Fact]
    public async Task SendAsync_WithEmptyToken_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available from ITokenProvider", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithNullToken_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((string?)null);

        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available from ITokenProvider", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceToken_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync("   ");

        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available from ITokenProvider", exception.Message);
    }

    [Fact]
    public async Task SendAsync_PassesCancellationTokenToProvider()
    {
        // Arrange
        const string expectedToken = "test-bearer-token";
        var cts = new CancellationTokenSource();

        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedToken);

        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");

        _innerHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() => new HttpResponseMessage(HttpStatusCode.OK));

        using var invoker = new HttpMessageInvoker(handler);

        // Act
        using (await invoker.SendAsync(request, cts.Token))
        {
            // Assert
            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(cts.Token), Times.Once);
        }
    }

    [Fact]
    public async Task SendAsync_WithMultipleRequests_CallsProviderForEachRequest()
    {
        // Arrange
        const string expectedToken = "test-bearer-token";
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedToken);

        var options = Options.Create(_settings);
        var handler = new PasswordLimitedTokenHandler(_tokenProviderMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        _innerHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() => new HttpResponseMessage(HttpStatusCode.OK));

        using var invoker = new HttpMessageInvoker(handler);

        // Act
        using var request1 = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using (await invoker.SendAsync(request1, CancellationToken.None)) { }

        using var request2 = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/member/get");
        using (await invoker.SendAsync(request2, CancellationToken.None)) { }

        // Assert
        _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
    }
}
