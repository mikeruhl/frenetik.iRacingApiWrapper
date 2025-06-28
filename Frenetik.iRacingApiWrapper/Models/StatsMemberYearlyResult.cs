namespace Frenetik.iRacingApiWrapper.Models;

public class StatsMemberYearlyResult
{
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("stats")]
    public List<StatsMemberYearlyStat> Stats { get; set; } = new List<StatsMemberYearlyStat>();
}

public class StatsMemberYearlyStat
{
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("top5")]
    public int Top5 { get; set; }

    [JsonPropertyName("poles")]
    public int Poles { get; set; }

    [JsonPropertyName("avg_start_position")]
    public int AvgStartPosition { get; set; }

    [JsonPropertyName("avg_finish_position")]
    public int AvgFinishPosition { get; set; }

    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    [JsonPropertyName("laps_led")]
    public int LapsLed { get; set; }

    [JsonPropertyName("avg_incidents")]
    public double AvgIncidents { get; set; }

    [JsonPropertyName("avg_points")]
    public int AvgPoints { get; set; }

    [JsonPropertyName("win_percentage")]
    public double WinPercentage { get; set; }

    [JsonPropertyName("top5_percentage")]
    public double Top5Percentage { get; set; }

    [JsonPropertyName("laps_led_percentage")]
    public double LapsLedPercentage { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }
}
