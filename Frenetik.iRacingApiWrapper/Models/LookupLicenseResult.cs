namespace Frenetik.iRacingApiWrapper.Models;

public class LookupLicenseResult
{
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("min_num_races")]
    public int? MinNumRaces { get; set; }

    [JsonPropertyName("participation_credits")]
    public int ParticipationCredits { get; set; }

    [JsonPropertyName("min_sr_to_fast_track")]
    public int? MinSrToFastTrack { get; set; }

    [JsonPropertyName("levels")]
    public List<LicenseLevel> Levels { get; set; } = new List<LicenseLevel>();

    [JsonPropertyName("min_num_tt")]
    public int? MinNumTt { get; set; }
}

public class LicenseLevel
{
    [JsonPropertyName("license_id")]
    public int LicenseId { get; set; }

    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    [JsonPropertyName("license")]
    public string License { get; set; } = string.Empty;

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("license_letter")]
    public string LicenseLetter { get; set; } = string.Empty;

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;
}
