namespace Frenetik.iRacingApiWrapper.Models;

public class ResultsLapChartData : IChunkInfo<ResultLapChartDataChunkInfoData>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("session_info")]
    public SessionInfoLapChartData SessionInfo { get; set; } = new SessionInfoLapChartData();

    [JsonPropertyName("best_lap_num")]
    public int BestLapNum { get; set; }

    [JsonPropertyName("best_lap_time")]
    public long BestLapTime { get; set; }

    [JsonPropertyName("best_nlaps_num")]
    public int BestNLapsNum { get; set; }

    [JsonPropertyName("best_nlaps_time")]
    public int BestNLapsTime { get; set; }

    [JsonPropertyName("best_qual_lap_num")]
    public int BestQualLapNum { get; set; }

    [JsonPropertyName("best_qual_lap_time")]
    public int BestQualLapTime { get; set; }

    [JsonPropertyName("best_qual_lap_at")]
    public DateTime? BestQualLapAt { get; set; }

    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();
}

public class SessionInfoLapChartData
{
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("simsession_number")]
    public int SimsessionNumber { get; set; }

    [JsonPropertyName("simsession_type")]
    public int SimsessionType { get; set; }

    [JsonPropertyName("simsession_name")]
    public string SimsessionName { get; set; } = string.Empty;

    [JsonPropertyName("num_laps_for_qual_average")]
    public int NumLapsForQualAverage { get; set; }

    [JsonPropertyName("num_laps_for_solo_average")]
    public int NumLapsForSoloAverage { get; set; }

    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    [JsonPropertyName("event_type_name")]
    public string EventTypeName { get; set; } = string.Empty;

    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;

    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();
}

public class ResultLapChartDataChunkInfoData
{
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("lap_number")]
    public int LapNumber { get; set; }

    [JsonPropertyName("flags")]
    public int Flags { get; set; }

    [JsonPropertyName("incident")]
    public bool Incident { get; set; }

    [JsonPropertyName("session_time")]
    public int SessionTime { get; set; }

    [JsonPropertyName("session_start_time")]
    public DateTime? SessionStartTime { get; set; }

    [JsonPropertyName("lap_time")]
    public int LapTime { get; set; }

    [JsonPropertyName("team_fastest_lap")]
    public bool TeamFastestLap { get; set; }

    [JsonPropertyName("personal_best_lap")]
    public bool PersonalBestLap { get; set; }

    [JsonPropertyName("helmet")]
    public HelmetInfo Helmet { get; set; } = new HelmetInfo();

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("car_number")]
    public string CarNumber { get; set; } = string.Empty;

    [JsonPropertyName("lap_events")]
    public List<string> LapEvents { get; set; } = new List<string>();

    [JsonPropertyName("lap_position")]
    public int LapPosition { get; set; }

    [JsonPropertyName("interval")]
    public int? Interval { get; set; }

    [JsonPropertyName("interval_units")]
    public string? IntervalUnits { get; set; }

    [JsonPropertyName("fastest_lap")]
    public bool FastestLap { get; set; }

    [JsonPropertyName("ai")]
    public bool AI { get; set; }
}
