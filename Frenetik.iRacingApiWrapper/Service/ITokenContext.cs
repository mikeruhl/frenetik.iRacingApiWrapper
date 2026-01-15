namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Provides access to the current token for the async execution flow.
/// Used for multi-user scenarios where different tokens are needed per request.
/// </summary>
public interface ITokenContext
{
    /// <summary>
    /// Gets the current token for this async context, if set.
    /// </summary>
    string? CurrentToken { get; }

    /// <summary>
    /// Sets the token for the current async execution flow.
    /// This token will be available for the duration of the async operation.
    /// </summary>
    /// <param name="token">The bearer token to use for API requests in this context</param>
    /// <returns>A disposable scope that restores the previous token when disposed</returns>
    IDisposable SetToken(string token);
}
