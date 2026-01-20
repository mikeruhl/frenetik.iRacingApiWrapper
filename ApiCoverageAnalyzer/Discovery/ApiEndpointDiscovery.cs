using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Models;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Discovers API endpoints using GetDoc()
/// </summary>
public class ApiEndpointDiscovery
{
    private readonly IRacingApiService _apiService;
    private readonly ILogger<ApiEndpointDiscovery> _logger;

    public ApiEndpointDiscovery(
        IRacingApiService apiService,
        ILogger<ApiEndpointDiscovery> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    /// <summary>
    /// Discover all API endpoints from GetDoc()
    /// </summary>
    public async Task<Dictionary<string, EndpointDetails>> DiscoverAsync()
    {
        _logger.LogInformation("Fetching API documentation via GetDoc()...");

        var doc = await _apiService.GetDoc();

        // Flatten the nested dictionary structure
        var endpoints = new Dictionary<string, EndpointDetails>();

        foreach (var category in doc)
        {
            foreach (var endpoint in category.Value)
            {
                endpoints[$"{category.Key}/{endpoint.Key}"] = endpoint.Value;
            }
        }

        _logger.LogInformation("Discovered {Count} endpoints from API documentation", endpoints.Count);

        return endpoints;
    }
}
