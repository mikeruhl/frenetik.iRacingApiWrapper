namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// TrackDetailsResult
/// </summary>
public class TrackDetailsResult
{
    /// <summary>
    /// Coordinates
    /// </summary>
    [JsonPropertyName("coordinates")]
    public string Coordinates { get; set; } = string.Empty;

    /// <summary>
    /// Detail Copy
    /// </summary>
    [JsonPropertyName("detail_copy")]
    public string DetailCopy { get; set; } = string.Empty;

    /// <summary>
    /// Detail Techspecs Copy
    /// </summary>
    [JsonPropertyName("detail_techspecs_copy")]
    public string DetailTechSpecsCopy { get; set; } = string.Empty;

    /// <summary>
    /// Detail Video
    /// </summary>
    [JsonPropertyName("detail_video")]
    public string DetailVideo { get; set; } = string.Empty;

    /// <summary>
    /// Folder
    /// </summary>
    [JsonPropertyName("folder")]
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Gallery Images
    /// </summary>
    [JsonPropertyName("gallery_images")]
    public string GalleryImages { get; set; } = string.Empty;

    /// <summary>
    /// Gallery Prefix
    /// </summary>
    [JsonPropertyName("gallery_prefix")]
    public string GalleryPrefix { get; set; } = string.Empty;

    /// <summary>
    /// Large Image
    /// </summary>
    [JsonPropertyName("large_image")]
    public string LargeImage { get; set; } = string.Empty;

    /// <summary>
    /// Logo
    /// </summary>
    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;

    /// <summary>
    /// North
    /// </summary>
    [JsonPropertyName("north")]
    public string North { get; set; } = string.Empty;

    /// <summary>
    /// Num Svg Images
    /// </summary>
    [JsonPropertyName("num_svg_images")]
    public int NumSvgImages { get; set; }

    /// <summary>
    /// Small Image
    /// </summary>
    [JsonPropertyName("small_image")]
    public string SmallImage { get; set; } = string.Empty;

    /// <summary>
    /// Track Id
    /// </summary>
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    /// <summary>
    /// Track Map
    /// </summary>
    [JsonPropertyName("track_map")]
    public string TrackMap { get; set; } = string.Empty;

    /// <summary>
    /// Track Map Layers
    /// </summary>
    [JsonPropertyName("track_map_layers")]
    public TrackMapLayers TrackMapLayers { get; set; } = new TrackMapLayers();
}

/// <summary>
/// TrackMapLayers
/// </summary>
public class TrackMapLayers
{
    /// <summary>
    /// Background
    /// </summary>
    [JsonPropertyName("background")]
    public string Background { get; set; } = string.Empty;

    /// <summary>
    /// Inactive
    /// </summary>
    [JsonPropertyName("inactive")]
    public string Inactive { get; set; } = string.Empty;

    /// <summary>
    /// Active
    /// </summary>
    [JsonPropertyName("active")]
    public string Active { get; set; } = string.Empty;

    /// <summary>
    /// Pitroad
    /// </summary>
    [JsonPropertyName("pitroad")]
    public string PitRoad { get; set; } = string.Empty;

    /// <summary>
    /// Start-Finish
    /// </summary>
    [JsonPropertyName("start-finish")]
    public string StartFinish { get; set; } = string.Empty;

    /// <summary>
    /// Turns
    /// </summary>
    [JsonPropertyName("turns")]
    public string Turns { get; set; } = string.Empty;
}

