namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// LookupLicenseResult
/// </summary>
public class LookupLicenseResult
{
    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Min Num Races
    /// </summary>
    [JsonPropertyName("min_num_races")]
    public int? MinNumRaces { get; set; }

    /// <summary>
    /// Participation Credits
    /// </summary>
    [JsonPropertyName("participation_credits")]
    public int ParticipationCredits { get; set; }

    /// <summary>
    /// Min Sr To Fast Track
    /// </summary>
    [JsonPropertyName("min_sr_to_fast_track")]
    public int? MinSrToFastTrack { get; set; }

    /// <summary>
    /// Levels
    /// </summary>
    [JsonPropertyName("levels")]
    public List<LicenseLevel> Levels { get; set; } = new List<LicenseLevel>();

    /// <summary>
    /// Min Num Tt
    /// </summary>
    [JsonPropertyName("min_num_tt")]
    public int? MinNumTt { get; set; }
}

/// <summary>
/// LicenseLevel
/// </summary>
public class LicenseLevel
{
    /// <summary>
    /// License Id
    /// </summary>
    [JsonPropertyName("license_id")]
    public int LicenseId { get; set; }

    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// License
    /// </summary>
    [JsonPropertyName("license")]
    public string License { get; set; } = string.Empty;

    /// <summary>
    /// Short Name
    /// </summary>
    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    /// <summary>
    /// License Letter
    /// </summary>
    [JsonPropertyName("license_letter")]
    public string LicenseLetter { get; set; } = string.Empty;

    /// <summary>
    /// Color
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;
}

