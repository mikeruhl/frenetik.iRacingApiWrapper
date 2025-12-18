namespace Frenetik.iRacingApiWrapper.Config;

/// <summary>
/// Configuration for retry policies
/// </summary>
public class RetryPolicySettings
{
    /// <summary>
    /// Number of retry attempts for 5xx errors
    /// </summary>
    public int ServerErrorRetryCount { get; set; } = 3;

    /// <summary>
    /// Base delay in milliseconds for exponential backoff on 5xx errors
    /// </summary>
    public int ServerErrorBaseDelayMs { get; set; } = 200;

    /// <summary>
    /// Number of retry attempts for 429 (Too Many Requests) errors
    /// </summary>
    public int RateLimitRetryCount { get; set; } = 3;

    /// <summary>
    /// Default delay in seconds when rate limit reset header is not present
    /// </summary>
    public int RateLimitDefaultDelaySeconds { get; set; } = 15;

    /// <summary>
    /// Number of retry attempts for 503 (Service Unavailable) errors.
    /// Note: 503 typically indicates iRacing is down for maintenance (can be 1+ hours).
    /// Default is 0 (fail immediately). Set to a higher value if you want to retry.
    /// </summary>
    public int ServiceUnavailableRetryCount { get; set; } = 0;

    /// <summary>
    /// Delay in seconds between 503 retry attempts.
    /// Only applies if ServiceUnavailableRetryCount > 0.
    /// </summary>
    public int ServiceUnavailableDelaySeconds { get; set; } = 60;

    /// <summary>
    /// Validates the retry policy settings to ensure they won't cause downstream exceptions
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when settings are invalid</exception>
    public void Validate()
    {
        if (ServerErrorRetryCount < 0)
            throw new ArgumentException("ServerErrorRetryCount must be non-negative", nameof(ServerErrorRetryCount));

        if (ServerErrorBaseDelayMs <= 0)
            throw new ArgumentException("ServerErrorBaseDelayMs must be positive", nameof(ServerErrorBaseDelayMs));

        if (RateLimitRetryCount < 0)
            throw new ArgumentException("RateLimitRetryCount must be non-negative", nameof(RateLimitRetryCount));

        if (RateLimitDefaultDelaySeconds <= 0)
            throw new ArgumentException("RateLimitDefaultDelaySeconds must be positive", nameof(RateLimitDefaultDelaySeconds));

        if (ServiceUnavailableRetryCount < 0)
            throw new ArgumentException("ServiceUnavailableRetryCount must be non-negative", nameof(ServiceUnavailableRetryCount));

        if (ServiceUnavailableDelaySeconds <= 0)
            throw new ArgumentException("ServiceUnavailableDelaySeconds must be positive", nameof(ServiceUnavailableDelaySeconds));
    }
}
