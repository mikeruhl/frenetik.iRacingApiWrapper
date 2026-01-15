using System.Net;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Frenetik.iRacingApiWrapper.Tests;

public class BearerTokenDelegatingHandlerTests
{
    private readonly Mock<ITokenProvider> _tokenProviderMock;
    private readonly Mock<ITokenContext> _tokenContextMock;
    private readonly IRacingDataSettings _settings;
    private readonly Mock<HttpMessageHandler> _innerHandlerMock;

    public BearerTokenDelegatingHandlerTests()
    {
        _tokenProviderMock = new Mock<ITokenProvider>();
        _tokenContextMock = new Mock<ITokenContext>();
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
            new BearerTokenDelegatingHandler(null!, options));
    }

    [Fact]
    public void Constructor_WithNullSettings_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new BearerTokenDelegatingHandler(_tokenProviderMock.Object, null!));
    }

    [Fact]
    public void Constructor_WithTokenContext_DoesNotThrow()
    {
        // Arrange
        var options = Options.Create(_settings);

        // Act
        var handler = new BearerTokenDelegatingHandler(
            _tokenProviderMock.Object,
            options,
            _tokenContextMock.Object);

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
        var handler = new BearerTokenDelegatingHandler(_tokenProviderMock.Object, options)
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
        }
    }

    [Fact]
    public async Task SendAsync_WithExternalUrl_DoesNotAddAuthorizationHeader()
    {
        // Arrange
        var options = Options.Create(_settings);
        var handler = new BearerTokenDelegatingHandler(_tokenProviderMock.Object, options)
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
    public async Task SendAsync_WithTokenContext_UsesContextTokenOverProvider()
    {
        // Arrange
        const string contextToken = "context-bearer-token";
        const string providerToken = "provider-bearer-token";

        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(contextToken);
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(providerToken);

        var options = Options.Create(_settings);
        var handler = new BearerTokenDelegatingHandler(
            _tokenProviderMock.Object,
            options,
            _tokenContextMock.Object)
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
            Assert.Equal(contextToken, request.Headers.Authorization.Parameter);

            // Token provider should not be called when context has a token
            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }

    [Fact]
    public async Task SendAsync_WithEmptyContextToken_FallsBackToProvider()
    {
        // Arrange
        const string providerToken = "provider-bearer-token";

        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(string.Empty);
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(providerToken);

        var options = Options.Create(_settings);
        var handler = new BearerTokenDelegatingHandler(
            _tokenProviderMock.Object,
            options,
            _tokenContextMock.Object)
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
        using var response = await invoker.SendAsync(request, CancellationToken.None);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(providerToken, request.Headers.Authorization.Parameter);

        // Token provider should be called when context token is empty
        _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WithNullContextToken_FallsBackToProvider()
    {
        // Arrange
        const string providerToken = "provider-bearer-token";

        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns((string?)null);
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(providerToken);

        var options = Options.Create(_settings);
        var handler = new BearerTokenDelegatingHandler(
            _tokenProviderMock.Object,
            options,
            _tokenContextMock.Object)
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
            Assert.Equal(providerToken, request.Headers.Authorization.Parameter);

            // Token provider should be called when context token is null
            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }

    [Fact]
    public async Task SendAsync_WithNoTokenAvailable_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns((string?)null);
        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        var options = Options.Create(_settings);
        var handler = new BearerTokenDelegatingHandler(
            _tokenProviderMock.Object,
            options,
            _tokenContextMock.Object)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithoutTokenContext_UsesProviderToken()
    {
        // Arrange
        const string providerToken = "provider-bearer-token";

        _tokenProviderMock.Setup(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(providerToken);

        var options = Options.Create(_settings);
        var handler = new BearerTokenDelegatingHandler(
            _tokenProviderMock.Object,
            options,
            null) // No token context
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
            Assert.Equal(providerToken, request.Headers.Authorization.Parameter);

            _tokenProviderMock.Verify(tp => tp.GetTokenAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
