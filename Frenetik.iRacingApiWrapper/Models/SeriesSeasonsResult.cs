namespace Frenetik.iRacingApiWrapper.Models
{
    public class SeriesSeasonsResult
    {
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; } = string.Empty;

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("allowed_season_members")]
        public Dictionary<string, SeriesSeasonsAllowSeasonMember>? AllowedSeasonMembers { get; set; }

        [JsonPropertyName("car_class_ids")]
        public List<int> CarClassIds { get; set; } = new();

        [JsonPropertyName("car_switching")]
        public bool CarSwitching { get; set; }

        [JsonPropertyName("car_types")]
        public List<SeriesSeasonsCarType> CarTypes { get; set; } = new();

        [JsonPropertyName("caution_laps_do_not_count")]
        public bool CautionLapsDoNotCount { get; set; }

        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        [JsonPropertyName("cross_license")]
        public bool CrossLicense { get; set; }

        [JsonPropertyName("driver_change_rule")]
        public int DriverChangeRule { get; set; }

        [JsonPropertyName("driver_changes")]
        public bool DriverChanges { get; set; }

        [JsonPropertyName("drops")]
        public int Drops { get; set; }

        [JsonPropertyName("enable_pitlane_collisions")]
        public bool EnablePitlaneCollisions { get; set; }

        [JsonPropertyName("fixed_setup")]
        public bool FixedSetup { get; set; }

        [JsonPropertyName("green_white_checkered_limit")]
        public int GreenWhiteCheckeredLimit { get; set; }

        [JsonPropertyName("grid_by_class")]
        public bool GridByClass { get; set; }

        [JsonPropertyName("hardcore_level")]
        public int HardcoreLevel { get; set; }

        [JsonPropertyName("has_supersessions")]
        public bool HasSupersessions { get; set; }

        [JsonPropertyName("ignore_license_for_practice")]
        public bool IgnoreLicenseForPractice { get; set; }

        [JsonPropertyName("incident_limit")]
        public int IncidentLimit { get; set; }

        [JsonPropertyName("incident_warn_mode")]
        public int IncidentWarnMode { get; set; }

        [JsonPropertyName("incident_warn_param1")]
        public int IncidentWarnParam1 { get; set; }

        [JsonPropertyName("incident_warn_param2")]
        public int IncidentWarnParam2 { get; set; }

        [JsonPropertyName("is_heat_racing")]
        public bool IsHeatRacing { get; set; }

        [JsonPropertyName("license_group")]
        public int LicenseGroup { get; set; }

        [JsonPropertyName("license_group_types")]
        public List<SeriesSeasonsLicenseGroupType> LicenseGroupTypes { get; set; } = new();

        [JsonPropertyName("lucky_dog")]
        public bool LuckyDog { get; set; }

        [JsonPropertyName("max_team_drivers")]
        public int MaxTeamDrivers { get; set; }

        [JsonPropertyName("max_weeks")]
        public int MaxWeeks { get; set; }

        [JsonPropertyName("min_team_drivers")]
        public int MinTeamDrivers { get; set; }

        [JsonPropertyName("multiclass")]
        public bool Multiclass { get; set; }

        [JsonPropertyName("must_use_diff_tire_types_in_race")]
        public bool MustUseDifferentTireTypesInRace { get; set; }

        //TODO: Find property type
        [JsonPropertyName("next_race_session")]
        public object? NextRaceSession { get; set; }

        [JsonPropertyName("num_opt_laps")]
        public int NumOptLaps { get; set; }

        [JsonPropertyName("official")]
        public bool Official { get; set; }

        [JsonPropertyName("op_duration")]
        public int OpDuration { get; set; }

        [JsonPropertyName("open_practice_session_type_id")]
        public int OpenPracticeSessionTypeId { get; set; }

        [JsonPropertyName("qualifier_must_start_race")]
        public bool QualifierMustStartRace { get; set; }

        [JsonPropertyName("race_week")]
        public int RaceWeek { get; set; }

        [JsonPropertyName("race_week_to_make_divisions")]
        public int RaceWeekToMakeDivisions { get; set; }

        [JsonPropertyName("reg_open_minutes")]
        public int RegOpenMinutes { get; set; }

        [JsonPropertyName("reg_user_count")]
        public int RegUserCount { get; set; }

        [JsonPropertyName("region_competition")]
        public bool RegionCompetition { get; set; }

        [JsonPropertyName("restrict_by_member")]
        public bool RestrictByMember { get; set; }

        [JsonPropertyName("restrict_to_car")]
        public bool RestrictToCar { get; set; }

        [JsonPropertyName("restrict_viewing")]
        public bool RestrictViewing { get; set; }

        [JsonPropertyName("schedule_description")]
        public string ScheduleDescription { get; set; } = string.Empty;

        [JsonPropertyName("schedules")]
        public List<Schedule> Schedules { get; set; } = new();

        [JsonPropertyName("season_quarter")]
        public int SeasonQuarter { get; set; }

        [JsonPropertyName("season_short_name")]
        public string SeasonShortName { get; set; } = string.Empty;

        [JsonPropertyName("season_year")]
        public int SeasonYear { get; set; }

        [JsonPropertyName("send_to_open_practice")]
        public bool SendToOpenPractice { get; set; }

        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        [JsonPropertyName("short_parade_lap")]
        public bool ShortParadeLap { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = string.Empty;

        [JsonPropertyName("start_on_qual_tire")]
        public bool StartOnQualTire { get; set; }

        [JsonPropertyName("start_zone")]
        public bool StartZone { get; set; }

        [JsonPropertyName("track_types")]
        public List<TrackType> TrackTypes { get; set; } = new();

        [JsonPropertyName("unsport_conduct_rule_mode")]
        public int UnsportConductRuleMode { get; set; }
    }

    public class SeriesSeasonsCarType
    {
        [JsonPropertyName("car_type")]
        public string CarTypeValue { get; set; } = string.Empty;
    }

    public class SeriesSeasonsLicenseGroupType
    {
        [JsonPropertyName("license_group_type")]
        public int LicenseGroupTypeValue { get; set; }
    }

    public class Schedule
    {
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        [JsonPropertyName("race_week_num")]
        public int RaceWeekNum { get; set; }

        [JsonPropertyName("car_restrictions")]
        public List<SeriesSeasonCarRestriction>? CarRestrictions { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("enable_pitlane_collisions")]
        public bool EnablePitlaneCollisions { get; set; }

        [JsonPropertyName("full_course_cautions")]
        public bool FullCourseCautions { get; set; }

        [JsonPropertyName("qual_attached")]
        public bool QualAttached { get; set; }

        [JsonPropertyName("race_lap_limit")]
        public int? RaceLapLimit { get; set; }

        [JsonPropertyName("race_time_descriptors")]
        public List<SeriesSeasonsRaceTimeDescriptor> RaceTimeDescriptors { get; set; } = new();

        [JsonPropertyName("race_time_limit")]
        public int? RaceTimeLimit { get; set; }

        [JsonPropertyName("race_week_cars")]
        public List<SeriesSeasonsRaceWeekCar>? RaceWeekCars { get; set; }

        [JsonPropertyName("restart_type")]
        public string RestartType { get; set; } = string.Empty;

        [JsonPropertyName("schedule_name")]
        public string ScheduleName { get; set; } = string.Empty;

        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; } = string.Empty;

        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        [JsonPropertyName("series_name")]
        public string SeriesName { get; set; } = string.Empty;

        [JsonPropertyName("short_parade_lap")]
        public bool ShortParadeLap { get; set; }

        [JsonPropertyName("simulated_time_multiplier")]
        public int SimulatedTimeMultiplier { get; set; }

        //TODO: Find property type
        [JsonPropertyName("special_event_type")]
        public object? SpecialEventType { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = string.Empty;

        [JsonPropertyName("start_type")]
        public string StartType { get; set; } = string.Empty;

        [JsonPropertyName("start_zone")]
        public bool StartZone { get; set; }

        [JsonPropertyName("track")]
        public SeriesSeasonsTrack Track { get; set; } = new();

        [JsonPropertyName("track_state")]
        public SeriesSeasonsTrackState TrackState { get; set; } = new();

        [JsonPropertyName("weather")]
        public SeriesSeasonsWeather Weather { get; set; } = new();
    }

    public class SeriesSeasonsRaceTimeDescriptor
    {
        [JsonPropertyName("repeating")]
        public bool Repeating { get; set; }

        [JsonPropertyName("session_minutes")]
        public int SessionMinutes { get; set; }

        [JsonPropertyName("session_times")]
        public List<string> SessionTimes { get; set; } = new();

        [JsonPropertyName("super_session")]
        public bool SuperSession { get; set; }
    }

    public class SeriesSeasonsTrack
    {
        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("config_name")]
        public string ConfigName { get; set; } = string.Empty;

        [JsonPropertyName("track_id")]
        public int TrackId { get; set; }

        [JsonPropertyName("track_name")]
        public string TrackName { get; set; } = string.Empty;
    }

    public class SeriesSeasonsTrackState
    {
        [JsonPropertyName("leave_marbles")]
        public bool LeaveMarbles { get; set; }
    }

    public class SeriesSeasonsWeather
    {
        [JsonPropertyName("allow_fog")]
        public bool AllowFog { get; set; }

        [JsonPropertyName("fog")]
        public int Fog { get; set; }

        [JsonPropertyName("forecast_options")]
        public SeriesSeasonsForecastOptions ForecastOptions { get; set; } = new();

        [JsonPropertyName("precip_option")]
        public int PrecipOption { get; set; }

        [JsonPropertyName("rel_humidity")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("simulated_start_time")]
        public string SimulatedStartTime { get; set; } = string.Empty;

        [JsonPropertyName("simulated_start_utc_time")]
        public string SimulatedStartUtcTime { get; set; } = string.Empty;

        [JsonPropertyName("simulated_time_multiplier")]
        public int SimulatedTimeMultiplier { get; set; }

        [JsonPropertyName("simulated_time_offsets")]
        public List<int> SimulatedTimeOffsets { get; set; } = new();

        [JsonPropertyName("skies")]
        public int Skies { get; set; }

        [JsonPropertyName("temp_units")]
        public int TemperatureUnits { get; set; }

        [JsonPropertyName("temp_value")]
        public int TemperatureValue { get; set; }

        [JsonPropertyName("time_of_day")]
        public int TimeOfDay { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("weather_summary")]
        public SeriesSeasonsWeatherSummary WeatherSummary { get; set; } = new();

        [JsonPropertyName("weather_url")]
        public string WeatherUrl { get; set; } = string.Empty;

        [JsonPropertyName("wind_dir")]
        public int WindDirection { get; set; }

        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }

        [JsonPropertyName("wind_value")]
        public int WindValue { get; set; }
    }

    public class SeriesSeasonsForecastOptions
    {
        [JsonPropertyName("forecast_type")]
        public int ForecastType { get; set; }

        [JsonPropertyName("precipitation")]
        public int Precipitation { get; set; }

        [JsonPropertyName("skies")]
        public int Skies { get; set; }

        [JsonPropertyName("stop_precip")]
        public int StopPrecip { get; set; }

        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }

        [JsonPropertyName("weather_seed")]
        public long WeatherSeed { get; set; }

        [JsonPropertyName("wind_dir")]
        public int WindDirection { get; set; }

        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }
    }

    public class SeriesSeasonsWeatherSummary
    {
        [JsonPropertyName("max_precip_rate")]
        public float MaxPrecipitationRate { get; set; }

        [JsonPropertyName("max_precip_rate_desc")]
        public string MaxPrecipitationRateDescription { get; set; } = string.Empty;

        [JsonPropertyName("precip_chance")]
        public float PrecipitationChance { get; set; }

        [JsonPropertyName("skies_high")]
        public int SkiesHigh { get; set; }

        [JsonPropertyName("skies_low")]
        public int SkiesLow { get; set; }

        [JsonPropertyName("temp_high")]
        public float TemperatureHigh { get; set; }

        [JsonPropertyName("temp_low")]
        public float TemperatureLow { get; set; }

        [JsonPropertyName("temp_units")]
        public int TemperatureUnits { get; set; }

        [JsonPropertyName("wind_high")]
        public float WindHigh { get; set; }

        [JsonPropertyName("wind_low")]
        public float WindLow { get; set; }

        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }
    }

    public class SeriesSeasonsAllowSeasonMember
    {
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }
    }

    public class SeriesSeasonCarRestriction
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("max_dry_tire_sets")]
        public int MaxDryTireSets { get; set; }

        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPctFuelFill { get; set; }

        [JsonPropertyName("power_adjust_pct")]
        public float PowerAdjustPct { get; set; }

        [JsonPropertyName("race_setup_id")]
        public int RaceSetupId { get; set; }

        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }
    }

    public class SeriesSeasonsRaceWeekCar
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("car_name")]
        public string CarName { get; set; } = string.Empty;

        [JsonPropertyName("car_name_abbreviated")]
        public string CarNameAbbreviated { get; set; } = string.Empty;
    }
}
