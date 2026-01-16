namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// ResultEventLogs
/// </summary>
public class ResultEventLogs : IChunkInfo<ResultEventLogsChunkInfoData>
{
    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Session Info
    /// </summary>
    [JsonPropertyName("session_info")]
    public SessionInfo SessionInfo { get; set; } = new SessionInfo();

    /// <summary>
    /// Chunk Info
    /// </summary>
    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();
}

/// <summary>
/// SessionInfo
/// </summary>
public class SessionInfo
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
    /// Simsession Number
    /// </summary>
    [JsonPropertyName("simsession_number")]
    public int SimSessionNumber { get; set; }

    /// <summary>
    /// Simsession Type
    /// </summary>
    [JsonPropertyName("simsession_type")]
    public int SimSessionType { get; set; }

    /// <summary>
    /// Simsession Name
    /// </summary>
    [JsonPropertyName("simsession_name")]
    public string SimSessionName { get; set; } = string.Empty;

    /// <summary>
    /// Event Type
    /// </summary>
    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    /// <summary>
    /// Event Type Name
    /// </summary>
    [JsonPropertyName("event_type_name")]
    public string EventTypeName { get; set; } = string.Empty;

    /// <summary>
    /// Private Session Id
    /// </summary>
    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

    /// <summary>
    /// Season Name
    /// </summary>
    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    /// <summary>
    /// Season Short Name
    /// </summary>
    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    /// <summary>
    /// Series Name
    /// </summary>
    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    /// <summary>
    /// Series Short Name
    /// </summary>
    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;

    /// <summary>
    /// Start Time
    /// </summary>
    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public EventLogTrack Track { get; set; } = new EventLogTrack();
}

/// <summary>
/// EventLogTrack
/// </summary>
public class EventLogTrack
{
    /// <summary>
    /// Track Id
    /// </summary>
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    /// <summary>
    /// Track Name
    /// </summary>
    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    /// <summary>
    /// Config Name
    /// </summary>
    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;
}

/// <summary>
/// ChunkInfo
/// </summary>
public class ChunkInfo
{
    /// <summary>
    /// Chunk Size
    /// </summary>
    [JsonPropertyName("chunk_size")]
    public int ChunkSize { get; set; }

    /// <summary>
    /// Num Chunks
    /// </summary>
    [JsonPropertyName("num_chunks")]
    public int NumChunks { get; set; }

    /// <summary>
    /// Rows
    /// </summary>
    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    /// <summary>
    /// Base Download Url
    /// </summary>
    [JsonPropertyName("base_download_url")]
    public string BaseDownloadUrl { get; set; } = string.Empty;

    /// <summary>
    /// Chunk File Names
    /// </summary>
    [JsonPropertyName("chunk_file_names")]
    public List<string> ChunkFileNames { get; set; } = new List<string>();
}

/// <summary>
/// ResultEventLogsChunkInfoData
/// </summary>
public class ResultEventLogsChunkInfoData
{
    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Simsession Number
    /// </summary>
    [JsonPropertyName("simsession_number")]
    public int SimSessionNumber { get; set; }

    /// <summary>
    /// Session Time
    /// </summary>
    [JsonPropertyName("session_time")]
    public int SessionTime { get; set; }

    /// <summary>
    /// Event Seq
    /// </summary>
    [JsonPropertyName("event_seq")]
    public int EventSeq { get; set; }

    /// <summary>
    /// Event Code
    /// </summary>
    [JsonPropertyName("event_code")]
    public int EventCode { get; set; }

    /// <summary>
    /// Group Id
    /// </summary>
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Lap Number
    /// </summary>
    [JsonPropertyName("lap_number")]
    public int LapNumber { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;
}

