namespace Frenetik.iRacingApiWrapper.Models;

public class ResultLapData : IChunkInfo<ResultLapDataChunkInfoData>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("session_info")]
    public LapDataSessionInfo SessionInfo { get; set; } = new LapDataSessionInfo();

    [JsonPropertyName("best_lap_num")]
    public int BestLapNum { get; set; }

    [JsonPropertyName("best_lap_time")]
    public int BestLapTime { get; set; }

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

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("livery")]
    public Livery Livery { get; set; } = new Livery();
}

public class LapDataSessionInfo
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
    public string StartTime { get; set; } = string.Empty;

    [JsonPropertyName("track")]
    public LapDataTrack Track { get; set; } = new LapDataTrack();
}

public class LapDataTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;
}

public class Livery
{
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("pattern")]
    public int Pattern { get; set; }

    [JsonPropertyName("color1")]
    public string Color1 { get; set; } = string.Empty;

    [JsonPropertyName("color2")]
    public string Color2 { get; set; } = string.Empty;

    [JsonPropertyName("color3")]
    public string Color3 { get; set; } = string.Empty;

    [JsonPropertyName("number_font")]
    public int NumberFont { get; set; }

    [JsonPropertyName("number_color1")]
    public string NumberColor1 { get; set; } = string.Empty;

    [JsonPropertyName("number_color2")]
    public string NumberColor2 { get; set; } = string.Empty;

    [JsonPropertyName("number_color3")]
    public string NumberColor3 { get; set; } = string.Empty;

    [JsonPropertyName("number_slant")]
    public int NumberSlant { get; set; }

    [JsonPropertyName("sponsor1")]
    public int Sponsor1 { get; set; }

    [JsonPropertyName("sponsor2")]
    public int Sponsor2 { get; set; }

    [JsonPropertyName("car_number")]
    public string CarNumber { get; set; } = string.Empty;

    [JsonPropertyName("wheel_color")]
    public string? WheelColor { get; set; }

    [JsonPropertyName("rim_type")]
    public int RimType { get; set; }
}

public class ResultLapDataChunkInfoData
{
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

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

    [JsonPropertyName("ai")]
    public bool Ai { get; set; }
}
