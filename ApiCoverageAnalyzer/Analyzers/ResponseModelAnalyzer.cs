using ApiCoverageAnalyzer.Comparers;
using ApiCoverageAnalyzer.Discovery;
using ApiCoverageAnalyzer.Models;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Analyzers;

/// <summary>
/// Analyzes response model coverage by fetching live API responses and comparing
/// the JSON structure against the mapped C# model properties.
/// </summary>
public class ResponseModelAnalyzer(
    ResponseFetcher fetcher,
    ModelPropertyExtractor extractor,
    ResponseModelComparer comparer,
    ILogger<ResponseModelAnalyzer> logger)
{
    public async Task<List<ResponseModelCoverageResult>> AnalyzeAsync(
        Dictionary<string, MatchedEndpoint> matchedEndpoints)
    {
        logger.LogInformation("Analyzing response model coverage for {Count} endpoints...",
            matchedEndpoints.Count);

        var results = new List<ResponseModelCoverageResult>();

        foreach (var (path, endpoint) in matchedEndpoints)
            results.Add(await AnalyzeEndpointAsync(path, endpoint));

        var checked_ = results.Where(r => !r.IsSkipped).ToList();
        if (checked_.Count > 0)
        {
            var totalProps = checked_.Sum(r => r.TotalJsonProperties);
            var coveredProps = checked_.Sum(r => r.CoveredProperties);
            var coverage = totalProps > 0 ? (double)coveredProps / totalProps * 100.0 : 100.0;
            logger.LogInformation(
                "Response model coverage: {Coverage:F1}% ({Covered}/{Total} properties across {Endpoints} endpoints)",
                coverage, coveredProps, totalProps, checked_.Count);
        }
        else
        {
            logger.LogInformation("No endpoints could be checked for response model coverage");
        }

        return results;
    }

    private async Task<ResponseModelCoverageResult> AnalyzeEndpointAsync(
        string endpointKey, MatchedEndpoint endpoint)
    {
        var result = new ResponseModelCoverageResult { EndpointPath = endpointKey };

        // Determine model type from wrapper method's return type
        var modelType = extractor.ExtractModelType(endpoint.Method);
        if (modelType == null)
        {
            result.IsSkipped = true;
            result.SkipReason = "No inspectable return type (Stream, dynamic, or void)";
            return result;
        }

        // Fetch actual JSON response using the API path, passing parameters for endpoints that require them
        var json = await fetcher.FetchAsync(endpoint.ApiPath, endpoint.Parameters);
        if (json == null)
        {
            result.IsSkipped = true;
            result.SkipReason = "Could not fetch response (required parameter sample values missing from AnalyzerSettings, or elevated permissions needed)";
            return result;
        }

        // Compare JSON structure against model properties
        var (missing, total) = comparer.Compare(json.Value, modelType);
        result.MissingProperties = missing;
        result.TotalJsonProperties = total;

        if (missing.Count > 0)
        {
            logger.LogWarning("{Path}: {Count} JSON properties not mapped in {Model}: {Props}",
                endpointKey, missing.Count, modelType.Name, string.Join(", ", missing.Select(m => m.Path)));
        }

        return result;
    }
}
