namespace Frenetik.iRacingApiWrapper.Models;
public class CustLeagueSessionResult
{
    [JsonPropertyName("mine")]
    public bool Mine { get; set; }

    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    [JsonPropertyName("sequence")]
    public string Sequence { get; set; } = string.Empty;

    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new List<Session>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }
}
