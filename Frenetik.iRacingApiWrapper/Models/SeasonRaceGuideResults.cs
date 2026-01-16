namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// SeasonRaceGuideResults
/// </summary>
public class SeasonRaceGuideResults
{
    /// <summary>
    /// Subscribed
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// Block Begin Time
    /// </summary>
    [JsonPropertyName("block_begin_time")]
    public DateTime BlockBeginTime { get; set; }

    /// <summary>
    /// Block End Time
    /// </summary>
    [JsonPropertyName("block_end_time")]
    public DateTime BlockEndTime { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Sessions
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<RaceGuideSession> Sessions { get; set; } = new List<RaceGuideSession>();
}

/// <summary>
/// RaceGuideSession
/// </summary>
public class RaceGuideSession
{
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
    /// Super Session
    /// </summary>
    [JsonPropertyName("super_session")]
    public bool SuperSession { get; set; }

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    /// <summary>
    /// End Time
    /// </summary>
    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Session Id
    /// </summary>
    [JsonPropertyName("session_id")]
    public long SessionId { get; set; }

    /// <summary>
    /// Entry Count
    /// </summary>
    [JsonPropertyName("entry_count")]
    public int EntryCount { get; set; }
}

