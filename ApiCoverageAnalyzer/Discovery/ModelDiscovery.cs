using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Discovers model types and their properties
/// </summary>
public class ModelDiscovery
{
    private readonly ILogger<ModelDiscovery> _logger;

    public ModelDiscovery(ILogger<ModelDiscovery> logger)
    {
        _logger = logger;
    }

    // Will be implemented in Phase 3 for dynamic analysis
}
