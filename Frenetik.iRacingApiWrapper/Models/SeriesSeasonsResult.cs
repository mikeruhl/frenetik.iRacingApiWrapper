namespace Frenetik.iRacingApiWrapper.Models
{
    /// <summary>
    /// SeriesSeasonsResult
    /// </summary>
    public class SeriesSeasonsResult
    {
        /// <summary>
        /// Season Id
        /// </summary>
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        /// <summary>
        /// Season Name
        /// </summary>
        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; } = string.Empty;

        /// <summary>
        /// Active
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Allowed Season Members
        /// </summary>
        [JsonPropertyName("allowed_season_members")]
        public Dictionary<string, SeriesSeasonsAllowSeasonMember>? AllowedSeasonMembers { get; set; }

        /// <summary>
        /// Car Class Ids
        /// </summary>
        [JsonPropertyName("car_class_ids")]
        public List<int> CarClassIds { get; set; } = new();

        /// <summary>
        /// Car Switching
        /// </summary>
        [JsonPropertyName("car_switching")]
        public bool CarSwitching { get; set; }

        /// <summary>
        /// Car Types
        /// </summary>
        [JsonPropertyName("car_types")]
        public List<SeriesSeasonsCarType> CarTypes { get; set; } = new();

        /// <summary>
        /// Caution Laps Do Not Count
        /// </summary>
        [JsonPropertyName("caution_laps_do_not_count")]
        public bool CautionLapsDoNotCount { get; set; }

        /// <summary>
        /// Complete
        /// </summary>
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        /// <summary>
        /// Connection Black Flag
        /// </summary>
        [JsonPropertyName("connection_black_flag")]
        public bool ConnectionBlackFlag { get; set; }

        /// <summary>
        /// Consec Caution Within N Laps
        /// </summary>
        [JsonPropertyName("consec_caution_within_nlaps")]
        public int ConsecCautionWithinNLaps { get; set; }

        /// <summary>
        /// Consec Cautions Single File
        /// </summary>
        [JsonPropertyName("consec_cautions_single_file")]
        public bool ConsecCautionsSingleFile { get; set; }

        /// <summary>
        /// Cross License
        /// </summary>
        [JsonPropertyName("cross_license")]
        public bool CrossLicense { get; set; }

        /// <summary>
        /// Distributed Matchmaking
        /// </summary>
        [JsonPropertyName("distributed_matchmaking")]
        public bool DistributedMatchmaking { get; set; }

        /// <summary>
        /// Driver Change Rule
        /// </summary>
        [JsonPropertyName("driver_change_rule")]
        public int DriverChangeRule { get; set; }

        /// <summary>
        /// Driver Changes
        /// </summary>
        [JsonPropertyName("driver_changes")]
        public bool DriverChanges { get; set; }

        /// <summary>
        /// Drops
        /// </summary>
        [JsonPropertyName("drops")]
        public int Drops { get; set; }

        /// <summary>
        /// Enable Pitlane Collisions
        /// </summary>
        [JsonPropertyName("enable_pitlane_collisions")]
        public bool EnablePitlaneCollisions { get; set; }

        /// <summary>
        /// Fixed Setup
        /// </summary>
        [JsonPropertyName("fixed_setup")]
        public bool FixedSetup { get; set; }

        /// <summary>
        /// Green White Checkered Limit
        /// </summary>
        [JsonPropertyName("green_white_checkered_limit")]
        public int GreenWhiteCheckeredLimit { get; set; }

        /// <summary>
        /// Grid By Class
        /// </summary>
        [JsonPropertyName("grid_by_class")]
        public bool GridByClass { get; set; }

        /// <summary>
        /// Hardcore Level
        /// </summary>
        [JsonPropertyName("hardcore_level")]
        public int HardcoreLevel { get; set; }

        /// <summary>
        /// Has Supersessions
        /// </summary>
        [JsonPropertyName("has_supersessions")]
        public bool HasSupersessions { get; set; }

        /// <summary>
        /// Heat Session Info
        /// </summary>
        [JsonPropertyName("heat_ses_info")]
        public SeriesSeasonsHeatSesInfo? HeatSesInfo { get; set; }

        /// <summary>
        /// Ignore License For Practice
        /// </summary>
        [JsonPropertyName("ignore_license_for_practice")]
        public bool IgnoreLicenseForPractice { get; set; }

        /// <summary>
        /// Incident Limit
        /// </summary>
        [JsonPropertyName("incident_limit")]
        public int IncidentLimit { get; set; }

        /// <summary>
        /// Incident Warn Mode
        /// </summary>
        [JsonPropertyName("incident_warn_mode")]
        public int IncidentWarnMode { get; set; }

        /// <summary>
        /// Incident Warn Param1
        /// </summary>
        [JsonPropertyName("incident_warn_param1")]
        public int IncidentWarnParam1 { get; set; }

        /// <summary>
        /// Incident Warn Param2
        /// </summary>
        [JsonPropertyName("incident_warn_param2")]
        public int IncidentWarnParam2 { get; set; }

        /// <summary>
        /// Is Heat Racing
        /// </summary>
        [JsonPropertyName("is_heat_racing")]
        public bool IsHeatRacing { get; set; }

        /// <summary>
        /// License Group
        /// </summary>
        [JsonPropertyName("license_group")]
        public int LicenseGroup { get; set; }

        /// <summary>
        /// License Group Types
        /// </summary>
        [JsonPropertyName("license_group_types")]
        public List<SeriesSeasonsLicenseGroupType> LicenseGroupTypes { get; set; } = new();

        /// <summary>
        /// Lucky Dog
        /// </summary>
        [JsonPropertyName("lucky_dog")]
        public bool LuckyDog { get; set; }

        /// <summary>
        /// Max Team Drivers
        /// </summary>
        [JsonPropertyName("max_team_drivers")]
        public int MaxTeamDrivers { get; set; }

        /// <summary>
        /// Max Weeks
        /// </summary>
        [JsonPropertyName("max_weeks")]
        public int MaxWeeks { get; set; }

        /// <summary>
        /// Min Team Drivers
        /// </summary>
        [JsonPropertyName("min_team_drivers")]
        public int MinTeamDrivers { get; set; }

        /// <summary>
        /// Multiclass
        /// </summary>
        [JsonPropertyName("multiclass")]
        public bool Multiclass { get; set; }

        /// <summary>
        /// Must Use Diff Tire Types In Race
        /// </summary>
        [JsonPropertyName("must_use_diff_tire_types_in_race")]
        public bool MustUseDifferentTireTypesInRace { get; set; }

        //TODO: Find property type
        /// <summary>
        /// Next Race Session
        /// </summary>
        [JsonPropertyName("next_race_session")]
        public object? NextRaceSession { get; set; }

        /// <summary>
        /// Num Fast Tows
        /// </summary>
        [JsonPropertyName("num_fast_tows")]
        public int NumFastTows { get; set; }

        /// <summary>
        /// Num Opt Laps
        /// </summary>
        [JsonPropertyName("num_opt_laps")]
        public int NumOptLaps { get; set; }

        /// <summary>
        /// Official
        /// </summary>
        [JsonPropertyName("official")]
        public bool Official { get; set; }

        /// <summary>
        /// Op Duration
        /// </summary>
        [JsonPropertyName("op_duration")]
        public int OpDuration { get; set; }

        /// <summary>
        /// Open Practice Session Type Id
        /// </summary>
        [JsonPropertyName("open_practice_session_type_id")]
        public int OpenPracticeSessionTypeId { get; set; }

        /// <summary>
        /// Qualifier Must Start Race
        /// </summary>
        [JsonPropertyName("qualifier_must_start_race")]
        public bool QualifierMustStartRace { get; set; }

        /// <summary>
        /// Race Week
        /// </summary>
        [JsonPropertyName("race_week")]
        public int RaceWeek { get; set; }

        /// <summary>
        /// Race Week To Make Divisions
        /// </summary>
        [JsonPropertyName("race_week_to_make_divisions")]
        public int RaceWeekToMakeDivisions { get; set; }

        /// <summary>
        /// Reg Open Minutes
        /// </summary>
        [JsonPropertyName("reg_open_minutes")]
        public int RegOpenMinutes { get; set; }

        /// <summary>
        /// Reg User Count
        /// </summary>
        [JsonPropertyName("reg_user_count")]
        public int RegUserCount { get; set; }

        /// <summary>
        /// Region Competition
        /// </summary>
        [JsonPropertyName("region_competition")]
        public bool RegionCompetition { get; set; }

        /// <summary>
        /// Rookie Season
        /// </summary>
        [JsonPropertyName("rookie_season")]
        public string RookieSeason { get; set; } = string.Empty;

        /// <summary>
        /// Restrict By Member
        /// </summary>
        [JsonPropertyName("restrict_by_member")]
        public bool RestrictByMember { get; set; }

        /// <summary>
        /// Restrict To Car
        /// </summary>
        [JsonPropertyName("restrict_to_car")]
        public bool RestrictToCar { get; set; }

        /// <summary>
        /// Restrict Viewing
        /// </summary>
        [JsonPropertyName("restrict_viewing")]
        public bool RestrictViewing { get; set; }

        /// <summary>
        /// Schedule Description
        /// </summary>
        [JsonPropertyName("schedule_description")]
        public string ScheduleDescription { get; set; } = string.Empty;

        /// <summary>
        /// Schedules
        /// </summary>
        [JsonPropertyName("schedules")]
        public List<Schedule> Schedules { get; set; } = new();

        /// <summary>
        /// Season Quarter
        /// </summary>
        [JsonPropertyName("season_quarter")]
        public int SeasonQuarter { get; set; }

        /// <summary>
        /// Season Short Name
        /// </summary>
        [JsonPropertyName("season_short_name")]
        public string SeasonShortName { get; set; } = string.Empty;

        /// <summary>
        /// Season Year
        /// </summary>
        [JsonPropertyName("season_year")]
        public int SeasonYear { get; set; }

        /// <summary>
        /// Score As Car Class Id
        /// </summary>
        [JsonPropertyName("score_as_carclassid")]
        public int ScoreAsCarClassId { get; set; }

        /// <summary>
        /// Send To Open Practice
        /// </summary>
        [JsonPropertyName("send_to_open_practice")]
        public bool SendToOpenPractice { get; set; }

        /// <summary>
        /// Series Id
        /// </summary>
        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        /// <summary>
        /// Short Parade Lap
        /// </summary>
        [JsonPropertyName("short_parade_lap")]
        public bool ShortParadeLap { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        [JsonPropertyName("start_date")]
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Start On Qual Tire
        /// </summary>
        [JsonPropertyName("start_on_qual_tire")]
        public bool StartOnQualTire { get; set; }

        /// <summary>
        /// Start Zone
        /// </summary>
        [JsonPropertyName("start_zone")]
        public bool StartZone { get; set; }

        /// <summary>
        /// Track Types
        /// </summary>
        [JsonPropertyName("track_types")]
        public List<TrackType> TrackTypes { get; set; } = new();

        /// <summary>
        /// Unsport Conduct Rule Mode
        /// </summary>
        [JsonPropertyName("unsport_conduct_rule_mode")]
        public int UnsportConductRuleMode { get; set; }
    }

    /// <summary>
    /// SeriesSeasonsCarType
    /// </summary>
    public class SeriesSeasonsCarType
    {
        /// <summary>
        /// Car Type
        /// </summary>
        [JsonPropertyName("car_type")]
        public string CarTypeValue { get; set; } = string.Empty;
    }

    /// <summary>
    /// SeriesSeasonsLicenseGroupType
    /// </summary>
    public class SeriesSeasonsLicenseGroupType
    {
        /// <summary>
        /// License Group Type
        /// </summary>
        [JsonPropertyName("license_group_type")]
        public int LicenseGroupTypeValue { get; set; }
    }

    /// <summary>
    /// Schedule
    /// </summary>
    public class Schedule
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
        public List<SeriesSeasonCarRestriction>? CarRestrictions { get; set; }

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
        public List<SeriesSeasonsRaceTimeDescriptor> RaceTimeDescriptors { get; set; } = new();

        /// <summary>
        /// Race Time Limit
        /// </summary>
        [JsonPropertyName("race_time_limit")]
        public int? RaceTimeLimit { get; set; }

        /// <summary>
        /// Race Week Car Class Ids
        /// </summary>
        [JsonPropertyName("race_week_car_class_ids")]
        public List<int> RaceWeekCarClassIds { get; set; } = new();

        /// <summary>
        /// Race Week Cars
        /// </summary>
        [JsonPropertyName("race_week_cars")]
        public List<SeriesSeasonsRaceWeekCar>? RaceWeekCars { get; set; }

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

        //TODO: Find property type
        /// <summary>
        /// Special Event Type
        /// </summary>
        [JsonPropertyName("special_event_type")]
        public object? SpecialEventType { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        [JsonPropertyName("start_date")]
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Warmup Length
        /// </summary>
        [JsonPropertyName("warmup_length")]
        public int WarmupLength { get; set; }

        /// <summary>
        /// Week End Time
        /// </summary>
        [JsonPropertyName("week_end_time")]
        public DateTimeOffset WeekEndTime { get; set; }

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
        public SeriesSeasonsTrack Track { get; set; } = new();

        /// <summary>
        /// Track State
        /// </summary>
        [JsonPropertyName("track_state")]
        public SeriesSeasonsTrackState TrackState { get; set; } = new();

        /// <summary>
        /// Weather
        /// </summary>
        [JsonPropertyName("weather")]
        public SeriesSeasonsWeather Weather { get; set; } = new();
    }

    /// <summary>
    /// SeriesSeasonsRaceTimeDescriptor
    /// </summary>
    public class SeriesSeasonsRaceTimeDescriptor
    {
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
        /// Session Times
        /// </summary>
        [JsonPropertyName("session_times")]
        public List<string> SessionTimes { get; set; } = new();

        /// <summary>
        /// Super Session
        /// </summary>
        [JsonPropertyName("super_session")]
        public bool SuperSession { get; set; }
    }

    /// <summary>
    /// SeriesSeasonsTrack
    /// </summary>
    public class SeriesSeasonsTrack
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
        public string ConfigName { get; set; } = string.Empty;

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
    /// SeriesSeasonsTrackState
    /// </summary>
    public class SeriesSeasonsTrackState
    {
        /// <summary>
        /// Leave Marbles
        /// </summary>
        [JsonPropertyName("leave_marbles")]
        public bool LeaveMarbles { get; set; }
    }

    /// <summary>
    /// SeriesSeasonsWeather
    /// </summary>
    public class SeriesSeasonsWeather
    {
        /// <summary>
        /// Allow Fog
        /// </summary>
        [JsonPropertyName("allow_fog")]
        public bool AllowFog { get; set; }

        /// <summary>
        /// Fog
        /// </summary>
        [JsonPropertyName("fog")]
        public int Fog { get; set; }

        /// <summary>
        /// Forecast Options
        /// </summary>
        [JsonPropertyName("forecast_options")]
        public SeriesSeasonsForecastOptions ForecastOptions { get; set; } = new();

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
        /// Simulated Start Utc Time
        /// </summary>
        [JsonPropertyName("simulated_start_utc_time")]
        public string SimulatedStartUtcTime { get; set; } = string.Empty;

        /// <summary>
        /// Simulated Time Multiplier
        /// </summary>
        [JsonPropertyName("simulated_time_multiplier")]
        public int SimulatedTimeMultiplier { get; set; }

        /// <summary>
        /// Simulated Time Offsets
        /// </summary>
        [JsonPropertyName("simulated_time_offsets")]
        public List<int> SimulatedTimeOffsets { get; set; } = new();

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
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }

        /// <summary>
        /// Weather Summary
        /// </summary>
        [JsonPropertyName("weather_summary")]
        public SeriesSeasonsWeatherSummary WeatherSummary { get; set; } = new();

        /// <summary>
        /// Weather Url
        /// </summary>
        [JsonPropertyName("weather_url")]
        public string WeatherUrl { get; set; } = string.Empty;

        /// <summary>
        /// Weather Var Initial
        /// </summary>
        [JsonPropertyName("weather_var_initial")]
        public int WeatherVarInitial { get; set; }

        /// <summary>
        /// Weather Var Ongoing
        /// </summary>
        [JsonPropertyName("weather_var_ongoing")]
        public int WeatherVarOngoing { get; set; }

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
    /// SeriesSeasonsForecastOptions
    /// </summary>
    public class SeriesSeasonsForecastOptions
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
    /// SeriesSeasonsWeatherSummary
    /// </summary>
    public class SeriesSeasonsWeatherSummary
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
        public int WindDir { get; set; }

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

    /// <summary>
    /// SeriesSeasonsAllowSeasonMember
    /// </summary>
    public class SeriesSeasonsAllowSeasonMember
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Season Id
        /// </summary>
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }
    }

    /// <summary>
    /// SeriesSeasonCarRestriction
    /// </summary>
    public class SeriesSeasonCarRestriction
    {
        /// <summary>
        /// Car Id
        /// </summary>
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        /// <summary>
        /// Max Dry Tire Sets
        /// </summary>
        [JsonPropertyName("max_dry_tire_sets")]
        public int MaxDryTireSets { get; set; }

        /// <summary>
        /// Max Pct Fuel Fill
        /// </summary>
        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPctFuelFill { get; set; }

        /// <summary>
        /// Power Adjust Pct
        /// </summary>
        [JsonPropertyName("power_adjust_pct")]
        public float PowerAdjustPct { get; set; }

        /// <summary>
        /// Race Setup Id
        /// </summary>
        [JsonPropertyName("race_setup_id")]
        public int RaceSetupId { get; set; }

        /// <summary>
        /// Weight Penalty Kg
        /// </summary>
        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }
    }

    /// <summary>
    /// SeriesSeasonsRaceWeekCar
    /// </summary>
    public class SeriesSeasonsRaceWeekCar
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
        /// Car Name Abbreviated
        /// </summary>
        [JsonPropertyName("car_name_abbreviated")]
        public string CarNameAbbreviated { get; set; } = string.Empty;
    }

    /// <summary>
    /// SeriesSeasonsHeatSesInfo
    /// </summary>
    public class SeriesSeasonsHeatSesInfo
    {
        /// <summary>
        /// Consolation Delta Max Field Size
        /// </summary>
        [JsonPropertyName("consolation_delta_max_field_size")]
        public int ConsolationDeltaMaxFieldSize { get; set; }

        /// <summary>
        /// Consolation Delta Session Laps
        /// </summary>
        [JsonPropertyName("consolation_delta_session_laps")]
        public int ConsolationDeltaSessionLaps { get; set; }

        /// <summary>
        /// Consolation Delta Session Length Minutes
        /// </summary>
        [JsonPropertyName("consolation_delta_session_length_minutes")]
        public int ConsolationDeltaSessionLengthMinutes { get; set; }

        /// <summary>
        /// Consolation First Max Field Size
        /// </summary>
        [JsonPropertyName("consolation_first_max_field_size")]
        public int ConsolationFirstMaxFieldSize { get; set; }

        /// <summary>
        /// Consolation First Session Laps
        /// </summary>
        [JsonPropertyName("consolation_first_session_laps")]
        public int ConsolationFirstSessionLaps { get; set; }

        /// <summary>
        /// Consolation First Session Length Minutes
        /// </summary>
        [JsonPropertyName("consolation_first_session_length_minutes")]
        public int ConsolationFirstSessionLengthMinutes { get; set; }

        /// <summary>
        /// Consolation Num Position To Invert
        /// </summary>
        [JsonPropertyName("consolation_num_position_to_invert")]
        public int ConsolationNumPositionToInvert { get; set; }

        /// <summary>
        /// Consolation Num To Consolation
        /// </summary>
        [JsonPropertyName("consolation_num_to_consolation")]
        public int ConsolationNumToConsolation { get; set; }

        /// <summary>
        /// Consolation Num To Main
        /// </summary>
        [JsonPropertyName("consolation_num_to_main")]
        public int ConsolationNumToMain { get; set; }

        /// <summary>
        /// Consolation Run Always
        /// </summary>
        [JsonPropertyName("consolation_run_always")]
        public bool ConsolationRunAlways { get; set; }

        /// <summary>
        /// Consolation Scores Champ Points
        /// </summary>
        [JsonPropertyName("consolation_scores_champ_points")]
        public bool ConsolationScoresChampPoints { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        [JsonPropertyName("created")]
        public string Created { get; set; } = string.Empty;

        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Heat Caution Type
        /// </summary>
        [JsonPropertyName("heat_caution_type")]
        public int HeatCautionType { get; set; }

        /// <summary>
        /// Heat Info Id
        /// </summary>
        [JsonPropertyName("heat_info_id")]
        public int HeatInfoId { get; set; }

        /// <summary>
        /// Heat Info Name
        /// </summary>
        [JsonPropertyName("heat_info_name")]
        public string HeatInfoName { get; set; } = string.Empty;

        /// <summary>
        /// Heat Laps
        /// </summary>
        [JsonPropertyName("heat_laps")]
        public int HeatLaps { get; set; }

        /// <summary>
        /// Heat Length Minutes
        /// </summary>
        [JsonPropertyName("heat_length_minutes")]
        public int HeatLengthMinutes { get; set; }

        /// <summary>
        /// Heat Max Field Size
        /// </summary>
        [JsonPropertyName("heat_max_field_size")]
        public int HeatMaxFieldSize { get; set; }

        /// <summary>
        /// Heat Num From Each To Main
        /// </summary>
        [JsonPropertyName("heat_num_from_each_to_main")]
        public int HeatNumFromEachToMain { get; set; }

        /// <summary>
        /// Heat Num Position To Invert
        /// </summary>
        [JsonPropertyName("heat_num_position_to_invert")]
        public int HeatNumPositionToInvert { get; set; }

        /// <summary>
        /// Heat Scores Champ Points
        /// </summary>
        [JsonPropertyName("heat_scores_champ_points")]
        public bool HeatScoresChampPoints { get; set; }

        /// <summary>
        /// Heat Session Minutes Estimate
        /// </summary>
        [JsonPropertyName("heat_session_minutes_estimate")]
        public int HeatSessionMinutesEstimate { get; set; }

        /// <summary>
        /// Hidden
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// Main Laps
        /// </summary>
        [JsonPropertyName("main_laps")]
        public int MainLaps { get; set; }

        /// <summary>
        /// Main Length Minutes
        /// </summary>
        [JsonPropertyName("main_length_minutes")]
        public int MainLengthMinutes { get; set; }

        /// <summary>
        /// Main Max Field Size
        /// </summary>
        [JsonPropertyName("main_max_field_size")]
        public int MainMaxFieldSize { get; set; }

        /// <summary>
        /// Main Num Position To Invert
        /// </summary>
        [JsonPropertyName("main_num_position_to_invert")]
        public int MainNumPositionToInvert { get; set; }

        /// <summary>
        /// Max Entrants
        /// </summary>
        [JsonPropertyName("max_entrants")]
        public int MaxEntrants { get; set; }

        /// <summary>
        /// Open Practice
        /// </summary>
        [JsonPropertyName("open_practice")]
        public bool OpenPractice { get; set; }

        /// <summary>
        /// Pre Main Practice Length Minutes
        /// </summary>
        [JsonPropertyName("pre_main_practice_length_minutes")]
        public int PreMainPracticeLengthMinutes { get; set; }

        /// <summary>
        /// Pre Qual Num To Main
        /// </summary>
        [JsonPropertyName("pre_qual_num_to_main")]
        public int PreQualNumToMain { get; set; }

        /// <summary>
        /// Pre Qual Practice Length Minutes
        /// </summary>
        [JsonPropertyName("pre_qual_practice_length_minutes")]
        public int PreQualPracticeLengthMinutes { get; set; }

        /// <summary>
        /// Qual Caution Type
        /// </summary>
        [JsonPropertyName("qual_caution_type")]
        public int QualCautionType { get; set; }

        /// <summary>
        /// Qual Laps
        /// </summary>
        [JsonPropertyName("qual_laps")]
        public int QualLaps { get; set; }

        /// <summary>
        /// Qual Length Minutes
        /// </summary>
        [JsonPropertyName("qual_length_minutes")]
        public int QualLengthMinutes { get; set; }

        /// <summary>
        /// Qual Num To Main
        /// </summary>
        [JsonPropertyName("qual_num_to_main")]
        public int QualNumToMain { get; set; }

        /// <summary>
        /// Qual Open Delay Seconds
        /// </summary>
        [JsonPropertyName("qual_open_delay_seconds")]
        public int QualOpenDelaySeconds { get; set; }

        /// <summary>
        /// Qual Scores Champ Points
        /// </summary>
        [JsonPropertyName("qual_scores_champ_points")]
        public bool QualScoresChampPoints { get; set; }

        /// <summary>
        /// Qual Scoring
        /// </summary>
        [JsonPropertyName("qual_scoring")]
        public int QualScoring { get; set; }

        /// <summary>
        /// Qual Style
        /// </summary>
        [JsonPropertyName("qual_style")]
        public int QualStyle { get; set; }

        /// <summary>
        /// Race Style
        /// </summary>
        [JsonPropertyName("race_style")]
        public int RaceStyle { get; set; }
    }
}

