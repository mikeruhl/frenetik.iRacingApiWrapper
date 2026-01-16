namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// SubSessionResults
/// </summary>
public class SubSessionResults
{
    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

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
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

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
    /// Series Logo
    /// </summary>
    [JsonPropertyName("series_logo")]
    public string SeriesLogo { get; set; } = string.Empty;

    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNumber { get; set; }

    /// <summary>
    /// Session Id
    /// </summary>
    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

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
    /// Private Session Id
    /// </summary>
    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

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
    /// Num Laps For Qual Average
    /// </summary>
    [JsonPropertyName("num_laps_for_qual_average")]
    public int NumLapsForQualAverage { get; set; }

    /// <summary>
    /// Num Laps For Solo Average
    /// </summary>
    [JsonPropertyName("num_laps_for_solo_average")]
    public int NumLapsForSoloAverage { get; set; }

    /// <summary>
    /// Corners Per Lap
    /// </summary>
    [JsonPropertyName("corners_per_lap")]
    public int CornersPerLap { get; set; }

    /// <summary>
    /// Caution Type
    /// </summary>
    [JsonPropertyName("caution_type")]
    public int CautionType { get; set; }

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
    /// Driver Changes
    /// </summary>
    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    /// <summary>
    /// Min Team Drivers
    /// </summary>
    [JsonPropertyName("min_team_drivers")]
    public int MinTeamDrivers { get; set; }

    /// <summary>
    /// Max Team Drivers
    /// </summary>
    [JsonPropertyName("max_team_drivers")]
    public int MaxTeamDrivers { get; set; }

    /// <summary>
    /// Driver Change Rule
    /// </summary>
    [JsonPropertyName("driver_change_rule")]
    public int DriverChangeRule { get; set; }

    /// <summary>
    /// Driver Change Param1
    /// </summary>
    [JsonPropertyName("driver_change_param1")]
    public int DriverChangeParam1 { get; set; }

    /// <summary>
    /// Driver Change Param2
    /// </summary>
    [JsonPropertyName("driver_change_param2")]
    public int DriverChangeParam2 { get; set; }

    /// <summary>
    /// Max Weeks
    /// </summary>
    [JsonPropertyName("max_weeks")]
    public int MaxWeeks { get; set; }

    /// <summary>
    /// Points Type
    /// </summary>
    [JsonPropertyName("points_type")]
    public string PointsType { get; set; } = string.Empty;

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
    /// Event Laps Complete
    /// </summary>
    [JsonPropertyName("event_laps_complete")]
    public int EventLapsComplete { get; set; }

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
    /// Official Session
    /// </summary>
    [JsonPropertyName("official_session")]
    public bool OfficialSession { get; set; }

    /// <summary>
    /// Heat Info Id
    /// </summary>
    [JsonPropertyName("heat_info_id")]
    public int HeatInfoId { get; set; }

    /// <summary>
    /// Special Event Type
    /// </summary>
    [JsonPropertyName("special_event_type")]
    public int SpecialEventType { get; set; }

    /// <summary>
    /// Damage Model
    /// </summary>
    [JsonPropertyName("damage_model")]
    public int DamageModel { get; set; }

    /// <summary>
    /// Can Protest
    /// </summary>
    [JsonPropertyName("can_protest")]
    public bool CanProtest { get; set; }

    /// <summary>
    /// Cooldown Minutes
    /// </summary>
    [JsonPropertyName("cooldown_minutes")]
    public int CooldownMinutes { get; set; }

