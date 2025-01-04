namespace Frenetik.iRacingApiWrapper.Models;

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
