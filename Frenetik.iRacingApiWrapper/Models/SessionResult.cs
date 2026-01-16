namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// SessionResult
/// </summary>
public class SessionResult
{
    /// <summary>
    /// Subscribed
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// Sessions
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new List<Session>();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

