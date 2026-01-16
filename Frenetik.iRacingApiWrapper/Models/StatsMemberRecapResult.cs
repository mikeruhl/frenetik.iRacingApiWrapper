namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsMemberRecapResult
/// </summary>
public class StatsMemberRecapResult
{
    /// <summary>
    /// Year
    /// </summary>
    [JsonPropertyName("year")]
    public int Year { get; set; }

    /// <summary>
    /// Stats
    /// </summary>
    public StatsMemberRecap Stats { get; set; } = new StatsMemberRecap();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Season
    /// </summary>
    [JsonPropertyName("season")]
    public int? Season { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; set; }
}

/// <summary>
/// StatsMemberRecap
/// </summary>
public class StatsMemberRecap
{
    /// <summary>
    /// Starts
    /// </summary>
    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    /// <summary>
    /// Wins
    /// </summary>
    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    /// <summary>
    /// Top5
    /// </summary>
    [JsonPropertyName("top5")]
    public int Top5 { get; set; }

    /// <summary>
    /// Avg Start Position
    /// </summary>
    [JsonPropertyName("avg_start_position")]
    public int AvgStartPosition { get; set; }

    /// <summary>
    /// Avg Finish Position
    /// </summary>
    [JsonPropertyName("avg_finish_position")]
    public int AvgFinishPosition { get; set; }

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
    /// Favorite Car
    /// </summary>
    [JsonPropertyName("favorite_car")]
    public FavoriteCar? FavoriteCar { get; set; }

    /// <summary>
    /// Favorite Track
    /// </summary>
    [JsonPropertyName("favorite_track")]
    public FavoriteTrack? FavoriteTrack { get; set; }
}

/// <summary>
/// FavoriteCar
/// </summary>
public class FavoriteCar
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
    /// Car Image
    /// </summary>
    [JsonPropertyName("car_image")]
    public string CarImage { get; set; } = string.Empty;
}

/// <summary>
/// FavoriteTrack
/// </summary>
public class FavoriteTrack
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

    /// <summary>
    /// Track Logo
    /// </summary>
    [JsonPropertyName("track_logo")]
    public string TrackLogo { get; set; } = string.Empty;
}

