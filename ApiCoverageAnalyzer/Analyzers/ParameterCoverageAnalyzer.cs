using ApiCoverageAnalyzer.Comparers;
using ApiCoverageAnalyzer.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ApiCoverageAnalyzer.Analyzers;

/// <summary>
/// Analyzes parameter coverage for each endpoint
/// </summary>
public class ParameterCoverageAnalyzer(
    ParameterComparer comparer,
    ILogger<ParameterCoverageAnalyzer> logger)
{
    public Task<List<ParameterAnalysisResult>> AnalyzeAsync(Dictionary<string, MatchedEndpoint> matchedEndpoints)
    {
        logger.LogInformation("Analyzing parameter coverage for {Count} endpoints...", matchedEndpoints.Count);

        var results = new List<ParameterAnalysisResult>();

        foreach (var (path, endpoint) in matchedEndpoints)
        {
            ParameterAnalysisResult result;

            // Skip parameter validation for methods that use dynamic parameters
            if (UsesDynamicParameters(endpoint.Method))
            {
                logger.LogDebug("Skipping parameter validation for {Method} - uses dynamic parameters", endpoint.Method.Name);
                result = new ParameterAnalysisResult
                {
                    EndpointPath = path,
                    TotalParameters = endpoint.Parameters.Count,
                    IsSkipped = true
                };
            }
            else
            {
                result = comparer.Compare(endpoint.Parameters, endpoint.Method);
                result.EndpointPath = path;
            }

            results.Add(result);
        }

        // Calculate coverage excluding skipped results
        var applicableResults = results.Where(r => !r.IsSkipped).ToList();
        var totalParams = applicableResults.Sum(r => r.TotalParameters);
        var coveredParams = applicableResults.Sum(r => r.CoveredParameters);
        var coverage = totalParams > 0 ? (double)coveredParams / totalParams * 100.0 : 100.0;

        logger.LogInformation("Parameter coverage: {Coverage}% ({Covered}/{Total})",
            coverage, coveredParams, totalParams);

        return Task.FromResult(results);
    }

    /// <summary>
    /// Check if a method uses dynamic parameters (e.g., Dictionary<string, string[]>)
    /// that represent flexible query parameters rather than fixed parameters
    /// </summary>
    private static bool UsesDynamicParameters(MethodInfo method)
    {
        var parameters = method.GetParameters();

        // Check for a single Dictionary<string, string[]> parameter (like the Lookup method)
        if (parameters.Length == 1)
        {
            var param = parameters[0];
            var paramType = param.ParameterType;

            // Check if it's a Dictionary<string, string[]>
            if (paramType.IsGenericType &&
                paramType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var typeArgs = paramType.GetGenericArguments();
                if (typeArgs.Length == 2 &&
                    typeArgs[0] == typeof(string) &&
                    typeArgs[1] == typeof(string[]))
                {
                    return true;
                }
            }
        }

        return false;
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
