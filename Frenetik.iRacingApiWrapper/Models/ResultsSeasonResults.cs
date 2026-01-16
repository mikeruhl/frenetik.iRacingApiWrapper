namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// ResultsSeasonResults
/// </summary>
public class ResultsSeasonResults
{
    /// <summary>
    /// Results List
    /// </summary>
    [JsonPropertyName("results_list")]
    public List<ResultsSeasonResultsListItem> ResultsList { get; set; } = new();

    /// <summary>
    /// Event Type
    /// </summary>
    [JsonPropertyName("event_type")]
    public int? EventType { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int? RaceWeekNum { get; set; }
}

/// <summary>
/// ResultsSeasonResultsListItem
/// </summary>
public class ResultsSeasonResultsListItem
{
    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

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
    /// Start Time
    /// </summary>
    [JsonPropertyName("start_time")]
    public string StartTime { get; set; } = string.Empty;

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
    /// Official Session
    /// </summary>
    [JsonPropertyName("official_session")]
    public bool OfficialSession { get; set; }

    /// <summary>
    /// Event Strength Of Field
    /// </summary>
    [JsonPropertyName("event_strength_of_field")]
    public int EventStrengthOfField { get; set; }

    /// <summary>
    /// Event Best Lap Time
    /// </summary>
    [JsonPropertyName("event_best_lap_time")]
    public int EventBestLapTime { get; set; }

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
    /// Num Drivers
    /// </summary>
    [JsonPropertyName("num_drivers")]
    public int NumDrivers { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();

    /// <summary>
    /// Car Classes
    /// </summary>
    [JsonPropertyName("car_classes")]
    public List<CarClassShort> CarClasses { get; set; } = new List<CarClassShort>();
}

/// <summary>
/// CarClassShort
/// </summary>
public class CarClassShort
{
    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Short Name
    /// </summary>
    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Num Entries
    /// </summary>
    [JsonPropertyName("num_entries")]
    public int NumEntries { get; set; }

    /// <summary>
    /// Strength Of Field
    /// </summary>
    [JsonPropertyName("strength_of_field")]
    public int StrengthOfField { get; set; }
}
