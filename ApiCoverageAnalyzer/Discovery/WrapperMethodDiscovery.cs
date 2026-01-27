using Frenetik.iRacingApiWrapper;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Discovers wrapper methods via reflection and extracts their API paths
/// </summary>
public class WrapperMethodDiscovery(
    ILogger<WrapperMethodDiscovery> logger,
    MethodPathExtractor pathExtractor)
{

    /// <summary>
    /// Discover all wrapper methods and map them to their API paths
    /// </summary>
    public Dictionary<string, MethodInfo> Discover()
    {
        logger.LogInformation("Discovering wrapper methods via reflection...");

        // Get the implementation type (IRacingApiService) instead of the interface
        // because we need the actual method bodies to extract paths
        var implementationType = typeof(IRacingApiService);
        var methods = implementationType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => !m.IsSpecialName &&
                        m.Name != "GetDoc" &&
                        m.DeclaringType == implementationType) // Only methods declared in IRacingApiService
            .ToList();

        logger.LogInformation("Discovered {Count} wrapper methods", methods.Count);

        // Extract paths from IL code
        var pathToMethod = pathExtractor.ExtractPathsFromMethods(methods);

        // Log some examples for debugging
        if (logger.IsEnabled(LogLevel.Debug))
        {
            var examples = pathToMethod.Take(5);
            foreach (var (path, method) in examples)
            {
                logger.LogDebug("  {Path} -> {MethodName}", path, method.Name);
            }
        }

        return pathToMethod;
    }
}
