using Frenetik.iRacingApiWrapper;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Discovers model types in the wrapper assembly that have JSON property mappings
/// </summary>
public class ModelDiscovery(ILogger<ModelDiscovery> logger)
{
    private static readonly Assembly WrapperAssembly = typeof(IRacingApiService).Assembly;

    /// <summary>
    /// Discovers all public model types in the wrapper assembly that have at least one
    /// [JsonPropertyName]-annotated property.
    /// </summary>
    public IReadOnlyDictionary<string, Type> DiscoverModelTypes()
    {
        logger.LogDebug("Discovering model types in {Assembly}", WrapperAssembly.GetName().Name);

        var types = WrapperAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsPublic &&
                        t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         .Any(p => p.GetCustomAttribute<JsonPropertyNameAttribute>() != null))
            .ToDictionary(t => t.Name, t => t, StringComparer.OrdinalIgnoreCase);

        logger.LogInformation("Discovered {Count} model types", types.Count);
        return types;
    }
}
