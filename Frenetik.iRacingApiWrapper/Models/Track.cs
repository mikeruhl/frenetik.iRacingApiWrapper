namespace Frenetik.iRacingApiWrapper.Models;

public class Track
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;
}