namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsMemberDivision
/// </summary>
public class StatsMemberDivision
{
    /// <summary>
    /// Division
    /// </summary>
    [JsonPropertyName("division")]
    public int Division { get; set; }

    /// <summary>
    /// Projected
    /// </summary>
    [JsonPropertyName("projected")]
    public bool Projected { get; set; }

    /// <summary>
    /// Event Type
    /// </summary>
    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }
}

