namespace Frenetik.iRacingApiWrapper.Models;

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
    /// Time Of Day
    /// </summary>
    [JsonPropertyName("time_of_day")]
    public int TimeOfDay { get; set; }

    /// <summary>
    /// Simulated Start Time
    /// </summary>
    [JsonPropertyName("simulated_start_time")]
    public DateTime SimulatedStartTime { get; set; }

    /// <summary>
    /// Simulated Time Offsets
    /// </summary>
    [JsonPropertyName("simulated_time_offsets")]
    public List<int> SimulatedTimeOffsets { get; set; } = new List<int>();

    /// <summary>
    /// Simulated Time Multiplier
    /// </summary>
    [JsonPropertyName("simulated_time_multiplier")]
    public int SimulatedTimeMultiplier { get; set; }
}

