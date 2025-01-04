namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Car Asset
/// </summary>
/// <remarks>image paths are relative to https://images-static.iracing.com/</remarks>
public class CarAsset
{
    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Car Rules
    /// </summary>
    [JsonPropertyName("car_rules")]
    public List<CarRule> CarRules { get; set; } = new List<CarRule>();

    /// <summary>
    /// Detail Copy
    /// </summary>
    [JsonPropertyName("detail_copy")]
    public string DetailCopy { get; set; } = string.Empty;

    /// <summary>
    /// Comma-Separated Values of Detail Screen Shot Images
    /// </summary>
    [JsonPropertyName("detail_screen_shot_images")]
    public string DetailScreenShotImages { get; set; } = string.Empty;

    /// <summary>
    /// Detail Tech Specs Copy (HTML)
    /// </summary>
    [JsonPropertyName("detail_tech_specs_copy")]
    public string DetailTechSpecsCopy { get; set; } = string.Empty;

    /// <summary>
    /// Folder assets are stored in
    /// </summary>
    [JsonPropertyName("folder")]
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Gallery Images
    /// </summary>
    [JsonPropertyName("gallery_images")]
    public string GalleryImages { get; set; } = string.Empty;

    /// <summary>
    /// Gallery Prefix (appears unused)
    /// </summary>
    [JsonPropertyName("gallery_prefix")]
    public string GalleryPrefix { get; set; } = string.Empty;

    /// <summary>
    /// Group Image (appears unused)
    /// </summary>
    [JsonPropertyName("group_image")]
    public string GroupImage { get; set; } = string.Empty;

    /// <summary>
    /// Group Name (appears unused)
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

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
    /// Small Image
    /// </summary>
    [JsonPropertyName("small_image")]
    public string SmallImage { get; set; } = string.Empty;

    /// <summary>
    /// Sponsor Logo
    /// </summary>
    [JsonPropertyName("sponsor_logo")]
    public string SponsorLogo { get; set; } = string.Empty;

    /// <summary>
    /// Template Path
    /// </summary>
    [JsonPropertyName("template_path")]
    public string TemplatePath { get; set; } = string.Empty;

}
