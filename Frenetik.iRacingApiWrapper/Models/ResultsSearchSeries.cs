namespace Frenetik.iRacingApiWrapper.Models;

public class ResultsSearchSeries : IChunkInfo<ResultsSearchSeriesChunkInfoData>
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public ResultsSearchSeriesData Data { get; set; } = new ResultsSearchSeriesData();

    public ChunkInfo ChunkInfo => Data.ChunkInfo;
}

public class ResultsSearchSeriesData
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

    [JsonPropertyName("params")]
    public ResultsSearchSeriesDataParameters Parameters { get; set; } = new ResultsSearchSeriesDataParameters();
}

public class ResultsSearchSeriesDataParameters
{
    [JsonPropertyName("category_ids")]
    public List<int> CategoryIds { get; set; } = new List<int>();

    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    [JsonPropertyName("official_only")]
    public bool OfficialOnly { get; set; }

    [JsonPropertyName("event_types")]
    public List<int> EventTypes { get; set; } = new List<int>();
}
public class ResultsSearchSeriesChunkInfoData
{
    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("start_time")]
    public string StartTime { get; set; } = string.Empty;

    [JsonPropertyName("end_time")]
    public string EndTime { get; set; } = string.Empty;

    [JsonPropertyName("license_category_id")]
    public int LicenseCategoryId { get; set; }

    [JsonPropertyName("license_category")]
    public string LicenseCategory { get; set; } = string.Empty;

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

    [JsonPropertyName("winner_name")]
    public string WinnerName { get; set; } = string.Empty;

    [JsonPropertyName("winner_ai")]
    public bool WinnerAi { get; set; }

    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();

    [JsonPropertyName("official_session")]
    public bool OfficialSession { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    [JsonPropertyName("event_type_name")]
    public string EventTypeName { get; set; } = string.Empty;

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;

    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    [JsonPropertyName("event_strength_of_field")]
    public int EventStrengthOfField { get; set; }

    [JsonPropertyName("event_average_lap")]
    public int EventAverageLap { get; set; }

    [JsonPropertyName("event_best_lap_time")]
    public int EventBestLapTime { get; set; }
}
