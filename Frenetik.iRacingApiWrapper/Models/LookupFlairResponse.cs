namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Response model for Lookup Flair endpoint, Icons are from https://github.com/lipis/flag-icons/
/// </summary>
public class LookupFlairResponse
{
    /// <summary>
    /// Success indicator
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Flair Infos
    /// </summary>
    [JsonPropertyName("flairs")]
    public List<FlairInfo> Flairs { get; set; } = [];

    /// <summary>
    /// Flair information
    /// </summary>
    public class FlairInfo
    {
        /// <summary>
        /// Flair Id
        /// </summary>
        [JsonPropertyName("flair_id")]
        public int FlairId { get; set; }
        /// <summary>
        /// Flair name
        /// </summary>
        [JsonPropertyName("flair_name")]
        public string FlairName { get; set; } = string.Empty;

        /// <summary>
        /// Flair short name
        /// </summary>
        [JsonPropertyName("flair_shortname")]
        public string? FlairShortName { get; set; }

        /// <summary>
        /// Country Code
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Sequence Number
        /// </summary>
        [JsonPropertyName("seq")]
        public int Seq { get; set; }
    }
}
