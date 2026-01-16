namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// SeriesResult
/// </summary>
public class SeriesResult
{
    /// <summary>
    /// Allowed Licenses
    /// </summary>
    [JsonPropertyName("allowed_licenses")]
    public List<SeriesResultLicense> AllowedLicenses { get; set; } = new List<SeriesResultLicense>();

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Eligible
    /// </summary>
    [JsonPropertyName("eligible")]
    public bool Eligible { get; set; }

    /// <summary>
    /// Forum Url
    /// </summary>
    [JsonPropertyName("forum_url")]
    public string ForumUrl { get; set; } = string.Empty;

    /// <summary>
    /// Max Starters
    /// </summary>
    [JsonPropertyName("max_starters")]
    public int MaxStarters { get; set; }

    /// <summary>
    /// Min Starters
    /// </summary>
    [JsonPropertyName("min_starters")]
    public int MinStarters { get; set; }

    /// <summary>
    /// Oval Caution Type
    /// </summary>
    [JsonPropertyName("oval_caution_type")]
    public int OvalCautionType { get; set; }

    /// <summary>
    /// Road Caution Type
    /// </summary>
    [JsonPropertyName("road_caution_type")]
    public int RoadCautionType { get; set; }

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Series Name
    /// </summary>
    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    /// <summary>
    /// Series Short Name
    /// </summary>
    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;
}

/// <summary>
/// SeriesResultLicense
/// </summary>
public class SeriesResultLicense
{
    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// Min License Level
    /// </summary>
    [JsonPropertyName("min_license_level")]
    public int MinLicenseLevel { get; set; }

    /// <summary>
    /// Max License Level
    /// </summary>
    [JsonPropertyName("max_license_level")]
    public int MaxLicenseLevel { get; set; }

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;
}

