namespace Frenetik.iRacingApiWrapper.Models.MemberAwards;

/// <summary>
/// MemberAward
/// </summary>
public class MemberAward
{
    /// <summary>
    /// Member Award Id
    /// </summary>
    [JsonPropertyName("member_award_id")]
    public int MemberAwardId { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Award Id
    /// </summary>
    [JsonPropertyName("award_id")]
    public int AwardId { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Has Pdf
    /// </summary>
    [JsonPropertyName("has_pdf")]
    public bool HasPdf { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Icon Url Small
    /// </summary>
    [JsonPropertyName("icon_url_small")]
    public string IconUrlSmall { get; set; } = string.Empty;

    /// <summary>
    /// Icon Url Large
    /// </summary>
    [JsonPropertyName("icon_url_large")]
    public string IconUrlLarge { get; set; } = string.Empty;

    /// <summary>
    /// Icon Url Unawarded
    /// </summary>
    [JsonPropertyName("icon_url_unawarded")]
    public string IconUrlUnawarded { get; set; } = string.Empty;

    /// <summary>
    /// Icon Background Color
    /// </summary>
    [JsonPropertyName("icon_background_color")]
    public string IconBackgroundColor { get; set; } = string.Empty;

    /// <summary>
    /// Weight
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    /// <summary>
    /// Award Count
    /// </summary>
    [JsonPropertyName("award_count")]
    public int AwardCount { get; set; }

    /// <summary>
    /// Award Order
    /// </summary>
    [JsonPropertyName("award_order")]
    public int AwardOrder { get; set; }

    /// <summary>
    /// Achievement
    /// </summary>
    [JsonPropertyName("achievement")]
    public bool Achievement { get; set; }
}
