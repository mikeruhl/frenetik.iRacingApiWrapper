namespace Frenetik.iRacingApiWrapper.Models;

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

    /// <summary>
    /// Response of array inside awards
    /// </summary>
    public class AwardInstanceAward
    {
        /// <summary>
        /// Member Award Id
        /// </summary>
        [JsonPropertyName("member_award_id")]
        public int MemberAwardId { get; set; }

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
        /// Award Order
        /// </summary>
        [JsonPropertyName("award_order")]
        public int AwardOrder { get; set; }
    }
}
