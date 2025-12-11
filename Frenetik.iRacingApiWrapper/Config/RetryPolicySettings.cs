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
}
