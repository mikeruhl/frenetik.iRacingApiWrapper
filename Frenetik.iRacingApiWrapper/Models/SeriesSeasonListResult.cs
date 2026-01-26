namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Get Series Season List Result
/// </summary>
public class SeriesSeasonListResult
{
    /// <summary>
    /// Seasons
    /// </summary>
    [JsonPropertyName("seasons")]
    public List<SeriesSeasonListSeason> Seasons { get; set; } = [];

    /// <summary>
    /// Season from Get Series Season List
    /// </summary>
    public class SeriesSeasonListSeason
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
        /// Allowed Season Members NOTE: Can't find a case where this is not null
        /// </summary>
        [JsonPropertyName("allowed_season_members")]
        public object? AllowedSeasonMembers { get; set; }

        /// <summary>
        /// Car Class Ids
        /// </summary>
        [JsonPropertyName("car_class_ids")]
        public List<int> CarClassIds { get; set; } = [];

        /// <summary>
        /// Car Switching
        /// </summary>
        [JsonPropertyName("car_switching")]
        public bool CarSwitching { get; set; }

        /// <summary>
        /// Car Types
        /// </summary>
        [JsonPropertyName("car_types")]
        public List<SeriesSeasonListCarType> CarTypes { get; set; } = [];

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
        /// Consec Caution Within Nlaps
        /// </summary>
        [JsonPropertyName("consec_caution_within_nlaps")]
        public int ConsecCautionWithinNlaps { get; set; }

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
        /// Current Week Sched
        /// </summary>
        [JsonPropertyName("current_week_sched")]
        public SeriesSeasonListCurrentWeekSched CurrentWeekSched { get; set; } = new();

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
        /// Elig
        /// </summary>
        [JsonPropertyName("elig")]
        public SeriesSeasonListElig Elig { get; set; } = new();

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
        /// Has Mpr
        /// </summary>
        [JsonPropertyName("has_mpr")]
        public bool HasMpr { get; set; }

        /// <summary>
        /// Has Supersessions
        /// </summary>
        [JsonPropertyName("has_supersessions")]
        public bool HasSupersessions { get; set; }

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
        public List<SeriesSeasonListLicenseGroupType> LicenseGroupTypes { get; set; } = [];

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
        public bool MustUseDiffTireTypesInRace { get; set; }

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
        /// Race Week Car Class Ids
        /// </summary>
        [JsonPropertyName("race_week_car_class_ids")]
        public List<SeriesSeasonListRaceWeekCarClassIds> RaceWeekCarClassIds { get; set; } = [];

        /// <summary>
        /// Race Week To Make Divisions
        /// </summary>
        [JsonPropertyName("race_week_to_make_divisions")]
        public int RaceWeekToMakeDivisions { get; set; }

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
        public string StartDate { get; set; } = string.Empty;

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
        public List<SeriesSeasonListTrackType> TrackTypes { get; set; } = [];

        /// <summary>
        /// Unsport Conduct Rule Mode
        /// </summary>
        [JsonPropertyName("unsport_conduct_rule_mode")]
        public int UnsportConductRuleMode { get; set; }
    }

    /// <summary>
    /// Series Season List Car Type
    /// </summary>
    public class SeriesSeasonListCarType
    {
        /// <summary>
        /// Car Type
        /// </summary>
        [JsonPropertyName("car_type")]
        public string CarType { get; set; } = string.Empty;
    }

    /// <summary>
    /// Series Season List Current Week Sched
    /// </summary>
    public class SeriesSeasonListCurrentWeekSched
    {
        /// <summary>
        /// Race Week Num
        /// </summary>
        [JsonPropertyName("race_week_num")]
        public int RaceWeekNum { get; set; }

        /// <summary>
        /// Track
        /// </summary>
        [JsonPropertyName("track")]
        public SeriesSeasonListTrack Track { get; set; } = new();

        /// <summary>
        /// Car Restrictions
        /// </summary>
        [JsonPropertyName("car_restrictions")]
        public List<object> CarRestrictions { get; set; } = [];

        /// <summary>
        /// Race Lap Limit
        /// </summary>
        [JsonPropertyName("race_lap_limit")]
        public int? RaceLapLimit { get; set; }

        /// <summary>
        /// Race Time Limit
        /// </summary>
        [JsonPropertyName("race_time_limit")]
        public int? RaceTimeLimit { get; set; }

        /// <summary>
        /// Precip Chance
        /// </summary>
        [JsonPropertyName("precip_chance")]
        public int PrecipChance { get; set; }

        /// <summary>
        /// Start Type
        /// </summary>
        [JsonPropertyName("start_type")]
        public string StartType { get; set; } = string.Empty;

        /// <summary>
        /// Category Id
        /// </summary>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
    }

    /// <summary>
    /// Series Season List Track
    /// </summary>
    public class SeriesSeasonListTrack
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
    /// Series Season List Elig
    /// </summary>
    public class SeriesSeasonListElig
    {
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
    }

    /// <summary>
    /// Series Season List License Group Type
    /// </summary>
    public class SeriesSeasonListLicenseGroupType
    {
        /// <summary>
        /// License Group Type
        /// </summary>
        [JsonPropertyName("license_group_type")]
        public int LicenseGroupType { get; set; }
    }

    /// <summary>
    /// Series Season List Race Week Car Class Ids
    /// </summary>
    public class SeriesSeasonListRaceWeekCarClassIds
    {
        /// <summary>
        /// Race Week Num
        /// </summary>
        [JsonPropertyName("race_week_num")]
        public int RaceWeekNum { get; set; }

        /// <summary>
        /// Car Class Ids
        /// </summary>
        [JsonPropertyName("car_class_ids")]
        public List<int> CarClassIds { get; set; } = [];
    }

    /// <summary>
    /// Series Season List Track Type
    /// </summary>
    public class SeriesSeasonListTrackType
    {
        /// <summary>
        /// Track Type
        /// </summary>
        [JsonPropertyName("track_type")]
        public string TrackType { get; set; } = string.Empty;
    }
}
