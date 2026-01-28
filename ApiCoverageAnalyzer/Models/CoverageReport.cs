using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Models;

/// <summary>
/// Comprehensive coverage report
/// </summary>
public class CoverageReport
{
    /// <summary>
    /// Report generation timestamp
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// iRacing API version
    /// </summary>
    [JsonPropertyName("api_version")]
    public string ApiVersion { get; set; } = string.Empty;

    /// <summary>
    /// Coverage summary statistics
    /// </summary>
    [JsonPropertyName("summary")]
    public CoverageSummary Summary { get; set; } = new();

    /// <summary>
    /// Per-endpoint coverage results
    /// </summary>
    [JsonPropertyName("endpoint_results")]
    public List<EndpointCoverageResult> EndpointResults { get; set; } = new();

    /// <summary>
    /// Missing endpoints not wrapped
    /// </summary>
    [JsonPropertyName("missing_endpoints")]
    public List<string> MissingEndpoints { get; set; } = new();
}

/// <summary>
/// Coverage summary statistics
/// </summary>
public class CoverageSummary
{
    /// <summary>
    /// Endpoint coverage percentage
    /// </summary>
    [JsonPropertyName("endpoint_coverage")]
    public double EndpointCoverage { get; set; }

    /// <summary>
    /// Parameter coverage percentage
    /// </summary>
    [JsonPropertyName("parameter_coverage")]
    public double ParameterCoverage { get; set; }

    /// <summary>
    /// Response schema coverage percentage
    /// </summary>
    [JsonPropertyName("response_schema_coverage")]
    public double ResponseSchemaCoverage { get; set; }

    /// <summary>
    /// Overall coverage percentage
    /// </summary>
    [JsonPropertyName("overall_coverage")]
    public double OverallCoverage { get; set; }

    /// <summary>
    /// Total number of endpoints
    /// </summary>
    [JsonPropertyName("total_endpoints")]
    public int TotalEndpoints { get; set; }

    /// <summary>
    /// Number of covered endpoints
    /// </summary>
    [JsonPropertyName("covered_endpoints")]
    public int CoveredEndpoints { get; set; }

    /// <summary>
    /// Total number of parameters across all endpoints
    /// </summary>
    [JsonPropertyName("total_parameters")]
    public int TotalParameters { get; set; }

    /// <summary>
    /// Number of covered parameters
    /// </summary>
    [JsonPropertyName("covered_parameters")]
    public int CoveredParameters { get; set; }
}
