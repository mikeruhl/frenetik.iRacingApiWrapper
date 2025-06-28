namespace Frenetik.iRacingApiWrapper.Models;

public class StatsMemberRecentRacesResult
{
    [JsonPropertyName("races")]
    public List<StatsMemberRecentRacesHelmetRace> Races { get; set; } = new List<StatsMemberRecentRacesHelmetRace>();

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }
}

public class StatsMemberRecentRacesLivery
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
}

public class StatsMemberRecentRacesHelmet
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

public class StatsMemberRecentRacesTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;
}

public class StatsMemberRecentRacesHelmetRace
{
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    [JsonPropertyName("livery")]
    public StatsMemberRecentRacesLivery Livery { get; set; } = new StatsMemberRecentRacesLivery();

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("session_start_time")]
    public DateTime SessionStartTime { get; set; }

    [JsonPropertyName("winner_group_id")]
    public int WinnerGroupId { get; set; }

    [JsonPropertyName("winner_name")]
    public string WinnerName { get; set; } = string.Empty;

    [JsonPropertyName("winner_helmet")]
    public StatsMemberRecentRacesHelmet WinnerHelmet { get; set; } = new StatsMemberRecentRacesHelmet();

    [JsonPropertyName("winner_license_level")]
    public int WinnerLicenseLevel { get; set; }

    [JsonPropertyName("start_position")]
    public int StartPosition { get; set; }

    [JsonPropertyName("finish_position")]
    public int FinishPosition { get; set; }

    [JsonPropertyName("qualifying_time")]
    public int QualifyingTime { get; set; }

    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    [JsonPropertyName("laps_led")]
    public int LapsLed { get; set; }

    [JsonPropertyName("incidents")]
    public int Incidents { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("strength_of_field")]
    public int StrengthOfField { get; set; }

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("old_sub_level")]
    public int OldSubLevel { get; set; }

    [JsonPropertyName("new_sub_level")]
    public int NewSubLevel { get; set; }

    [JsonPropertyName("oldi_rating")]
    public int OldiRating { get; set; }

    [JsonPropertyName("newi_rating")]
    public int NewiRating { get; set; }

    [JsonPropertyName("track")]
    public StatsMemberRecentRacesTrack Track { get; set; } = new StatsMemberRecentRacesTrack();
}

