namespace Frenetik.iRacingApiWrapper.Models;

public class StatsWorldRecordResultsChunkInfoData
{
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;
    
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("season_year")]
    public int? SeasonYear { get; set; }

    [JsonPropertyName("season_quarter")]
    public int? SeasonQuarter { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = string.Empty;

    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;

    [JsonPropertyName("license")]
    public StatsWorldRecordResultsChunkInfoLicense License { get; set; } = new StatsWorldRecordResultsChunkInfoLicense();

    [JsonPropertyName("practice_lap_time")]
    public int PracticeLapTime { get; set; }

    [JsonPropertyName("practice_date")]
    public DateTime PracticeDate { get; set; }

    [JsonPropertyName("qualify_lap_time")]
    public int QualifyLapTime { get; set; }

    [JsonPropertyName("qualify_date")]
    public DateTime QualifyDate { get; set; }

    [JsonPropertyName("tt_lap_time")]
    public int? TtLapTime { get; set; }

    [JsonPropertyName("tt_date")]
    public DateTime? TtDate { get; set; }

    [JsonPropertyName("race_lap_time")]
    public int RaceLapTime { get; set; }

    [JsonPropertyName("race_date")]
    public DateTime RaceDate { get; set; }
}

public class StatsWorldRecordResultsChunkInfoLicense
{
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    [JsonPropertyName("tt_rating")]
    public int TtRating { get; set; }

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}
