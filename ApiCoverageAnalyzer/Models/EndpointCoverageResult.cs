using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Models;

/// <summary>
/// Coverage result for a single endpoint
/// </summary>
public class EndpointCoverageResult
{
    /// <summary>
    /// API endpoint path
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Wrapper method name (if matched)
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Coverage status
    /// </summary>
    [JsonPropertyName("status")]
    public CoverageStatus Status { get; set; } = CoverageStatus.NotCovered;

    /// <summary>
    /// Parameter coverage percentage for this endpoint
    /// </summary>
    [JsonPropertyName("parameter_coverage")]
    public double ParameterCoverage { get; set; }

    /// <summary>
    /// Parameter coverage details
    /// </summary>
    [JsonPropertyName("parameter_result")]
    public ParameterCoverageResult? ParameterResult { get; set; }

    /// <summary>
    /// Error message if analysis failed
    /// </summary>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }
}

/// <summary>
/// Coverage status enumeration
/// </summary>
public enum CoverageStatus
{
    /// <summary>
    /// Endpoint is not covered by wrapper
    /// </summary>
    NotCovered,

    /// <summary>
    /// Endpoint is partially covered
    /// </summary>
    Partial,

    /// <summary>
    /// Endpoint is fully covered
    /// </summary>
    Complete,

    /// <summary>
    /// Analysis failed for this endpoint
    /// </summary>
    Failed,

    /// <summary>
    /// Endpoint requires specific permissions
    /// </summary>
    RequiresPermission,

    /// <summary>
    /// Unable to generate valid test data
    /// </summary>
    NoTestData
}
