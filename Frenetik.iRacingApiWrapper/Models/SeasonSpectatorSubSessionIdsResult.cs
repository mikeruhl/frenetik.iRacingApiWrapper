namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// SeasonSpectatorSubSessionIdsResult
/// </summary>
public class SeasonSpectatorSubSessionIdsResult
{
    /// <summary>
    /// Event Types
    /// </summary>
    [JsonPropertyName("event_types")]
    public List<int> EventTypes { get; set; } = new List<int>();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Subsession Ids
    /// </summary>
    [JsonPropertyName("subsession_ids")]
    public List<int> SubSessionIds { get; set; } = new List<int>();
}

