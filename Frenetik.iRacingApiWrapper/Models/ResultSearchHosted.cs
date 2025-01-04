namespace Frenetik.iRacingApiWrapper.Models;

public class ResultSearchHosted : IChunkInfo<ResultSearchHostedChunkInfoData>
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public ResultSearchHostedData Data { get; set; } = new ResultSearchHostedData();

    public ChunkInfo ChunkInfo => Data.ChunkInfo;
}

public class ResultSearchHostedData
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

    [JsonPropertyName("params")]
    public ResultSearchHostedParams Params { get; set; } = new ResultSearchHostedParams();
}

public class ResultSearchHostedParams
{
    [JsonPropertyName("start_range_begin")]
    public string StartRangeBegin { get; set; } = string.Empty;

    [JsonPropertyName("category_ids")]
    public List<int> CategoryIds { get; set; } = new List<int>();

    [JsonPropertyName("host_cust_id")]
    public int HostCustId { get; set; }
}

public class ResultSearchHostedChunkInfoData
{
    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("license_category_id")]
    public int LicenseCategoryId { get; set; }

    [JsonPropertyName("num_drivers")]
    public int NumDrivers { get; set; }

    [JsonPropertyName("num_cautions")]
    public int NumCautions { get; set; }

    [JsonPropertyName("num_caution_laps")]
    public int NumCautionLaps { get; set; }

    [JsonPropertyName("num_lead_changes")]
    public int NumLeadChanges { get; set; }

    [JsonPropertyName("event_laps_complete")]
    public int EventLapsComplete { get; set; }

    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    [JsonPropertyName("winner_group_id")]
    public int WinnerGroupId { get; set; }

    [JsonPropertyName("winner_ai")]
    public bool WinnerAi { get; set; }

    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();

    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

    [JsonPropertyName("session_name")]
    public string SessionName { get; set; } = string.Empty;

    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    [JsonPropertyName("league_season_id")]
    public int LeagueSeasonId { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("practice_length")]
    public int PracticeLength { get; set; }

    [JsonPropertyName("qualify_length")]
    public int QualifyLength { get; set; }

    [JsonPropertyName("qualify_laps")]
    public int QualifyLaps { get; set; }

    [JsonPropertyName("race_length")]
    public int RaceLength { get; set; }

    [JsonPropertyName("race_laps")]
    public int RaceLaps { get; set; }

    [JsonPropertyName("heat_race")]
    public bool HeatRace { get; set; }

    [JsonPropertyName("host")]
    public Session.SessionDriver Host { get; set; } = new Session.SessionDriver();

    [JsonPropertyName("cars")]
    public List<CarInfo> Cars { get; set; } = new List<CarInfo>();
}

public class CarInfo
{
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;

    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    [JsonPropertyName("car_class_name")]
    public string CarClassName { get; set; } = string.Empty;

    [JsonPropertyName("car_class_short_name")]
    public string CarClassShortName { get; set; } = string.Empty;

    [JsonPropertyName("car_name_abbreviated")]
    public string CarNameAbbreviated { get; set; } = string.Empty;
}
