namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Error response from iRacing API
/// </summary>
internal class ErrorResponse
{
    /// <summary>
    /// Error code
    /// </summary>
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;

    /// <summary>
    /// Error message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}

