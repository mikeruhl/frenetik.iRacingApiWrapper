namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Represents a car racing rule or regulation
/// </summary>
public class CarRule
{
    /// <summary>
    /// Rule Category Name
    /// </summary>
    [JsonPropertyName("rule_category")]
    public string RuleCategory { get; set; } = string.Empty;

    /// <summary>
    /// Description of Rule Category
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

