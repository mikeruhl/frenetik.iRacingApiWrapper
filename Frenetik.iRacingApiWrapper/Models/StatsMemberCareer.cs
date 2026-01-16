namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsMemberCareer
/// </summary>
public class StatsMemberCareer
{
    /// <summary>
    /// Stats
    /// </summary>
    [JsonPropertyName("stats")]
    public List<StatsMemberCareerStat> Stats { get; set; } = new List<StatsMemberCareerStat>();

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }
}

/// <summary>
/// StatsMemberCareerStat
/// </summary>
public class StatsMemberCareerStat
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
    /// Poles
    /// </summary>
    [JsonPropertyName("poles")]
    public int Poles { get; set; }

    /// <summary>
    /// Avg Start Position
    /// </summary>
    [JsonPropertyName("avg_start_position")]
    public int AvgStartPosition { get; set; }

    /// <summary>
    /// Avg Finish Position
    /// </summary>
    [JsonPropertyName("avg_finish_position")]
    public int AvgFinishPosition { get; set; }

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
    /// Avg Incidents
    /// </summary>
    [JsonPropertyName("avg_incidents")]
    public double AvgIncidents { get; set; }

    /// <summary>
    /// Avg Points
    /// </summary>
    [JsonPropertyName("avg_points")]
    public int AvgPoints { get; set; }

    /// <summary>
    /// Win Percentage
    /// </summary>
    [JsonPropertyName("win_percentage")]
    public double WinPercentage { get; set; }

    /// <summary>
    /// Top5 Percentage
    /// </summary>
    [JsonPropertyName("top5_percentage")]
    public double Top5Percentage { get; set; }

    /// <summary>
    /// Laps Led Percentage
    /// </summary>
    [JsonPropertyName("laps_led_percentage")]
    public double LapsLedPercentage { get; set; }
}

