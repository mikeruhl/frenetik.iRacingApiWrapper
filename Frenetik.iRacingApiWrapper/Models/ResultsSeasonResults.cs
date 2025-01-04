namespace Frenetik.iRacingApiWrapper.Models;

public class ResultsSeasonResults
{
    [JsonPropertyName("results_list")]
    public List<ResultsSeasonResultsListItem> ResultsList { get; set; } = new();

    [JsonPropertyName("event_type")]
    public int? EventType { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("race_week_num")]
    public int? RaceWeekNum { get; set; }
}

public class ResultsSeasonResultsListItem
{
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    [JsonPropertyName("event_type_name")]
    public string EventTypeName { get; set; } = string.Empty;

    [JsonPropertyName("start_time")]
    public string StartTime { get; set; } = string.Empty;

    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("official_session")]
    public bool OfficialSession { get; set; }

    [JsonPropertyName("event_strength_of_field")]
    public int EventStrengthOfField { get; set; }

    [JsonPropertyName("event_best_lap_time")]
    public int EventBestLapTime { get; set; }

    [JsonPropertyName("num_cautions")]
    public int NumCautions { get; set; }

    [JsonPropertyName("num_caution_laps")]
    public int NumCautionLaps { get; set; }

    [JsonPropertyName("num_lead_changes")]
    public int NumLeadChanges { get; set; }

    [JsonPropertyName("num_drivers")]
    public int NumDrivers { get; set; }

    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();

    [JsonPropertyName("car_classes")]
    public List<CarClassShort> CarClasses { get; set; } = new List<CarClassShort>();
}

public class CarClassShort
{
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("num_entries")]
    public int NumEntries { get; set; }

    [JsonPropertyName("strength_of_field")]
    public int StrengthOfField { get; set; }
}