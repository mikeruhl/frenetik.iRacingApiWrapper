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
    public DateTimeOffset SimulatedStartTime { get; set; }

    /// <summary>
    /// Simulated Time Offsets
    /// </summary>
    [JsonPropertyName("simulated_time_offsets")]
    public List<int> SimulatedTimeOffsets { get; set; } = new List<int>();

    /// <summary>
    /// Allow Fog
    /// </summary>
    [JsonPropertyName("allow_fog")]
    public bool AllowFog { get; set; }

    /// <summary>
    /// Precip Option
    /// </summary>
    [JsonPropertyName("precip_option")]
    public int PrecipOption { get; set; }

    /// <summary>
    /// Track Water
    /// </summary>
    [JsonPropertyName("track_water")]
    public int TrackWater { get; set; }

    /// <summary>
    /// Simulated Time Multiplier
    /// </summary>
    [JsonPropertyName("simulated_time_multiplier")]
    public int SimulatedTimeMultiplier { get; set; }

    /// <summary>
    /// Forecast Options
    /// </summary>
    [JsonPropertyName("forecast_options")]
    public WeatherForecastOptions ForecastOptions { get; set; } = new();

    /// <summary>
    /// Weather Summary
    /// </summary>
    [JsonPropertyName("weather_summary")]
    public WeatherSummary WeatherSummary { get; set; } = new();

    /// <summary>
    /// Weather Url
    /// </summary>
    [JsonPropertyName("weather_url")]
    public string WeatherUrl { get; set; } = string.Empty;
}

/// <summary>
/// Weather Forecast Options
/// </summary>
public class WeatherForecastOptions
{
    /// <summary>
    /// Forecast Type
    /// </summary>
    [JsonPropertyName("forecast_type")]
    public int ForecastType { get; set; }

    /// <summary>
    /// Precipitation
    /// </summary>
    [JsonPropertyName("precipitation")]
    public int Precipitation { get; set; }

    /// <summary>
    /// Skies
    /// </summary>
    [JsonPropertyName("skies")]
    public int Skies { get; set; }

    /// <summary>
    /// Stop Precip
    /// </summary>
    [JsonPropertyName("stop_precip")]
    public int StopPrecip { get; set; }

    /// <summary>
    /// Temperature
    /// </summary>
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }

    /// <summary>
    /// Weather Seed
    /// </summary>
    [JsonPropertyName("weather_seed")]
    public int WeatherSeed { get; set; }

    /// <summary>
    /// Wind Dir
    /// </summary>
    [JsonPropertyName("wind_dir")]
    public int WindDir { get; set; }

    /// <summary>
    /// Wind Speed
    /// </summary>
    [JsonPropertyName("wind_speed")]
    public int WindSpeed { get; set; }
}

/// <summary>
/// Weather Summary
/// </summary>
public class WeatherSummary
{
    /// <summary>
    /// Max Precip Rate
    /// </summary>
    [JsonPropertyName("max_precip_rate")]
    public int MaxPrecipRate { get; set; }

    /// <summary>
    /// Max Precip Rate Desc
    /// </summary>
    [JsonPropertyName("max_precip_rate_desc")]
    public string MaxPrecipRateDesc { get; set; } = string.Empty;

    /// <summary>
    /// Precip Chance
    /// </summary>
    [JsonPropertyName("precip_chance")]
    public int PrecipChance { get; set; }

    /// <summary>
    /// Skies High
    /// </summary>
    [JsonPropertyName("skies_high")]
    public int SkiesHigh { get; set; }

    /// <summary>
    /// Skies Low
    /// </summary>
    [JsonPropertyName("skies_low")]
    public int SkiesLow { get; set; }

    /// <summary>
    /// Temp High
    /// </summary>
    [JsonPropertyName("temp_high")]
    public double TempHigh { get; set; }

    /// <summary>
    /// Temp Low
    /// </summary>
    [JsonPropertyName("temp_low")]
    public double TempLow { get; set; }

    /// <summary>
    /// Temp Units
    /// </summary>
    [JsonPropertyName("temp_units")]
    public int TempUnits { get; set; }

    /// <summary>
    /// Wind Dir
    /// </summary>
    [JsonPropertyName("wind_dir")]
    public int WindDir { get; set; }

    /// <summary>
    /// Wind High
    /// </summary>
    [JsonPropertyName("wind_high")]
    public double WindHigh { get; set; }

    /// <summary>
    /// Wind Low
    /// </summary>
    [JsonPropertyName("wind_low")]
    public double WindLow { get; set; }

    /// <summary>
    /// Wind Units
    /// </summary>
    [JsonPropertyName("wind_units")]
    public int WindUnits { get; set; }
}

