namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Represents a league in iRacing
/// </summary>
public class League
{
    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// Owner's Customer Id
    /// </summary>
    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    /// <summary>
    /// League name
    /// </summary>
    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

    /// <summary>
    /// Creation date
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// About/description text
    /// </summary>
    [JsonPropertyName("about")]
    public string About { get; set; } = string.Empty;

    /// <summary>
    /// League website URL
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Number of members
    /// </summary>
    [JsonPropertyName("roster_count")]
    public int RosterCount { get; set; }

    /// <summary>
    /// Whether league is recruiting
    /// </summary>
    [JsonPropertyName("recruiting")]
    public bool Recruiting { get; set; }

    /// <summary>
    /// Whether user is admin
    /// </summary>
    [JsonPropertyName("is_admin")]
    public bool IsAdmin { get; set; }

    /// <summary>
    /// Whether user is member
    /// </summary>
    [JsonPropertyName("is_member")]
    public bool IsMember { get; set; }

    /// <summary>
    /// Whether user has pending application
    /// </summary>
    [JsonPropertyName("pending_application")]
    public bool PendingApplication { get; set; }

    /// <summary>
    /// Whether user has pending invitation
    /// </summary>
    [JsonPropertyName("pending_invitation")]
    public bool PendingInvitation { get; set; }

    /// <summary>
    /// League owner details
    /// </summary>
    [JsonPropertyName("owner")]
    public OwnerResult Owner { get; set; } = new OwnerResult();

    /// <summary>
    /// League owner information
    /// </summary>
    public class OwnerResult
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Helmet customization
        /// </summary>
        [JsonPropertyName("helmet")]
        public HelmetResult Helmet { get; set; } = new HelmetResult();

        /// <summary>
        /// Car number
        /// </summary>
        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        /// <summary>
        /// Nickname
        /// </summary>
        [JsonPropertyName("nick_name")]
        public string NickName { get; set; } = string.Empty;
    }

    /// <summary>
    /// Helmet customization details
    /// </summary>
    public class HelmetResult
    {
        /// <summary>
        /// Helmet pattern Id
        /// </summary>
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        /// <summary>
        /// Primary color
        /// </summary>
        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        /// <summary>
        /// Secondary color
        /// </summary>
        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        /// <summary>
        /// Tertiary color
        /// </summary>
        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        /// <summary>
        /// Face type Id
        /// </summary>
        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        /// <summary>
        /// Helmet type Id
        /// </summary>
        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }
}



