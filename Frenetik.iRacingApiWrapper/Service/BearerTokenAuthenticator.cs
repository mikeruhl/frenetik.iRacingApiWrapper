using RestSharp;
using RestSharp.Authenticators;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Authenticator that handles bearer token authentication for the iRacing API
/// </summary>
public class BearerTokenAuthenticator : IAuthenticator
{
    private readonly ITokenProvider _tokenProvider;

    /// <summary>
    /// Constructor for the BearerTokenAuthenticator
    /// </summary>
    /// <param name="tokenProvider">Token provider that supplies bearer tokens</param>
    public BearerTokenAuthenticator(ITokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
    }

    /// <summary>
    /// Authenticates the client with the iRacing API using a bearer token
    /// </summary>
    /// <param name="client">REST client</param>
    /// <param name="request">REST request</param>
    public async ValueTask Authenticate(IRestClient client, RestRequest request)
    {
        var token = await _tokenProvider.GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Token provider returned null or empty token");
        }

        request.AddOrUpdateHeader("Authorization", $"Bearer {token}");
    }
}
