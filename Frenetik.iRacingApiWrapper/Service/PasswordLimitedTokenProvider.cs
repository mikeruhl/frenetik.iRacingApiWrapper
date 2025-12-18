using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Token provider implementation using iRacing's Password Limited OAuth grant flow.
/// This grant is intended for automated/headless clients that run on behalf of a registered user.
/// Should be used once at startup, then refresh tokens should be used to maintain access.
/// </summary>
public class PasswordLimitedTokenProvider : ITokenProvider, IDisposable
{
    private readonly PasswordLimitedTokenProviderSettings _settings;
    private readonly ILogger<PasswordLimitedTokenProvider> _logger;
    private readonly HttpClient _httpClient;
    private readonly bool _disposeHttpClient;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    private TokenResponse? _cachedTokenResponse;
    private DateTime _tokenExpiry = DateTime.MinValue;
    private DateTime _refreshTokenExpiry = DateTime.MinValue;
    private bool _disposed;

    /// <summary>
    /// Constructor for PasswordLimitedTokenProvider
    /// </summary>
    /// <param name="settings">OAuth configuration settings</param>
    /// <param name="logger">Logger instance</param>
    /// <param name="httpClient">Optional HTTP client. If not provided, a new one will be created.</param>
    public PasswordLimitedTokenProvider(
        IOptions<PasswordLimitedTokenProviderSettings> settings,
        ILogger<PasswordLimitedTokenProvider> logger,
        HttpClient? httpClient = null)
    {
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(logger);

        _settings = settings.Value;
        ValidateSettings(_settings);

        _logger = logger;

        if (httpClient == null)
        {
            _httpClient = new HttpClient();
            _disposeHttpClient = true;
        }
        else
        {
            _httpClient = httpClient;
            _disposeHttpClient = false;
        }
    }

    private static void ValidateSettings(PasswordLimitedTokenProviderSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(settings.ClientId))
        {
            throw new ArgumentException("ClientId is required and cannot be null or empty.", nameof(settings.ClientId));
        }

        if (string.IsNullOrWhiteSpace(settings.ClientSecret))
        {
            throw new ArgumentException("ClientSecret is required and cannot be null or empty.", nameof(settings.ClientSecret));
        }

        if (string.IsNullOrWhiteSpace(settings.Username))
        {
            throw new ArgumentException("Username is required and cannot be null or empty.", nameof(settings.Username));
        }

