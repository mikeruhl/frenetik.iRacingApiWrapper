namespace Frenetik.iRacingApiWrapper.Models;

public class SeriesResult
{
    [JsonPropertyName("allowed_licenses")]
    public List<SeriesResultLicense> AllowedLicenses { get; set; } = new List<SeriesResultLicense>();

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("eligible")]
    public bool Eligible { get; set; }

    [JsonPropertyName("forum_url")]
    public string ForumUrl { get; set; } = string.Empty;

    [JsonPropertyName("max_starters")]
    public int MaxStarters { get; set; }

    [JsonPropertyName("min_starters")]
    public int MinStarters { get; set; }

    [JsonPropertyName("oval_caution_type")]
    public int OvalCautionType { get; set; }

    [JsonPropertyName("road_caution_type")]
    public int RoadCautionType { get; set; }

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;
}

public class SeriesResultLicense
{
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    [JsonPropertyName("min_license_level")]
    public int MinLicenseLevel { get; set; }

    [JsonPropertyName("max_license_level")]
    public int MaxLicenseLevel { get; set; }

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;
}
