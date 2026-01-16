namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Represents a country in iRacing
/// </summary>
public class Country
{
    /// <summary>
    /// Country name
    /// </summary>
    [JsonPropertyName("country_name")]
    public string CountryName { get; set; } = string.Empty;

    /// <summary>
    /// ISO country code
    /// </summary>
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = string.Empty;
}

