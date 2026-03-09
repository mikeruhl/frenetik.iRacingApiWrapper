using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Fetches raw JSON responses from iRacing API endpoints for model analysis
/// </summary>
public class ResponseFetcher(
    IHttpClientFactory httpClientFactory,
    IOptions<IRacingDataSettings> settings,
    ILogger<ResponseFetcher> logger)
{
    private readonly string _baseUrl = settings.Value.BaseUrl;

    /// <summary>
    /// Fetches the raw JSON for an endpoint path (e.g., "/series/seasons").
    /// Handles the link-following pattern used by most iRacing API endpoints.
    /// Returns null if the call fails (endpoint requires parameters, auth issues, etc.).
    /// </summary>
    public async Task<JsonElement?> FetchAsync(string apiPath)
    {
        // Ensure path starts with /
        var path = apiPath.StartsWith('/') ? apiPath : $"/{apiPath}";
        var url = $"{_baseUrl}/data{path}";

        try
        {
            logger.LogDebug("Fetching {Url}", url);

            // Use the auth-enabled named client for the initial call
            var client = httpClientFactory.CreateClient(IRacingApiService.HttpClientName);
            using var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogDebug("Endpoint {Path} returned {Status} — skipping response model check",
                    apiPath, response.StatusCode);
                return null;
            }

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            // Handle the iRacing link-following pattern:
            // Initial response is { "link": "https://s3.amazonaws.com/..." }
            if (json.ValueKind == JsonValueKind.Object &&
                json.TryGetProperty("link", out var linkProp))
            {
                var link = linkProp.GetString();
                if (!string.IsNullOrEmpty(link))
                {
                    logger.LogDebug("Following link for {Path}", apiPath);
                    using var linkedResponse = await client.GetAsync(link);
                    if (!linkedResponse.IsSuccessStatusCode) return null;
                    return await linkedResponse.Content.ReadFromJsonAsync<JsonElement>();
                }
            }

            return json;
        }
        catch (Exception ex)
        {
            logger.LogDebug("Failed to fetch {Path}: {Message}", apiPath, ex.Message);
            return null;
        }
    }
}
