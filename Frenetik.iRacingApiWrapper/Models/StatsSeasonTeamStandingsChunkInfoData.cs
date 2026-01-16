namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsSeasonTeamStandingsChunkInfoData
/// </summary>
public class StatsSeasonTeamStandingsChunkInfoData
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
    public int CustomerId { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// License
    /// </summary>
    [JsonPropertyName("license")]
    public StatsSeasonTeamStandingsLicense License { get; set; } = new StatsSeasonTeamStandingsLicense();

    /// <summary>
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    /// <summary>
    /// Weeks Counted
    /// </summary>
    [JsonPropertyName("weeks_counted")]
    public int WeeksCounted { get; set; }

    /// <summary>
    /// Starts
    /// </summary>
    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    /// <summary>
    /// Wins
    /// </summary>
    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    /// <summary>
    /// Top5
    /// </summary>
    [JsonPropertyName("top5")]
    public int Top5 { get; set; }

    /// <summary>
    /// Top25 Percent
    /// </summary>
    [JsonPropertyName("top25_percent")]
    public int Top25Percent { get; set; }

    /// <summary>
    /// Poles
    /// </summary>
    [JsonPropertyName("poles")]
    public int Poles { get; set; }

    /// <summary>
    /// Avg Start Position
    /// </summary>
    [JsonPropertyName("avg_start_position")]
    public int AverageStartPosition { get; set; }

    /// <summary>
    /// Avg Finish Position
    /// </summary>
    [JsonPropertyName("avg_finish_position")]
    public int AverageFinishPosition { get; set; }

    /// <summary>
    /// Avg Field Size
    /// </summary>
    [JsonPropertyName("avg_field_size")]
    public int AverageFieldSize { get; set; }

    /// <summary>
    /// Laps
    /// </summary>
    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    /// <summary>
    /// Laps Led
    /// </summary>
    [JsonPropertyName("laps_led")]
    public int LapsLed { get; set; }

    /// <summary>
    /// Incidents
    /// </summary>
    [JsonPropertyName("incidents")]
    public int Incidents { get; set; }

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

    /// <summary>
    /// Week Dropped
    /// </summary>
    [JsonPropertyName("week_dropped")]
    public bool WeekDropped { get; set; }
}

/// <summary>
/// StatsSeasonTeamStandingsLicense
/// </summary>
public class StatsSeasonTeamStandingsLicense
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

