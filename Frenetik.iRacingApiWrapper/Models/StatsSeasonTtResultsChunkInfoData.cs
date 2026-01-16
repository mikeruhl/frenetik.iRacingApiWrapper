namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsSeasonTtResultsChunkInfoData
/// </summary>
public class StatsSeasonTtResultsChunkInfoData
{
    /// <summary>
    /// Rank
    /// </summary>
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Division
    /// </summary>
    [JsonPropertyName("division")]
    public int Division { get; set; }

    /// <summary>
    /// Flair Id
    /// </summary>
    [JsonPropertyName("flair_id")]
    public int FlairId { get; set; }

    /// <summary>
    /// Flair Name
    /// </summary>
    [JsonPropertyName("flair_name")]
    public string FlairName { get; set; } = string.Empty;

    /// <summary>
    /// Flair Shortname
    /// </summary>
    [JsonPropertyName("flair_shortname")]
    public string FlairShortName { get; set; } = string.Empty;

    /// <summary>
    /// License
    /// </summary>
    [JsonPropertyName("license")]
    public StatsSeasonTtResultsChunkInfoLicense License { get; set; } = new StatsSeasonTtResultsChunkInfoLicense();

    /// <summary>
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    /// <summary>
    /// Best Nlaps Time
    /// </summary>
    [JsonPropertyName("best_nlaps_time")]
    public int BestNlapsTime { get; set; }

    /// <summary>
    /// Starts
    /// </summary>
    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    /// <summary>
    /// Points
    /// </summary>
    [JsonPropertyName("points")]
    public int Points { get; set; }

    /// <summary>
    /// Raw Points
    /// </summary>
    [JsonPropertyName("raw_points")]
    public double RawPoints { get; set; }
}

/// <summary>
/// StatsSeasonTtResultsChunkInfoLicense
/// </summary>
public class StatsSeasonTtResultsChunkInfoLicense
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
    /// Color
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

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

