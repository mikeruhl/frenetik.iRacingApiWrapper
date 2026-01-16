namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// SeriesAsset
/// </summary>
public class SeriesAsset
{
    /// <summary>
    /// Large Image
    /// </summary>
    [JsonPropertyName("large_image")]
    public string? LargeImage { get; set; }

    /// <summary>
    /// Logo
    /// </summary>
    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;

    /// <summary>
    /// Series Copy
    /// </summary>
    [JsonPropertyName("series_copy")]
    public string SeriesCopy { get; set; } = string.Empty;

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Small Image
    /// </summary>
    [JsonPropertyName("small_image")]
    public string? SmallImage { get; set; }
}

