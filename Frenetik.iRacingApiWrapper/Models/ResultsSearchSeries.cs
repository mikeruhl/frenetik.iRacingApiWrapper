namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// ResultsSearchSeries
/// </summary>
public class ResultsSearchSeries : IChunkInfo<ResultsSearchSeriesChunkInfoData>
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
    public ResultsSearchSeriesData Data { get; set; } = new ResultsSearchSeriesData();

    /// <summary>
    /// Chunk info
    /// </summary>
    public ChunkInfo ChunkInfo => Data.ChunkInfo;
}

/// <summary>
/// ResultsSearchSeriesData
/// </summary>
public class ResultsSearchSeriesData
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
    public ResultsSearchSeriesDataParameters Parameters { get; set; } = new ResultsSearchSeriesDataParameters();
}

/// <summary>
/// ResultsSearchSeriesDataParameters
/// </summary>
public class ResultsSearchSeriesDataParameters
{
    /// <summary>
    /// Category Ids
    /// </summary>
    [JsonPropertyName("category_ids")]
    public List<int> CategoryIds { get; set; } = new List<int>();

    /// <summary>
    /// Season Year
    /// </summary>
    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    /// <summary>
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    /// <summary>
    /// Official Only
    /// </summary>
    [JsonPropertyName("official_only")]
    public bool OfficialOnly { get; set; }

    /// <summary>
    /// Event Types
    /// </summary>
    [JsonPropertyName("event_types")]
    public List<int> EventTypes { get; set; } = new List<int>();
}
/// <summary>
/// ResultsSearchSeriesChunkInfoData
/// </summary>
public class ResultsSearchSeriesChunkInfoData
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
    public string StartTime { get; set; } = string.Empty;

    /// <summary>
    /// End Time
    /// </summary>
    [JsonPropertyName("end_time")]
    public string EndTime { get; set; } = string.Empty;

    /// <summary>
    /// License Category Id
    /// </summary>
    [JsonPropertyName("license_category_id")]
    public int LicenseCategoryId { get; set; }

    /// <summary>
    /// License Category
    /// </summary>
    [JsonPropertyName("license_category")]
    public string LicenseCategory { get; set; } = string.Empty;

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
    /// Winner Name
    /// </summary>
    [JsonPropertyName("winner_name")]
    public string WinnerName { get; set; } = string.Empty;

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
    /// Official Session
    /// </summary>
    [JsonPropertyName("official_session")]
    public bool OfficialSession { get; set; }

    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Season Year
    /// </summary>
    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    /// <summary>
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

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
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

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
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    /// <summary>
    /// Event Strength Of Field
    /// </summary>
    [JsonPropertyName("event_strength_of_field")]
    public int EventStrengthOfField { get; set; }

    /// <summary>
    /// Event Average Lap
    /// </summary>
    [JsonPropertyName("event_average_lap")]
    public int EventAverageLap { get; set; }

    /// <summary>
    /// Event Best Lap Time
    /// </summary>
    [JsonPropertyName("event_best_lap_time")]
    public int EventBestLapTime { get; set; }
}

