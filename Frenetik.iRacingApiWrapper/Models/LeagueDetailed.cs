namespace Frenetik.iRacingApiWrapper.Models;

public class LeagueDetailed
{
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("about")]
    public string About { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("recruiting")]
    public bool Recruiting { get; set; }

    [JsonPropertyName("rules")]
    public string Rules { get; set; } = string.Empty;

    [JsonPropertyName("private_wall")]
    public bool PrivateWall { get; set; }

    [JsonPropertyName("private_roster")]
    public bool PrivateRoster { get; set; }

    [JsonPropertyName("private_schedule")]
    public bool PrivateSchedule { get; set; }

    [JsonPropertyName("private_results")]
    public bool PrivateResults { get; set; }

    [JsonPropertyName("is_owner")]
    public bool IsOwner { get; set; }

    [JsonPropertyName("is_admin")]
    public bool IsAdmin { get; set; }

    [JsonPropertyName("roster_count")]
    public int RosterCount { get; set; }

    [JsonPropertyName("owner")]
    public OwnerResult Owner { get; set; } = new OwnerResult();

    [JsonPropertyName("image")]
    public ImageResult Image { get; set; } = new ImageResult();

    [JsonPropertyName("tags")]
    public TagCategoryResult Tags { get; set; } = new TagCategoryResult();

    [JsonPropertyName("league_applications")]
    public List<object> LeagueApplications { get; set; } = new List<object>();
    //TODO: find above type

    [JsonPropertyName("pending_requests")]
    public List<object> PendingRequests { get; set; } = new List<object>();
    //TODO: find above type

    [JsonPropertyName("is_member")]
    public bool IsMember { get; set; }

    [JsonPropertyName("is_applicant")]
    public bool IsApplicant { get; set; }

    [JsonPropertyName("is_invite")]
    public bool IsInvite { get; set; }

    [JsonPropertyName("is_ignored")]
    public bool IsIgnored { get; set; }

    [JsonPropertyName("roster")]
    public List<RosterResult> Roster { get; set; } = new List<RosterResult>();


    public class OwnerResult
    {
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();

        [JsonPropertyName("car_number")]
        public int? CarNumber { get; set; }

        [JsonPropertyName("nick_name")]
        public string NickName { get; set; } = string.Empty;
    }

    public class ImageResult
    {
        [JsonPropertyName("small_logo")]
        public string SmallLogo { get; set; } = string.Empty;

        [JsonPropertyName("large_logo")]
        public string LargeLogo { get; set; } = string.Empty;
    }

    public class TagCategoryResult
    {
        [JsonPropertyName("categorized")]
        public List<Categorized> Categorized { get; set; } = new List<Categorized>();

        [JsonPropertyName("not_categorized")]
        public List<NotCategorized> NotCategorized { get; set; } = new List<NotCategorized>();
    }

    public class Categorized
    {
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("tags")]
        public List<TagCategoryResult> Tags { get; set; } = new List<TagCategoryResult>();
    }

    public class TagResult
    {
        [JsonPropertyName("tag_id")]
        public int TagId { get; set; }

        [JsonPropertyName("tag_name")]
        public string TagName { get; set; } = string.Empty;
    }

    public class NotCategorized
    {
        [JsonPropertyName("tag_id")]
        public int TagId { get; set; }

        [JsonPropertyName("tag_name")]
        public string TagName { get; set; } = string.Empty;
    }

    public class RosterResult
    {
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();

        [JsonPropertyName("owner")]
        public bool Owner { get; set; }

        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("league_mail_opt_out")]
        public bool LeagueMailOptOut { get; set; }

        [JsonPropertyName("league_pm_opt_out")]
        public bool LeaguePmOptOut { get; set; }

        [JsonPropertyName("league_member_since")]
        public DateTime LeagueMemberSince { get; set; }

        [JsonPropertyName("car_number")]
        public int? CarNumber { get; set; }

        [JsonPropertyName("nick_name")]
        public string? NickName { get; set; }
    }
}
