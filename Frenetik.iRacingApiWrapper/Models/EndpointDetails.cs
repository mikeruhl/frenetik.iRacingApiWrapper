using Frenetik.iRacingApiWrapper.JsonConverters;

namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// API endpoint details and documentation
/// </summary>
public class EndpointDetails
{
    /// <summary>
    /// Endpoint URL
    /// </summary>
    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;

    /// <summary>
    /// Notes about the endpoint
    /// </summary>
    [JsonPropertyName("note")]
    [JsonConverter(typeof(SingleOrArrayConverter<List<string>, string>))]
    public List<string> Notes { get; set; } = new List<string>();

    /// <summary>
    /// Cache expiration time in seconds
    /// </summary>
    [JsonPropertyName("expirationSeconds")]
    public int ExpirationSeconds { get; set; }

    /// <summary>
    /// Endpoint parameters
    /// </summary>
    public Dictionary<string, EndpointParameter> Parameters { get; set; } = new Dictionary<string, EndpointParameter>();

    /// <summary>
    /// Endpoint parameter definition
    /// </summary>
    public class EndpointParameter
    {
        /// <summary>
        /// Parameter data type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Parameter description
        /// </summary>
        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Whether parameter is required
        /// </summary>
        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}



