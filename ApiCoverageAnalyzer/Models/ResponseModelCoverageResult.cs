using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Models;

/// <summary>
/// Response model coverage result for a single endpoint
/// </summary>
public class ResponseModelCoverageResult
{
    /// <summary>
    /// API endpoint path
    /// </summary>
    [JsonPropertyName("endpoint_path")]
    public string EndpointPath { get; set; } = string.Empty;

    /// <summary>
    /// Whether this endpoint was skipped (e.g., requires parameters, non-JSON return type)
    /// </summary>
    [JsonPropertyName("is_skipped")]
    public bool IsSkipped { get; set; }

    /// <summary>
    /// Reason this endpoint was skipped
    /// </summary>
    [JsonPropertyName("skip_reason")]
    public string? SkipReason { get; set; }

    /// <summary>
    /// JSON properties present in the response but missing from the model
    /// </summary>
    [JsonPropertyName("missing_properties")]
    public List<string> MissingProperties { get; set; } = new();

    /// <summary>
    /// Total number of JSON properties encountered in the response
    /// </summary>
    [JsonPropertyName("total_json_properties")]
    public int TotalJsonProperties { get; set; }

    /// <summary>
    /// Number of JSON properties covered by the model
    /// </summary>
    [JsonPropertyName("covered_properties")]
    public int CoveredProperties => TotalJsonProperties - MissingProperties.Count;

    /// <summary>
    /// Coverage percentage for this endpoint's response model
    /// </summary>
    [JsonPropertyName("coverage_percentage")]
    public double CoveragePercentage => TotalJsonProperties > 0
        ? (double)CoveredProperties / TotalJsonProperties * 100.0
        : 100.0;
}
