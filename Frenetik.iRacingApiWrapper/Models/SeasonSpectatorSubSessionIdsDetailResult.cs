namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Season Spectator SubSession Ids Detail Result
/// </summary>
public class SeasonSpectatorSubSessionIdsDetailResult
{
    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Season Ids
    /// </summary>
    [JsonPropertyName("season_ids")]
    public List<int> SeasonIds { get; set; } = [];

    /// <summary>
    /// Event Types
    /// </summary>
    [JsonPropertyName("event_types")]
    public List<int> EventTypes { get; set; } = [];

    /// <summary>
    /// Subsessions
    /// </summary>
    [JsonPropertyName("subsessions")]
    public List<SeasonSpectatorSubSessionIdsDetailSubsessions> Subsessions { get; set; } = [];

    /// <summary>
    /// Subsessions Detail
    /// </summary>
    public class SeasonSpectatorSubSessionIdsDetailSubsessions
    {
        /// <summary>
        /// Subsession Id
        /// </summary>
        [JsonPropertyName("subsession_id")]
        public int SubsessionId { get; set; }

        /// <summary>
        /// Session Id
        /// </summary>
        [JsonPropertyName("session_id")]
        public int SessionId { get; set; }

        /// <summary>
        /// Season Id
        /// </summary>
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        /// <summary>
        /// Start Time
        /// </summary>
        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Race Week Number
        /// </summary>
        [JsonPropertyName("race_week_num")]
        public int RaceWeekNum { get; set; }

        /// <summary>
        /// Event Type
        /// </summary>
        [JsonPropertyName("event_type")]
        public int EventType { get; set; }
    }
}
