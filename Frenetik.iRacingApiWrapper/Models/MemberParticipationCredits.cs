namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// MemberParticipationCredits
/// </summary>
public class MemberParticipationCredits
{
    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Series Name
    /// </summary>
    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// License Group Name
    /// </summary>
    [JsonPropertyName("license_group_name")]
    public string LicenseGroupName { get; set; } = string.Empty;

    /// <summary>
    /// Participation Credits
    /// </summary>
    [JsonPropertyName("participation_credits")]
    public int ParticipationCredits { get; set; }

    /// <summary>
    /// Min Weeks
    /// </summary>
    [JsonPropertyName("min_weeks")]
    public int MinimumWeeks { get; set; }

    /// <summary>
    /// Weeks
    /// </summary>
    [JsonPropertyName("weeks")]
    public int Weeks { get; set; }

    /// <summary>
    /// Earned Credits
    /// </summary>
    [JsonPropertyName("earned_credits")]
    public int EarnedCredits { get; set; }

    /// <summary>
    /// Total Credits
    /// </summary>
    [JsonPropertyName("total_credits")]
    public int TotalCredits { get; set; }
}

