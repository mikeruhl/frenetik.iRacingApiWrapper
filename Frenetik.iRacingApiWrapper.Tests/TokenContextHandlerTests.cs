using System.Net;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Frenetik.iRacingApiWrapper.Tests;

public class TokenContextHandlerTests
{
    private readonly Mock<ITokenContext> _tokenContextMock;
    private readonly IRacingDataSettings _settings;
    private readonly Mock<HttpMessageHandler> _innerHandlerMock;

    public TokenContextHandlerTests()
    {
        _tokenContextMock = new Mock<ITokenContext>();
        _settings = new IRacingDataSettings
        {
            BaseUrl = "https://members-ng.iracing.com"
        };
        _innerHandlerMock = new Mock<HttpMessageHandler>();
    }

    [Fact]
    public void Constructor_WithNullTokenContext_ThrowsArgumentNullException()
    {
        // Arrange
        var options = Options.Create(_settings);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new TokenContextHandler(null!, options));
    }

    [Fact]
    public void Constructor_WithNullSettings_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new TokenContextHandler(_tokenContextMock.Object, null!));
    }

    [Fact]
    public void Constructor_WithValidParameters_DoesNotThrow()
    {
        // Arrange
        var options = Options.Create(_settings);

        // Act
        var handler = new TokenContextHandler(_tokenContextMock.Object, options);

        // Assert
        Assert.NotNull(handler);
    }

    [Fact]
    public async Task SendAsync_WithIRacingUrl_AddsAuthorizationHeader()
    {
        // Arrange
        const string expectedToken = "context-bearer-token";
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(expectedToken);

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
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
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
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
            _tokenContextMock.Verify(tc => tc.CurrentToken, Times.Never);
        }
    }

    [Fact]
    public async Task SendAsync_WithS3Url_DoesNotAddAuthorizationHeader()
    {
        // Arrange
        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
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
            _tokenContextMock.Verify(tc => tc.CurrentToken, Times.Never);
        }
    }

    [Fact]
    public async Task SendAsync_WithEmptyToken_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(string.Empty);

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available from ITokenContext", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithNullToken_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns((string?)null);

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available from ITokenContext", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceToken_ThrowsInvalidOperationException()
    {
        // Arrange
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns("   ");

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        Assert.Contains("No bearer token available from ITokenContext", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithMultipleRequests_UsesContextTokenForEach()
    {
        // Arrange
        const string token1 = "context-token-1";
        const string token2 = "context-token-2";

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
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

        // Act - First request
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(token1);
        using var request1 = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using (_ = await invoker.SendAsync(request1, CancellationToken.None))
        {
            Assert.Equal(token1, request1.Headers.Authorization?.Parameter);
        }

        // Act - Second request with different token
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(token2);
        using var request2 = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/member/get");
        using (_ = await invoker.SendAsync(request2, CancellationToken.None))
        {
            Assert.Equal(token2, request2.Headers.Authorization?.Parameter);
        }
    }

    [Fact]
    public async Task SendAsync_AccessesCurrentTokenPropertyOnlyForIRacingUrls()
    {
        // Arrange
        const string expectedToken = "context-bearer-token";
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns(expectedToken);

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
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

        // Act - iRacing URL should access CurrentToken
        using var iracingRequest = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using (await invoker.SendAsync(iracingRequest, CancellationToken.None)) { }

        // Act - External URL should NOT access CurrentToken
        using var externalRequest = new HttpRequestMessage(HttpMethod.Get, "https://external.com/data.json");
        using (await invoker.SendAsync(externalRequest, CancellationToken.None)) { }

        // Assert - CurrentToken accessed only once (for iRacing URL)
        _tokenContextMock.Verify(tc => tc.CurrentToken, Times.Once);
    }

    [Fact]
    public async Task SendAsync_ErrorMessageMentionsITokenContext()
    {
        // Arrange
        _tokenContextMock.Setup(tc => tc.CurrentToken).Returns((string?)null);

        var options = Options.Create(_settings);
        var handler = new TokenContextHandler(_tokenContextMock.Object, options)
        {
            InnerHandler = _innerHandlerMock.Object
        };

        using var request = new HttpRequestMessage(HttpMethod.Get, "https://members-ng.iracing.com/data/series/get");
        using var invoker = new HttpMessageInvoker(handler);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => invoker.SendAsync(request, CancellationToken.None));

        // Verify the error message mentions ITokenContext.SetToken()
        Assert.Contains("ITokenContext.SetToken()", exception.Message);
    }
}
