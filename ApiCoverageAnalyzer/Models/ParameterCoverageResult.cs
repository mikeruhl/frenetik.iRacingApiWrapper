using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Models;

/// <summary>
/// Parameter coverage result for an endpoint
/// </summary>
public class ParameterCoverageResult
{
    /// <summary>
    /// Missing parameters (in API, not in wrapper)
    /// </summary>
    [JsonPropertyName("missing_parameters")]
    public List<string> MissingParameters { get; set; } = new();

    /// <summary>
    /// Extra parameters (in wrapper, not in API)
    /// </summary>
    [JsonPropertyName("extra_parameters")]
    public List<string> ExtraParameters { get; set; } = new();

    /// <summary>
    /// Type mismatches between API and wrapper
    /// </summary>
    [JsonPropertyName("type_mismatches")]
    public List<TypeMismatch> TypeMismatches { get; set; } = new();

    /// <summary>
    /// Required/optional mismatches
    /// </summary>
    [JsonPropertyName("required_optional_mismatches")]
    public List<string> RequiredOptionalMismatches { get; set; } = new();

    /// <summary>
    /// Total number of parameters defined in API
    /// </summary>
    [JsonPropertyName("total_parameters")]
    public int TotalParameters { get; set; }

    /// <summary>
    /// Number of correctly covered parameters
    /// </summary>
    [JsonPropertyName("covered_parameters")]
    public int CoveredParameters { get; set; }

    /// <summary>
    /// Indicates if parameter validation was skipped (e.g., for methods using dynamic parameters)
    /// </summary>
    [JsonPropertyName("is_skipped")]
    public bool IsSkipped { get; set; }
}

/// <summary>
/// Type mismatch information
/// </summary>
public class TypeMismatch
{
    /// <summary>
    /// Parameter name
    /// </summary>
    [JsonPropertyName("parameter")]
    public string Parameter { get; set; } = string.Empty;

    /// <summary>
    /// Expected type from API
    /// </summary>
    [JsonPropertyName("api_type")]
    public string ApiType { get; set; } = string.Empty;

    /// <summary>
    /// Actual type in wrapper
    /// </summary>
    [JsonPropertyName("wrapper_type")]
    public string WrapperType { get; set; } = string.Empty;
}
