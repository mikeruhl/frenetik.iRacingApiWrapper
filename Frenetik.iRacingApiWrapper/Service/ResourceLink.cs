namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Link object to fetch CDN resources
/// </summary>
internal class ResourceLink
{
    /// <summary>
    /// Link Url
    /// </summary>
    public string Link { get; set; } = string.Empty;

    /// <summary>
    /// Expiration of Link
    /// </summary>
    public DateTime Expires { get; set; }
}
