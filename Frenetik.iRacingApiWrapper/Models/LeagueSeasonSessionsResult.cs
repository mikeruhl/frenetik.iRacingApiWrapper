namespace Frenetik.iRacingApiWrapper.Models;

public partial class LeagueSeasonSessionsResult
{
    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new List<Session>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    public class Session
    {
        [JsonPropertyName("cars")]
        public List<Car> Cars { get; set; } = new List<Car>();

        [JsonPropertyName("driver_changes")]
        public bool DriverChanges { get; set; }

        [JsonPropertyName("entry_count")]
        public int EntryCount { get; set; }

        [JsonPropertyName("has_results")]
        public bool HasResults { get; set; }

        [JsonPropertyName("launch_at")]
        public DateTime LaunchAt { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("league_season_id")]
        public int LeagueSeasonId { get; set; }

        [JsonPropertyName("lone_qualify")]
        public bool LoneQualify { get; set; }

        [JsonPropertyName("pace_car_class_id")]
        public int? PaceCarClassId { get; set; }

        [JsonPropertyName("pace_car_id")]
        public int? PaceCarId { get; set; }

        [JsonPropertyName("password_protected")]
        public bool PasswordProtected { get; set; }

        [JsonPropertyName("practice_length")]
        public int PracticeLength { get; set; }

        [JsonPropertyName("private_session_id")]
        public int PrivateSessionId { get; set; }

        [JsonPropertyName("qualify_laps")]
        public int QualifyLaps { get; set; }

        [JsonPropertyName("qualify_length")]
        public int QualifyLength { get; set; }

        [JsonPropertyName("race_laps")]
        public int RaceLaps { get; set; }

        [JsonPropertyName("race_length")]
        public int RaceLength { get; set; }

        [JsonPropertyName("session_id")]
        public int SessionId { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("subsession_id")]
        public int SubsessionId { get; set; }

        [JsonPropertyName("team_entry_count")]
        public int TeamEntryCount { get; set; }

        [JsonPropertyName("time_limit")]
        public int TimeLimit { get; set; }

        [JsonPropertyName("track")]
        public Track Track { get; set; } = new Track();

        [JsonPropertyName("track_state")]
        public TrackState TrackState { get; set; } = new TrackState();

        [JsonPropertyName("weather")]
        public Weather Weather { get; set; } = new Weather();

        [JsonPropertyName("winner_id")]
        public int WinnerId { get; set; }

        [JsonPropertyName("winner_name")]
        public string WinnerName { get; set; } = string.Empty;
    }

    public class Car
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("car_name")]
        public string CarName { get; set; } = string.Empty;

        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        [JsonPropertyName("car_class_name")]
        public string CarClassName { get; set; } = string.Empty;
    }

    public class TrackState
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

    public class Weather
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
        public int RelHumidity { get; set; }

        [JsonPropertyName("fog")]
        public int Fog { get; set; }

        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }

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
    }
}
