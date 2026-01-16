namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// ResultLapData
/// </summary>
public class ResultLapData : IChunkInfo<ResultLapDataChunkInfoData>
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
    public LapDataSessionInfo SessionInfo { get; set; } = new LapDataSessionInfo();

    /// <summary>
    /// Best Lap Num
    /// </summary>
    [JsonPropertyName("best_lap_num")]
    public int BestLapNum { get; set; }

    /// <summary>
    /// Best Lap Time
    /// </summary>
    [JsonPropertyName("best_lap_time")]
    public int BestLapTime { get; set; }

    /// <summary>
    /// Best Nlaps Num
    /// </summary>
    [JsonPropertyName("best_nlaps_num")]
    public int BestNLapsNum { get; set; }

    /// <summary>
    /// Best Nlaps Time
    /// </summary>
    [JsonPropertyName("best_nlaps_time")]
    public int BestNLapsTime { get; set; }

    /// <summary>
    /// Best Qual Lap Num
    /// </summary>
    [JsonPropertyName("best_qual_lap_num")]
    public int BestQualLapNum { get; set; }

    /// <summary>
    /// Best Qual Lap Time
    /// </summary>
    [JsonPropertyName("best_qual_lap_time")]
    public int BestQualLapTime { get; set; }

    /// <summary>
    /// Best Qual Lap At
    /// </summary>
    [JsonPropertyName("best_qual_lap_at")]
    public DateTime? BestQualLapAt { get; set; }

    /// <summary>
    /// Chunk Info
    /// </summary>
    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

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
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// License Level
    /// </summary>
    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    /// <summary>
    /// Livery
    /// </summary>
    [JsonPropertyName("livery")]
    public Livery Livery { get; set; } = new Livery();
}

/// <summary>
/// LapDataSessionInfo
/// </summary>
public class LapDataSessionInfo
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
    public int SimsessionNumber { get; set; }

    /// <summary>
    /// Simsession Type
    /// </summary>
    [JsonPropertyName("simsession_type")]
    public int SimsessionType { get; set; }

    /// <summary>
    /// Simsession Name
    /// </summary>
    [JsonPropertyName("simsession_name")]
    public string SimsessionName { get; set; } = string.Empty;

    /// <summary>
    /// Num Laps For Qual Average
    /// </summary>
    [JsonPropertyName("num_laps_for_qual_average")]
    public int NumLapsForQualAverage { get; set; }

    /// <summary>
    /// Num Laps For Solo Average
    /// </summary>
    [JsonPropertyName("num_laps_for_solo_average")]
    public int NumLapsForSoloAverage { get; set; }

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
    public string StartTime { get; set; } = string.Empty;

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public LapDataTrack Track { get; set; } = new LapDataTrack();
}

/// <summary>
/// LapDataTrack
/// </summary>
public class LapDataTrack
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
/// Livery
/// </summary>
public class Livery
{
    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Pattern
    /// </summary>
    [JsonPropertyName("pattern")]
    public int Pattern { get; set; }

    /// <summary>
    /// Color1
    /// </summary>
    [JsonPropertyName("color1")]
    public string Color1 { get; set; } = string.Empty;

    /// <summary>
    /// Color2
    /// </summary>
    [JsonPropertyName("color2")]
    public string Color2 { get; set; } = string.Empty;

    /// <summary>
    /// Color3
    /// </summary>
    [JsonPropertyName("color3")]
    public string Color3 { get; set; } = string.Empty;

    /// <summary>
    /// Number Font
    /// </summary>
    [JsonPropertyName("number_font")]
    public int NumberFont { get; set; }

    /// <summary>
    /// Number Color1
    /// </summary>
    [JsonPropertyName("number_color1")]
    public string NumberColor1 { get; set; } = string.Empty;

    /// <summary>
    /// Number Color2
    /// </summary>
    [JsonPropertyName("number_color2")]
    public string NumberColor2 { get; set; } = string.Empty;

    /// <summary>
    /// Number Color3
    /// </summary>
    [JsonPropertyName("number_color3")]
    public string NumberColor3 { get; set; } = string.Empty;

    /// <summary>
    /// Number Slant
    /// </summary>
    [JsonPropertyName("number_slant")]
    public int NumberSlant { get; set; }

    /// <summary>
    /// Sponsor1
    /// </summary>
    [JsonPropertyName("sponsor1")]
    public int Sponsor1 { get; set; }

    /// <summary>
    /// Sponsor2
    /// </summary>
    [JsonPropertyName("sponsor2")]
    public int Sponsor2 { get; set; }

    /// <summary>
    /// Car Number
    /// </summary>
    [JsonPropertyName("car_number")]
    public string CarNumber { get; set; } = string.Empty;

    /// <summary>
    /// Wheel Color
    /// </summary>
    [JsonPropertyName("wheel_color")]
    public string? WheelColor { get; set; }

    /// <summary>
    /// Rim Type
    /// </summary>
    [JsonPropertyName("rim_type")]
    public int RimType { get; set; }
}

/// <summary>
/// ResultLapDataChunkInfoData
/// </summary>
public class ResultLapDataChunkInfoData
{
    /// <summary>
    /// Group Id
    /// </summary>
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Lap Number
    /// </summary>
    [JsonPropertyName("lap_number")]
    public int LapNumber { get; set; }

    /// <summary>
    /// Flags
    /// </summary>
    [JsonPropertyName("flags")]
    public int Flags { get; set; }

    /// <summary>
    /// Incident
    /// </summary>
    [JsonPropertyName("incident")]
    public bool Incident { get; set; }

    /// <summary>
    /// Session Time
    /// </summary>
    [JsonPropertyName("session_time")]
    public int SessionTime { get; set; }

    /// <summary>
    /// Session Start Time
    /// </summary>
    [JsonPropertyName("session_start_time")]
    public DateTime? SessionStartTime { get; set; }

    /// <summary>
    /// Lap Time
    /// </summary>
    [JsonPropertyName("lap_time")]
    public int LapTime { get; set; }

    /// <summary>
    /// Team Fastest Lap
    /// </summary>
    [JsonPropertyName("team_fastest_lap")]
    public bool TeamFastestLap { get; set; }

    /// <summary>
    /// Personal Best Lap
    /// </summary>
    [JsonPropertyName("personal_best_lap")]
    public bool PersonalBestLap { get; set; }

    /// <summary>
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public HelmetInfo Helmet { get; set; } = new HelmetInfo();

    /// <summary>
    /// License Level
    /// </summary>
    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    /// <summary>
    /// Car Number
    /// </summary>
    [JsonPropertyName("car_number")]
    public string CarNumber { get; set; } = string.Empty;

    /// <summary>
    /// Lap Events
    /// </summary>
    [JsonPropertyName("lap_events")]
    public List<string> LapEvents { get; set; } = new List<string>();

    /// <summary>
    /// Ai
    /// </summary>
    [JsonPropertyName("ai")]
    public bool Ai { get; set; }
}

