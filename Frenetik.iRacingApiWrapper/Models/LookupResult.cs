namespace Frenetik.iRacingApiWrapper.Models;

public class LookupResult
{
    [JsonPropertyName("lookups")]
    public List<Lookup> Lookups { get; set; } = new List<Lookup>();

    [JsonPropertyName("tag")]
    public string Tag { get; set; } = string.Empty;
}

public class Lookup
{
    [JsonPropertyName("lookup_type")]
    public string LookupType { get; set; } = string.Empty;

    [JsonPropertyName("lookup_values")]
    public List<LookupValue> LookupValues { get; set; } = new List<LookupValue>();
}

public class LookupValue
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("seq")]
    public int Seq { get; set; }
}
