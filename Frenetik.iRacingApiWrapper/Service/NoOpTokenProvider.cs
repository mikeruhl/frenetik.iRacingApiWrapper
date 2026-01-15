namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// A no-operation token provider for multi-user scenarios where tokens are provided per-request via ITokenContext.
/// This provider returns an empty string and relies on the BearerTokenDelegatingHandler to use the token from ITokenContext instead.
/// </summary>
public class NoOpTokenProvider : ITokenProvider
{
    /// <summary>
    /// Returns an empty string. The actual token should be set via ITokenContext.SetToken() for each request.
    /// </summary>
    /// <param name="cancellationToken">Token to observe while waiting for the token.</param>
    /// <returns>An empty string</returns>
    public Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(string.Empty);
    }
}
