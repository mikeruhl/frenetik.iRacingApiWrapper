namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Series Season Schedule Result
/// </summary>
public class SeriesSeasonScheduleResult
{
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
    /// Schedules
    /// </summary>
    [JsonPropertyName("schedules")]
    public List<SeriesSeasonSchedule> Schedules { get; set; } = [];
}

/// <summary>
/// Series Season Schedule
/// </summary>
public class SeriesSeasonSchedule
{
    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    /// <summary>
    /// Car Restrictions
    /// </summary>
    [JsonPropertyName("car_restrictions")]
    public List<object> CarRestrictions { get; set; } = [];

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Enable Pitlane Collisions
    /// </summary>
    [JsonPropertyName("enable_pitlane_collisions")]
    public bool EnablePitlaneCollisions { get; set; }

    /// <summary>
    /// Event Options
    /// </summary>
    [JsonPropertyName("event_options")]
    public SeriesSeasonScheduleEventOptions EventOptions { get; set; } = new();

    /// <summary>
    /// Event Sessions
    /// </summary>
    [JsonPropertyName("event_sessions")]
    public List<SeriesSeasonScheduleEventSession> EventSessions { get; set; } = [];

    /// <summary>
    /// Full Course Cautions
    /// </summary>
    [JsonPropertyName("full_course_cautions")]
    public bool FullCourseCautions { get; set; }

    /// <summary>
    /// Practice Length
    /// </summary>
    [JsonPropertyName("practice_length")]
    public int PracticeLength { get; set; }

    /// <summary>
    /// Qual Attached
    /// </summary>
    [JsonPropertyName("qual_attached")]
    public bool QualAttached { get; set; }

    /// <summary>
    /// Qual Time Descriptors
    /// </summary>
    [JsonPropertyName("qual_time_descriptors")]
    public List<object> QualTimeDescriptors { get; set; } = [];

    /// <summary>
    /// Qualify Laps
    /// </summary>
    [JsonPropertyName("qualify_laps")]
    public int QualifyLaps { get; set; }

    /// <summary>
    /// Qualify Length
    /// </summary>
    [JsonPropertyName("qualify_length")]
    public int QualifyLength { get; set; }

    /// <summary>
    /// Race Lap Limit
    /// </summary>
    [JsonPropertyName("race_lap_limit")]
    public int? RaceLapLimit { get; set; }

    /// <summary>
    /// Race Time Descriptors
    /// </summary>
    [JsonPropertyName("race_time_descriptors")]
    public List<SeriesSeasonScheduleRaceTimeDescriptor> RaceTimeDescriptors { get; set; } = [];

    /// <summary>
    /// Race Time Limit
    /// </summary>
    [JsonPropertyName("race_time_limit")]
    public int? RaceTimeLimit { get; set; }

    /// <summary>
    /// Race Week Car Classes
    /// </summary>
    [JsonPropertyName("race_week_car_classes")]
    public List<object> RaceWeekCarClasses { get; set; } = [];

    /// <summary>
    /// Restart Type
    /// </summary>
    [JsonPropertyName("restart_type")]
    public string RestartType { get; set; } = string.Empty;

    /// <summary>
    /// Schedule Name
    /// </summary>
    [JsonPropertyName("schedule_name")]
    public string ScheduleName { get; set; } = string.Empty;

    /// <summary>
    /// Season Name
    /// </summary>
    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

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
    /// Short Parade Lap
    /// </summary>
    [JsonPropertyName("short_parade_lap")]
    public bool ShortParadeLap { get; set; }

    /// <summary>
    /// Special Event Type
    /// </summary>
    [JsonPropertyName("special_event_type")]
    public object? SpecialEventType { get; set; }

    /// <summary>
    /// Start Date
    /// </summary>
    [JsonPropertyName("start_date")]
    public string StartDate { get; set; } = string.Empty;

