namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Session
/// </summary>
public class Session
{
    /// <summary>
    /// Num Drivers
    /// </summary>
    [JsonPropertyName("num_drivers")]
    public int NumDrivers { get; set; }

    /// <summary>
    /// Num Spotters
    /// </summary>
    [JsonPropertyName("num_spotters")]
    public int NumSpotters { get; set; }

    /// <summary>
    /// Num Spectators
    /// </summary>
    [JsonPropertyName("num_spectators")]
    public int NumSpectators { get; set; }

    /// <summary>
    /// Num Broadcasters
    /// </summary>
    [JsonPropertyName("num_broadcasters")]
    public int NumBroadcasters { get; set; }

    /// <summary>
    /// Available Reserved Broadcaster Slots
    /// </summary>
    [JsonPropertyName("available_reserved_broadcaster_slots")]
    public int AvailableReservedBroadcasterSlots { get; set; }

    /// <summary>
    /// Num Spectator Slots
    /// </summary>
    [JsonPropertyName("num_spectator_slots")]
    public int NumSpectatorSlots { get; set; }

    /// <summary>
    /// Available Spectator Slots
    /// </summary>
    [JsonPropertyName("available_spectator_slots")]
    public int AvailableSpectatorSlots { get; set; }

    /// <summary>
    /// Can Broadcast
    /// </summary>
    [JsonPropertyName("can_broadcast")]
    public bool CanBroadcast { get; set; }

    /// <summary>
    /// Can Watch
    /// </summary>
    [JsonPropertyName("can_watch")]
    public bool CanWatch { get; set; }

    /// <summary>
    /// Can Spot
    /// </summary>
    [JsonPropertyName("can_spot")]
    public bool CanSpot { get; set; }

    /// <summary>
    /// Elig
    /// </summary>
    [JsonPropertyName("elig")]
    public EligibilityResponse Eligibility { get; set; } = new EligibilityResponse();

    /// <summary>
    /// Driver Changes
    /// </summary>
    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    /// <summary>
    /// Restrict Viewing
    /// </summary>
    [JsonPropertyName("restrict_viewing")]
    public bool RestrictViewing { get; set; }

    /// <summary>
    /// Max Users
    /// </summary>
    [JsonPropertyName("max_users")]
    public int MaxUsers { get; set; }

    /// <summary>
    /// Private Session Id
    /// </summary>
    [JsonPropertyName("private_session_id")]
    public int PrivateSessionId { get; set; }

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
    /// Password Protected
    /// </summary>
    [JsonPropertyName("password_protected")]
    public bool PasswordProtected { get; set; }

    /// <summary>
    /// Session Name
    /// </summary>
    [JsonPropertyName("session_name")]
    public string SessionName { get; set; } = string.Empty;

    /// <summary>
    /// Open Reg Expires
    /// </summary>
    [JsonPropertyName("open_reg_expires")]
    public DateTime OpenRegExpires { get; set; }

    /// <summary>
    /// Launch At
    /// </summary>
    [JsonPropertyName("launch_at")]
    public DateTime LaunchAt { get; set; }

    /// <summary>
    /// Full Course Cautions
    /// </summary>
    [JsonPropertyName("full_course_cautions")]
    public bool FullCourseCautions { get; set; }

    /// <summary>
    /// Num Fast Tows
    /// </summary>
    [JsonPropertyName("num_fast_tows")]
    public int NumFastTows { get; set; }

    /// <summary>
    /// Rolling Starts
    /// </summary>
    [JsonPropertyName("rolling_starts")]
    public bool RollingStarts { get; set; }

    /// <summary>
    /// Restarts
    /// </summary>
    [JsonPropertyName("restarts")]
    public int Restarts { get; set; }

    /// <summary>
    /// Multiclass Type
    /// </summary>
    [JsonPropertyName("multiclass_type")]
    public int MulticlassType { get; set; }

    /// <summary>
    /// Pits In Use
    /// </summary>
    [JsonPropertyName("pits_in_use")]
    public int PitsInUse { get; set; }

    /// <summary>
    /// Cars Left
    /// </summary>
    [JsonPropertyName("cars_left")]
    public int CarsLeft { get; set; }

    /// <summary>
    /// Max Drivers
    /// </summary>
    [JsonPropertyName("max_drivers")]
    public int MaxDrivers { get; set; }

    /// <summary>
    /// Hardcore Level
    /// </summary>
    [JsonPropertyName("hardcore_level")]
    public int HardcoreLevel { get; set; }

    /// <summary>
    /// Practice Length
    /// </summary>
    [JsonPropertyName("practice_length")]
    public int PracticeLength { get; set; }

    /// <summary>
    /// Lone Qualify
    /// </summary>
    [JsonPropertyName("lone_qualify")]
    public bool LoneQualify { get; set; }

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
    /// Warmup Length
    /// </summary>
    [JsonPropertyName("warmup_length")]
    public int WarmupLength { get; set; }

