namespace Frenetik.iRacingApiWrapper.Models;
public class MemberAward
{
    [JsonPropertyName("member_award_id")]
    public int MemberAwardId { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("award_id")]
    public int AwardId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("pdf_url")]
    public string PdfUrl { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("icon_url_small")]
    public string IconUrlSmall { get; set; } = string.Empty;

    [JsonPropertyName("icon_url_large")]
    public string IconUrlLarge { get; set; } = string.Empty;

    [JsonPropertyName("icon_url_unawarded")]
    public string IconUrlUnawarded { get; set; } = string.Empty;

    [JsonPropertyName("icon_background_color")]
    public string IconBackgroundColor { get; set; } = string.Empty;

    [JsonPropertyName("certificate_file_name")]
    public string CertificateFileName { get; set; } = string.Empty;

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("award_count")]
    public int AwardCount { get; set; }

    [JsonPropertyName("award_order")]
    public int AwardOrder { get; set; }

    [JsonPropertyName("achievement")]
    public bool Achievement { get; set; }
}
