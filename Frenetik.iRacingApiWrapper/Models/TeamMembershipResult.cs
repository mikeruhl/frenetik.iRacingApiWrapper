namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Team Membership Result
/// </summary>
public class TeamMembershipResult
{
    /// <summary>
    /// Team Id
    /// </summary>
    [JsonPropertyName("team_id")]
    public int TeamId { get; set; }

    /// <summary>
    /// Team Name
    /// </summary>
    [JsonPropertyName("team_name")]
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Owner
    /// </summary>
    [JsonPropertyName("owner")]
    public bool Owner { get; set; }

    /// <summary>
    /// Admin
    /// </summary>
    [JsonPropertyName("admin")]
    public bool Admin { get; set; }

    /// <summary>
    /// Default Team
    /// </summary>
    [JsonPropertyName("default_team")]
    public bool DefaultTeam { get; set; }
}
