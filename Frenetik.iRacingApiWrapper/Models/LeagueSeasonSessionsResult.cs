namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// League season sessions result
/// </summary>
public partial class LeagueSeasonSessionsResult
{
    /// <summary>
    /// Sessions
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new List<Session>();

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
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// Session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Cars
        /// </summary>
        [JsonPropertyName("cars")]
        public List<Car> Cars { get; set; } = new List<Car>();

        /// <summary>
        /// Driver Changes
        /// </summary>
        [JsonPropertyName("driver_changes")]
        public bool DriverChanges { get; set; }

        /// <summary>
        /// Entry Count
        /// </summary>
        [JsonPropertyName("entry_count")]
        public int EntryCount { get; set; }

        /// <summary>
        /// Has Results
        /// </summary>
        [JsonPropertyName("has_results")]
        public bool HasResults { get; set; }

        /// <summary>
        /// Launch At
        /// </summary>
        [JsonPropertyName("launch_at")]
        public DateTime LaunchAt { get; set; }

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
        /// Lone Qualify
        /// </summary>
        [JsonPropertyName("lone_qualify")]
        public bool LoneQualify { get; set; }

        /// <summary>
        /// Pace Car Class Id
        /// </summary>
        [JsonPropertyName("pace_car_class_id")]
        public int? PaceCarClassId { get; set; }

        /// <summary>
        /// Pace Car Id
        /// </summary>
        [JsonPropertyName("pace_car_id")]
        public int? PaceCarId { get; set; }

        /// <summary>
        /// Password Protected
        /// </summary>
        [JsonPropertyName("password_protected")]
        public bool PasswordProtected { get; set; }

        /// <summary>
        /// Practice Length
        /// </summary>
        [JsonPropertyName("practice_length")]
        public int PracticeLength { get; set; }

        /// <summary>
        /// Private Session Id
        /// </summary>
        [JsonPropertyName("private_session_id")]
        public int PrivateSessionId { get; set; }

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
        /// Session Id
        /// </summary>
        [JsonPropertyName("session_id")]
        public int SessionId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Subsession Id
        /// </summary>
        [JsonPropertyName("subsession_id")]
        public int SubsessionId { get; set; }

        /// <summary>
        /// Team Entry Count
        /// </summary>
        [JsonPropertyName("team_entry_count")]
        public int TeamEntryCount { get; set; }

        /// <summary>
        /// Time Limit
        /// </summary>
        [JsonPropertyName("time_limit")]
        public int TimeLimit { get; set; }

        /// <summary>
        /// Track
        /// </summary>
        [JsonPropertyName("track")]
        public Track Track { get; set; } = new Track();

        /// <summary>
        /// Track State
        /// </summary>
        [JsonPropertyName("track_state")]
        public TrackState TrackState { get; set; } = new TrackState();

        /// <summary>
        /// Weather
        /// </summary>
        [JsonPropertyName("weather")]
        public Weather Weather { get; set; } = new Weather();

        /// <summary>
        /// Winner Id
        /// </summary>
        [JsonPropertyName("winner_id")]
        public int WinnerId { get; set; }

        /// <summary>
        /// Winner Name
        /// </summary>
        [JsonPropertyName("winner_name")]
        public string WinnerName { get; set; } = string.Empty;
    }

    /// <summary>
    /// Car
    /// </summary>
    public class Car
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
    }

    /// <summary>
    /// TrackState
    /// </summary>
    public class TrackState
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
    /// Weather
    /// </summary>
    public class Weather
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
        public int RelHumidity { get; set; }

        /// <summary>
        /// Fog
        /// </summary>
        [JsonPropertyName("fog")]
        public int Fog { get; set; }

        /// <summary>
        /// Wind Dir
        /// </summary>
        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }

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
    }
}

