namespace Frenetik.iRacingApiWrapper.Models;

public class ResultEventLogs : IChunkInfo<ResultEventLogsChunkInfoData>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("session_info")]
    public SessionInfo SessionInfo { get; set; } = new SessionInfo();

    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();
}

public class SessionInfo
{
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("simsession_number")]
    public int SimSessionNumber { get; set; }

    [JsonPropertyName("simsession_type")]
    public int SimSessionType { get; set; }

    [JsonPropertyName("simsession_name")]
    public string SimSessionName { get; set; } = string.Empty;

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
    public EventLogTrack Track { get; set; } = new EventLogTrack();
}

public class EventLogTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;
}

public class ChunkInfo
{
    [JsonPropertyName("chunk_size")]
    public int ChunkSize { get; set; }

    [JsonPropertyName("num_chunks")]
    public int NumChunks { get; set; }

    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    [JsonPropertyName("base_download_url")]
    public string BaseDownloadUrl { get; set; } = string.Empty;

    [JsonPropertyName("chunk_file_names")]
    public List<string> ChunkFileNames { get; set; } = new List<string>();
}

public class ResultEventLogsChunkInfoData
{
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("simsession_number")]
    public int SimSessionNumber { get; set; }

    [JsonPropertyName("session_time")]
    public int SessionTime { get; set; }

    [JsonPropertyName("event_seq")]
    public int EventSeq { get; set; }

    [JsonPropertyName("event_code")]
    public int EventCode { get; set; }

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("lap_number")]
    public int LapNumber { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;
}
