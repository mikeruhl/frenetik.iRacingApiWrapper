using ApiCoverageAnalyzer.Comparers;
using ApiCoverageAnalyzer.Discovery;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ApiCoverageAnalyzer.Analyzers;

/// <summary>
/// Analyzes endpoint coverage by comparing API endpoints to wrapper methods
/// </summary>
public class EndpointCoverageAnalyzer(
    ApiEndpointDiscovery apiDiscovery,
    WrapperMethodDiscovery wrapperDiscovery,
    EndpointComparer comparer,
    ILogger<EndpointCoverageAnalyzer> logger)
{
    public async Task<EndpointAnalysisResult> AnalyzeAsync()
    {
        logger.LogInformation("Analyzing endpoint coverage...");

        // Discover API endpoints
        var apiEndpoints = await apiDiscovery.DiscoverAsync();
        logger.LogInformation("Discovered {Count} API endpoints", apiEndpoints.Count);

        // Discover wrapper methods
        var wrapperMethods = wrapperDiscovery.Discover();
        logger.LogInformation("Discovered {Count} wrapper methods", wrapperMethods.Count);

        // Compare and match
        var result = comparer.Compare(apiEndpoints, wrapperMethods);

        logger.LogInformation("Endpoint coverage: {Coverage}% ({Covered}/{Total})",
            result.CoveragePercentage, result.CoveredEndpoints, result.TotalEndpoints);

        return result;
    }
}

/// <summary>
/// Result of endpoint analysis
/// </summary>
public class EndpointAnalysisResult
{
    public int TotalEndpoints { get; set; }
    public int CoveredEndpoints { get; set; }
    public double CoveragePercentage { get; set; }
    public List<string> MissingEndpoints { get; set; } = new();
    public Dictionary<string, MatchedEndpoint> MatchedEndpoints { get; set; } = new();
}

/// <summary>
/// Matched endpoint information
/// </summary>
public class MatchedEndpoint
{
    public string EndpointPath { get; set; } = string.Empty;
    public string MethodName { get; set; } = string.Empty;
    public MethodInfo Method { get; set; } = null!;
    public Dictionary<string, EndpointParameter> Parameters { get; set; } = new();
}

/// <summary>
/// Endpoint parameter information
/// </summary>
public class EndpointParameter
{
    public string Type { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public bool Required { get; set; }
}
