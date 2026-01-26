using ApiCoverageAnalyzer.Analyzers;
using ApiCoverageAnalyzer.Utilities;
using Frenetik.iRacingApiWrapper.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ApiCoverageAnalyzer.Comparers;

/// <summary>
/// Compares API endpoints to wrapper methods
/// </summary>
public class EndpointComparer
{
    private readonly NamingConventions _naming;
    private readonly ILogger<EndpointComparer> _logger;

    public EndpointComparer(
        NamingConventions naming,
        ILogger<EndpointComparer> logger)
    {
        _naming = naming;
        _logger = logger;
    }

    /// <summary>
    /// Compare API endpoints to wrapper methods and find matches
    /// </summary>
    /// <param name="apiEndpoints">API endpoints from GetDoc()</param>
    /// <param name="pathToMethodMap">Map of API paths to wrapper methods (from IL extraction)</param>
    public EndpointAnalysisResult Compare(
        Dictionary<string, EndpointDetails> apiEndpoints,
        Dictionary<string, MethodInfo> pathToMethodMap)
    {
        var result = new EndpointAnalysisResult
        {
            TotalEndpoints = apiEndpoints.Count
        };

        foreach (var (endpointKey, endpointDetails) in apiEndpoints)
        {
            // Try to match endpoint by its link (actual path)
            var matchedMethod = FindMatchingMethod(endpointKey, endpointDetails.Link, pathToMethodMap);

            if (matchedMethod != null)
            {
                result.MatchedEndpoints[endpointKey] = new MatchedEndpoint
                {
                    EndpointPath = endpointKey,
                    MethodName = matchedMethod.Name,
                    Method = matchedMethod,
                    Parameters = endpointDetails.Parameters.ToDictionary(
                        p => p.Key,
                        p => new EndpointParameter
                        {
                            // Override type to datetime if note indicates ISO-8601 date
                            Type = IsDateType(p.Value.Note) ? "datetime" : p.Value.Type,
                            Note = p.Value.Note,
                            Required = p.Value.Required
                        })
                };
                result.CoveredEndpoints++;
            }
            else
            {
                result.MissingEndpoints.Add(endpointKey);
                _logger.LogWarning("No wrapper method found for endpoint: {Endpoint} (link: {Link})",
                    endpointKey, endpointDetails.Link);
            }
        }

        result.CoveragePercentage = result.TotalEndpoints > 0
            ? (double)result.CoveredEndpoints / result.TotalEndpoints * 100.0
            : 100.0;

        return result;
    }

    private static string ExtractPath(string url)
    {
        return new Uri(url).AbsolutePath.Replace("/data", "");
    }

    private static bool IsDateType(string note)
    {
        return !string.IsNullOrEmpty(note) && note.Contains("ISO-8601 UTC time zero offset", StringComparison.OrdinalIgnoreCase);
    }

    private MethodInfo? FindMatchingMethod(
        string endpointKey,
        string endpointLink,
        Dictionary<string, MethodInfo> pathToMethodMap)
    {
        // The pathToMethodMap is keyed by actual API paths extracted from IL
        // Try direct path matching with various formats

        _logger.LogDebug("Matching endpoint '{EndpointKey}' (link: '{EndpointLink}')",
            endpointKey, endpointLink);

        // Try exact match with the link
        var endpointPath = ExtractPath(endpointLink);
        if (pathToMethodMap.TryGetValue(endpointPath, out var method))
        {
            _logger.LogDebug("  ✓ Exact match found: {MethodName} (path: {Path})", method.Name, endpointLink);
            return method;
        }

        // Try without leading slash
        var linkWithoutSlash = endpointLink.TrimStart('/');
        if (pathToMethodMap.TryGetValue(linkWithoutSlash, out method))
        {
            _logger.LogDebug("  ✓ Match found without slash: {MethodName} (path: {Path})", method.Name, linkWithoutSlash);
            return method;
        }

        // Try without /data/ prefix
        if (endpointLink.StartsWith("/data/"))
        {
            var withoutData = endpointLink.Substring(6);
            if (pathToMethodMap.TryGetValue(withoutData, out method))
            {
                _logger.LogDebug("  ✓ Match found without /data/: {MethodName} (path: {Path})", method.Name, withoutData);
                return method;
            }
        }

        // Try case-insensitive match
        var caseInsensitiveMatch = pathToMethodMap.FirstOrDefault(kvp =>
            kvp.Key.Equals(endpointLink, StringComparison.OrdinalIgnoreCase));

        if (caseInsensitiveMatch.Value != null)
        {
            _logger.LogDebug("  ✓ Case-insensitive match found: {MethodName} (path: {Path})",
                caseInsensitiveMatch.Value.Name, caseInsensitiveMatch.Key);
            return caseInsensitiveMatch.Value;
        }

        // Log similar paths for debugging
        var similarPaths = pathToMethodMap.Keys
            .Where(p => p.Contains(endpointLink.TrimStart('/').Split('/').Last()))
            .Take(3)
            .ToList();

        if (similarPaths.Any())
        {
            _logger.LogDebug("  ✗ No match found. Similar paths in map: {Paths}", string.Join(", ", similarPaths));
        }
        else
        {
            _logger.LogDebug("  ✗ No match found for path: {Path}", endpointLink);
        }

        return null;
    }
}
