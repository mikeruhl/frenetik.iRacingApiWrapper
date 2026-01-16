namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// ResultSearchHosted
/// </summary>
public class ResultSearchHosted : IChunkInfo<ResultSearchHostedChunkInfoData>
{
    /// <summary>
    /// Type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Data
    /// </summary>
    [JsonPropertyName("data")]
    public ResultSearchHostedData Data { get; set; } = new ResultSearchHostedData();

    /// <summary>
    /// Chunk info
    /// </summary>
    public ChunkInfo ChunkInfo => Data.ChunkInfo;
}

/// <summary>
/// ResultSearchHostedData
/// </summary>
public class ResultSearchHostedData
{
    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Chunk Info
    /// </summary>
    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

    /// <summary>
    /// Params
    /// </summary>
    [JsonPropertyName("params")]
    public ResultSearchHostedParams Params { get; set; } = new ResultSearchHostedParams();
}

/// <summary>
/// ResultSearchHostedParams
/// </summary>
public class ResultSearchHostedParams
{
    /// <summary>
    /// Start Range Begin
    /// </summary>
    [JsonPropertyName("start_range_begin")]
    public string StartRangeBegin { get; set; } = string.Empty;

    /// <summary>
    /// Category Ids
    /// </summary>
    [JsonPropertyName("category_ids")]
    public List<int> CategoryIds { get; set; } = new List<int>();

    /// <summary>
    /// Host Cust Id
    /// </summary>
    [JsonPropertyName("host_cust_id")]
    public int HostCustId { get; set; }
}

/// <summary>
/// ResultSearchHostedChunkInfoData
/// </summary>
public class ResultSearchHostedChunkInfoData
{
    /// <summary>
    /// Session Id
    /// </summary>
    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Start Time
    /// </summary>
    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// End Time
    /// </summary>
    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// License Category Id
    /// </summary>
    [JsonPropertyName("license_category_id")]
    public int LicenseCategoryId { get; set; }

    /// <summary>
    /// Num Drivers
    /// </summary>
    [JsonPropertyName("num_drivers")]
    public int NumDrivers { get; set; }

    /// <summary>
    /// Num Cautions
    /// </summary>
    [JsonPropertyName("num_cautions")]
    public int NumCautions { get; set; }

    /// <summary>
    /// Num Caution Laps
    /// </summary>
    [JsonPropertyName("num_caution_laps")]
    public int NumCautionLaps { get; set; }

    /// <summary>
    /// Num Lead Changes
    /// </summary>
    [JsonPropertyName("num_lead_changes")]
    public int NumLeadChanges { get; set; }

    /// <summary>
    /// Event Laps Complete
    /// </summary>
    [JsonPropertyName("event_laps_complete")]
    public int EventLapsComplete { get; set; }

    /// <summary>
    /// Driver Changes
    /// </summary>
    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    /// <summary>
    /// Winner Group Id
    /// </summary>
    [JsonPropertyName("winner_group_id")]
    public int WinnerGroupId { get; set; }

    /// <summary>
    /// Winner Ai
    /// </summary>
    [JsonPropertyName("winner_ai")]
    public bool WinnerAi { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();

    /// <summary>
    /// Private Session Id
    /// </summary>
    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

    /// <summary>
    /// Session Name
    /// </summary>
    [JsonPropertyName("session_name")]
    public string SessionName { get; set; } = string.Empty;

    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// League Season Id
    /// </summary>
    [JsonPropertyName("league_season_id")]
    public int LeagueSeasonId { get; set; }

    /// <summary>
    /// Created
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// Practice Length
    /// </summary>
    [JsonPropertyName("practice_length")]
    public int PracticeLength { get; set; }

    /// <summary>
    /// Qualify Length
    /// </summary>
    [JsonPropertyName("qualify_length")]
    public int QualifyLength { get; set; }

    /// <summary>
    /// Qualify Laps
    /// </summary>
    [JsonPropertyName("qualify_laps")]
    public int QualifyLaps { get; set; }

    /// <summary>
    /// Race Length
    /// </summary>
    [JsonPropertyName("race_length")]
    public int RaceLength { get; set; }

    /// <summary>
    /// Race Laps
    /// </summary>
    [JsonPropertyName("race_laps")]
    public int RaceLaps { get; set; }

    /// <summary>
    /// Heat Race
    /// </summary>
    [JsonPropertyName("heat_race")]
    public bool HeatRace { get; set; }

    /// <summary>
    /// Host
    /// </summary>
    [JsonPropertyName("host")]
    public Session.SessionDriver Host { get; set; } = new Session.SessionDriver();

    /// <summary>
    /// Cars
    /// </summary>
    [JsonPropertyName("cars")]
    public List<CarInfo> Cars { get; set; } = new List<CarInfo>();
}

/// <summary>
/// CarInfo
/// </summary>
public class CarInfo
{
    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Car Name
    /// </summary>
    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;

    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Car Class Name
    /// </summary>
    [JsonPropertyName("car_class_name")]
    public string CarClassName { get; set; } = string.Empty;

    /// <summary>
    /// Car Class Short Name
    /// </summary>
    [JsonPropertyName("car_class_short_name")]
    public string CarClassShortName { get; set; } = string.Empty;

    /// <summary>
    /// Car Name Abbreviated
    /// </summary>
    [JsonPropertyName("car_name_abbreviated")]
    public string CarNameAbbreviated { get; set; } = string.Empty;
}