    /// <summary>
    /// Start Type
    /// </summary>
    [JsonPropertyName("start_type")]
    public string StartType { get; set; } = string.Empty;

    /// <summary>
    /// Start Zone
    /// </summary>
    [JsonPropertyName("start_zone")]
    public bool StartZone { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public SeriesSeasonScheduleTrack Track { get; set; } = new();

    /// <summary>
    /// Track State
    /// </summary>
    [JsonPropertyName("track_state")]
    public SeriesSeasonScheduleTrackState TrackState { get; set; } = new();

    /// <summary>
    /// Warmup Length
    /// </summary>
    [JsonPropertyName("warmup_length")]
    public int WarmupLength { get; set; }

    /// <summary>
    /// Weather
    /// </summary>
    [JsonPropertyName("weather")]
    public SeriesSeasonScheduleWeather Weather { get; set; } = new();

    /// <summary>
    /// Week End Time
    /// </summary>
    [JsonPropertyName("week_end_time")]
    public string WeekEndTime { get; set; } = string.Empty;
}

/// <summary>
/// Series Season Schedule Event Options
/// </summary>
public class SeriesSeasonScheduleEventOptions
{
    /// <summary>
    /// Allow Wave Arounds
    /// </summary>
    [JsonPropertyName("allow_wave_arounds")]
    public bool AllowWaveArounds { get; set; }

    /// <summary>
    /// Cautions Enabled
    /// </summary>
    [JsonPropertyName("cautions_enabled")]
    public bool CautionsEnabled { get; set; }

    /// <summary>
    /// Qualify Scoring Type
    /// </summary>
    [JsonPropertyName("qualify_scoring_type")]
    public int QualifyScoringType { get; set; }

    /// <summary>
    /// Restart Type
    /// </summary>
    [JsonPropertyName("restart_type")]
    public int RestartType { get; set; }

    /// <summary>
    /// Short Parade Lap
    /// </summary>
    [JsonPropertyName("short_parade_lap")]
    public bool ShortParadeLap { get; set; }

    /// <summary>
    /// Single File Consec Cautions
    /// </summary>
    [JsonPropertyName("single_file_consec_cautions")]
    public bool SingleFileConsecCautions { get; set; }

    /// <summary>
    /// Standing Start
    /// </summary>
    [JsonPropertyName("standing_start")]
    public bool StandingStart { get; set; }

    /// <summary>
    /// Starting Grid Type
    /// </summary>
    [JsonPropertyName("starting_grid_type")]
    public int StartingGridType { get; set; }
}

/// <summary>
/// Series Season Schedule Event Session
/// </summary>
public class SeriesSeasonScheduleEventSession
{
    /// <summary>
    /// Laps
    /// </summary>
    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    /// <summary>
    /// Minutes
    /// </summary>
    [JsonPropertyName("minutes")]
    public int Minutes { get; set; }

    /// <summary>
    /// Start Time Offset
    /// </summary>
    [JsonPropertyName("start_time_offset")]
    public int StartTimeOffset { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    /// Type Name
    /// </summary>
    [JsonPropertyName("type_name")]
    public string TypeName { get; set; } = string.Empty;

    /// <summary>
    /// Unlimited Laps
    /// </summary>
    [JsonPropertyName("unlimited_laps")]
    public bool UnlimitedLaps { get; set; }

    /// <summary>
    /// Unlimited Time
    /// </summary>
    [JsonPropertyName("unlimited_time")]
    public bool UnlimitedTime { get; set; }
}

/// <summary>
/// Series Season Schedule Race Time Descriptor
/// </summary>
public class SeriesSeasonScheduleRaceTimeDescriptor
{
    /// <summary>
    /// Day Offset
    /// </summary>
    [JsonPropertyName("day_offset")]
    public List<int> DayOffset { get; set; } = [];

    /// <summary>
    /// First Session Time
    /// </summary>
    [JsonPropertyName("first_session_time")]
    public string FirstSessionTime { get; set; } = string.Empty;

