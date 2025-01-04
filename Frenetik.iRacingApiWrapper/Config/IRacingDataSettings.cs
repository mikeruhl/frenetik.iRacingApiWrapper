namespace Frenetik.iRacingApiWrapper.Config;

/// <summary>
/// Settings for connection to iRacing ResultsSearchSeriesData endpoints
/// </summary>
public class IRacingDataSettings
{
    /// <summary>
    /// IRacing Base Url
    /// </summary>
    public string BaseUrl { get; set; } = "https://members-ng.iracing.com";

    /// <summary>
    /// Member username
    /// </summary>
    public string Username { set; get; } = string.Empty;

    /// <summary>
    /// Member Password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
