namespace Frenetik.iRacingApiWrapper.Models;

public class TeamResult
{
    [JsonPropertyName("team_id")]
    public int TeamId { get; set; }

    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    [JsonPropertyName("team_name")]
    public string TeamName { get; set; } = string.Empty;

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("roster_count")]
    public int RosterCount { get; set; }

    [JsonPropertyName("recruiting")]
    public bool Recruiting { get; set; }

    [JsonPropertyName("private_wall")]
    public bool PrivateWall { get; set; }

    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("is_owner")]
    public bool IsOwner { get; set; }

    [JsonPropertyName("is_admin")]
    public bool IsAdmin { get; set; }

    [JsonPropertyName("suit")]
    public TeamGetResultSuit Suit { get; set; } = new TeamGetResultSuit();

    [JsonPropertyName("owner")]
    public TeamGetResultOwner Owner { get; set; } = new TeamGetResultOwner();

    [JsonPropertyName("tags")]
    public TeamGetResultTags Tags { get; set; } = new TeamGetResultTags();

    //TODO: GET TeamApplications and PendingRequests schemas
    [JsonPropertyName("team_applications")]
    public List<object> TeamApplications { get; set; } = new List<object>();

    [JsonPropertyName("pending_requests")]
    public List<object> PendingRequests { get; set; } = new List<object>();

    [JsonPropertyName("is_member")]
    public bool IsMember { get; set; }

    [JsonPropertyName("is_applicant")]
    public bool IsApplicant { get; set; }

    [JsonPropertyName("is_invite")]
    public bool IsInvite { get; set; }

    [JsonPropertyName("is_ignored")]
    public bool IsIgnored { get; set; }

    [JsonPropertyName("roster")]
    public List<TeamGetResultRoster> Roster { get; set; } = new List<TeamGetResultRoster>();
}

public class TeamGetResultSuit
{
    [JsonPropertyName("pattern")]
    public int Pattern { get; set; }

    [JsonPropertyName("color1")]
    public string Color1 { get; set; } = string.Empty;

    [JsonPropertyName("color2")]
    public string Color2 { get; set; } = string.Empty;

    [JsonPropertyName("color3")]
    public string Color3 { get; set; } = string.Empty;
}

public class TeamGetResultOwner
{
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    [JsonPropertyName("owner")]
    public bool IsOwner { get; set; }

    [JsonPropertyName("admin")]
    public bool IsAdmin { get; set; }
}

//TODO: Get schemas for categoried and notcategorized
public class TeamGetResultTags
{
    [JsonPropertyName("categorized")]
    public List<object> Categorized { get; set; } = new List<object>();

    [JsonPropertyName("not_categorized")]
    public List<object> NotCategorized { get; set; } = new List<object>();
}

public class TeamGetResultRoster
{
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    [JsonPropertyName("owner")]
    public bool IsOwner { get; set; }

    [JsonPropertyName("admin")]
    public bool IsAdmin { get; set; }
}
