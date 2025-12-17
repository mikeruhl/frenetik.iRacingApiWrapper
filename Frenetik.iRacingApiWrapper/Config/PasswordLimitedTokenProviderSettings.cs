namespace Frenetik.iRacingApiWrapper.Config;

/// <summary>
/// Configuration settings for the Password Limited OAuth grant flow
/// </summary>
public class PasswordLimitedTokenProviderSettings
{
    /// <summary>
    /// OAuth token endpoint URL
    /// </summary>
    public string TokenEndpoint { get; set; } = "https://oauth.iracing.com/oauth2/token";

    /// <summary>
    /// Client identifier issued during client registration
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Client secret issued during client registration
    /// </summary>
    public string ClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// User's email address or other issued identifier
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// User's password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// OAuth scope to request (e.g., "iracing.auth")
    /// </summary>
    public string? Scope { get; set; } = "iracing.auth";
}
