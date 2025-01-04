namespace Frenetik.iRacingApiWrapper.Models;
public class SeasonRaceGuideResults
{
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    [JsonPropertyName("block_begin_time")]
    public DateTime BlockBeginTime { get; set; }

    [JsonPropertyName("block_end_time")]
    public DateTime BlockEndTime { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("sessions")]
    public List<RaceGuideSession> Sessions { get; set; } = new List<RaceGuideSession>();
}

public class RaceGuideSession
{
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("super_session")]
    public bool SuperSession { get; set; }

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("session_id")]
    public long SessionId { get; set; }

    [JsonPropertyName("entry_count")]
    public int EntryCount { get; set; }
}
