namespace Frenetik.iRacingApiWrapper.Models;

public class PointsSystemResponse
{
    [JsonPropertyName("points_systems")]
    public List<PointsSystem> PointsSystems { get; set; } = new List<PointsSystem>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    public class PointsSystem
    {
        [JsonPropertyName("points_system_id")]
        public int PointsSystemId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("retired")]
        public bool Retired { get; set; }

        [JsonPropertyName("iracing_system")]
        public bool IRacingSystem { get; set; }
    }
}
