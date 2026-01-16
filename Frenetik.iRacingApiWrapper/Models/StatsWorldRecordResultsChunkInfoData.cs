namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsWorldRecordResultsChunkInfoData
/// </summary>
public class StatsWorldRecordResultsChunkInfoData
{
    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;
    
    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Track Id
    /// </summary>
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    /// <summary>
    /// Season Year
    /// </summary>
    [JsonPropertyName("season_year")]
    public int? SeasonYear { get; set; }

    /// <summary>
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int? SeasonQuarter { get; set; }

    /// <summary>
    /// Country Code
    /// </summary>
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = string.Empty;

    /// <summary>
    /// Region
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;

    /// <summary>
    /// License
    /// </summary>
    [JsonPropertyName("license")]
    public StatsWorldRecordResultsChunkInfoLicense License { get; set; } = new StatsWorldRecordResultsChunkInfoLicense();

    /// <summary>
    /// Practice Lap Time
    /// </summary>
    [JsonPropertyName("practice_lap_time")]
    public int PracticeLapTime { get; set; }

    /// <summary>
    /// Practice Date
    /// </summary>
    [JsonPropertyName("practice_date")]
    public DateTime PracticeDate { get; set; }

    /// <summary>
    /// Qualify Lap Time
    /// </summary>
    [JsonPropertyName("qualify_lap_time")]
    public int QualifyLapTime { get; set; }

    /// <summary>
    /// Qualify Date
    /// </summary>
    [JsonPropertyName("qualify_date")]
    public DateTime QualifyDate { get; set; }

    /// <summary>
    /// Tt Lap Time
    /// </summary>
    [JsonPropertyName("tt_lap_time")]
    public int? TtLapTime { get; set; }

    /// <summary>
    /// Tt Date
    /// </summary>
    [JsonPropertyName("tt_date")]
    public DateTime? TtDate { get; set; }

    /// <summary>
    /// Race Lap Time
    /// </summary>
    [JsonPropertyName("race_lap_time")]
    public int RaceLapTime { get; set; }

    /// <summary>
    /// Race Date
    /// </summary>
    [JsonPropertyName("race_date")]
    public DateTime RaceDate { get; set; }
}

/// <summary>
/// StatsWorldRecordResultsChunkInfoLicense
/// </summary>
public class StatsWorldRecordResultsChunkInfoLicense
{
    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// License Level
    /// </summary>
    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    /// <summary>
    /// Safety Rating
    /// </summary>
    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    /// <summary>
    /// Irating
    /// </summary>
    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    /// <summary>
    /// Tt Rating
    /// </summary>
    [JsonPropertyName("tt_rating")]
    public int TtRating { get; set; }

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Group Id
    /// </summary>
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}

