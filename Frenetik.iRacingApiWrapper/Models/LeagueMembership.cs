namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// LeagueMembership
/// </summary>
public class LeagueMembership
{
    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// League Name
    /// </summary>
    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

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
    /// League Mail Opt Out
    /// </summary>
    [JsonPropertyName("league_mail_opt_out")]
    public bool LeagueMailOptOut { get; set; }

    /// <summary>
    /// League Pm Opt Out
    /// </summary>
    [JsonPropertyName("league_pm_opt_out")]
    public bool LeaguePmOptOut { get; set; }

    /// <summary>
    /// Car Number
    /// </summary>
    [JsonPropertyName("car_number")]
    public int? CarNumber { get; set; }

    /// <summary>
    /// Nick Name
    /// </summary>
    [JsonPropertyName("nick_name")]
    public string? NickName { get; set; }
}

