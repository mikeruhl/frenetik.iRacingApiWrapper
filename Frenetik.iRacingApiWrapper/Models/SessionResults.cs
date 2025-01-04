namespace Frenetik.iRacingApiWrapper.Models;

public class SubSessionResults
{
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;

    [JsonPropertyName("series_logo")]
    public string SeriesLogo { get; set; } = string.Empty;

    [JsonPropertyName("race_week_num")]
    public int RaceWeekNumber { get; set; }

    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("license_category_id")]
    public int LicenseCategoryId { get; set; }

    [JsonPropertyName("license_category")]
    public string LicenseCategory { get; set; } = string.Empty;

    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("num_laps_for_qual_average")]
    public int NumLapsForQualAverage { get; set; }

    [JsonPropertyName("num_laps_for_solo_average")]
    public int NumLapsForSoloAverage { get; set; }

    [JsonPropertyName("corners_per_lap")]
    public int CornersPerLap { get; set; }

    [JsonPropertyName("caution_type")]
    public int CautionType { get; set; }

    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    [JsonPropertyName("event_type_name")]
    public string EventTypeName { get; set; } = string.Empty;

    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    [JsonPropertyName("min_team_drivers")]
    public int MinTeamDrivers { get; set; }

    [JsonPropertyName("max_team_drivers")]
    public int MaxTeamDrivers { get; set; }

    [JsonPropertyName("driver_change_rule")]
    public int DriverChangeRule { get; set; }

    [JsonPropertyName("driver_change_param1")]
    public int DriverChangeParam1 { get; set; }

    [JsonPropertyName("driver_change_param2")]
    public int DriverChangeParam2 { get; set; }

    [JsonPropertyName("max_weeks")]
    public int MaxWeeks { get; set; }

    [JsonPropertyName("points_type")]
    public string PointsType { get; set; } = string.Empty;

    [JsonPropertyName("event_strength_of_field")]
    public int EventStrengthOfField { get; set; }

    [JsonPropertyName("event_average_lap")]
    public int EventAverageLap { get; set; }

    [JsonPropertyName("event_laps_complete")]
    public int EventLapsComplete { get; set; }

    [JsonPropertyName("num_cautions")]
    public int NumCautions { get; set; }

    [JsonPropertyName("num_caution_laps")]
    public int NumCautionLaps { get; set; }

    [JsonPropertyName("num_lead_changes")]
    public int NumLeadChanges { get; set; }

    [JsonPropertyName("official_session")]
    public bool OfficialSession { get; set; }

    [JsonPropertyName("heat_info_id")]
    public int HeatInfoId { get; set; }

    [JsonPropertyName("special_event_type")]
    public int SpecialEventType { get; set; }

    [JsonPropertyName("damage_model")]
    public int DamageModel { get; set; }

    [JsonPropertyName("can_protest")]
    public bool CanProtest { get; set; }

    [JsonPropertyName("cooldown_minutes")]
    public int CooldownMinutes { get; set; }

    [JsonPropertyName("limit_minutes")]
    public int LimitMinutes { get; set; }

    [JsonPropertyName("track")]
    public TrackResult Track { get; set; } = new TrackResult();

    [JsonPropertyName("weather")]
    public WeatherResult Weather { get; set; } = new WeatherResult();

    [JsonPropertyName("track_state")]
    public TrackStateResult TrackState { get; set; } = new TrackStateResult();

    [JsonPropertyName("session_results")]
    public List<SessionResult> SessionResults { get; set; } = new List<SessionResult>();

    [JsonPropertyName("race_summary")]
    public RaceSummaryResult RaceSummary { get; set; } = new RaceSummaryResult();

    [JsonPropertyName("car_classes")]
    public List<CarClass> CarClasses { get; set; } = new List<CarClass>();

    [JsonPropertyName("allowed_licenses")]
    public List<AllowedLicense> AllowedLicenses { get; set; } = new List<AllowedLicense>();

    [JsonPropertyName("results_restricted")]
    public bool ResultsRestricted { get; set; }

    [JsonPropertyName("associated_subsession_ids")]
    public List<int> AssociatedSubsessionIds { get; set; } = new List<int>();

    public class TrackResult
    {
        [JsonPropertyName("track_id")]
        public int TrackId { get; set; }

        [JsonPropertyName("track_name")]
        public string TrackName { get; set; } = string.Empty;

        [JsonPropertyName("config_name")]
        public string ConfigName { get; set; } = string.Empty;

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;
    }

    public class WeatherResult
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("temp_units")]
        public int TempUnits { get; set; }

        [JsonPropertyName("temp_value")]
        public int TempValue { get; set; }

        [JsonPropertyName("rel_humidity")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("fog")]
        public int Fog { get; set; }

        [JsonPropertyName("wind_dir")]
        public int WindDirection { get; set; }

        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }

        [JsonPropertyName("wind_value")]
        public int WindValue { get; set; }

        [JsonPropertyName("skies")]
        public int Skies { get; set; }

        [JsonPropertyName("weather_var_initial")]
        public int WeatherVarInitial { get; set; }

        [JsonPropertyName("weather_var_ongoing")]
        public int WeatherVarOngoing { get; set; }

        [JsonPropertyName("allow_fog")]
        public bool AllowFog { get; set; }

        [JsonPropertyName("track_water")]
        public int TrackWater { get; set; }

        [JsonPropertyName("precip_option")]
        public int PrecipOption { get; set; }

        [JsonPropertyName("time_of_day")]
        public int TimeOfDay { get; set; }

        [JsonPropertyName("simulated_start_utc_time")]
        public DateTime SimulatedStartUtcTime { get; set; }

        [JsonPropertyName("simulated_start_utc_offset")]
        public int SimulatedStartUtcOffset { get; set; }
    }

    public class TrackStateResult
    {
        [JsonPropertyName("leave_marbles")]
        public bool LeaveMarbles { get; set; }

        [JsonPropertyName("practice_rubber")]
        public int PracticeRubber { get; set; }

        [JsonPropertyName("qualify_rubber")]
        public int QualifyRubber { get; set; }

        [JsonPropertyName("warmup_rubber")]
        public int WarmupRubber { get; set; }

        [JsonPropertyName("race_rubber")]
        public int RaceRubber { get; set; }

        [JsonPropertyName("practice_grip_compound")]
        public int PracticeGripCompound { get; set; }

        [JsonPropertyName("qualify_grip_compound")]
        public int QualifyGripCompound { get; set; }

        [JsonPropertyName("warmup_grip_compound")]
        public int WarmupGripCompound { get; set; }

        [JsonPropertyName("race_grip_compound")]
        public int RaceGripCompound { get; set; }
    }

    public class RaceSummaryResult
    {
        [JsonPropertyName("subsession_id")]
        public int SubsessionId { get; set; }

        [JsonPropertyName("average_lap")]
        public int AverageLap { get; set; }

        [JsonPropertyName("laps_complete")]
        public int LapsComplete { get; set; }

        [JsonPropertyName("num_cautions")]
        public int NumCautions { get; set; }

        [JsonPropertyName("num_caution_laps")]
        public int NumCautionLaps { get; set; }

        [JsonPropertyName("num_lead_changes")]
        public int NumLeadChanges { get; set; }

        [JsonPropertyName("field_strength")]
        public int FieldStrength { get; set; }

        [JsonPropertyName("num_opt_laps")]
        public int NumOptLaps { get; set; }

        [JsonPropertyName("has_opt_path")]
        public bool HasOptPath { get; set; }

        [JsonPropertyName("special_event_type")]
        public int SpecialEventType { get; set; }

        [JsonPropertyName("special_event_type_text")]
        public string SpecialEventTypeText { get; set; } = string.Empty;
    }
    public class SessionResult
    {
        [JsonPropertyName("simsession_number")]
        public int SimSessionNumber { get; set; }

        [JsonPropertyName("simsession_type")]
        public int SimSessionType { get; set; }

        [JsonPropertyName("simsession_type_name")]
        public string SimSessionTypeName { get; set; } = string.Empty;

        [JsonPropertyName("simsession_subtype")]
        public int SimSessionSubType { get; set; }

        [JsonPropertyName("simsession_name")]
        public string SimSessionName { get; set; } = string.Empty;

        [JsonPropertyName("weather_result")]
        public SessionResultWeatherResult WeatherResult { get; set; } = new();

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; } = new List<Result>();
    }

    public class Result
    {
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("finish_position")]
        public int FinishPosition { get; set; }

        [JsonPropertyName("finish_position_in_class")]
        public int FinishPositionInClass { get; set; }

        [JsonPropertyName("laps_lead")]
        public int LapsLead { get; set; }

        [JsonPropertyName("laps_complete")]
        public int LapsComplete { get; set; }

        [JsonPropertyName("opt_laps_complete")]
        public int OptLapsComplete { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [JsonPropertyName("class_interval")]
        public int ClassInterval { get; set; }

        [JsonPropertyName("average_lap")]
        public int AverageLap { get; set; }

        [JsonPropertyName("best_lap_num")]
        public int BestLapNumber { get; set; }

        [JsonPropertyName("best_lap_time")]
        public int BestLapTime { get; set; }

        [JsonPropertyName("best_nlaps_num")]
        public int BestNLapsNumber { get; set; }

        [JsonPropertyName("best_nlaps_time")]
        public int BestNLapsTime { get; set; }

        [JsonPropertyName("best_qual_lap_at")]
        public DateTime BestQualifyingLapAt { get; set; }

        [JsonPropertyName("best_qual_lap_num")]
        public int BestQualifyingLapNumber { get; set; }

        [JsonPropertyName("best_qual_lap_time")]
        public int BestQualifyingLapTime { get; set; }

        [JsonPropertyName("reason_out_id")]
        public int ReasonOutId { get; set; }

        [JsonPropertyName("reason_out")]
        public string ReasonOut { get; set; } = string.Empty;

        [JsonPropertyName("champ_points")]
        public int ChampionshipPoints { get; set; }

        [JsonPropertyName("drop_race")]
        public bool DropRace { get; set; }

        [JsonPropertyName("club_points")]
        public int ClubPoints { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("qual_lap_time")]
        public int QualifyingLapTime { get; set; }

        [JsonPropertyName("starting_position")]
        public int StartingPosition { get; set; }

        [JsonPropertyName("starting_position_in_class")]
        public int StartingPositionInClass { get; set; }

        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        [JsonPropertyName("car_class_name")]
        public string CarClassName { get; set; } = string.Empty;

        [JsonPropertyName("car_class_short_name")]
        public string CarClassShortName { get; set; } = string.Empty;

        [JsonPropertyName("club_id")]
        public int ClubId { get; set; }

        [JsonPropertyName("club_name")]
        public string ClubName { get; set; } = string.Empty;

        [JsonPropertyName("club_shortname")]
        public string ClubShortName { get; set; } = string.Empty;

        [JsonPropertyName("division")]
        public int Division { get; set; }

        [JsonPropertyName("division_name")]
        public string DivisionName { get; set; } = string.Empty;

        [JsonPropertyName("old_license_level")]
        public int OldLicenseLevel { get; set; }

        [JsonPropertyName("old_sub_level")]
        public int OldSubLevel { get; set; }

        [JsonPropertyName("old_cpi")]
        public double OldCpi { get; set; }

        [JsonPropertyName("oldi_rating")]
        public int OldIRating { get; set; }

        [JsonPropertyName("old_ttrating")]
        public int OldTTRating { get; set; }

        [JsonPropertyName("new_license_level")]
        public int NewLicenseLevel { get; set; }

        [JsonPropertyName("new_sub_level")]
        public int NewSubLevel { get; set; }

        [JsonPropertyName("new_cpi")]
        public double NewCpi { get; set; }

        [JsonPropertyName("newi_rating")]
        public int NewIRating { get; set; }

        [JsonPropertyName("new_ttrating")]
        public int NewTTRating { get; set; }

        [JsonPropertyName("multiplier")]
        public int Multiplier { get; set; }

        [JsonPropertyName("license_change_oval")]
        public int LicenseChangeOval { get; set; }

        [JsonPropertyName("license_change_road")]
        public int LicenseChangeRoad { get; set; }

        [JsonPropertyName("incidents")]
        public int Incidents { get; set; }

        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPercentFuelFill { get; set; }

        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }

        [JsonPropertyName("league_points")]
        public int LeaguePoints { get; set; }

        [JsonPropertyName("league_agg_points")]
        public int LeagueAggregatePoints { get; set; }

        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("car_name")]
        public string CarName { get; set; } = string.Empty;

        [JsonPropertyName("aggregate_champ_points")]
        public int AggregateChampionshipPoints { get; set; }

        [JsonPropertyName("livery")]
        public Livery Livery { get; set; } = new Livery();

        [JsonPropertyName("suit")]
        public Suit Suit { get; set; } = new Suit();

        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();

        [JsonPropertyName("watched")]
        public bool Watched { get; set; }

        [JsonPropertyName("friend")]
        public bool Friend { get; set; }

        [JsonPropertyName("ai")]
        public bool AI { get; set; }
    }
    public class Livery
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        [JsonPropertyName("number_font")]
        public int NumberFont { get; set; }

        [JsonPropertyName("number_color1")]
        public string NumberColor1 { get; set; } = string.Empty;

        [JsonPropertyName("number_color2")]
        public string NumberColor2 { get; set; } = string.Empty;

        [JsonPropertyName("number_color3")]
        public string NumberColor3 { get; set; } = string.Empty;

        [JsonPropertyName("number_slant")]
        public int NumberSlant { get; set; }

        [JsonPropertyName("sponsor1")]
        public int Sponsor1 { get; set; }

        [JsonPropertyName("sponsor2")]
        public int Sponsor2 { get; set; }

        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        [JsonPropertyName("wheel_color")]
        public string? WheelColor { get; set; }

        [JsonPropertyName("rim_type")]
        public int RimType { get; set; }
    }
    public class Suit
    {
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;
    }

    public class Helmet
    {
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }

    public class SessionResultCarClass
    {
        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        [JsonPropertyName("cars_in_class")]
        public List<CarInClass> CarsInClass { get; set; } = new List<CarInClass>();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("relative_speed")]
        public int RelativeSpeed { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; } = string.Empty;
    }

    public class CarInClass
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("package_id")]
        public int PackageId { get; set; }
    }

    public class AllowedLicense
    {
        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        [JsonPropertyName("license_group")]
        public int LicenseGroup { get; set; }

        [JsonPropertyName("min_license_level")]
        public int MinLicenseLevel { get; set; }

        [JsonPropertyName("max_license_level")]
        public int MaxLicenseLevel { get; set; }

        [JsonPropertyName("group_name")]
        public string GroupName { get; set; } = string.Empty;
    }

    public class SessionResultWeatherResult
    {
        [JsonPropertyName("avg_skies")]
        public int AverageSkies { get; set; }

        [JsonPropertyName("avg_cloud_cover_pct")]
        public double AverageCloudCoverPercentage { get; set; }

        [JsonPropertyName("min_cloud_cover_pct")]
        public double MinimumCloudCoverPercentage { get; set; }

        [JsonPropertyName("max_cloud_cover_pct")]
        public double MaximumCloudCoverPercentage { get; set; }

        [JsonPropertyName("temp_units")]
        public int TemperatureUnits { get; set; }

        [JsonPropertyName("avg_temp")]
        public double AverageTemperature { get; set; }

        [JsonPropertyName("min_temp")]
        public double MinimumTemperature { get; set; }

        [JsonPropertyName("max_temp")]
        public double MaximumTemperature { get; set; }

        [JsonPropertyName("avg_rel_humidity")]
        public double AverageRelativeHumidity { get; set; }

        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }

        [JsonPropertyName("avg_wind_speed")]
        public double AverageWindSpeed { get; set; }

        [JsonPropertyName("min_wind_speed")]
        public double MinimumWindSpeed { get; set; }

        [JsonPropertyName("max_wind_speed")]
        public double MaximumWindSpeed { get; set; }

        [JsonPropertyName("avg_wind_dir")]
        public int AverageWindDirection { get; set; }

        [JsonPropertyName("max_fog")]
        public double MaximumFog { get; set; }

        [JsonPropertyName("fog_time_pct")]
        public double FogTimePercentage { get; set; }

        [JsonPropertyName("precip_time_pct")]
        public double PrecipitationTimePercentage { get; set; }

        [JsonPropertyName("precip_mm")]
        public int PrecipitationMillimeters { get; set; }

        [JsonPropertyName("precip_mm2hr_before_session")]
        public int PrecipitationMillimetersPerHourBeforeSession { get; set; }

        [JsonPropertyName("simulated_start_time")]
        public DateTime SimulatedStartTime { get; set; }
    }

}