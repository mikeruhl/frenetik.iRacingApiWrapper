namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// League Roster Result
/// </summary>
public class LeagueRosterResult
{
    /// <summary>
    /// Indicates whether the league roster is private
    /// </summary>
    [JsonPropertyName("private_roster")]
    public bool PrivateRoster { get; set; }

    /// <summary>
    /// List of league roster members
    /// </summary>
    [JsonPropertyName("roster")]
    public List<LeagueRosterMember> Roster { get; set; } = new List<LeagueRosterMember>();

    /// <summary>
    /// League Roster Member
    /// </summary>
    public class LeagueRosterMember
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Helmet customization
        /// </summary>
        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();

        /// <summary>
        /// Indicates whether the member is the league owner
        /// </summary>
        [JsonPropertyName("owner")]
        public bool Owner { get; set; }

        /// <summary>
        /// Indicates whether the member is a league admin
        /// </summary>
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        /// <summary>
        /// Indicates whether the member has opted out of league mail
        /// </summary>
        [JsonPropertyName("league_mail_opt_out")]
        public bool LeagueMailOptOut { get; set; }

        /// <summary>
        /// Indicates whether the member has opted out of league private messages
        /// </summary>
        [JsonPropertyName("league_pm_opt_out")]
        public bool LeaguePmOptOut { get; set; }

        /// <summary>
        /// Date and time when the member joined the league
        /// </summary>
        [JsonPropertyName("league_member_since")]
        public DateTime LeagueMemberSince { get; set; }

        /// <summary>
        /// Car number assigned to the member
        /// </summary>
        [JsonPropertyName("car_number")]
        public string? CarNumber { get; set; }

        /// <summary>
        /// Nickname of the member
        /// </summary>
        [JsonPropertyName("nick_name")]
        public string? NickName { get; set; }
    }
}
