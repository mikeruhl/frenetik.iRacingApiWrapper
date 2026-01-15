using Frenetik.iRacingApiWrapper.Service;

namespace Frenetik.iRacingApiWrapper.Tests;

public class NoOpTokenProviderTests
{
    [Fact]
    public async Task GetTokenAsync_ReturnsEmptyString()
    {
        // Arrange
        var provider = new NoOpTokenProvider();

        // Act
        var token = await provider.GetTokenAsync();

        // Assert
        Assert.Equal(string.Empty, token);
    }

    [Fact]
    public async Task GetTokenAsync_WithCancellationToken_ReturnsEmptyString()
    {
        // Arrange
        var provider = new NoOpTokenProvider();
        using var cts = new CancellationTokenSource();

        // Act
        var token = await provider.GetTokenAsync(cts.Token);

        // Assert
        Assert.Equal(string.Empty, token);
    }

    [Fact]
    public async Task GetTokenAsync_CalledMultipleTimes_AlwaysReturnsEmptyString()
    {
        // Arrange
        var provider = new NoOpTokenProvider();

        // Act
        var token1 = await provider.GetTokenAsync();
        var token2 = await provider.GetTokenAsync();
        var token3 = await provider.GetTokenAsync();

        // Assert
        Assert.Equal(string.Empty, token1);
        Assert.Equal(string.Empty, token2);
        Assert.Equal(string.Empty, token3);
    }

    [Fact]
    public async Task GetTokenAsync_WithCancelledToken_ReturnsEmptyStringImmediately()
    {
        // Arrange
        var provider = new NoOpTokenProvider();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act
        var token = await provider.GetTokenAsync(cts.Token);

        // Assert
        Assert.Equal(string.Empty, token);
    }
}