    /// <summary>
    /// Repeat Minutes
    /// </summary>
    [JsonPropertyName("repeat_minutes")]
    public int RepeatMinutes { get; set; }

    /// <summary>
    /// Repeating
    /// </summary>
    [JsonPropertyName("repeating")]
    public bool Repeating { get; set; }

    /// <summary>
    /// Session Minutes
    /// </summary>
    [JsonPropertyName("session_minutes")]
    public int SessionMinutes { get; set; }

    /// <summary>
    /// Start Date
    /// </summary>
    [JsonPropertyName("start_date")]
    public string StartDate { get; set; } = string.Empty;

    /// <summary>
    /// Super Session
    /// </summary>
    [JsonPropertyName("super_session")]
    public bool SuperSession { get; set; }
}

/// <summary>
/// Series Season Schedule Track
/// </summary>
public class SeriesSeasonScheduleTrack
{
    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Config Name
    /// </summary>
    [JsonPropertyName("config_name")]
    public string? ConfigName { get; set; }

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
}

/// <summary>
/// Series Season Schedule Track State
/// </summary>
public class SeriesSeasonScheduleTrackState
{
    /// <summary>
    /// Leave Marbles
    /// </summary>
    [JsonPropertyName("leave_marbles")]
    public bool LeaveMarbles { get; set; }

    /// <summary>
    /// Practice Rubber
    /// </summary>
    [JsonPropertyName("practice_rubber")]
    public int PracticeRubber { get; set; }
}

/// <summary>
/// Series Season Schedule Weather
/// </summary>
public class SeriesSeasonScheduleWeather
{
    /// <summary>
    /// Allow Fog
    /// </summary>
    [JsonPropertyName("allow_fog")]
    public bool AllowFog { get; set; }

    /// <summary>
    /// Forecast Options
    /// </summary>
    [JsonPropertyName("forecast_options")]
    public SeriesSeasonScheduleForecastOptions ForecastOptions { get; set; } = new();

    /// <summary>
    /// Precip Option
    /// </summary>
    [JsonPropertyName("precip_option")]
    public int PrecipOption { get; set; }

    /// <summary>
    /// Rel Humidity
    /// </summary>
    [JsonPropertyName("rel_humidity")]
    public int RelativeHumidity { get; set; }

    /// <summary>
    /// Simulated Start Time
    /// </summary>
    [JsonPropertyName("simulated_start_time")]
    public string SimulatedStartTime { get; set; } = string.Empty;

    /// <summary>
    /// Simulated Time Multiplier
    /// </summary>
    [JsonPropertyName("simulated_time_multiplier")]
    public int SimulatedTimeMultiplier { get; set; }

    /// <summary>
    /// Simulated Time Offsets
    /// </summary>
    [JsonPropertyName("simulated_time_offsets")]
    public List<int> SimulatedTimeOffsets { get; set; } = [];

    /// <summary>
    /// Skies
    /// </summary>
    [JsonPropertyName("skies")]
    public int Skies { get; set; }

    /// <summary>
    /// Temp Units
    /// </summary>
    [JsonPropertyName("temp_units")]
    public int TemperatureUnits { get; set; }

    /// <summary>
    /// Temp Value
    /// </summary>
    [JsonPropertyName("temp_value")]
    public int TemperatureValue { get; set; }

    /// <summary>
    /// Time Of Day
    /// </summary>
    [JsonPropertyName("time_of_day")]
    public int TimeOfDay { get; set; }

    /// <summary>
    /// Track Water
    /// </summary>
    [JsonPropertyName("track_water")]
    public int TrackWater { get; set; }

    /// <summary>
    /// Version
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; }

    /// <summary>
    /// Weather Summary
    /// </summary>
    [JsonPropertyName("weather_summary")]
    public SeriesSeasonScheduleWeatherSummary WeatherSummary { get; set; } = new();

