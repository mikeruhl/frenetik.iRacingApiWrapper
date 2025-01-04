namespace Frenetik.iRacingApiWrapper.Models;

public class StatsMemberBests
{
    [JsonPropertyName("cars_driven")]
    public List<StatsMemberCar> CarsDriven { get; set; } = new List<StatsMemberCar>();

    [JsonPropertyName("bests")]
    public List<StatsMemberBest> Bests { get; set; } = new List<StatsMemberBest>();

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("car_id")]
    public int CarId { get; set; }
}

public class StatsMemberCar
{
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;
}

public class StatsMemberBest
{
    [JsonPropertyName("track")]
    public StatsMemberTrack Track { get; set; } = new StatsMemberTrack();

    [JsonPropertyName("event_type")]
    public string EventType { get; set; } = string.Empty;

    [JsonPropertyName("best_lap_time")]
    public int BestLapTime { get; set; }

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }
}

public class StatsMemberTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;
}