    /// <summary>
    /// Race Laps
    /// </summary>
    [JsonPropertyName("race_laps")]
    public int RaceLaps { get; set; }

    /// <summary>
    /// Race Length
    /// </summary>
    [JsonPropertyName("race_length")]
    public int RaceLength { get; set; }

    /// <summary>
    /// Time Limit
    /// </summary>
    [JsonPropertyName("time_limit")]
    public int TimeLimit { get; set; }

    /// <summary>
    /// Restrict Results
    /// </summary>
    [JsonPropertyName("restrict_results")]
    public bool RestrictResults { get; set; }

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
    /// Unsport Conduct Rule Mode
    /// </summary>
    [JsonPropertyName("unsport_conduct_rule_mode")]
    public int UnsportConductRuleMode { get; set; }

    /// <summary>
    /// Lucky Dog
    /// </summary>
    [JsonPropertyName("lucky_dog")]
    public bool LuckyDog { get; set; }

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
    /// Qualifier Must Start Race
    /// </summary>
    [JsonPropertyName("qualifier_must_start_race")]
    public bool QualifierMustStartRace { get; set; }

    /// <summary>
    /// Driver Change Rule
    /// </summary>
    [JsonPropertyName("driver_change_rule")]
    public int DriverChangeRule { get; set; }

    /// <summary>
    /// Fixed Setup
    /// </summary>
    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    /// <summary>
    /// Entry Count
    /// </summary>
    [JsonPropertyName("entry_count")]
    public int EntryCount { get; set; }

    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// League Season Id
    /// </summary>
    [JsonPropertyName("league_season_id")]
    public int LeagueSeasonId { get; set; }

    /// <summary>
    /// Session Type
    /// </summary>
    [JsonPropertyName("session_type")]
    public int SessionType { get; set; }

    /// <summary>
    /// Order Id
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

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
    /// Status
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// Pace Car Id
    /// </summary>
    [JsonPropertyName("pace_car_id")]
    public int? PaceCarId { get; set; }

    /// <summary>
    /// Pace Car Class Id
    /// </summary>
    [JsonPropertyName("pace_car_class_id")]
    public int? PaceCarClassId { get; set; }

    /// <summary>
    /// Num Opt Laps
    /// </summary>
    [JsonPropertyName("num_opt_laps")]
    public int NumOptLaps { get; set; }

    /// <summary>
    /// Damage Model
    /// </summary>
    [JsonPropertyName("damage_model")]
    public int DamageModel { get; set; }

    /// <summary>
    /// Do Not Paint Cars
    /// </summary>
    [JsonPropertyName("do_not_paint_cars")]
    public bool DoNotPaintCars { get; set; }

    /// <summary>
    /// Green White Checkered Limit
    /// </summary>
    [JsonPropertyName("green_white_checkered_limit")]
    public int GreenWhiteCheckeredLimit { get; set; }

    /// <summary>
    /// Do Not Count Caution Laps
    /// </summary>
    [JsonPropertyName("do_not_count_caution_laps")]
    public bool DoNotCountCautionLaps { get; set; }

    /// <summary>
    /// Consec Cautions Single File
    /// </summary>
    [JsonPropertyName("consec_cautions_single_file")]
    public bool ConsecCautionsSingleFile { get; set; }

    /// <summary>
    /// No Lapper Wave Arounds
    /// </summary>
    [JsonPropertyName("no_lapper_wave_arounds")]
    public bool NoLapperWaveArounds { get; set; }

    /// <summary>
    /// Short Parade Lap
    /// </summary>
    [JsonPropertyName("short_parade_lap")]
    public bool ShortParadeLap { get; set; }

    /// <summary>
    /// Start On Qual Tire
    /// </summary>
    [JsonPropertyName("start_on_qual_tire")]
    public bool StartOnQualTire { get; set; }

    /// <summary>
    /// Telemetry Restriction
    /// </summary>
    [JsonPropertyName("telemetry_restriction")]
    public int TelemetryRestriction { get; set; }

    /// <summary>
    /// Telemetry Force To Disk
    /// </summary>
    [JsonPropertyName("telemetry_force_to_disk")]
    public int TelemetryForceToDisk { get; set; }

    /// <summary>
    /// Max Ai Drivers
    /// </summary>
    [JsonPropertyName("max_ai_drivers")]
    public int MaxAiDrivers { get; set; }

    /// <summary>
    /// Ai Avoid Players
    /// </summary>
    [JsonPropertyName("ai_avoid_players")]
    public bool AiAvoidPlayers { get; set; }

    /// <summary>
    /// Must Use Diff Tire Types In Race
    /// </summary>
    [JsonPropertyName("must_use_diff_tire_types_in_race")]
    public bool MustUseDiffTireTypesInRace { get; set; }

