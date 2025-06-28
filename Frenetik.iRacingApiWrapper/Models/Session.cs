namespace Frenetik.iRacingApiWrapper.Models;

public class Session
{
    [JsonPropertyName("num_drivers")]
    public int NumDrivers { get; set; }

    [JsonPropertyName("num_spotters")]
    public int NumSpotters { get; set; }

    [JsonPropertyName("num_spectators")]
    public int NumSpectators { get; set; }

    [JsonPropertyName("num_broadcasters")]
    public int NumBroadcasters { get; set; }

    [JsonPropertyName("available_reserved_broadcaster_slots")]
    public int AvailableReservedBroadcasterSlots { get; set; }

    [JsonPropertyName("num_spectator_slots")]
    public int NumSpectatorSlots { get; set; }

    [JsonPropertyName("available_spectator_slots")]
    public int AvailableSpectatorSlots { get; set; }

    [JsonPropertyName("can_broadcast")]
    public bool CanBroadcast { get; set; }

    [JsonPropertyName("can_watch")]
    public bool CanWatch { get; set; }

    [JsonPropertyName("can_spot")]
    public bool CanSpot { get; set; }

    [JsonPropertyName("elig")]
    public EligibilityResponse Eligibility { get; set; } = new EligibilityResponse();

    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    [JsonPropertyName("restrict_viewing")]
    public bool RestrictViewing { get; set; }