        if (string.IsNullOrWhiteSpace(settings.Password))
        {
            throw new ArgumentException("Password is required and cannot be null or empty.", nameof(settings.Password));
        }
    }

    /// <summary>
    /// Gets a valid bearer token, using cached token if available, refresh token if expired,
    /// or obtaining a new token via password grant
    /// </summary>
    /// <param name="cancellationToken">Token to observe while waiting to enter the semaphore.</param>
    public async Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        await _semaphore.WaitAsync(cancellationToken);
        try
        {
            // Return cached access token if still valid
            if (_cachedTokenResponse != null && DateTime.UtcNow < _tokenExpiry)
            {
                _logger.LogDebug("Returning cached access token");
                return _cachedTokenResponse.AccessToken;
            }

            // Try to refresh if we have a valid refresh token
            if (_cachedTokenResponse?.RefreshToken != null && DateTime.UtcNow < _refreshTokenExpiry)
            {
                _logger.LogInformation("Access token expired, attempting to refresh");
                try
                {
                    await RefreshTokenAsync(cancellationToken);
                    return _cachedTokenResponse!.AccessToken;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to refresh token, will attempt password grant");
                }
            }

            // Obtain new token via password grant
            _logger.LogInformation("Obtaining new token via password limited grant");
            await ObtainTokenViaPasswordGrantAsync(cancellationToken);
            return _cachedTokenResponse!.AccessToken;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <summary>
    /// Obtains a new token using the password limited grant
    /// </summary>
    private async Task ObtainTokenViaPasswordGrantAsync(CancellationToken cancellationToken)
    {
        var maskedClientSecret = MaskSecret(_settings.ClientSecret, _settings.ClientId);
        var maskedPassword = MaskSecret(_settings.Password, _settings.Username);

        var formData = new Dictionary<string, string>
        {
            { "grant_type", "password_limited" },
            { "client_id", _settings.ClientId },
            { "client_secret", maskedClientSecret },
            { "username", _settings.Username },
            { "password", maskedPassword }
        };

        if (!string.IsNullOrWhiteSpace(_settings.Scope))
        {
            formData["scope"] = _settings.Scope;
        }

        await SendTokenRequestAsync(formData, cancellationToken);
    }

    /// <summary>
    /// Refreshes the access token using the refresh token
    /// </summary>
    private async Task RefreshTokenAsync(CancellationToken cancellationToken)
    {
        if (_cachedTokenResponse?.RefreshToken == null)
        {
            throw new InvalidOperationException("No refresh token available");
        }

        var maskedClientSecret = MaskSecret(_settings.ClientSecret, _settings.ClientId);

        var formData = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "client_id", _settings.ClientId },
            { "client_secret", maskedClientSecret },
            { "refresh_token", _cachedTokenResponse.RefreshToken }
        };

        await SendTokenRequestAsync(formData, cancellationToken);
    }

    /// <summary>
    /// Sends the token request and processes the response
    /// </summary>
    private async Task SendTokenRequestAsync(Dictionary<string, string> formData, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, _settings.TokenEndpoint)
        {
            Content = new FormUrlEncodedContent(formData)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        // If request failed, read error content for better error messages
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);

            // Check for rate limiting
            // Per iRacing OAuth spec: Rate limiting returns 400 BadRequest with "unauthorized_client" error
            // and a Retry-After header (differs from RFC 6749 which uses HTTP 429 for rate limiting)
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string? errorCode = null;
                try
                {
                    using var doc = JsonDocument.Parse(errorContent);
                    if (doc.RootElement.TryGetProperty("error", out var errorElement) &&
                        errorElement.ValueKind == JsonValueKind.String)
                    {
                        errorCode = errorElement.GetString();
                    }
                }
                catch (JsonException)
                {
                    // If error response is not valid JSON, fall back to string matching
                }

                var isUnauthorizedClient =
                    (!string.IsNullOrEmpty(errorCode) &&
                     string.Equals(errorCode, "unauthorized_client", StringComparison.OrdinalIgnoreCase)) ||
                    errorContent.Contains("unauthorized_client", StringComparison.OrdinalIgnoreCase);

                if (isUnauthorizedClient)
                {
                    var retryAfter = response.Headers.RetryAfter?.Delta?.TotalSeconds ?? 60;
                    throw new InvalidOperationException(
                        $"Rate limit exceeded. Retry after {retryAfter} seconds. Error: {errorContent}");
                }
            }

            // Check for standard HTTP 429 rate limiting as fallback
            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                var retryAfter = response.Headers.RetryAfter?.Delta?.TotalSeconds ?? 60;
                throw new InvalidOperationException(
                    $"Rate limit exceeded. Retry after {retryAfter} seconds. Error: {errorContent}");
            }

            // Throw with detailed error message for all other failures
            throw new HttpRequestException(
                $"OAuth token request failed with status {(int)response.StatusCode} {response.StatusCode}. Error: {errorContent}",
                null,
                response.StatusCode);
        }

        // Log rate limit headers if present
        if (response.Headers.TryGetValues("RateLimit-Remaining", out var remainingValues))
        {
            var remaining = remainingValues.FirstOrDefault();
            _logger.LogDebug("Rate limit remaining: {Remaining}", remaining);
        }

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        _cachedTokenResponse = JsonSerializer.Deserialize<TokenResponse>(
            responseContent,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (_cachedTokenResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize token response");
        }

        // Calculate expiry times with a 60-second buffer for safety (ensure non-negative)
        _tokenExpiry = DateTime.UtcNow.AddSeconds(Math.Max(0, _cachedTokenResponse.ExpiresIn - 60));

        if (_cachedTokenResponse.RefreshTokenExpiresIn.HasValue)
        {
            _refreshTokenExpiry = DateTime.UtcNow.AddSeconds(Math.Max(0, _cachedTokenResponse.RefreshTokenExpiresIn.Value - 60));
        }

        _logger.LogInformation(
            "Token obtained successfully. Expires in {ExpiresIn} seconds. Refresh token: {HasRefresh}",
            _cachedTokenResponse.ExpiresIn,
            _cachedTokenResponse.RefreshToken != null ? "Yes" : "No");
    }

    /// <summary>
    /// Masks a secret using iRacing's masking algorithm.
    /// Algorithm: Base64(SHA256(secret + normalized_identifier))
    /// where normalized_identifier is trimmed and lowercased.
    /// </summary>
    /// <param name="secret">The secret to mask (client_secret or password)</param>
    /// <param name="identifier">The identifier (client_id for client_secret, username for password)</param>
    /// <returns>Base64-encoded SHA-256 hash</returns>
    private static string MaskSecret(string secret, string identifier)
    {
        // Normalize the identifier (trim and lowercase)
        var normalizedId = identifier.Trim().ToLowerInvariant();

        // Concatenate secret with normalized identifier
        var combined = $"{secret}{normalizedId}";

        // SHA-256 hash the combined string
        var bytes = Encoding.UTF8.GetBytes(combined);
        var hash = SHA256.HashData(bytes);

        // Base64 encode the hash
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Disposes of resources used by the token provider
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _semaphore.Dispose();

        if (_disposeHttpClient)
        {
            _httpClient.Dispose();
        }

        _disposed = true;
    }

    /// <summary>
    /// Response from the OAuth token endpoint
    /// </summary>
    private class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = string.Empty;

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        [JsonPropertyName("refresh_token_expires_in")]
        public int? RefreshTokenExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
    }
}
