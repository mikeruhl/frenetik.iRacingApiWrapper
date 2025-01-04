namespace Frenetik.iRacingApiWrapper.Models;

public class MemberProfile
{
    [JsonPropertyName("recent_awards")]
    public List<RecentAward> RecentAwards { get; set; } = new List<RecentAward>();

    [JsonPropertyName("activity")]
    public Activity Activity { get; set; } = new Activity();

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    [JsonPropertyName("profile")]
    public List<Profile> Profile { get; set; } = new List<Profile>();

    [JsonPropertyName("member_info")]
    public MemberProfileInfo MemberInfo { get; set; } = new MemberProfileInfo();

    [JsonPropertyName("field_defs")]
    public List<FieldDef> FieldDefinitions { get; set; } = new List<FieldDef>();

    [JsonPropertyName("license_history")]
    public List<LicenseHistory> LicenseHistory { get; set; } = new List<LicenseHistory>();

    [JsonPropertyName("is_generic_image")]
    public bool IsGenericImage { get; set; }

    [JsonPropertyName("follow_counts")]
    public FollowCounts FollowCounts { get; set; } = new FollowCounts();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("recent_events")]
    public List<RecentEvent> RecentEvents { get; set; } = new List<RecentEvent>();

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }
}

public class RecentAward
{
    [JsonPropertyName("member_award_id")]
    public int MemberAwardId { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("award_id")]
    public int AwardId { get; set; }

    [JsonPropertyName("award_date")]
    public string AwardDate { get; set; } = string.Empty;

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("awarded_description")]
    public string AwardedDescription { get; set; } = string.Empty;

    [JsonPropertyName("viewed")]
    public bool Viewed { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("icon_url_small")]
    public string IconUrlSmall { get; set; } = string.Empty;

    [JsonPropertyName("icon_url_large")]
    public string IconUrlLarge { get; set; } = string.Empty;

    [JsonPropertyName("icon_url_unawarded")]
    public string IconUrlUnawarded { get; set; } = string.Empty;

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("award_count")]
    public int AwardCount { get; set; }

    [JsonPropertyName("award_order")]
    public int AwardOrder { get; set; }

    [JsonPropertyName("achievement")]
    public bool Achievement { get; set; }
}

public class Activity
{
    [JsonPropertyName("recent_30days_count")]
    public int Recent30DaysCount { get; set; }

    [JsonPropertyName("prev_30days_count")]
    public int Prev30DaysCount { get; set; }

    [JsonPropertyName("consecutive_weeks")]
    public int ConsecutiveWeeks { get; set; }

    [JsonPropertyName("most_consecutive_weeks")]
    public int MostConsecutiveWeeks { get; set; }
}

public class Profile
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("editable")]
    public bool Editable { get; set; }
}

public class MemberProfileInfo
{
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("helmet")]
    public MemberProfileHelmet Helmet { get; set; } = new MemberProfileHelmet();

    [JsonPropertyName("last_login")]
    public string LastLogin { get; set; } = string.Empty;

    [JsonPropertyName("member_since")]
    public string MemberSince { get; set; } = string.Empty;

    [JsonPropertyName("club_id")]
    public int ClubId { get; set; }

    [JsonPropertyName("club_name")]
    public string ClubName { get; set; } = string.Empty;

    [JsonPropertyName("ai")]
    public bool Ai { get; set; }

    [JsonPropertyName("licenses")]
    public List<License> Licenses { get; set; } = new List<License>();
}

public class MemberProfileHelmet
{
    [JsonPropertyName("pattern")]
    public int Pattern { get; set; }

    [JsonPropertyName("color1")]
    public string Color1 { get; set; } = string.Empty;

    [JsonPropertyName("color2")]
    public string Color2 { get; set; } = string.Empty;

    [JsonPropertyName("color3")]
    public string Color3 { get; set; } = string.Empty;

    [JsonPropertyName("face_type")]
    public int FaceType { get; set; }

    [JsonPropertyName("helmet_type")]
    public int HelmetType { get; set; }
}

public class License
{
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    [JsonPropertyName("cpi")]
    public double Cpi { get; set; }

    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    [JsonPropertyName("tt_rating")]
    public int TTRating { get; set; }

    [JsonPropertyName("mpr_num_races")]
    public int MprNumRaces { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("pro_promotable")]
    public bool ProPromotable { get; set; }

    [JsonPropertyName("mpr_num_tts")]
    public int MprNumTts { get; set; }
}

public class FieldDef
{
    [JsonPropertyName("field_id")]
    public int FieldId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("editable")]
    public bool Editable { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;

    [JsonPropertyName("section")]
    public string Section { get; set; } = string.Empty;

    [JsonPropertyName("row_order")]
    public int RowOrder { get; set; }

    [JsonPropertyName("column")]
    public int Column { get; set; }

    [JsonPropertyName("number_of_lines")]
    public int NumberOfLines { get; set; }
}

public class LicenseHistory
{
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    [JsonPropertyName("cpi")]
    public double Cpi { get; set; }

    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    [JsonPropertyName("tt_rating")]
    public int TTRating { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}

public class FollowCounts
{
    [JsonPropertyName("followers")]
    public int Followers { get; set; }

    [JsonPropertyName("follows")]
    public int Follows { get; set; }
}

public class RecentEvent
{
    [JsonPropertyName("event_type")]
    public string EventType { get; set; } = string.Empty;

    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    [JsonPropertyName("start_time")]
    public string StartTime { get; set; } = string.Empty;

    [JsonPropertyName("event_id")]
    public int EventId { get; set; }

    [JsonPropertyName("event_name")]
    public string EventName { get; set; } = string.Empty;

    [JsonPropertyName("simsession_type")]
    public int SimsessionType { get; set; }

    [JsonPropertyName("starting_position")]
    public int StartingPosition { get; set; }

    [JsonPropertyName("finish_position")]
    public int FinishPosition { get; set; }

    [JsonPropertyName("best_lap_time")]
    public int BestLapTime { get; set; }

    [JsonPropertyName("percent_rank")]
    public int PercentRank { get; set; }

    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;

    [JsonPropertyName("logo_url")]
    public string LogoUrl { get; set; } = string.Empty;

    [JsonPropertyName("track")]
    public Track Track { get; set; } = new Track();
}
