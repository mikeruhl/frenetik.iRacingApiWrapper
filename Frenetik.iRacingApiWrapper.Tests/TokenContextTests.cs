using Frenetik.iRacingApiWrapper.Service;

namespace Frenetik.iRacingApiWrapper.Tests;

public class TokenContextTests
{
    [Fact]
    public void CurrentToken_WithNoTokenSet_ReturnsNull()
    {
        // Arrange
        var tokenContext = new TokenContext();

        // Act
        var result = tokenContext.CurrentToken;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SetToken_WithValidToken_SetsCurrentToken()
    {
        // Arrange
        var tokenContext = new TokenContext();
        const string expectedToken = "test-bearer-token";

        // Act
        using (tokenContext.SetToken(expectedToken))
        {
            // Assert
            Assert.Equal(expectedToken, tokenContext.CurrentToken);
        }
    }

    [Fact]
    public void SetToken_WithNullToken_ThrowsArgumentNullException()
    {
        // Arrange
        var tokenContext = new TokenContext();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => tokenContext.SetToken(null!));
    }

    [Fact]
    public void SetToken_WithEmptyToken_ThrowsArgumentException()
    {
        // Arrange
        var tokenContext = new TokenContext();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => tokenContext.SetToken(string.Empty));
    }

    [Fact]
    public void SetToken_WithWhitespaceToken_ThrowsArgumentException()
    {
        // Arrange
        var tokenContext = new TokenContext();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => tokenContext.SetToken("   "));
    }

    [Fact]
    public void SetToken_AfterDispose_RestoresPreviousToken()
    {
        // Arrange
        var tokenContext = new TokenContext();
        const string token = "test-bearer-token";

        // Act
        using (tokenContext.SetToken(token))
        {
            Assert.Equal(token, tokenContext.CurrentToken);
        }

        // Assert
        Assert.Null(tokenContext.CurrentToken);
    }

    [Fact]
    public void SetToken_Nested_RestoresPreviousTokenOnDispose()
    {
        // Arrange
        var tokenContext = new TokenContext();
        const string firstToken = "first-token";
        const string secondToken = "second-token";

        // Act & Assert
        using (tokenContext.SetToken(firstToken))
        {
            Assert.Equal(firstToken, tokenContext.CurrentToken);

            using (tokenContext.SetToken(secondToken))
            {
                Assert.Equal(secondToken, tokenContext.CurrentToken);
            }

            // After inner scope, should restore first token
            Assert.Equal(firstToken, tokenContext.CurrentToken);
        }

        // After outer scope, should be null
        Assert.Null(tokenContext.CurrentToken);
    }

    [Fact]
    public async Task SetToken_WithAsyncFlow_MaintainsTokenContext()
    {
        // Arrange
        var tokenContext = new TokenContext();
        const string expectedToken = "async-test-token";

        // Act
        using (tokenContext.SetToken(expectedToken))
        {
            await Task.Delay(10); // Simulate async work
            var tokenBeforeAwait = tokenContext.CurrentToken;

            await Task.Run(() =>
            {
                // Token should flow to async continuation
                Assert.Equal(expectedToken, tokenContext.CurrentToken);
            });

            var tokenAfterAwait = tokenContext.CurrentToken;

            // Assert
            Assert.Equal(expectedToken, tokenBeforeAwait);
            Assert.Equal(expectedToken, tokenAfterAwait);
        }
    }

    [Fact]
    public async Task SetToken_ConcurrentTasks_IsolatesTokens()
    {
        // Arrange
        var tokenContext = new TokenContext();
        const string token1 = "token-1";
        const string token2 = "token-2";

        // Act
        var task1 = Task.Run(async () =>
        {
            using (tokenContext.SetToken(token1))
            {
                await Task.Delay(50);
                return tokenContext.CurrentToken;
            }
        });

        var task2 = Task.Run(async () =>
        {
            using (tokenContext.SetToken(token2))
            {
                await Task.Delay(50);
                return tokenContext.CurrentToken;
            }
        });

        var results = await Task.WhenAll(task1, task2);

        // Assert
        Assert.Equal(token1, results[0]);
        Assert.Equal(token2, results[1]);
    }

    [Fact]
    public void SetToken_MultipleDisposes_DoesNotThrow()
    {
        // Arrange
        var tokenContext = new TokenContext();
        const string token = "test-token";

        // Act
        var scope = tokenContext.SetToken(token);
        scope.Dispose();
        scope.Dispose(); // Second dispose should not throw

        // Assert
        Assert.Null(tokenContext.CurrentToken);
    }
}
