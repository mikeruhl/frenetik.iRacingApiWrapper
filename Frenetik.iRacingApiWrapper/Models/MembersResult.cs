namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// MembersResult
/// </summary>
public class MembersResult
{
    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Cust Ids
    /// </summary>
    [JsonPropertyName("cust_ids")]
    public List<int> CustomerIds { get; set; } = new List<int>();

    /// <summary>
    /// Members
    /// </summary>
    [JsonPropertyName("members")]
    public List<Member> Members { get; set; } = new List<Member>();
}

/// <summary>
/// Member
/// </summary>
public class Member
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
    public ProfileHelmet Helmet { get; set; } = new ProfileHelmet();

    /// <summary>
    /// Last Login
    /// </summary>
    [JsonPropertyName("last_login")]
    public DateTime LastLogin { get; set; }

    /// <summary>
    /// Member Since
    /// </summary>
    [JsonPropertyName("member_since")]
    public DateTime MemberSince { get; set; }

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
}

/// <summary>
/// ProfileHelmet
/// </summary>
public class ProfileHelmet
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

