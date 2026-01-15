using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Options;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// DelegatingHandler that intelligently adds bearer token authentication only to iRacing API requests.
/// External requests (S3, CDN, etc.) are passed through without authentication.
/// Supports both single-user (via ITokenProvider) and multi-user scenarios (via ITokenContext).
/// </summary>
public class BearerTokenDelegatingHandler : DelegatingHandler
{
    private readonly ITokenProvider _tokenProvider;
    private readonly ITokenContext? _tokenContext;
    private readonly IRacingDataSettings _settings;

    /// <summary>
    /// Constructor for the BearerTokenDelegatingHandler
    /// </summary>
    /// <param name="tokenProvider">Token provider that supplies bearer tokens</param>
    /// <param name="settings">iRacing settings containing the base URL</param>
    /// <param name="tokenContext">Optional token context for per-request tokens in multi-user scenarios</param>
    public BearerTokenDelegatingHandler(
        ITokenProvider tokenProvider,
        IOptions<IRacingDataSettings> settings,
        ITokenContext? tokenContext = null)
    {
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        _tokenContext = tokenContext;
        ArgumentNullException.ThrowIfNull(settings);
        _settings = settings.Value;
    }

    /// <summary>
    /// Sends an HTTP request, adding bearer token authentication only for iRacing API requests.
    /// Checks for per-request token via ITokenContext first, then falls back to ITokenProvider.
    /// </summary>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Only add authentication for iRacing base URL requests
        // External URLs (S3, CDN, etc.) should not include Authorization header
        if (request.RequestUri != null &&
            request.RequestUri.AbsoluteUri.StartsWith(_settings.BaseUrl, StringComparison.OrdinalIgnoreCase))
        {
            // Check for per-request token first (multi-user scenario), then fall back to token provider (single-user scenario)
            var token = _tokenContext?.CurrentToken;

            if (string.IsNullOrWhiteSpace(token))
            {
                token = await _tokenProvider.GetTokenAsync(cancellationToken);
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException(
                    "No bearer token available. Either set a token via ITokenContext.SetToken() or configure a valid ITokenProvider.");
            }

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
