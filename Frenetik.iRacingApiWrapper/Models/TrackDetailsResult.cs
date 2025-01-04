namespace Frenetik.iRacingApiWrapper.Models;

public class TrackDetailsResult
{
    [JsonPropertyName("coordinates")]
    public string Coordinates { get; set; } = string.Empty;

    [JsonPropertyName("detail_copy")]
    public string DetailCopy { get; set; } = string.Empty;

    [JsonPropertyName("detail_techspecs_copy")]
    public string DetailTechSpecsCopy { get; set; } = string.Empty;

    [JsonPropertyName("detail_video")]
    public string DetailVideo { get; set; } = string.Empty;

    [JsonPropertyName("folder")]
    public string Folder { get; set; } = string.Empty;

    [JsonPropertyName("gallery_images")]
    public string GalleryImages { get; set; } = string.Empty;

    [JsonPropertyName("gallery_prefix")]
    public string GalleryPrefix { get; set; } = string.Empty;

    [JsonPropertyName("large_image")]
    public string LargeImage { get; set; } = string.Empty;

    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;

    [JsonPropertyName("north")]
    public string North { get; set; } = string.Empty;

    [JsonPropertyName("num_svg_images")]
    public int NumSvgImages { get; set; }

    [JsonPropertyName("small_image")]
    public string SmallImage { get; set; } = string.Empty;

    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_map")]
    public string TrackMap { get; set; } = string.Empty;

    [JsonPropertyName("track_map_layers")]
    public TrackMapLayers TrackMapLayers { get; set; } = new TrackMapLayers();
}

public class TrackMapLayers
{
    [JsonPropertyName("background")]
    public string Background { get; set; } = string.Empty;

    [JsonPropertyName("inactive")]
    public string Inactive { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    public string Active { get; set; } = string.Empty;

    [JsonPropertyName("pitroad")]
    public string PitRoad { get; set; } = string.Empty;

    [JsonPropertyName("start-finish")]
    public string StartFinish { get; set; } = string.Empty;

    [JsonPropertyName("turns")]
    public string Turns { get; set; } = string.Empty;
}
