namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// TeamResult
/// </summary>
public class TeamResult
{
    /// <summary>
    /// Team Id
    /// </summary>
    [JsonPropertyName("team_id")]
    public int TeamId { get; set; }

    /// <summary>
    /// Owner Id
    /// </summary>
    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    /// <summary>
    /// Team Name
    /// </summary>
    [JsonPropertyName("team_name")]
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Created
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// Hidden
    /// </summary>
    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    /// <summary>
    /// About
    /// </summary>
    [JsonPropertyName("about")]
    public string About { get; set; } = string.Empty;

    /// <summary>
    /// Url
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Roster Count
    /// </summary>
    [JsonPropertyName("roster_count")]
    public int RosterCount { get; set; }

    /// <summary>
    /// Recruiting
    /// </summary>
    [JsonPropertyName("recruiting")]
    public bool Recruiting { get; set; }

    /// <summary>
    /// Private Wall
    /// </summary>
    [JsonPropertyName("private_wall")]
    public bool PrivateWall { get; set; }

    /// <summary>
    /// Is Default
    /// </summary>
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// Is Owner
    /// </summary>
    [JsonPropertyName("is_owner")]
    public bool IsOwner { get; set; }

    /// <summary>
    /// Is Admin
    /// </summary>
    [JsonPropertyName("is_admin")]
    public bool IsAdmin { get; set; }

    /// <summary>
    /// Suit
    /// </summary>
    [JsonPropertyName("suit")]
    public TeamGetResultSuit Suit { get; set; } = new TeamGetResultSuit();

    /// <summary>
    /// Owner
    /// </summary>
    [JsonPropertyName("owner")]
    public TeamGetResultOwner Owner { get; set; } = new TeamGetResultOwner();

    /// <summary>
    /// Tags
    /// </summary>
    [JsonPropertyName("tags")]
    public TeamGetResultTags Tags { get; set; } = new TeamGetResultTags();

    //TODO: GET TeamApplications and PendingRequests schemas
    /// <summary>
    /// Team Applications
    /// </summary>
    [JsonPropertyName("team_applications")]
    public List<object> TeamApplications { get; set; } = new List<object>();

    /// <summary>
    /// Pending Requests
    /// </summary>
    [JsonPropertyName("pending_requests")]
    public List<object> PendingRequests { get; set; } = new List<object>();

    /// <summary>
    /// Is Member
    /// </summary>
    [JsonPropertyName("is_member")]
    public bool IsMember { get; set; }

    /// <summary>
    /// Is Applicant
    /// </summary>
    [JsonPropertyName("is_applicant")]
    public bool IsApplicant { get; set; }

    /// <summary>
    /// Is Invite
    /// </summary>
    [JsonPropertyName("is_invite")]
    public bool IsInvite { get; set; }

    /// <summary>
    /// Is Ignored
    /// </summary>
    [JsonPropertyName("is_ignored")]
    public bool IsIgnored { get; set; }

    /// <summary>
    /// Roster
    /// </summary>
    [JsonPropertyName("roster")]
    public List<TeamGetResultRoster> Roster { get; set; } = new List<TeamGetResultRoster>();
}

/// <summary>
/// TeamGetResultSuit
/// </summary>
public class TeamGetResultSuit
{
    /// <summary>
    /// Pattern
    /// </summary>
    [JsonPropertyName("pattern")]
    public int Pattern { get; set; }

    /// <summary>
    /// Color1
    /// </summary>
    [JsonPropertyName("color1")]
    public string Color1 { get; set; } = string.Empty;

    /// <summary>
    /// Color2
    /// </summary>
    [JsonPropertyName("color2")]
    public string Color2 { get; set; } = string.Empty;

    /// <summary>
    /// Color3
    /// </summary>
    [JsonPropertyName("color3")]
    public string Color3 { get; set; } = string.Empty;
}

/// <summary>
/// TeamGetResultOwner
/// </summary>
public class TeamGetResultOwner
{
    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    /// <summary>
    /// Owner
    /// </summary>
    [JsonPropertyName("owner")]
    public bool IsOwner { get; set; }

    /// <summary>
    /// Admin
    /// </summary>
    [JsonPropertyName("admin")]
    public bool IsAdmin { get; set; }
}

//TODO: Get schemas for categoried and notcategorized
/// <summary>
/// TeamGetResultTags
/// </summary>
public class TeamGetResultTags
{
    /// <summary>
    /// Categorized
    /// </summary>
    [JsonPropertyName("categorized")]
    public List<object> Categorized { get; set; } = new List<object>();

    /// <summary>
    /// Not Categorized
    /// </summary>
    [JsonPropertyName("not_categorized")]
    public List<object> NotCategorized { get; set; } = new List<object>();
}

/// <summary>
/// TeamGetResultRoster
/// </summary>
public class TeamGetResultRoster
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
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    /// <summary>
    /// Owner
    /// </summary>
    [JsonPropertyName("owner")]
    public bool IsOwner { get; set; }

    /// <summary>
    /// Admin
    /// </summary>
    [JsonPropertyName("admin")]
    public bool IsAdmin { get; set; }
}