    /// <summary>
    /// Start Zone
    /// </summary>
    [JsonPropertyName("start_zone")]
    public bool StartZone { get; set; }

    /// <summary>
    /// Enable Pitlane Collisions
    /// </summary>
    [JsonPropertyName("enable_pitlane_collisions")]
    public bool EnablePitlaneCollisions { get; set; }

    /// <summary>
    /// Disallow Virtual Mirror
    /// </summary>
    [JsonPropertyName("disallow_virtual_mirror")]
    public bool DisallowVirtualMirror { get; set; }

    /// <summary>
    /// Session Full
    /// </summary>
    [JsonPropertyName("session_full")]
    public bool SessionFull { get; set; }

    /// <summary>
    /// Host
    /// </summary>
    [JsonPropertyName("host")]
    public SessionDriver Host { get; set; } = new SessionDriver();

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public TrackResponse Track { get; set; } = new TrackResponse();

    /// <summary>
    /// Weather
    /// </summary>
    [JsonPropertyName("weather")]
    public Weather Weather { get; set; } = new Weather();

    /// <summary>
    /// Track State
    /// </summary>
    [JsonPropertyName("track_state")]
    public TrackStateResponse TrackState { get; set; } = new TrackStateResponse();

    /// <summary>
    /// Farm
    /// </summary>
    [JsonPropertyName("farm")]
    public FarmResponse Farm { get; set; } = new FarmResponse();

    /// <summary>
    /// Admins
    /// </summary>
    [JsonPropertyName("admins")]
    public List<SessionDriver> Admins { get; set; } = new List<SessionDriver>();

    /// <summary>
    /// Allowed Teams
    /// </summary>
    [JsonPropertyName("allowed_teams")]
    public List<int> AllowedTeams { get; set; } = new List<int>();

    /// <summary>
    /// Allowed Leagues
    /// </summary>
    [JsonPropertyName("allowed_leagues")]
    public List<int> AllowedLeagues { get; set; } = new List<int>();

    /// <summary>
    /// Cars
    /// </summary>
    [JsonPropertyName("cars")]
    public List<CarResponse> Cars { get; set; } = new List<CarResponse>();

    /// <summary>
    /// Count By Car Id
    /// </summary>
    [JsonPropertyName("count_by_car_id")]
    public Dictionary<string, int> CountByCarId { get; set; } = new Dictionary<string, int>();

    /// <summary>
    /// Count By Car Class Id
    /// </summary>
    [JsonPropertyName("count_by_car_class_id")]
    public Dictionary<string, int> CountByCarClassId { get; set; } = new Dictionary<string, int>();

    /// <summary>
    /// Car Types
    /// </summary>
    [JsonPropertyName("car_types")]
    public List<CarType> CarTypes { get; set; } = new List<CarType>();

    /// <summary>
    /// Track Types
    /// </summary>
    [JsonPropertyName("track_types")]
    public List<TrackTypeResponse> TrackTypes { get; set; } = new List<TrackTypeResponse>();

    /// <summary>
    /// License Group Types
    /// </summary>
    [JsonPropertyName("license_group_types")]
    public List<LicenseGroupTypeResponse> LicenseGroupTypes { get; set; } = new List<LicenseGroupTypeResponse>();

    /// <summary>
    /// Event Types
    /// </summary>
    [JsonPropertyName("event_types")]
    public List<EventType> EventTypes { get; set; } = new List<EventType>();

    /// <summary>
    /// Session Types
    /// </summary>
    [JsonPropertyName("session_types")]
    public List<SessionTypeResponse> SessionTypes { get; set; } = new List<SessionTypeResponse>();

    /// <summary>
    /// Can Join
    /// </summary>
    [JsonPropertyName("can_join")]
    public bool CanJoin { get; set; }

    /// <summary>
    /// Sess Admin
    /// </summary>
    [JsonPropertyName("sess_admin")]
    public bool SessAdmin { get; set; }

    /// <summary>
    /// Friends
    /// </summary>
    [JsonPropertyName("friends")]
    public List<SessionDriver> Friends { get; set; } = new List<SessionDriver>();

    /// <summary>
    /// Watched
    /// </summary>
    [JsonPropertyName("watched")]
    public List<SessionDriver> Watched { get; set; } = new List<SessionDriver>();

    /// <summary>
    /// End Time
    /// </summary>
    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Is Heat Racing
    /// </summary>
    [JsonPropertyName("is_heat_racing")]
    public bool IsHeatRacing { get; set; }

    /// <summary>
    /// Team Entry Count
    /// </summary>
    [JsonPropertyName("team_entry_count")]
    public int TeamEntryCount { get; set; }

    /// <summary>
    /// Populated
    /// </summary>
    [JsonPropertyName("populated")]
    public bool Populated { get; set; }

