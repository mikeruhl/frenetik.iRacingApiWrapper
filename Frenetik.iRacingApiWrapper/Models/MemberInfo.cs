namespace Frenetik.iRacingApiWrapper.Models;

public class MemberInfo
{
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("on_car_name")]
    public string OnCarName { get; set; } = string.Empty;

    [JsonPropertyName("member_since")]
    public DateTime MemberSince { get; set; }

    [JsonPropertyName("last_test_track")]
    public int LastTestTrack { get; set; }

    [JsonPropertyName("last_test_car")]
    public int LastTestCar { get; set; }

    [JsonPropertyName("last_season")]
    public int LastSeason { get; set; }

    [JsonPropertyName("flags")]
    public int Flags { get; set; }

    [JsonPropertyName("club_id")]
    public int ClubId { get; set; }

    [JsonPropertyName("club_name")]
    public string ClubName { get; set; } = string.Empty;

    [JsonPropertyName("connection_type")]
    public string ConnectionType { get; set; } = string.Empty;

    [JsonPropertyName("download_server")]
    public string DownloadServer { get; set; } = string.Empty;

    [JsonPropertyName("last_login")]
    public DateTime LastLogin { get; set; }

    [JsonPropertyName("read_comp_rules")]
    public DateTime ReadCompRules { get; set; }

    [JsonPropertyName("account")]
    public AccountInfo Account { get; set; } = new AccountInfo();

    [JsonPropertyName("helmet")]
    public HelmetInfo Helmet { get; set; } = new HelmetInfo();

    [JsonPropertyName("suit")]
    public SuitInfo Suit { get; set; } = new SuitInfo();

    [JsonPropertyName("licenses")]
    public LicenseInfo Licenses { get; set; } = new LicenseInfo();

    [JsonPropertyName("car_packages")]
    public List<CarPackageInfo> CarPackages { get; set; } = new List<CarPackageInfo>();

    [JsonPropertyName("track_packages")]
    public List<TrackPackageInfo> TrackPackages { get; set; } = new List<TrackPackageInfo>();

    [JsonPropertyName("other_owned_packages")]
    public List<int> OtherOwnedPackages { get; set; } = new List<int>();

    [JsonPropertyName("dev")]
    public bool IsDev { get; set; }

    [JsonPropertyName("alpha_tester")]
    public bool IsAlphaTester { get; set; }

    [JsonPropertyName("rain_tester")]
    public bool IsRainTester { get; set; }

    [JsonPropertyName("broadcaster")]
    public bool IsBroadcaster { get; set; }

    [JsonPropertyName("restrictions")]
    public Dictionary<string, object> Restrictions { get; set; } = new Dictionary<string, object>();

    [JsonPropertyName("has_read_comp_rules")]
    public bool HasReadCompRules { get; set; }

    [JsonPropertyName("flags_hex")]
    public string FlagsHex { get; set; } = string.Empty;

    [JsonPropertyName("hundred_pct_club")]
    public bool IsHundredPctClub { get; set; }

    [JsonPropertyName("twenty_pct_discount")]
    public bool HasTwentyPctDiscount { get; set; }

    [JsonPropertyName("race_official")]
    public bool IsRaceOfficial { get; set; }

    [JsonPropertyName("ai")]
    public bool IsAI { get; set; }

    [JsonPropertyName("bypass_hosted_password")]
    public bool BypassHostedPassword { get; set; }

    [JsonPropertyName("read_tc")]
    public DateTime ReadTermsAndConditions { get; set; }

    [JsonPropertyName("read_pp")]
    public DateTime ReadPrivacyPolicy { get; set; }

    [JsonPropertyName("has_read_tc")]
    public bool HasReadTermsAndConditions { get; set; }

    [JsonPropertyName("has_read_pp")]
    public bool HasReadPrivacyPolicy { get; set; }
}

public class AccountInfo
{
    [JsonPropertyName("ir_dollars")]
    public int IrDollars { get; set; }

    [JsonPropertyName("ir_credits")]
    public int IrCredits { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("country_rules")]
    public object CountryRules { get; set; } = new object();
}

public class HelmetInfo
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

public class SuitInfo
{
    [JsonPropertyName("pattern")]
    public int Pattern { get; set; }

    [JsonPropertyName("color1")]
    public string Color1 { get; set; } = string.Empty;

    [JsonPropertyName("color2")]
    public string Color2 { get; set; } = string.Empty;

    [JsonPropertyName("color3")]
    public string Color3 { get; set; } = string.Empty;

    [JsonPropertyName("body_type")]
    public int BodyType { get; set; }
}

public class LicenseInfo
{
    [JsonPropertyName("oval")]
    public LicenseCategoryInfo Oval { get; set; } = new LicenseCategoryInfo();

    [JsonPropertyName("road")]
    public LicenseCategoryInfo Road { get; set; } = new LicenseCategoryInfo();

    [JsonPropertyName("dirt_oval")]
    public LicenseCategoryInfo DirtOval { get; set; } = new LicenseCategoryInfo();

    [JsonPropertyName("dirt_road")]
    public LicenseCategoryInfo DirtRoad { get; set; } = new LicenseCategoryInfo();
}

public class LicenseCategoryInfo
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
    public double CPI { get; set; }

    [JsonPropertyName("irating")]
    public int iRating { get; set; }

    [JsonPropertyName("tt_rating")]
    public int TTRating { get; set; }

    [JsonPropertyName("mpr_num_races")]
    public int MPRNumRaces { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("pro_promotable")]
    public bool IsProPromotable { get; set; }

    [JsonPropertyName("mpr_num_tts")]
    public int MPRNumTTS { get; set; }
}

public class CarPackageInfo
{
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    [JsonPropertyName("content_ids")]
    public List<int> ContentIds { get; set; } = new List<int>();
}

public class TrackPackageInfo
{
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    [JsonPropertyName("content_ids")]
    public List<int> ContentIds { get; set; } = new List<int>();
}
