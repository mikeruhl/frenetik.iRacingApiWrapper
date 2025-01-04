namespace Frenetik.iRacingApiWrapper.Models;
public class LeagueMembership
{
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

    [JsonPropertyName("owner")]
    public bool Owner { get; set; }

    [JsonPropertyName("admin")]
    public bool Admin { get; set; }

    [JsonPropertyName("league_mail_opt_out")]
    public bool LeagueMailOptOut { get; set; }

    [JsonPropertyName("league_pm_opt_out")]
    public bool LeaguePmOptOut { get; set; }

    [JsonPropertyName("car_number")]
    public int? CarNumber { get; set; }

    [JsonPropertyName("nick_name")]
    public string? NickName { get; set; }
}
