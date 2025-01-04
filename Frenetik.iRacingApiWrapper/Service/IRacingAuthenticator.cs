using Microsoft.Extensions.Logging;
using Polly;
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

    /// <summary>
    /// Constructor for the IRacingAuthenticator
    /// </summary>
    /// <param name="baseUrl">Api Base Url</param>
    /// <param name="username">iRacing Username</param>
    /// <param name="password">iRacing Password</param>
    /// <param name="logger">Logger</param>
    public IRacingAuthenticator(string baseUrl, string username, string password, ILogger<IRacingApiService> logger)
    {
        _baseUrl = baseUrl;
        _username = username;
        _password = password;
        _logger = logger;
        _cookieContainer = new CookieContainer();
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

        var polly = Policy.HandleResult<RestResponse>(r => (int)r.StatusCode == (int)HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(15 * (retry + 1)), HandleOnRetry);


        var response = await polly.ExecuteAsync(() => client.ExecuteAsync(request));

        if (response.IsSuccessStatusCode && !response.Content!.Contains("\"authcode\":0") && response.Cookies != null)
        {
            _cookieContainer.Add(response.Cookies);
        }
        else
        {
            var responseBody = response.Content;
            throw new HttpRequestException("Unable to authenticate with iRacing");
        }
    }

    private Task<TimeSpan> RetryTooManyRequests(int retryCount, DelegateResult<RestResponse> response, Context context)
    {
        var resetTime = response.Result.Headers?.FirstOrDefault(h => h.Name != null && h.Name.Equals("X-RateLimit-Reset", StringComparison.OrdinalIgnoreCase))?.Value?.ToString();
        if (resetTime != null)
        {
            var resetTimeSeconds = int.Parse(resetTime);
            var resetTimeUtc = DateTimeOffset.FromUnixTimeSeconds(resetTimeSeconds);
            var waitTime = resetTimeUtc - DateTimeOffset.UtcNow;
            _logger.LogInformation($"Rate limit exceeded. Waiting {waitTime} before retrying");
            return Task.FromResult(waitTime);
        }
        else
        {
            _logger.LogInformation($"Rate limit exceeded but no rate limiting headers found. Waiting 15 seconds before retrying.");
            return Task.FromResult(TimeSpan.FromSeconds(15));
        }
    }

    private Task HandleOnRetry(DelegateResult<RestResponse> response, TimeSpan timeSpan)
    {
        _logger.LogInformation($"Rate limit exceeded. Waiting {timeSpan} before retrying.");
        return Task.CompletedTask;
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
