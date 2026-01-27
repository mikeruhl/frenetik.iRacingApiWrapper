using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Models;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Discovers API endpoints using GetDoc()
/// </summary>
public class ApiEndpointDiscovery(
    IRacingApiService apiService,
    ILogger<ApiEndpointDiscovery> logger)
{

    /// <summary>
    /// Discover all API endpoints from GetDoc()
    /// </summary>
    public async Task<Dictionary<string, EndpointDetails>> DiscoverAsync()
    {
        logger.LogInformation("Fetching API documentation via GetDoc()...");

        var doc = await apiService.GetDoc();

        // Flatten the nested dictionary structure
        var endpoints = new Dictionary<string, EndpointDetails>();

        foreach (var category in doc)
        {
            foreach (var endpoint in category.Value)
            {
                endpoints[$"{category.Key}/{endpoint.Key}"] = endpoint.Value;
            }
        }

        logger.LogInformation("Discovered {Count} endpoints from API documentation", endpoints.Count);

        return endpoints;
    }
}
