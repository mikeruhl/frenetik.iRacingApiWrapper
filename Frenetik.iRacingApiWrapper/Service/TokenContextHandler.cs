using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Options;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// DelegatingHandler for multi-user scenarios using ITokenContext.
/// Adds bearer token authentication to iRacing API requests using per-request tokens set via ITokenContext.SetToken().
/// External requests (S3, CDN, etc.) are passed through without authentication.
/// </summary>
public class TokenContextHandler : DelegatingHandler
{
    private readonly ITokenContext _tokenContext;
    private readonly IRacingDataSettings _settings;

    /// <summary>
    /// Constructor for the TokenContextHandler
    /// </summary>
    /// <param name="tokenContext">Token context for per-request tokens in multi-user scenarios</param>
    /// <param name="settings">iRacing settings containing the base URL</param>
    public TokenContextHandler(
        ITokenContext tokenContext,
        IOptions<IRacingDataSettings> settings)
    {
        _tokenContext = tokenContext ?? throw new ArgumentNullException(nameof(tokenContext));
        ArgumentNullException.ThrowIfNull(settings);
        _settings = settings.Value;
    }

    /// <summary>
    /// Sends an HTTP request, adding bearer token authentication only for iRacing API requests.
    /// Uses the token set via ITokenContext.SetToken() for this request.
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
            var token = _tokenContext.CurrentToken;

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException(
                    "No bearer token available from ITokenContext. Ensure ITokenContext.SetToken() is called before making API requests.");
            }

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
