namespace Frenetik.iRacingApiWrapper.Models;
public class SeasonSpectatorSubSessionIdsResult
{
    [JsonPropertyName("event_types")]
    public List<int> EventTypes { get; set; } = new List<int>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("subsession_ids")]
    public List<int> SubSessionIds { get; set; } = new List<int>();
}
