namespace Frenetik.iRacingApiWrapper.Models;

public class MembersResult
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("cust_ids")]
    public List<int> CustomerIds { get; set; } = new List<int>();

    [JsonPropertyName("members")]
    public List<Member> Members { get; set; } = new List<Member>();
}

public class Member
{
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("helmet")]
    public ProfileHelmet Helmet { get; set; } = new ProfileHelmet();

    [JsonPropertyName("last_login")]
    public DateTime LastLogin { get; set; }

    [JsonPropertyName("member_since")]
    public DateTime MemberSince { get; set; }

    [JsonPropertyName("club_id")]
    public int ClubId { get; set; }

    [JsonPropertyName("club_name")]
    public string ClubName { get; set; } = string.Empty;

    [JsonPropertyName("ai")]
    public bool Ai { get; set; }
}

public class ProfileHelmet
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
