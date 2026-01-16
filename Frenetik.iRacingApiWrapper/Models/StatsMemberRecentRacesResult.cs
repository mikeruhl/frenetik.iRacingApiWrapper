namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsMemberRecentRacesResult
/// </summary>
public class StatsMemberRecentRacesResult
{
    /// <summary>
    /// Races
    /// </summary>
    [JsonPropertyName("races")]
    public List<StatsMemberRecentRacesHelmetRace> Races { get; set; } = new List<StatsMemberRecentRacesHelmetRace>();

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }
}

/// <summary>
/// StatsMemberRecentRacesLivery
/// </summary>
public class StatsMemberRecentRacesLivery
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
}

/// <summary>
/// StatsMemberRecentRacesHelmet
/// </summary>
public class StatsMemberRecentRacesHelmet
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
/// StatsMemberRecentRacesTrack
/// </summary>
public class StatsMemberRecentRacesTrack
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
}

/// <summary>
/// StatsMemberRecentRacesHelmetRace
/// </summary>
public class StatsMemberRecentRacesHelmetRace
{
    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

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
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Livery
    /// </summary>
    [JsonPropertyName("livery")]
    public StatsMemberRecentRacesLivery Livery { get; set; } = new StatsMemberRecentRacesLivery();

    /// <summary>
    /// License Level
    /// </summary>
    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    /// <summary>
    /// Session Start Time
    /// </summary>
    [JsonPropertyName("session_start_time")]
    public DateTime SessionStartTime { get; set; }

    /// <summary>
    /// Winner Group Id
    /// </summary>
    [JsonPropertyName("winner_group_id")]
    public int WinnerGroupId { get; set; }

    /// <summary>
    /// Winner Name
    /// </summary>
    [JsonPropertyName("winner_name")]
    public string WinnerName { get; set; } = string.Empty;

    /// <summary>
    /// Winner Helmet
    /// </summary>
    [JsonPropertyName("winner_helmet")]
    public StatsMemberRecentRacesHelmet WinnerHelmet { get; set; } = new StatsMemberRecentRacesHelmet();

    /// <summary>
    /// Winner License Level
    /// </summary>
    [JsonPropertyName("winner_license_level")]
    public int WinnerLicenseLevel { get; set; }

    /// <summary>
    /// Start Position
    /// </summary>
    [JsonPropertyName("start_position")]
    public int StartPosition { get; set; }

    /// <summary>
    /// Finish Position
    /// </summary>
    [JsonPropertyName("finish_position")]
    public int FinishPosition { get; set; }

    /// <summary>
    /// Qualifying Time
    /// </summary>
    [JsonPropertyName("qualifying_time")]
    public int QualifyingTime { get; set; }

    /// <summary>
    /// Laps
    /// </summary>
    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    /// <summary>
    /// Laps Led
    /// </summary>
    [JsonPropertyName("laps_led")]
    public int LapsLed { get; set; }

    /// <summary>
    /// Incidents
    /// </summary>
    [JsonPropertyName("incidents")]
    public int Incidents { get; set; }

    /// <summary>
    /// Points
    /// </summary>
    [JsonPropertyName("points")]
    public int Points { get; set; }

    /// <summary>
    /// Strength Of Field
    /// </summary>
    [JsonPropertyName("strength_of_field")]
    public int StrengthOfField { get; set; }

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Old Sub Level
    /// </summary>
    [JsonPropertyName("old_sub_level")]
    public int OldSubLevel { get; set; }

    /// <summary>
    /// New Sub Level
    /// </summary>
    [JsonPropertyName("new_sub_level")]
    public int NewSubLevel { get; set; }

    /// <summary>
    /// Oldi Rating
    /// </summary>
    [JsonPropertyName("oldi_rating")]
    public int OldiRating { get; set; }

    /// <summary>
    /// Newi Rating
    /// </summary>
    [JsonPropertyName("newi_rating")]
    public int NewiRating { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public StatsMemberRecentRacesTrack Track { get; set; } = new StatsMemberRecentRacesTrack();
}


