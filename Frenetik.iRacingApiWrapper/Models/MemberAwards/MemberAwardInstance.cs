namespace Frenetik.iRacingApiWrapper.Models.MemberAwards;

/// <summary>
/// Data Response Body
/// </summary>
public partial class MemberAwardInstance
{
    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Award Id
    /// </summary>
    [JsonPropertyName("award_id")]
    public int AwardId { get; set; }

    /// <summary>
    /// Achievement
    /// </summary>
    [JsonPropertyName("achievement")]
    public bool Achievement { get; set; }

    /// <summary>
    /// Award Count
    /// </summary>
    [JsonPropertyName("award_count")]
    public int AwardCount { get; set; }

    /// <summary>
    /// Awards
    /// </summary>
    [JsonPropertyName("awards")]
    public List<AwardInstanceAward> Awards { get; set; } = [];
}