    /// <summary>
    /// Limit Minutes
    /// </summary>
    [JsonPropertyName("limit_minutes")]
    public int LimitMinutes { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public TrackResult Track { get; set; } = new TrackResult();

    /// <summary>
    /// Weather
    /// </summary>
    [JsonPropertyName("weather")]
    public WeatherResult Weather { get; set; } = new WeatherResult();

    /// <summary>
    /// Track State
    /// </summary>
    [JsonPropertyName("track_state")]
    public TrackStateResult TrackState { get; set; } = new TrackStateResult();

    /// <summary>
    /// Session Results
    /// </summary>
    [JsonPropertyName("session_results")]
    public List<SessionResult> SessionResults { get; set; } = new List<SessionResult>();

    /// <summary>
    /// Race Summary
    /// </summary>
    [JsonPropertyName("race_summary")]
    public RaceSummaryResult RaceSummary { get; set; } = new RaceSummaryResult();

    /// <summary>
    /// Car Classes
    /// </summary>
    [JsonPropertyName("car_classes")]
    public List<CarClass> CarClasses { get; set; } = new List<CarClass>();

    /// <summary>
    /// Allowed Licenses
    /// </summary>
    [JsonPropertyName("allowed_licenses")]
    public List<AllowedLicense> AllowedLicenses { get; set; } = new List<AllowedLicense>();

    /// <summary>
    /// Results Restricted
    /// </summary>
    [JsonPropertyName("results_restricted")]
    public bool ResultsRestricted { get; set; }

    /// <summary>
    /// Associated Subsession Ids
    /// </summary>
    [JsonPropertyName("associated_subsession_ids")]
    public List<int> AssociatedSubsessionIds { get; set; } = new List<int>();

    /// <summary>
    /// TrackResult
    /// </summary>
    public class TrackResult
    {
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

        /// <summary>
        /// Config Name
        /// </summary>
        [JsonPropertyName("config_name")]
        public string ConfigName { get; set; } = string.Empty;

        /// <summary>
        /// Category Id
        /// </summary>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;
    }

    /// <summary>
    /// WeatherResult
    /// </summary>
    public class WeatherResult
    {
        /// <summary>
        /// Version
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }

        /// <summary>
        /// Temp Units
        /// </summary>
        [JsonPropertyName("temp_units")]
        public int TempUnits { get; set; }

        /// <summary>
        /// Temp Value
        /// </summary>
        [JsonPropertyName("temp_value")]
        public int TempValue { get; set; }

        /// <summary>
        /// Rel Humidity
        /// </summary>
        [JsonPropertyName("rel_humidity")]
        public int RelativeHumidity { get; set; }

        /// <summary>
        /// Fog
        /// </summary>
        [JsonPropertyName("fog")]
        public int Fog { get; set; }

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

        /// <summary>
        /// Skies
        /// </summary>
        [JsonPropertyName("skies")]
        public int Skies { get; set; }

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
        /// Allow Fog
        /// </summary>
        [JsonPropertyName("allow_fog")]
        public bool AllowFog { get; set; }

        /// <summary>
        /// Track Water
        /// </summary>
        [JsonPropertyName("track_water")]
        public int TrackWater { get; set; }

        /// <summary>
        /// Precip Option
        /// </summary>
        [JsonPropertyName("precip_option")]
        public int PrecipOption { get; set; }

        /// <summary>
        /// Time Of Day
        /// </summary>
        [JsonPropertyName("time_of_day")]
        public int TimeOfDay { get; set; }

        /// <summary>
        /// Simulated Start Utc Time
        /// </summary>
        [JsonPropertyName("simulated_start_utc_time")]
        public DateTime SimulatedStartUtcTime { get; set; }

        /// <summary>
        /// Simulated Start Utc Offset
        /// </summary>
        [JsonPropertyName("simulated_start_utc_offset")]
        public int SimulatedStartUtcOffset { get; set; }
    }

    /// <summary>
    /// TrackStateResult
    /// </summary>
    public class TrackStateResult
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

        /// <summary>
        /// Qualify Rubber
        /// </summary>
        [JsonPropertyName("qualify_rubber")]
        public int QualifyRubber { get; set; }

        /// <summary>
        /// Warmup Rubber
        /// </summary>
        [JsonPropertyName("warmup_rubber")]
        public int WarmupRubber { get; set; }

        /// <summary>
        /// Race Rubber
        /// </summary>
        [JsonPropertyName("race_rubber")]
        public int RaceRubber { get; set; }

        /// <summary>
        /// Practice Grip Compound
        /// </summary>
        [JsonPropertyName("practice_grip_compound")]
        public int PracticeGripCompound { get; set; }

        /// <summary>
        /// Qualify Grip Compound
        /// </summary>
        [JsonPropertyName("qualify_grip_compound")]
        public int QualifyGripCompound { get; set; }

        /// <summary>
        /// Warmup Grip Compound
        /// </summary>
        [JsonPropertyName("warmup_grip_compound")]
        public int WarmupGripCompound { get; set; }

