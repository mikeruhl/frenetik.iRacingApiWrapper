namespace Frenetik.iRacingApiWrapper.Config;

/// <summary>
/// Settings for connection to iRacing API endpoints
/// </summary>
public class IRacingDataSettings
{
    /// <summary>
    /// IRacing Base Url
    /// </summary>
    public string BaseUrl { get; set; } = "https://members-ng.iracing.com";

    /// <summary>
    /// Retry policy configuration for API requests
    /// </summary>
    public RetryPolicySettings RetryPolicy { get; set; } = new RetryPolicySettings();

    /// <summary>
    /// Maximum number of parallel asset requests when downloading multiple assets.
    /// Prevents connection pool exhaustion and rate limiting when fetching many resources concurrently.
    /// Default is 10.
    /// </summary>
    public int MaxParallelAssetRequests { get; set; } = 10;
}
