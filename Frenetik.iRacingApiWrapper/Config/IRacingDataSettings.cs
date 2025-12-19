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
}
