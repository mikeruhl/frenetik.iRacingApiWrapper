namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Customer league session query result
/// </summary>
public class CustLeagueSessionResult
{
    /// <summary>
    /// Whether this is the user's own league
    /// </summary>
    [JsonPropertyName("mine")]
    public bool Mine { get; set; }

    /// <summary>
    /// Whether user is subscribed to this league
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// Sequence number
    /// </summary>
    [JsonPropertyName("sequence")]
    public string Sequence { get; set; } = string.Empty;

    /// <summary>
    /// List of sessions
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new List<Session>();

    /// <summary>
    /// Whether the query was successful
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

