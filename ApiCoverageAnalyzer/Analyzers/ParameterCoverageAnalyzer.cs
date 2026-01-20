using ApiCoverageAnalyzer.Comparers;
using ApiCoverageAnalyzer.Models;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Analyzers;

/// <summary>
/// Analyzes parameter coverage for each endpoint
/// </summary>
public class ParameterCoverageAnalyzer
{
    private readonly ParameterComparer _comparer;
    private readonly ILogger<ParameterCoverageAnalyzer> _logger;

    public ParameterCoverageAnalyzer(
        ParameterComparer comparer,
        ILogger<ParameterCoverageAnalyzer> logger)
    {
        _comparer = comparer;
        _logger = logger;
    }

    public Task<List<ParameterAnalysisResult>> AnalyzeAsync(Dictionary<string, MatchedEndpoint> matchedEndpoints)
    {
        _logger.LogInformation("Analyzing parameter coverage for {Count} endpoints...", matchedEndpoints.Count);

        var results = new List<ParameterAnalysisResult>();

        foreach (var (path, endpoint) in matchedEndpoints)
        {
            var result = _comparer.Compare(endpoint.Parameters, endpoint.Method);
            result.EndpointPath = path;
            results.Add(result);
        }

        var totalParams = results.Sum(r => r.TotalParameters);
        var coveredParams = results.Sum(r => r.CoveredParameters);
        var coverage = totalParams > 0 ? (double)coveredParams / totalParams * 100.0 : 100.0;

        _logger.LogInformation("Parameter coverage: {Coverage}% ({Covered}/{Total})",
            coverage, coveredParams, totalParams);

        return Task.FromResult(results);
    }
}

/// <summary>
/// Result of parameter analysis for an endpoint
/// </summary>
public class ParameterAnalysisResult : ParameterCoverageResult
{
    public string EndpointPath { get; set; } = string.Empty;

    public double CoveragePercentage => TotalParameters > 0
        ? (double)CoveredParameters / TotalParameters * 100.0
        : 100.0;
}
