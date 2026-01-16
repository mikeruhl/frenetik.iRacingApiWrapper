namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// PointsSystemResponse
/// </summary>
public class PointsSystemResponse
{
    /// <summary>
    /// Points Systems
    /// </summary>
    [JsonPropertyName("points_systems")]
    public List<PointsSystem> PointsSystems { get; set; } = new List<PointsSystem>();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Subscribed
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// PointsSystem
    /// </summary>
    public class PointsSystem
    {
        /// <summary>
        /// Points System Id
        /// </summary>
        [JsonPropertyName("points_system_id")]
        public int PointsSystemId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// League Id
        /// </summary>
        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        /// <summary>
        /// Retired
        /// </summary>
        [JsonPropertyName("retired")]
        public bool Retired { get; set; }

        /// <summary>
        /// Iracing System
        /// </summary>
        [JsonPropertyName("iracing_system")]
        public bool IRacingSystem { get; set; }
    }
}

