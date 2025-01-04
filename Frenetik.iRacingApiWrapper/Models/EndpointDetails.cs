using Frenetik.iRacingApiWrapper.JsonConverters;

namespace Frenetik.iRacingApiWrapper.Models;

public class EndpointDetails
{
    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;

    [JsonPropertyName("note")]
    [JsonConverter(typeof(SingleOrArrayConverter<List<string>, string>))]
    public List<string> Notes { get; set; } = new List<string>();

    [JsonPropertyName("expirationSeconds")]
    public int ExpirationSeconds { get; set; }

    public Dictionary<string, EndpointParameter> Parameters { get; set; } = new Dictionary<string, EndpointParameter>();

    public class EndpointParameter
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}


