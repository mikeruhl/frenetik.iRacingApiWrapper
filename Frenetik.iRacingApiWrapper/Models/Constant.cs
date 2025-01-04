namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Constants for iRacing
/// </summary>
public class Constant
{
    /// <summary>
    /// Constant Value
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }

    /// <summary>
    /// Constant label
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;
}
