namespace Frenetik.iRacingApiWrapper.Models;
public class SeriesAsset
{
    [JsonPropertyName("large_image")]
    public string? LargeImage { get; set; }

    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;

    [JsonPropertyName("series_copy")]
    public string SeriesCopy { get; set; } = string.Empty;

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("small_image")]
    public string? SmallImage { get; set; }
}
