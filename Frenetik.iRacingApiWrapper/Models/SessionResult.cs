namespace Frenetik.iRacingApiWrapper.Models;
public class SessionResult
{
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new List<Session>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }
}
