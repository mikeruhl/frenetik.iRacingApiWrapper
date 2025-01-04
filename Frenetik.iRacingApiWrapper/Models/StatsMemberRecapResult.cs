namespace Frenetik.iRacingApiWrapper.Models;

public class StatsMemberRecapResult
{
    [JsonPropertyName("year")]
    public int Year { get; set; }

    public StatsMemberRecap Stats { get; set; } = new StatsMemberRecap();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("season")]
    public int? Season { get; set; }

    [JsonPropertyName("customer_id")]
    public int CustomerId { get; set; }
}

public class StatsMemberRecap
{
    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("top5")]
    public int Top5 { get; set; }

    [JsonPropertyName("avg_start_position")]
    public int AvgStartPosition { get; set; }

    [JsonPropertyName("avg_finish_position")]
    public int AvgFinishPosition { get; set; }

    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    [JsonPropertyName("laps_led")]
    public int LapsLed { get; set; }

    [JsonPropertyName("favorite_car")]
    public FavoriteCar? FavoriteCar { get; set; }

    [JsonPropertyName("favorite_track")]
    public FavoriteTrack? FavoriteTrack { get; set; }
}

public class FavoriteCar
{
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;

    [JsonPropertyName("car_image")]
    public string CarImage { get; set; } = string.Empty;
}

public class FavoriteTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;

    [JsonPropertyName("track_logo")]
    public string TrackLogo { get; set; } = string.Empty;
}
