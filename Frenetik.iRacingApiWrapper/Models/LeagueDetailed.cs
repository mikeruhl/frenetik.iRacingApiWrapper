namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// LeagueDetailed
/// </summary>
public class LeagueDetailed
{
    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// Owner Id
    /// </summary>
    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    /// <summary>
    /// League Name
    /// </summary>
    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

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
    /// Message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

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
    /// Recruiting
    /// </summary>
    [JsonPropertyName("recruiting")]
    public bool Recruiting { get; set; }

    /// <summary>
    /// Rules
    /// </summary>
    [JsonPropertyName("rules")]
    public string Rules { get; set; } = string.Empty;

    /// <summary>
    /// Private Wall
    /// </summary>
    [JsonPropertyName("private_wall")]
    public bool PrivateWall { get; set; }

    /// <summary>
    /// Private Roster
    /// </summary>
    [JsonPropertyName("private_roster")]
    public bool PrivateRoster { get; set; }

    /// <summary>
    /// Private Schedule
    /// </summary>
    [JsonPropertyName("private_schedule")]
    public bool PrivateSchedule { get; set; }

    /// <summary>
    /// Private Results
    /// </summary>
    [JsonPropertyName("private_results")]
    public bool PrivateResults { get; set; }

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
    /// Roster Count
    /// </summary>
    [JsonPropertyName("roster_count")]
    public int RosterCount { get; set; }

    /// <summary>
    /// Owner
    /// </summary>
    [JsonPropertyName("owner")]
    public OwnerResult Owner { get; set; } = new OwnerResult();

    /// <summary>
    /// Image
    /// </summary>
    [JsonPropertyName("image")]
    public ImageResult Image { get; set; } = new ImageResult();

    /// <summary>
    /// Tags
    /// </summary>
    [JsonPropertyName("tags")]
    public TagCategoryResult Tags { get; set; } = new TagCategoryResult();

    /// <summary>
    /// League Applications
    /// </summary>
    [JsonPropertyName("league_applications")]
    public List<object> LeagueApplications { get; set; } = new List<object>();
    //TODO: find above type

    /// <summary>
    /// Pending Requests
    /// </summary>
    [JsonPropertyName("pending_requests")]
    public List<object> PendingRequests { get; set; } = new List<object>();
    //TODO: find above type

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
    public List<RosterResult> Roster { get; set; } = new List<RosterResult>();


    /// <summary>
    /// OwnerResult
    /// </summary>
    public class OwnerResult
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
        /// Car Number
        /// </summary>
        [JsonPropertyName("car_number")]
        public int? CarNumber { get; set; }

        /// <summary>
        /// Nick Name
        /// </summary>
        [JsonPropertyName("nick_name")]
        public string NickName { get; set; } = string.Empty;
    }

    /// <summary>
    /// ImageResult
    /// </summary>
    public class ImageResult
    {
        /// <summary>
        /// Small Logo
        /// </summary>
        [JsonPropertyName("small_logo")]
        public string SmallLogo { get; set; } = string.Empty;

        /// <summary>
        /// Large Logo
        /// </summary>
        [JsonPropertyName("large_logo")]
        public string LargeLogo { get; set; } = string.Empty;
    }

    /// <summary>
    /// TagCategoryResult
    /// </summary>
    public class TagCategoryResult
    {
        /// <summary>
        /// Categorized
        /// </summary>
        [JsonPropertyName("categorized")]
        public List<Categorized> Categorized { get; set; } = new List<Categorized>();

        /// <summary>
        /// Not Categorized
        /// </summary>
        [JsonPropertyName("not_categorized")]
        public List<NotCategorized> NotCategorized { get; set; } = new List<NotCategorized>();
    }

    /// <summary>
    /// Categorized
    /// </summary>
    public class Categorized
    {
        /// <summary>
        /// Category Id
        /// </summary>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        [JsonPropertyName("tags")]
        public List<TagCategoryResult> Tags { get; set; } = new List<TagCategoryResult>();
    }

    /// <summary>
    /// TagResult
    /// </summary>
    public class TagResult
    {
        /// <summary>
        /// Tag Id
        /// </summary>
        [JsonPropertyName("tag_id")]
        public int TagId { get; set; }

        /// <summary>
        /// Tag Name
        /// </summary>
        [JsonPropertyName("tag_name")]
        public string TagName { get; set; } = string.Empty;
    }

    /// <summary>
    /// NotCategorized
    /// </summary>
    public class NotCategorized
    {
        /// <summary>
        /// Tag Id
        /// </summary>
        [JsonPropertyName("tag_id")]
        public int TagId { get; set; }

        /// <summary>
        /// Tag Name
        /// </summary>
        [JsonPropertyName("tag_name")]
        public string TagName { get; set; } = string.Empty;
    }

    /// <summary>
    /// RosterResult
    /// </summary>
    public class RosterResult
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
        /// League Member Since
        /// </summary>
        [JsonPropertyName("league_member_since")]
        public DateTime LeagueMemberSince { get; set; }

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
}