        /// <summary>
        /// Race Grip Compound
        /// </summary>
        [JsonPropertyName("race_grip_compound")]
        public int RaceGripCompound { get; set; }
    }

    /// <summary>
    /// RaceSummaryResult
    /// </summary>
    public class RaceSummaryResult
    {
        /// <summary>
        /// Subsession Id
        /// </summary>
        [JsonPropertyName("subsession_id")]
        public int SubsessionId { get; set; }

        /// <summary>
        /// Average Lap
        /// </summary>
        [JsonPropertyName("average_lap")]
        public int AverageLap { get; set; }

        /// <summary>
        /// Laps Complete
        /// </summary>
        [JsonPropertyName("laps_complete")]
        public int LapsComplete { get; set; }

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
        /// Field Strength
        /// </summary>
        [JsonPropertyName("field_strength")]
        public int FieldStrength { get; set; }

        /// <summary>
        /// Num Opt Laps
        /// </summary>
        [JsonPropertyName("num_opt_laps")]
        public int NumOptLaps { get; set; }

        /// <summary>
        /// Has Opt Path
        /// </summary>
        [JsonPropertyName("has_opt_path")]
        public bool HasOptPath { get; set; }

        /// <summary>
        /// Special Event Type
        /// </summary>
        [JsonPropertyName("special_event_type")]
        public int SpecialEventType { get; set; }

        /// <summary>
        /// Special Event Type Text
        /// </summary>
        [JsonPropertyName("special_event_type_text")]
        public string SpecialEventTypeText { get; set; } = string.Empty;
    }
    /// <summary>
    /// SessionResult
    /// </summary>
    public class SessionResult
    {
        /// <summary>
        /// Simsession Number
        /// </summary>
        [JsonPropertyName("simsession_number")]
        public int SimSessionNumber { get; set; }

        /// <summary>
        /// Simsession Type
        /// </summary>
        [JsonPropertyName("simsession_type")]
        public int SimSessionType { get; set; }

        /// <summary>
        /// Simsession Type Name
        /// </summary>
        [JsonPropertyName("simsession_type_name")]
        public string SimSessionTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Simsession Subtype
        /// </summary>
        [JsonPropertyName("simsession_subtype")]
        public int SimSessionSubType { get; set; }

        /// <summary>
        /// Simsession Name
        /// </summary>
        [JsonPropertyName("simsession_name")]
        public string SimSessionName { get; set; } = string.Empty;

        /// <summary>
        /// Weather Result
        /// </summary>
        [JsonPropertyName("weather_result")]
        public SessionResultWeatherResult WeatherResult { get; set; } = new();

        /// <summary>
        /// Results
        /// </summary>
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; } = new List<Result>();
    }

    /// <summary>
    /// Result
    /// </summary>
    public class Result
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
        /// Finish Position
        /// </summary>
        [JsonPropertyName("finish_position")]
        public int FinishPosition { get; set; }

        /// <summary>
        /// Finish Position In Class
        /// </summary>
        [JsonPropertyName("finish_position_in_class")]
        public int FinishPositionInClass { get; set; }

        /// <summary>
        /// Laps Lead
        /// </summary>
        [JsonPropertyName("laps_lead")]
        public int LapsLead { get; set; }

        /// <summary>
        /// Laps Complete
        /// </summary>
        [JsonPropertyName("laps_complete")]
        public int LapsComplete { get; set; }

        /// <summary>
        /// Opt Laps Complete
        /// </summary>
        [JsonPropertyName("opt_laps_complete")]
        public int OptLapsComplete { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        /// <summary>
        /// Class Interval
        /// </summary>
        [JsonPropertyName("class_interval")]
        public int ClassInterval { get; set; }

        /// <summary>
        /// Average Lap
        /// </summary>
        [JsonPropertyName("average_lap")]
        public int AverageLap { get; set; }

        /// <summary>
        /// Best Lap Num
        /// </summary>
        [JsonPropertyName("best_lap_num")]
        public int BestLapNumber { get; set; }

        /// <summary>
        /// Best Lap Time
        /// </summary>
        [JsonPropertyName("best_lap_time")]
        public int BestLapTime { get; set; }

        /// <summary>
        /// Best Nlaps Num
        /// </summary>
        [JsonPropertyName("best_nlaps_num")]
        public int BestNLapsNumber { get; set; }

        /// <summary>
        /// Best Nlaps Time
        /// </summary>
        [JsonPropertyName("best_nlaps_time")]
        public int BestNLapsTime { get; set; }

        /// <summary>
        /// Best Qual Lap At
        /// </summary>
        [JsonPropertyName("best_qual_lap_at")]
        public DateTime BestQualifyingLapAt { get; set; }

        /// <summary>
        /// Best Qual Lap Num
        /// </summary>
        [JsonPropertyName("best_qual_lap_num")]
        public int BestQualifyingLapNumber { get; set; }

        /// <summary>
        /// Best Qual Lap Time
        /// </summary>
        [JsonPropertyName("best_qual_lap_time")]
        public int BestQualifyingLapTime { get; set; }

        /// <summary>
        /// Reason Out Id
        /// </summary>
        [JsonPropertyName("reason_out_id")]
        public int ReasonOutId { get; set; }

        /// <summary>
        /// Reason Out
        /// </summary>
        [JsonPropertyName("reason_out")]
        public string ReasonOut { get; set; } = string.Empty;

        /// <summary>
        /// Champ Points
        /// </summary>
        [JsonPropertyName("champ_points")]
        public int ChampionshipPoints { get; set; }

        /// <summary>
        /// Drop Race
        /// </summary>
        [JsonPropertyName("drop_race")]
        public bool DropRace { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// Qual Lap Time
        /// </summary>
        [JsonPropertyName("qual_lap_time")]
        public int QualifyingLapTime { get; set; }

        /// <summary>
        /// Starting Position
        /// </summary>
        [JsonPropertyName("starting_position")]
        public int StartingPosition { get; set; }

        /// <summary>
        /// Starting Position In Class
        /// </summary>
        [JsonPropertyName("starting_position_in_class")]
        public int StartingPositionInClass { get; set; }

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
        /// Flair Id
        /// </summary>
        [JsonPropertyName("flair_id")]
        public int FlairId { get; set; }

        /// <summary>
        /// Flair Name
        /// </summary>
        [JsonPropertyName("flair_name")]
        public string FlairName { get; set; } = string.Empty;

        /// <summary>
        /// Flair Shortname
        /// </summary>
        [JsonPropertyName("flair_shortname")]
        public string FlairShortName { get; set; } = string.Empty;

        /// <summary>
        /// Division
        /// </summary>
        [JsonPropertyName("division")]
        public int Division { get; set; }

        /// <summary>
        /// Division Name
        /// </summary>
        [JsonPropertyName("division_name")]
        public string DivisionName { get; set; } = string.Empty;

        /// <summary>
        /// Old License Level
        /// </summary>
        [JsonPropertyName("old_license_level")]
        public int OldLicenseLevel { get; set; }

        /// <summary>
        /// Old Sub Level
        /// </summary>
        [JsonPropertyName("old_sub_level")]
        public int OldSubLevel { get; set; }

        /// <summary>
        /// Old Cpi
        /// </summary>
        [JsonPropertyName("old_cpi")]
        public double OldCpi { get; set; }

        /// <summary>
        /// Oldi Rating
        /// </summary>
        [JsonPropertyName("oldi_rating")]
        public int OldIRating { get; set; }

        /// <summary>
        /// Old Ttrating
        /// </summary>
        [JsonPropertyName("old_ttrating")]
        public int OldTTRating { get; set; }

        /// <summary>
        /// New License Level
        /// </summary>
        [JsonPropertyName("new_license_level")]
        public int NewLicenseLevel { get; set; }

        /// <summary>
        /// New Sub Level
        /// </summary>
        [JsonPropertyName("new_sub_level")]
        public int NewSubLevel { get; set; }

        /// <summary>
        /// New Cpi
        /// </summary>
        [JsonPropertyName("new_cpi")]
        public double NewCpi { get; set; }

        /// <summary>
        /// Newi Rating
        /// </summary>
        [JsonPropertyName("newi_rating")]
        public int NewIRating { get; set; }

        /// <summary>
        /// New Ttrating
        /// </summary>
        [JsonPropertyName("new_ttrating")]
        public int NewTTRating { get; set; }

        /// <summary>
        /// Multiplier
        /// </summary>
        [JsonPropertyName("multiplier")]
        public int Multiplier { get; set; }

        /// <summary>
        /// License Change Oval
        /// </summary>
        [JsonPropertyName("license_change_oval")]
        public int LicenseChangeOval { get; set; }

        /// <summary>
        /// License Change Road
        /// </summary>
        [JsonPropertyName("license_change_road")]
        public int LicenseChangeRoad { get; set; }

        /// <summary>
        /// Incidents
        /// </summary>
        [JsonPropertyName("incidents")]
        public int Incidents { get; set; }

        /// <summary>
        /// Max Pct Fuel Fill
        /// </summary>
        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPercentFuelFill { get; set; }

        /// <summary>
        /// Weight Penalty Kg
        /// </summary>
        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }

        /// <summary>
        /// League Points
        /// </summary>
        [JsonPropertyName("league_points")]
        public int LeaguePoints { get; set; }

        /// <summary>
        /// League Agg Points
        /// </summary>
        [JsonPropertyName("league_agg_points")]
        public int LeagueAggregatePoints { get; set; }

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
        /// Aggregate Champ Points
        /// </summary>
        [JsonPropertyName("aggregate_champ_points")]
        public int AggregateChampionshipPoints { get; set; }

        /// <summary>
        /// Livery
        /// </summary>
        [JsonPropertyName("livery")]
        public Livery Livery { get; set; } = new Livery();

        /// <summary>
        /// Suit
        /// </summary>
        [JsonPropertyName("suit")]
        public Suit Suit { get; set; } = new Suit();

        /// <summary>
        /// Helmet
        /// </summary>
        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();

        /// <summary>
        /// Watched
        /// </summary>
        [JsonPropertyName("watched")]
        public bool Watched { get; set; }

        /// <summary>
        /// Friend
        /// </summary>
        [JsonPropertyName("friend")]
        public bool Friend { get; set; }

        /// <summary>
        /// Ai
        /// </summary>
        [JsonPropertyName("ai")]
        public bool AI { get; set; }
    }
    /// <summary>
    /// Livery
    /// </summary>
    public class Livery
    {
        /// <summary>
        /// Car Id
        /// </summary>
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        /// <summary>
        /// Pattern
        /// </summary>
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        /// <summary>
        /// Color1
        /// </summary>
        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        /// <summary>
        /// Color2
        /// </summary>
        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        /// <summary>
        /// Color3
        /// </summary>
        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        /// <summary>
        /// Number Font
        /// </summary>
        [JsonPropertyName("number_font")]
        public int NumberFont { get; set; }

        /// <summary>
        /// Number Color1
        /// </summary>
        [JsonPropertyName("number_color1")]
        public string NumberColor1 { get; set; } = string.Empty;

        /// <summary>
        /// Number Color2
        /// </summary>
        [JsonPropertyName("number_color2")]
        public string NumberColor2 { get; set; } = string.Empty;

        /// <summary>
        /// Number Color3
        /// </summary>
        [JsonPropertyName("number_color3")]
        public string NumberColor3 { get; set; } = string.Empty;

        /// <summary>
        /// Number Slant
        /// </summary>
        [JsonPropertyName("number_slant")]
        public int NumberSlant { get; set; }

        /// <summary>
        /// Sponsor1
        /// </summary>
        [JsonPropertyName("sponsor1")]
        public int Sponsor1 { get; set; }

        /// <summary>
        /// Sponsor2
        /// </summary>
        [JsonPropertyName("sponsor2")]
        public int Sponsor2 { get; set; }

        /// <summary>
        /// Car Number
        /// </summary>
        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        /// <summary>
        /// Wheel Color
        /// </summary>
        [JsonPropertyName("wheel_color")]
        public string? WheelColor { get; set; }

        /// <summary>
        /// Rim Type
        /// </summary>
        [JsonPropertyName("rim_type")]
        public int RimType { get; set; }
    }
    /// <summary>
    /// Suit
    /// </summary>
    public class Suit
    {
        /// <summary>
        /// Pattern
        /// </summary>
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        /// <summary>
        /// Color1
        /// </summary>
        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        /// <summary>
        /// Color2
        /// </summary>
        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        /// <summary>
        /// Color3
        /// </summary>
        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;
    }

    /// <summary>
    /// Helmet
    /// </summary>
    public class Helmet
    {
        /// <summary>
        /// Pattern
        /// </summary>
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        /// <summary>
        /// Color1
        /// </summary>
        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        /// <summary>
        /// Color2
        /// </summary>
        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        /// <summary>
        /// Color3
        /// </summary>
        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        /// <summary>
        /// Face Type
        /// </summary>
        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        /// <summary>
        /// Helmet Type
        /// </summary>
        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }

    /// <summary>
    /// SessionResultCarClass
    /// </summary>
    public class SessionResultCarClass
    {
        /// <summary>
        /// Car Class Id
        /// </summary>
        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        /// <summary>
        /// Cars In Class
        /// </summary>
        [JsonPropertyName("cars_in_class")]
        public List<CarInClass> CarsInClass { get; set; } = new List<CarInClass>();

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Relative Speed
        /// </summary>
        [JsonPropertyName("relative_speed")]
        public int RelativeSpeed { get; set; }

        /// <summary>
        /// Short Name
        /// </summary>
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; } = string.Empty;
    }

    /// <summary>
    /// CarInClass
    /// </summary>
    public class CarInClass
    {
        /// <summary>
        /// Car Id
        /// </summary>
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        /// <summary>
        /// Package Id
        /// </summary>
        [JsonPropertyName("package_id")]
        public int PackageId { get; set; }
    }

    /// <summary>
    /// AllowedLicense
    /// </summary>
    public class AllowedLicense
    {
        /// <summary>
        /// Parent Id
        /// </summary>
        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// License Group
        /// </summary>
        [JsonPropertyName("license_group")]
        public int LicenseGroup { get; set; }

        /// <summary>
        /// Min License Level
        /// </summary>
        [JsonPropertyName("min_license_level")]
        public int MinLicenseLevel { get; set; }

        /// <summary>
        /// Max License Level
        /// </summary>
        [JsonPropertyName("max_license_level")]
        public int MaxLicenseLevel { get; set; }

        /// <summary>
        /// Group Name
        /// </summary>
        [JsonPropertyName("group_name")]
        public string GroupName { get; set; } = string.Empty;
    }

    /// <summary>
    /// SessionResultWeatherResult
    /// </summary>
    public class SessionResultWeatherResult
    {
        /// <summary>
        /// Avg Skies
        /// </summary>
        [JsonPropertyName("avg_skies")]
        public int AverageSkies { get; set; }

        /// <summary>
        /// Avg Cloud Cover Pct
        /// </summary>
        [JsonPropertyName("avg_cloud_cover_pct")]
        public double AverageCloudCoverPercentage { get; set; }

        /// <summary>
        /// Min Cloud Cover Pct
        /// </summary>
        [JsonPropertyName("min_cloud_cover_pct")]
        public double MinimumCloudCoverPercentage { get; set; }

        /// <summary>
        /// Max Cloud Cover Pct
        /// </summary>
        [JsonPropertyName("max_cloud_cover_pct")]
        public double MaximumCloudCoverPercentage { get; set; }

        /// <summary>
        /// Temp Units
        /// </summary>
        [JsonPropertyName("temp_units")]
        public int TemperatureUnits { get; set; }

        /// <summary>
        /// Avg Temp
        /// </summary>
        [JsonPropertyName("avg_temp")]
        public double AverageTemperature { get; set; }

        /// <summary>
        /// Min Temp
        /// </summary>
        [JsonPropertyName("min_temp")]
        public double MinimumTemperature { get; set; }

        /// <summary>
        /// Max Temp
        /// </summary>
        [JsonPropertyName("max_temp")]
        public double MaximumTemperature { get; set; }

        /// <summary>
        /// Avg Rel Humidity
        /// </summary>
        [JsonPropertyName("avg_rel_humidity")]
        public double AverageRelativeHumidity { get; set; }

        /// <summary>
        /// Wind Units
        /// </summary>
        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }

        /// <summary>
        /// Avg Wind Speed
        /// </summary>
        [JsonPropertyName("avg_wind_speed")]
        public double AverageWindSpeed { get; set; }

        /// <summary>
        /// Min Wind Speed
        /// </summary>
        [JsonPropertyName("min_wind_speed")]
        public double MinimumWindSpeed { get; set; }

        /// <summary>
        /// Max Wind Speed
        /// </summary>
        [JsonPropertyName("max_wind_speed")]
        public double MaximumWindSpeed { get; set; }

        /// <summary>
        /// Avg Wind Dir
        /// </summary>
        [JsonPropertyName("avg_wind_dir")]
        public int AverageWindDirection { get; set; }

        /// <summary>
        /// Max Fog
        /// </summary>
        [JsonPropertyName("max_fog")]
        public double MaximumFog { get; set; }

        /// <summary>
        /// Fog Time Pct
        /// </summary>
        [JsonPropertyName("fog_time_pct")]
        public double FogTimePercentage { get; set; }

        /// <summary>
        /// Precip Time Pct
        /// </summary>
        [JsonPropertyName("precip_time_pct")]
        public double PrecipitationTimePercentage { get; set; }

        /// <summary>
        /// Precip Mm
        /// </summary>
        [JsonPropertyName("precip_mm")]
        public int PrecipitationMillimeters { get; set; }

        /// <summary>
        /// Precip Mm2hr Before Session
        /// </summary>
        [JsonPropertyName("precip_mm2hr_before_session")]
        public int PrecipitationMillimetersPerHourBeforeSession { get; set; }

        /// <summary>
        /// Simulated Start Time
        /// </summary>
        [JsonPropertyName("simulated_start_time")]
        public DateTime SimulatedStartTime { get; set; }
    }

}
