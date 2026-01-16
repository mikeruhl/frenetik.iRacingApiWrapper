namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// MemberProfile
/// </summary>
public class MemberProfile
{
    /// <summary>
    /// Recent Awards
    /// </summary>
    [JsonPropertyName("recent_awards")]
    public List<RecentAward> RecentAwards { get; set; } = new List<RecentAward>();

    /// <summary>
    /// Activity
    /// </summary>
    [JsonPropertyName("activity")]
    public Activity Activity { get; set; } = new Activity();

    /// <summary>
    /// Image Url
    /// </summary>
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Profile
    /// </summary>
    [JsonPropertyName("profile")]
    public List<Profile> Profile { get; set; } = new List<Profile>();

    /// <summary>
    /// Member Info
    /// </summary>
    [JsonPropertyName("member_info")]
    public MemberProfileInfo MemberInfo { get; set; } = new MemberProfileInfo();

    /// <summary>
    /// Field Defs
    /// </summary>
    [JsonPropertyName("field_defs")]
    public List<FieldDef> FieldDefinitions { get; set; } = new List<FieldDef>();

    /// <summary>
    /// License History
    /// </summary>
    [JsonPropertyName("license_history")]
    public List<LicenseHistory> LicenseHistory { get; set; } = new List<LicenseHistory>();

    /// <summary>
    /// Is Generic Image
    /// </summary>
    [JsonPropertyName("is_generic_image")]
    public bool IsGenericImage { get; set; }

    /// <summary>
    /// Follow Counts
    /// </summary>
    [JsonPropertyName("follow_counts")]
    public FollowCounts FollowCounts { get; set; } = new FollowCounts();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Disabled
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Recent Events
    /// </summary>
    [JsonPropertyName("recent_events")]
    public List<RecentEvent> RecentEvents { get; set; } = new List<RecentEvent>();

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }
}

/// <summary>
/// RecentAward
/// </summary>
public class RecentAward
{
    /// <summary>
    /// Member Award Id
    /// </summary>
    [JsonPropertyName("member_award_id")]
    public int MemberAwardId { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Award Id
    /// </summary>
    [JsonPropertyName("award_id")]
    public int AwardId { get; set; }

    /// <summary>
    /// Award Date
    /// </summary>
    [JsonPropertyName("award_date")]
    public string AwardDate { get; set; } = string.Empty;

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Awarded Description
    /// </summary>
    [JsonPropertyName("awarded_description")]
    public string AwardedDescription { get; set; } = string.Empty;

    /// <summary>
    /// Viewed
    /// </summary>
    [JsonPropertyName("viewed")]
    public bool Viewed { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Icon Url Small
    /// </summary>
    [JsonPropertyName("icon_url_small")]
    public string IconUrlSmall { get; set; } = string.Empty;

    /// <summary>
    /// Icon Url Large
    /// </summary>
    [JsonPropertyName("icon_url_large")]
    public string IconUrlLarge { get; set; } = string.Empty;

    /// <summary>
    /// Icon Url Unawarded
    /// </summary>
    [JsonPropertyName("icon_url_unawarded")]
    public string IconUrlUnawarded { get; set; } = string.Empty;

    /// <summary>
    /// Weight
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    /// <summary>
    /// Award Count
    /// </summary>
    [JsonPropertyName("award_count")]
    public int AwardCount { get; set; }

    /// <summary>
    /// Award Order
    /// </summary>
    [JsonPropertyName("award_order")]
    public int AwardOrder { get; set; }

    /// <summary>
    /// Achievement
    /// </summary>
    [JsonPropertyName("achievement")]
    public bool Achievement { get; set; }
}

/// <summary>
/// Activity
/// </summary>
public class Activity
{
    /// <summary>
    /// Recent 30Days Count
    /// </summary>
    [JsonPropertyName("recent_30days_count")]
    public int Recent30DaysCount { get; set; }

    /// <summary>
    /// Prev 30Days Count
    /// </summary>
    [JsonPropertyName("prev_30days_count")]
    public int Prev30DaysCount { get; set; }

    /// <summary>
    /// Consecutive Weeks
    /// </summary>
    [JsonPropertyName("consecutive_weeks")]
    public int ConsecutiveWeeks { get; set; }

    /// <summary>
    /// Most Consecutive Weeks
    /// </summary>
    [JsonPropertyName("most_consecutive_weeks")]
    public int MostConsecutiveWeeks { get; set; }
}

/// <summary>
/// Profile
/// </summary>
public class Profile
{
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Value
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Editable
    /// </summary>
    [JsonPropertyName("editable")]
    public bool Editable { get; set; }
}

/// <summary>
/// MemberProfileInfo
/// </summary>
public class MemberProfileInfo
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
    public MemberProfileHelmet Helmet { get; set; } = new MemberProfileHelmet();

    /// <summary>
    /// Last Login
    /// </summary>
    [JsonPropertyName("last_login")]
    public string LastLogin { get; set; } = string.Empty;

    /// <summary>
    /// Member Since
    /// </summary>
    [JsonPropertyName("member_since")]
    public string MemberSince { get; set; } = string.Empty;

    /// <summary>
    /// Flair Id
    /// </summary>
    [JsonPropertyName("flair_id")]
    public int FlairId { get; set; }

    /// <summary>
    /// Flair Name
    /// </summary>
    [JsonPropertyName("flair_name")]
    public string FlairName { get; set; } = string.Empty;

    /// <summary>
    /// Flair Shortname
    /// </summary>
    [JsonPropertyName("flair_shortname")]
    public string FlairShortName { get; set; } = string.Empty;

    /// <summary>
    /// Ai
    /// </summary>
    [JsonPropertyName("ai")]
    public bool Ai { get; set; }

    /// <summary>
    /// Licenses
    /// </summary>
    [JsonPropertyName("licenses")]
    public List<License> Licenses { get; set; } = new List<License>();
}

/// <summary>
/// MemberProfileHelmet
/// </summary>
public class MemberProfileHelmet
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