    [JsonPropertyName("max_users")]
    public int MaxUsers { get; set; }

    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("password_protected")]
    public bool PasswordProtected { get; set; }

    [JsonPropertyName("session_name")]
    public string SessionName { get; set; } = string.Empty;

    [JsonPropertyName("open_reg_expires")]
    public DateTime OpenRegExpires { get; set; }

    [JsonPropertyName("launch_at")]
    public DateTime LaunchAt { get; set; }

    [JsonPropertyName("full_course_cautions")]
    public bool FullCourseCautions { get; set; }

    [JsonPropertyName("num_fast_tows")]
    public int NumFastTows { get; set; }

    [JsonPropertyName("rolling_starts")]
    public bool RollingStarts { get; set; }

    [JsonPropertyName("restarts")]
    public int Restarts { get; set; }

    [JsonPropertyName("multiclass_type")]
    public int MulticlassType { get; set; }

    [JsonPropertyName("pits_in_use")]
    public int PitsInUse { get; set; }

    [JsonPropertyName("cars_left")]
    public int CarsLeft { get; set; }

    [JsonPropertyName("max_drivers")]
    public int MaxDrivers { get; set; }

    [JsonPropertyName("hardcore_level")]
    public int HardcoreLevel { get; set; }

    [JsonPropertyName("practice_length")]
    public int PracticeLength { get; set; }

    [JsonPropertyName("lone_qualify")]
    public bool LoneQualify { get; set; }

    [JsonPropertyName("qualify_laps")]
    public int QualifyLaps { get; set; }

    [JsonPropertyName("qualify_length")]
    public int QualifyLength { get; set; }

    [JsonPropertyName("warmup_length")]
    public int WarmupLength { get; set; }

    [JsonPropertyName("race_laps")]
    public int RaceLaps { get; set; }

    [JsonPropertyName("race_length")]
    public int RaceLength { get; set; }

    [JsonPropertyName("time_limit")]
    public int TimeLimit { get; set; }

    [JsonPropertyName("restrict_results")]
    public bool RestrictResults { get; set; }

    [JsonPropertyName("incident_limit")]
    public int IncidentLimit { get; set; }

    [JsonPropertyName("incident_warn_mode")]
    public int IncidentWarnMode { get; set; }

    [JsonPropertyName("incident_warn_param1")]
    public int IncidentWarnParam1 { get; set; }

    [JsonPropertyName("incident_warn_param2")]
    public int IncidentWarnParam2 { get; set; }

    [JsonPropertyName("unsport_conduct_rule_mode")]
    public int UnsportConductRuleMode { get; set; }

    [JsonPropertyName("lucky_dog")]
    public bool LuckyDog { get; set; }

    [JsonPropertyName("min_team_drivers")]
    public int MinTeamDrivers { get; set; }

    [JsonPropertyName("max_team_drivers")]
    public int MaxTeamDrivers { get; set; }

    [JsonPropertyName("qualifier_must_start_race")]
    public bool QualifierMustStartRace { get; set; }

    [JsonPropertyName("driver_change_rule")]
    public int DriverChangeRule { get; set; }

    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    [JsonPropertyName("entry_count")]
    public int EntryCount { get; set; }

    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    [JsonPropertyName("league_season_id")]
    public int LeagueSeasonId { get; set; }

    [JsonPropertyName("session_type")]
    public int SessionType { get; set; }

    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    [JsonPropertyName("min_license_level")]
    public int MinLicenseLevel { get; set; }

    [JsonPropertyName("max_license_level")]
    public int MaxLicenseLevel { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("pace_car_id")]
    public int? PaceCarId { get; set; }

    [JsonPropertyName("pace_car_class_id")]
    public int? PaceCarClassId { get; set; }

    [JsonPropertyName("num_opt_laps")]
    public int NumOptLaps { get; set; }

    [JsonPropertyName("damage_model")]
    public int DamageModel { get; set; }

    [JsonPropertyName("do_not_paint_cars")]
    public bool DoNotPaintCars { get; set; }

    [JsonPropertyName("green_white_checkered_limit")]
    public int GreenWhiteCheckeredLimit { get; set; }

    [JsonPropertyName("do_not_count_caution_laps")]
    public bool DoNotCountCautionLaps { get; set; }

    [JsonPropertyName("consec_cautions_single_file")]
    public bool ConsecCautionsSingleFile { get; set; }

    [JsonPropertyName("no_lapper_wave_arounds")]
    public bool NoLapperWaveArounds { get; set; }

    [JsonPropertyName("short_parade_lap")]
    public bool ShortParadeLap { get; set; }

    [JsonPropertyName("start_on_qual_tire")]
    public bool StartOnQualTire { get; set; }

    [JsonPropertyName("telemetry_restriction")]
    public int TelemetryRestriction { get; set; }

    [JsonPropertyName("telemetry_force_to_disk")]
    public int TelemetryForceToDisk { get; set; }

    [JsonPropertyName("max_ai_drivers")]
    public int MaxAiDrivers { get; set; }

    [JsonPropertyName("ai_avoid_players")]
    public bool AiAvoidPlayers { get; set; }

    [JsonPropertyName("must_use_diff_tire_types_in_race")]
    public bool MustUseDiffTireTypesInRace { get; set; }

    [JsonPropertyName("start_zone")]
    public bool StartZone { get; set; }

    [JsonPropertyName("enable_pitlane_collisions")]
    public bool EnablePitlaneCollisions { get; set; }

    [JsonPropertyName("disallow_virtual_mirror")]
    public bool DisallowVirtualMirror { get; set; }

    [JsonPropertyName("session_full")]
    public bool SessionFull { get; set; }

    [JsonPropertyName("host")]
    public SessionDriver Host { get; set; } = new SessionDriver();

    [JsonPropertyName("track")]
    public TrackResponse Track { get; set; } = new TrackResponse();

    [JsonPropertyName("weather")]
    public Weather Weather { get; set; } = new Weather();

    [JsonPropertyName("track_state")]
    public TrackStateResponse TrackState { get; set; } = new TrackStateResponse();

    [JsonPropertyName("farm")]
    public FarmResponse Farm { get; set; } = new FarmResponse();

    [JsonPropertyName("admins")]
    public List<SessionDriver> Admins { get; set; } = new List<SessionDriver>();

    [JsonPropertyName("allowed_teams")]
    public List<int> AllowedTeams { get; set; } = new List<int>();

    [JsonPropertyName("allowed_leagues")]
    public List<int> AllowedLeagues { get; set; } = new List<int>();

    [JsonPropertyName("cars")]
    public List<CarResponse> Cars { get; set; } = new List<CarResponse>();

    [JsonPropertyName("count_by_car_id")]
    public Dictionary<string, int> CountByCarId { get; set; } = new Dictionary<string, int>();

    [JsonPropertyName("count_by_car_class_id")]
    public Dictionary<string, int> CountByCarClassId { get; set; } = new Dictionary<string, int>();

    [JsonPropertyName("car_types")]
    public List<CarType> CarTypes { get; set; } = new List<CarType>();

    [JsonPropertyName("track_types")]
    public List<TrackTypeResponse> TrackTypes { get; set; } = new List<TrackTypeResponse>();

    [JsonPropertyName("license_group_types")]
    public List<LicenseGroupTypeResponse> LicenseGroupTypes { get; set; } = new List<LicenseGroupTypeResponse>();

    [JsonPropertyName("event_types")]
    public List<EventType> EventTypes { get; set; } = new List<EventType>();

    [JsonPropertyName("session_types")]
    public List<SessionTypeResponse> SessionTypes { get; set; } = new List<SessionTypeResponse>();

    [JsonPropertyName("can_join")]
    public bool CanJoin { get; set; }

    [JsonPropertyName("sess_admin")]
    public bool SessAdmin { get; set; }

    [JsonPropertyName("friends")]
    public List<SessionDriver> Friends { get; set; } = new List<SessionDriver>();

    [JsonPropertyName("watched")]
    public List<SessionDriver> Watched { get; set; } = new List<SessionDriver>();

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("is_heat_racing")]
    public bool IsHeatRacing { get; set; }

    [JsonPropertyName("team_entry_count")]
    public int TeamEntryCount { get; set; }

    [JsonPropertyName("populated")]
    public bool Populated { get; set; }

    [JsonPropertyName("broadcaster")]
    public bool Broadcaster { get; set; }

    [JsonPropertyName("min_ir")]
    public int MinIr { get; set; }

    [JsonPropertyName("max_ir")]
    public int MaxIr { get; set; }

    public class EligibilityResponse
    {
        [JsonPropertyName("session_full")]
        public bool SessionFull { get; set; }

        [JsonPropertyName("can_spot")]
        public bool CanSpot { get; set; }

        [JsonPropertyName("can_watch")]
        public bool CanWatch { get; set; }

        [JsonPropertyName("can_drive")]
        public bool CanDrive { get; set; }

        [JsonPropertyName("has_sess_password")]
        public bool HasSessionPassword { get; set; }

        [JsonPropertyName("needs_purchase")]
        public bool NeedsPurchase { get; set; }

        [JsonPropertyName("own_car")]
        public bool OwnCar { get; set; }

        [JsonPropertyName("own_track")]
        public bool OwnTrack { get; set; }

        [JsonPropertyName("purchase_skus")]
        public List<int> PurchaseSkus { get; set; } = new List<int>();

        [JsonPropertyName("registered")]
        public bool Registered { get; set; }
    }

    public class SessionDriver
    {
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("helmet")]
        public HelmetInfo Helmet { get; set; } = new HelmetInfo();
    }



    public class TrackResponse
    {
        [JsonPropertyName("track_id")]
        public int TrackId { get; set; }

        [JsonPropertyName("track_name")]
        public string TrackName { get; set; } = string.Empty;

        [JsonPropertyName("config_name")]
        public string ConfigName { get; set; } = string.Empty;
    }



    public class TrackStateResponse
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

    public class TrackTypeResponse
    {
        [JsonPropertyName("track_type")]
        public string TrackTypeName { get; set; } = string.Empty;
    }

    public class LicenseGroupTypeResponse
    {
        [JsonPropertyName("license_group_type")]
        public int LicenseGroupTypeId { get; set; }
    }

    public class EventType
    {
        [JsonPropertyName("event_type")]
        public int EventTypeId { get; set; }
    }

    public class SessionTypeResponse
    {
        [JsonPropertyName("session_type")]
        public int SessionTypeId { get; set; }
    }

    public class FarmResponse
    {
        [JsonPropertyName("farm_id")]
        public int FarmId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("image_path")]
        public string ImagePath { get; set; } = string.Empty;

        [JsonPropertyName("displayed")]
        public bool Displayed { get; set; }
    }

    public class CarResponse
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("car_name")]
        public string CarName { get; set; } = string.Empty;

        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        [JsonPropertyName("car_class_name")]
        public string CarClassName { get; set; } = string.Empty;

        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPctFuelFill { get; set; }

        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }

        [JsonPropertyName("power_adjust_pct")]
        public float PowerAdjustPct { get; set; }

        [JsonPropertyName("max_dry_tire_sets")]
        public int MaxDryTireSets { get; set; }

        [JsonPropertyName("package_id")]
        public int PackageId { get; set; }
    }

    /// <summary>
    /// Car Type
    /// </summary>
    public class CarType
    {
        /// <summary>
        /// Car Type
        /// </summary>
        [JsonPropertyName("car_type")]
        public string Type { get; set; } = string.Empty;
    }
}
