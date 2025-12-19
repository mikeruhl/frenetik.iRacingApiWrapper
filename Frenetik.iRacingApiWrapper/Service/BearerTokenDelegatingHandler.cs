using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Options;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// DelegatingHandler that intelligently adds bearer token authentication only to iRacing API requests.
/// External requests (S3, CDN, etc.) are passed through without authentication.
/// </summary>
public class BearerTokenDelegatingHandler : DelegatingHandler
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IRacingDataSettings _settings;

    /// <summary>
    /// Constructor for the BearerTokenDelegatingHandler
    /// </summary>
    /// <param name="tokenProvider">Token provider that supplies bearer tokens</param>
    /// <param name="settings">iRacing settings containing the base URL</param>
    public BearerTokenDelegatingHandler(
        ITokenProvider tokenProvider,
        IOptions<IRacingDataSettings> settings)
    {
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        ArgumentNullException.ThrowIfNull(settings);
        _settings = settings.Value;
    }

    /// <summary>
    /// Sends an HTTP request, adding bearer token authentication only for iRacing API requests
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
            var token = await _tokenProvider.GetTokenAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Token provider returned null or empty token");
            }

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