    /// <summary>
    /// Wind Dir
    /// </summary>
    [JsonPropertyName("wind_dir")]
    public int WindDirection { get; set; }

    /// <summary>
    /// Wind Units
    /// </summary>
    [JsonPropertyName("wind_units")]
    public int WindUnits { get; set; }

    /// <summary>
    /// Wind Value
    /// </summary>
    [JsonPropertyName("wind_value")]
    public int WindValue { get; set; }
}

/// <summary>
/// Series Season Schedule Forecast Options
/// </summary>
public class SeriesSeasonScheduleForecastOptions
{
    /// <summary>
    /// Allow Fog
    /// </summary>
    [JsonPropertyName("allow_fog")]
    public bool AllowFog { get; set; }

    /// <summary>
    /// Forecast Type
    /// </summary>
    [JsonPropertyName("forecast_type")]
    public int ForecastType { get; set; }

    /// <summary>
    /// Precipitation
    /// </summary>
    [JsonPropertyName("precipitation")]
    public int Precipitation { get; set; }

    /// <summary>
    /// Skies
    /// </summary>
    [JsonPropertyName("skies")]
    public int Skies { get; set; }

    /// <summary>
    /// Stop Precip
    /// </summary>
    [JsonPropertyName("stop_precip")]
    public int StopPrecip { get; set; }

    /// <summary>
    /// Temperature
    /// </summary>
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }

    /// <summary>
    /// Weather Seed
    /// </summary>
    [JsonPropertyName("weather_seed")]
    public long WeatherSeed { get; set; }

    /// <summary>
    /// Wind Dir
    /// </summary>
    [JsonPropertyName("wind_dir")]
    public int WindDirection { get; set; }

    /// <summary>
    /// Wind Speed
    /// </summary>
    [JsonPropertyName("wind_speed")]
    public int WindSpeed { get; set; }
}

/// <summary>
/// Series Season Schedule Weather Summary
/// </summary>
public class SeriesSeasonScheduleWeatherSummary
{
    /// <summary>
    /// Max Precip Rate
    /// </summary>
    [JsonPropertyName("max_precip_rate")]
    public float MaxPrecipitationRate { get; set; }

    /// <summary>
    /// Max Precip Rate Desc
    /// </summary>
    [JsonPropertyName("max_precip_rate_desc")]
    public string MaxPrecipitationRateDescription { get; set; } = string.Empty;

    /// <summary>
    /// Precip Chance
    /// </summary>
    [JsonPropertyName("precip_chance")]
    public float PrecipitationChance { get; set; }

    /// <summary>
    /// Skies High
    /// </summary>
    [JsonPropertyName("skies_high")]
    public int SkiesHigh { get; set; }

    /// <summary>
    /// Skies Low
    /// </summary>
    [JsonPropertyName("skies_low")]
    public int SkiesLow { get; set; }

    /// <summary>
    /// Temp High
    /// </summary>
    [JsonPropertyName("temp_high")]
    public float TemperatureHigh { get; set; }

    /// <summary>
    /// Temp Low
    /// </summary>
    [JsonPropertyName("temp_low")]
    public float TemperatureLow { get; set; }

    /// <summary>
    /// Temp Units
    /// </summary>
    [JsonPropertyName("temp_units")]
    public int TemperatureUnits { get; set; }

    /// <summary>
    /// Wind Dir
    /// </summary>
    [JsonPropertyName("wind_dir")]
    public int WindDirection { get; set; }

    /// <summary>
    /// Wind High
    /// </summary>
    [JsonPropertyName("wind_high")]
    public float WindHigh { get; set; }

    /// <summary>
    /// Wind Low
    /// </summary>
    [JsonPropertyName("wind_low")]
    public float WindLow { get; set; }

    /// <summary>
    /// Wind Units
    /// </summary>
    [JsonPropertyName("wind_units")]
    public int WindUnits { get; set; }
}
