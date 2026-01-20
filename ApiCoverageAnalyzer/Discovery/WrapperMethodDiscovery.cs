using Frenetik.iRacingApiWrapper;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Discovers wrapper methods via reflection and extracts their API paths
/// </summary>
public class WrapperMethodDiscovery
{
    private readonly ILogger<WrapperMethodDiscovery> _logger;


    public WrapperMethodDiscovery(ILogger<WrapperMethodDiscovery> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Discover all wrapper methods and map them to their API paths
    /// </summary>
    public Dictionary<string, MethodInfo> Discover()
    {
        _logger.LogInformation("Discovering wrapper methods via reflection...");

        // Get the implementation type (IRacingApiService) instead of the interface
        // because we need the actual method bodies to extract paths
        var implementationType = typeof(IRacingApiService);
        var methods = implementationType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => !m.IsSpecialName &&
                        m.Name != "GetDoc" &&
                        m.DeclaringType == implementationType) // Only methods declared in IRacingApiService
            .ToList();

        _logger.LogInformation("Discovered {Count} wrapper methods", methods.Count);

        // Extract paths from IL code
        var pathToMethod = MethodPathExtractor.ExtractPathsFromMethods(methods);

        _logger.LogInformation("Extracted paths from {Count} methods", pathToMethod.Count);

        // Log some examples for debugging
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            var examples = pathToMethod.Take(5);
            foreach (var (path, method) in examples)
            {
                _logger.LogDebug("  {Path} -> {MethodName}", path, method.Name);
            }
        }

        return pathToMethod;
    }
}
