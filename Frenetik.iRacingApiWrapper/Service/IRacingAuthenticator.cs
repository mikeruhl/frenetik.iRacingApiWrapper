using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Exceptions;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Authenticator that handles the authentication process for the iRacing API
/// </summary>
public class IRacingAuthenticator : IAuthenticator
{
    private readonly string _baseUrl;
    private readonly string _username;
    private readonly string _password;
    private readonly ILogger<IRacingApiService> _logger;
    private readonly CookieContainer _cookieContainer;
    private readonly AsyncRetryPolicy<RestResponse> _retryPolicy;

    /// <summary>
    /// Constructor for the IRacingAuthenticator
    /// </summary>
    /// <param name="baseUrl">Api Base Url</param>
    /// <param name="username">iRacing Username</param>
    /// <param name="password">iRacing Password</param>
    /// <param name="retrySettings">Retry policy settings</param>
    /// <param name="logger">Logger</param>
    public IRacingAuthenticator(string baseUrl, string username, string password, RetryPolicySettings retrySettings, ILogger<IRacingApiService> logger)
    {
        _baseUrl = baseUrl;
        _username = username;
        _password = password;
        _logger = logger;
        _cookieContainer = new CookieContainer();
        _retryPolicy = RetryPolicyBuilder.BuildAuthenticationPolicy(retrySettings, logger);
    }

    /// <summary>
    /// Authenticates the client with the iRacing API
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public async ValueTask Authenticate(IRestClient client, RestRequest request)
    {
        request.CookieContainer = _cookieContainer;
        await CheckForCookie();
        request.CookieContainer = _cookieContainer;
    }



    private async Task CheckForCookie()
    {
        // Get the cookies from the CookieContainer
        CookieCollection cookies = _cookieContainer.GetCookies(new Uri(_baseUrl));

        // Check if the "authtoken_members" cookie exists
        foreach (Cookie cookie in cookies)
        {
            if (cookie.Name == "authtoken_members" && !cookie.Expired)
            {
                return;
            }
        }

        var client = new RestClient(_baseUrl);
        var request = new RestRequest("/auth", Method.Post);
        request.CookieContainer = _cookieContainer;
        request.AddJsonBody(new { email = _username, password = EncodeCredentials() });

        var response = await _retryPolicy.ExecuteAsync(() => client.ExecuteAsync(request));

        if (response.IsSuccessStatusCode && !response.Content!.Contains("\"authcode\":0") && response.Cookies != null)
        {
            _cookieContainer.Add(response.Cookies);
        }
        else
        {
            // After all retries, check if it's a service unavailable error
            RetryPolicyBuilder.ThrowIfServiceUnavailable(response);

            // Otherwise throw authentication error
            var responseBody = response.Content;
            throw new HttpRequestException("Unable to authenticate with iRacing");
        }
    }

    private string EncodeCredentials()
    {
        string credentials = _password + _username.ToLower();
        byte[] credentialBytes = Encoding.UTF8.GetBytes(credentials);
        byte[] hashedBytes;

        using (var sha256 = SHA256.Create())
        {
            hashedBytes = sha256.ComputeHash(credentialBytes);
        }

        return Convert.ToBase64String(hashedBytes);
    }

}
