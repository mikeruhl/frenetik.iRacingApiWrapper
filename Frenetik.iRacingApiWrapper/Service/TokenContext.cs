namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Thread-safe token context using AsyncLocal for async flow.
/// Allows per-request bearer tokens in multi-user scenarios.
/// </summary>
public class TokenContext : ITokenContext
{
    private static readonly AsyncLocal<string?> _currentToken = new();

    /// <summary>
    /// Gets the current token for this async context, if set.
    /// </summary>
    public string? CurrentToken => _currentToken.Value;

    /// <summary>
    /// Sets the token for the current async execution flow.
    /// This token will be available for the duration of the async operation.
    /// </summary>
    /// <param name="token">The bearer token to use for API requests in this context</param>
    /// <returns>A disposable scope that restores the previous token when disposed</returns>
    public IDisposable SetToken(string token)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);

        var previousToken = _currentToken.Value;
        _currentToken.Value = token;

        return new TokenScope(previousToken);
    }

    private class TokenScope : IDisposable
    {
        private readonly string? _previousToken;
        private bool _disposed;

        public TokenScope(string? previousToken)
        {
            _previousToken = previousToken;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _currentToken.Value = _previousToken;
                _disposed = true;
            }
        }
    }
}
