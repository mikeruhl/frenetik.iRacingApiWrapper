namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// LookupResult
/// </summary>
public class LookupResult
{
    /// <summary>
    /// Lookups
    /// </summary>
    [JsonPropertyName("lookups")]
    public List<Lookup> Lookups { get; set; } = new List<Lookup>();

    /// <summary>
    /// Tag
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; } = string.Empty;
}

/// <summary>
/// Lookup
/// </summary>
public class Lookup
{
    /// <summary>
    /// Lookup Type
    /// </summary>
    [JsonPropertyName("lookup_type")]
    public string LookupType { get; set; } = string.Empty;

    /// <summary>
    /// Lookup Values
    /// </summary>
    [JsonPropertyName("lookup_values")]
    public List<LookupValue> LookupValues { get; set; } = new List<LookupValue>();
}

/// <summary>
/// LookupValue
/// </summary>
public class LookupValue
{
    /// <summary>
    /// Value
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Seq
    /// </summary>
    [JsonPropertyName("seq")]
    public int Seq { get; set; }
}

