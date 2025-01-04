namespace Frenetik.iRacingApiWrapper.Models;

public class StatsMemberDivision
{
    [JsonPropertyName("division")]
    public int Division { get; set; }

    [JsonPropertyName("projected")]
    public bool Projected { get; set; }

    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }
}