    /// <summary>
    /// Face Type
    /// </summary>
    [JsonPropertyName("face_type")]
    public int FaceType { get; set; }

    /// <summary>
    /// Helmet Type
    /// </summary>
    [JsonPropertyName("helmet_type")]
    public int HelmetType { get; set; }
}

/// <summary>
/// License
/// </summary>
public class License
{
    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// License Level
    /// </summary>
    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    /// <summary>
    /// Safety Rating
    /// </summary>
    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    /// <summary>
    /// Cpi
    /// </summary>
    [JsonPropertyName("cpi")]
    public double Cpi { get; set; }

    /// <summary>
    /// Irating
    /// </summary>
    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    /// <summary>
    /// Tt Rating
    /// </summary>
    [JsonPropertyName("tt_rating")]
    public int TTRating { get; set; }

    /// <summary>
    /// Mpr Num Races
    /// </summary>
    [JsonPropertyName("mpr_num_races")]
    public int MprNumRaces { get; set; }

    /// <summary>
    /// Color
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Group Id
    /// </summary>
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    /// <summary>
    /// Pro Promotable
    /// </summary>
    [JsonPropertyName("pro_promotable")]
    public bool ProPromotable { get; set; }

    /// <summary>
    /// Mpr Num Tts
    /// </summary>
    [JsonPropertyName("mpr_num_tts")]
    public int MprNumTts { get; set; }
}

/// <summary>
/// FieldDef
/// </summary>
public class FieldDef
{
    /// <summary>
    /// Field Id
    /// </summary>
    [JsonPropertyName("field_id")]
    public int FieldId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Value
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Editable
    /// </summary>
    [JsonPropertyName("editable")]
    public bool Editable { get; set; }

    /// <summary>
    /// Label
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Section
    /// </summary>
    [JsonPropertyName("section")]
    public string Section { get; set; } = string.Empty;

    /// <summary>
    /// Row Order
    /// </summary>
    [JsonPropertyName("row_order")]
    public int RowOrder { get; set; }

    /// <summary>
    /// Column
    /// </summary>
    [JsonPropertyName("column")]
    public int Column { get; set; }

    /// <summary>
    /// Number Of Lines
    /// </summary>
    [JsonPropertyName("number_of_lines")]
    public int NumberOfLines { get; set; }
}

/// <summary>
/// LicenseHistory
/// </summary>
public class LicenseHistory
{
    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// License Level
    /// </summary>
    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    /// <summary>
    /// Safety Rating
    /// </summary>
    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    /// <summary>
    /// Cpi
    /// </summary>
    [JsonPropertyName("cpi")]
    public double Cpi { get; set; }

    /// <summary>
    /// Irating
    /// </summary>
    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    /// <summary>
    /// Tt Rating
    /// </summary>
    [JsonPropertyName("tt_rating")]
    public int TTRating { get; set; }

    /// <summary>
    /// Color
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Group Id
    /// </summary>
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}

/// <summary>
/// FollowCounts
/// </summary>
public class FollowCounts
{
    /// <summary>
    /// Followers
    /// </summary>
    [JsonPropertyName("followers")]
    public int Followers { get; set; }

    /// <summary>
    /// Follows
    /// </summary>
    [JsonPropertyName("follows")]
    public int Follows { get; set; }
}

/// <summary>
/// RecentEvent
/// </summary>
public class RecentEvent
{
    /// <summary>
    /// Event Type
    /// </summary>
    [JsonPropertyName("event_type")]
    public string EventType { get; set; } = string.Empty;

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Start Time
    /// </summary>
    [JsonPropertyName("start_time")]
    public string StartTime { get; set; } = string.Empty;

    /// <summary>
    /// Event Id
    /// </summary>
    [JsonPropertyName("event_id")]
    public int EventId { get; set; }

    /// <summary>
    /// Event Name
    /// </summary>
    [JsonPropertyName("event_name")]
    public string EventName { get; set; } = string.Empty;

    /// <summary>
    /// Simsession Type
    /// </summary>
    [JsonPropertyName("simsession_type")]
    public int SimsessionType { get; set; }

    /// <summary>
    /// Starting Position
    /// </summary>
    [JsonPropertyName("starting_position")]
    public int StartingPosition { get; set; }

    /// <summary>
    /// Finish Position
    /// </summary>
    [JsonPropertyName("finish_position")]
    public int FinishPosition { get; set; }

    /// <summary>
    /// Best Lap Time
    /// </summary>
    [JsonPropertyName("best_lap_time")]
    public int BestLapTime { get; set; }

    /// <summary>
    /// Percent Rank
    /// </summary>
    [JsonPropertyName("percent_rank")]
    public int PercentRank { get; set; }

    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Car Name
    /// </summary>
    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;

    /// <summary>
    /// Logo Url
    /// </summary>
    [JsonPropertyName("logo_url")]
    public string LogoUrl { get; set; } = string.Empty;

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();
}

