using System.Text.Json.Serialization;

namespace Frenetik.iRacingApiWrapper.SnapshotTests.Infrastructure;

public class Snapshot
{
    [JsonPropertyName("endpoint")]
    public required string Endpoint { get; init; }

    [JsonPropertyName("method")]
    public required string Method { get; init; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("responseJson")]
    public string? ResponseJson { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }
}
