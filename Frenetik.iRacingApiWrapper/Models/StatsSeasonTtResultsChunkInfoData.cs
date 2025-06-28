namespace Frenetik.iRacingApiWrapper.Models;

public class StatsSeasonTtResultsChunkInfoData
{
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("division")]
    public int Division { get; set; }

    [JsonPropertyName("flair_id")]
    public int FlairId { get; set; }

    [JsonPropertyName("flair_name")]
    public string FlairName { get; set; } = string.Empty;

    [JsonPropertyName("flair_shortname")]
    public string FlairShortName { get; set; } = string.Empty;

    [JsonPropertyName("license")]
    public StatsSeasonTtResultsChunkInfoLicense License { get; set; } = new StatsSeasonTtResultsChunkInfoLicense();

    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    [JsonPropertyName("best_nlaps_time")]
    public int BestNlapsTime { get; set; }

    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("raw_points")]
    public double RawPoints { get; set; }
}

public class StatsSeasonTtResultsChunkInfoLicense
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

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}
