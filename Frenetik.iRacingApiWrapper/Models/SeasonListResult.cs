namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// SeasonListResult
/// </summary>
public class SeasonListResult
{
    /// <summary>
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    /// <summary>
    /// Season Year
    /// </summary>
    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    /// <summary>
    /// Seasons
    /// </summary>
    [JsonPropertyName("seasons")]
    public List<SeasonResult> Seasons { get; set; } = new List<SeasonResult>();
}

/// <summary>
/// SeasonResult
/// </summary>
public class SeasonResult
{
    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Season Name
    /// </summary>
    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    /// <summary>
    /// Series Name
    /// </summary>
    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    /// <summary>
    /// Official
    /// </summary>
    [JsonPropertyName("official")]
    public bool Official { get; set; }

    /// <summary>
    /// Season Year
    /// </summary>
    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    /// <summary>
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// Fixed Setup
    /// </summary>
    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    /// <summary>
    /// Driver Changes
    /// </summary>
    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }
}

