namespace ApiCoverageAnalyzer;

/// <summary>
/// Configuration settings for the API coverage analyzer
/// </summary>
public class AnalyzerSettings
{
    /// <summary>
    /// Explicit parameter name mappings from API names to wrapper names
    /// Key: API parameter name (snake_case), Value: Wrapper parameter name (camelCase)
    /// </summary>
    public Dictionary<string, string> ParameterMappings { get; set; } = new(StringComparer.OrdinalIgnoreCase)
    {
        // Default mappings - API uses abbreviated form, wrapper uses full form
        { "cust_id", "customerId" },
        { "cust_ids", "customerIds" }
    };

    /// <summary>
    /// Default threshold for endpoint coverage percentage
    /// </summary>
    public double DefaultEndpointThreshold { get; set; } = 100.0;

    /// <summary>
    /// Default threshold for parameter coverage percentage
    /// </summary>
    public double DefaultParameterThreshold { get; set; } = 100.0;

    /// <summary>
    /// Whether to fail the build if thresholds are not met
    /// </summary>
    public bool FailOnThresholdViolation { get; set; } = false;
}
