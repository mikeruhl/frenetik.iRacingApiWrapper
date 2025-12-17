namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Interface for providing bearer tokens to the iRacing API client.
/// Implementations should handle OAuth token acquisition, caching, and refresh logic.
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Gets a valid bearer token for authenticating requests to the iRacing API.
    /// This method will be called for each request, so implementations should cache tokens
    /// and only refresh when necessary.
    /// </summary>
    /// <returns>A valid bearer token</returns>
    Task<string> GetTokenAsync();
}