    /// <summary>
    /// Broadcaster
    /// </summary>
    [JsonPropertyName("broadcaster")]
    public bool Broadcaster { get; set; }

    /// <summary>
    /// Min Ir
    /// </summary>
    [JsonPropertyName("min_ir")]
    public int MinIr { get; set; }

    /// <summary>
    /// Max Ir
    /// </summary>
    [JsonPropertyName("max_ir")]
    public int MaxIr { get; set; }

    /// <summary>
    /// EligibilityResponse
    /// </summary>
    public class EligibilityResponse
    {
        /// <summary>
        /// Session Full
        /// </summary>
        [JsonPropertyName("session_full")]
        public bool SessionFull { get; set; }

        /// <summary>
        /// Can Spot
        /// </summary>
        [JsonPropertyName("can_spot")]
        public bool CanSpot { get; set; }

        /// <summary>
        /// Can Watch
        /// </summary>
        [JsonPropertyName("can_watch")]
        public bool CanWatch { get; set; }

        /// <summary>
        /// Can Drive
        /// </summary>
        [JsonPropertyName("can_drive")]
        public bool CanDrive { get; set; }

        /// <summary>
        /// Has Sess Password
        /// </summary>
        [JsonPropertyName("has_sess_password")]
        public bool HasSessionPassword { get; set; }

        /// <summary>
        /// Needs Purchase
        /// </summary>
        [JsonPropertyName("needs_purchase")]
        public bool NeedsPurchase { get; set; }

        /// <summary>
        /// Own Car
        /// </summary>
        [JsonPropertyName("own_car")]
        public bool OwnCar { get; set; }

        /// <summary>
        /// Own Track
        /// </summary>
        [JsonPropertyName("own_track")]
        public bool OwnTrack { get; set; }

        /// <summary>
        /// Purchase Skus
        /// </summary>
        [JsonPropertyName("purchase_skus")]
        public List<int> PurchaseSkus { get; set; } = new List<int>();

        /// <summary>
        /// Registered
        /// </summary>
        [JsonPropertyName("registered")]
        public bool Registered { get; set; }
    }

    /// <summary>
    /// SessionDriver
    /// </summary>
    public class SessionDriver
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Helmet
        /// </summary>
        [JsonPropertyName("helmet")]
        public HelmetInfo Helmet { get; set; } = new HelmetInfo();
    }



    /// <summary>
    /// TrackResponse
    /// </summary>
    public class TrackResponse
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
    }



    /// <summary>
    /// TrackStateResponse
    /// </summary>
    public class TrackStateResponse
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
    /// TrackTypeResponse
    /// </summary>
    public class TrackTypeResponse
    {
        /// <summary>
        /// Track Type
        /// </summary>
        [JsonPropertyName("track_type")]
        public string TrackTypeName { get; set; } = string.Empty;
    }

    /// <summary>
    /// LicenseGroupTypeResponse
    /// </summary>
    public class LicenseGroupTypeResponse
    {
        /// <summary>
        /// License Group Type
        /// </summary>
        [JsonPropertyName("license_group_type")]
        public int LicenseGroupTypeId { get; set; }
    }

    /// <summary>
    /// EventType
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// Event Type
        /// </summary>
        [JsonPropertyName("event_type")]
        public int EventTypeId { get; set; }
    }

    /// <summary>
    /// SessionTypeResponse
    /// </summary>
    public class SessionTypeResponse
    {
        /// <summary>
        /// Session Type
        /// </summary>
        [JsonPropertyName("session_type")]
        public int SessionTypeId { get; set; }
    }

    /// <summary>
    /// FarmResponse
    /// </summary>
    public class FarmResponse
    {
        /// <summary>
        /// Farm Id
        /// </summary>
        [JsonPropertyName("farm_id")]
        public int FarmId { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Image Path
        /// </summary>
        [JsonPropertyName("image_path")]
        public string ImagePath { get; set; } = string.Empty;

        /// <summary>
        /// Displayed
        /// </summary>
        [JsonPropertyName("displayed")]
        public bool Displayed { get; set; }
    }

    /// <summary>
    /// CarResponse
    /// </summary>
    public class CarResponse
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
        /// Max Pct Fuel Fill
        /// </summary>
        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPctFuelFill { get; set; }

        /// <summary>
        /// Weight Penalty Kg
        /// </summary>
        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }

        /// <summary>
        /// Power Adjust Pct
        /// </summary>
        [JsonPropertyName("power_adjust_pct")]
        public float PowerAdjustPct { get; set; }

        /// <summary>
        /// Max Dry Tire Sets
        /// </summary>
        [JsonPropertyName("max_dry_tire_sets")]
        public int MaxDryTireSets { get; set; }

        /// <summary>
        /// Package Id
        /// </summary>
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

