namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Error response from iRacing API
/// </summary>
internal class ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
