namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsMemberBests
/// </summary>
public class StatsMemberBests
{
    /// <summary>
    /// Cars Driven
    /// </summary>
    [JsonPropertyName("cars_driven")]
    public List<StatsMemberCar> CarsDriven { get; set; } = new List<StatsMemberCar>();

    /// <summary>
    /// Bests
    /// </summary>
    [JsonPropertyName("bests")]
    public List<StatsMemberBest> Bests { get; set; } = new List<StatsMemberBest>();

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }
}

/// <summary>
/// StatsMemberCar
/// </summary>
public class StatsMemberCar
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
}

/// <summary>
/// StatsMemberBest
/// </summary>
public class StatsMemberBest
{
    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public StatsMemberTrack Track { get; set; } = new StatsMemberTrack();

    /// <summary>
    /// Event Type
    /// </summary>
    [JsonPropertyName("event_type")]
    public string EventType { get; set; } = string.Empty;

    /// <summary>
    /// Best Lap Time
    /// </summary>
    [JsonPropertyName("best_lap_time")]
    public int BestLapTime { get; set; }

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// End Time
    /// </summary>
    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

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
}

/// <summary>
/// StatsMemberTrack
/// </summary>
public class StatsMemberTrack
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

