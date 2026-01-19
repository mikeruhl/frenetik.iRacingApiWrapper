namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// MemberInfo
/// </summary>
public class MemberInfo
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
    /// First Name
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Last Name
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// On Car Name
    /// </summary>
    [JsonPropertyName("on_car_name")]
    public string OnCarName { get; set; } = string.Empty;

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
    /// Flair Country Code
    /// </summary>
    [JsonPropertyName("flair_country_code")]
    public string FlairCountryCode { get; set; } = string.Empty;

    /// <summary>
    /// Last Login
    /// </summary>
    [JsonPropertyName("last_login")]
    public DateTime LastLogin { get; set; }

    /// <summary>
    /// Read Tc
    /// </summary>
    [JsonPropertyName("read_tc")]
    public DateTime ReadTermsAndConditions { get; set; }

    /// <summary>
    /// Read Pp
    /// </summary>
    [JsonPropertyName("read_pp")]
    public DateTime ReadPrivacyPolicy { get; set; }

    /// <summary>
    /// Read Comp Rules
    /// </summary>
    [JsonPropertyName("read_comp_rules")]
    public DateTime ReadCompRules { get; set; }

    /// <summary>
    /// Flags
    /// </summary>
    [JsonPropertyName("flags")]
    public int Flags { get; set; }

    /// <summary>
    /// Connection Type
    /// </summary>
    [JsonPropertyName("connection_type")]
    public string ConnectionType { get; set; } = string.Empty;

    /// <summary>
    /// Download Server
    /// </summary>
    [JsonPropertyName("download_server")]
    public string DownloadServer { get; set; } = string.Empty;

    /// <summary>
    /// Account
    /// </summary>
    [JsonPropertyName("account")]
    public AccountInfo Account { get; set; } = new AccountInfo();

    /// <summary>
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public HelmetInfo Helmet { get; set; } = new HelmetInfo();

    /// <summary>
    /// Suit
    /// </summary>
    [JsonPropertyName("suit")]
    public SuitInfo Suit { get; set; } = new SuitInfo();

    /// <summary>
    /// Licenses
    /// </summary>
    [JsonPropertyName("licenses")]
    public LicenseInfo Licenses { get; set; } = new LicenseInfo();

    /// <summary>
    /// Car Packages
    /// </summary>
    [JsonPropertyName("car_packages")]
    public List<CarPackageInfo> CarPackages { get; set; } = new List<CarPackageInfo>();

    /// <summary>
    /// Track Packages
    /// </summary>
    [JsonPropertyName("track_packages")]
    public List<TrackPackageInfo> TrackPackages { get; set; } = new List<TrackPackageInfo>();

    /// <summary>
    /// Other Owned Packages
    /// </summary>
    [JsonPropertyName("other_owned_packages")]
    public List<int> OtherOwnedPackages { get; set; } = new List<int>();

    /// <summary>
    /// Dev
    /// </summary>
    [JsonPropertyName("dev")]
    public bool IsDev { get; set; }

    /// <summary>
    /// Alpha Tester
    /// </summary>
    [JsonPropertyName("alpha_tester")]
    public bool IsAlphaTester { get; set; }

    /// <summary>
    /// Rain Tester
    /// </summary>
    [JsonPropertyName("rain_tester")]
    public bool IsRainTester { get; set; }

    /// <summary>
    /// Broadcaster
    /// </summary>
    [JsonPropertyName("broadcaster")]
    public bool IsBroadcaster { get; set; }

    /// <summary>
    /// Restrictions
    /// </summary>
    [JsonPropertyName("restrictions")]
    public Dictionary<string, object> Restrictions { get; set; } = [];

    /// <summary>
    /// Has Read Comp Rules
    /// </summary>
    [JsonPropertyName("has_read_comp_rules")]
    public bool HasReadCompRules { get; set; }

    /// <summary>
    /// Has Read NDA
    /// </summary>
    [JsonPropertyName("has_read_nda")]
    public bool HasReadNDA { get; set; }

    /// <summary>
    /// Flags Hex
    /// </summary>
    [JsonPropertyName("flags_hex")]
    public string FlagsHex { get; set; } = string.Empty;

    /// <summary>
    /// Hundred Pct Club
    /// </summary>
    [JsonPropertyName("hundred_pct_club")]
    public bool IsHundredPctClub { get; set; }

    /// <summary>
    /// Twenty Pct Discount
    /// </summary>
    [JsonPropertyName("twenty_pct_discount")]
    public bool HasTwentyPctDiscount { get; set; }

    /// <summary>
    /// Last Season
    /// </summary>
    [JsonPropertyName("last_season")]
    public int LastSeason { get; set; }

    /// <summary>
    /// Has Additional Content
    /// </summary>
    [JsonPropertyName("has_additional_content")]
    public bool HasAdditionalContent { get; set; }

    /// <summary>
    /// Has Read Tc
    /// </summary>
    [JsonPropertyName("has_read_tc")]
    public bool HasReadTermsAndConditions { get; set; }

    /// <summary>
    /// Has Read Pp
    /// </summary>
    [JsonPropertyName("has_read_pp")]
    public bool HasReadPrivacyPolicy { get; set; }
}

/// <summary>
/// AccountInfo
/// </summary>
public class AccountInfo
{
    /// <summary>
    /// Ir Dollars
    /// </summary>
    [JsonPropertyName("ir_dollars")]
    public double IrDollars { get; set; }

    /// <summary>
    /// Ir Credits
    /// </summary>
    [JsonPropertyName("ir_credits")]
    public int IrCredits { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Country Rules
    /// </summary>
    [JsonPropertyName("country_rules")]
    public object CountryRules { get; set; } = new object();
}

/// <summary>
/// HelmetInfo
/// </summary>
public class HelmetInfo
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
/// SuitInfo
/// </summary>
public class SuitInfo
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
    /// Body Type
    /// </summary>
    [JsonPropertyName("body_type")]
    public int BodyType { get; set; }
}

/// <summary>
/// LicenseInfo
/// </summary>
public class LicenseInfo
{
    /// <summary>
    /// Oval
    /// </summary>
    [JsonPropertyName("oval")]
    public LicenseCategoryInfo Oval { get; set; } = new LicenseCategoryInfo();

    /// <summary>
    /// Sports Car
    /// </summary>
    [JsonPropertyName("sports_car")]
    public LicenseCategoryInfo SportsCar { get; set; } = new LicenseCategoryInfo();

    /// <summary>
    /// Formula Car
    /// </summary>
    [JsonPropertyName("formula_car")]
    public LicenseCategoryInfo FormulaCar { get; set; } = new LicenseCategoryInfo();

    /// <summary>
    /// Dirt Oval
    /// </summary>
    [JsonPropertyName("dirt_oval")]
    public LicenseCategoryInfo DirtOval { get; set; } = new LicenseCategoryInfo();

    /// <summary>
    /// Dirt Road
    /// </summary>
    [JsonPropertyName("dirt_road")]
    public LicenseCategoryInfo DirtRoad { get; set; } = new LicenseCategoryInfo();
}

/// <summary>
/// LicenseCategoryInfo
/// </summary>
public class LicenseCategoryInfo
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
    /// Category Name
    /// </summary>
    [JsonPropertyName("category_name")]
    public string CategoryName { get; set; } = string.Empty;

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
    public double CPI { get; set; }

    /// <summary>
    /// Irating
    /// </summary>
    [JsonPropertyName("irating")]
    public int iRating { get; set; }

    /// <summary>
    /// Tt Rating
    /// </summary>
    [JsonPropertyName("tt_rating")]
    public int TTRating { get; set; }

    /// <summary>
    /// Mpr Num Races
    /// </summary>
    [JsonPropertyName("mpr_num_races")]
    public int MPRNumRaces { get; set; }

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
    public bool IsProPromotable { get; set; }

    /// <summary>
    /// Seq
    /// </summary>
    [JsonPropertyName("seq")]
    public int Seq { get; set; }

    /// <summary>
    /// Mpr Num Tts
    /// </summary>
    [JsonPropertyName("mpr_num_tts")]
    public int MPRNumTTS { get; set; }
}

/// <summary>
/// CarPackageInfo
/// </summary>
public class CarPackageInfo
{
    /// <summary>
    /// Package Id
    /// </summary>
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    /// <summary>
    /// Content Ids
    /// </summary>
    [JsonPropertyName("content_ids")]
    public List<int> ContentIds { get; set; } = new List<int>();
}

/// <summary>
/// TrackPackageInfo
/// </summary>
public class TrackPackageInfo
{
    /// <summary>
    /// Package Id
    /// </summary>
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    /// <summary>
    /// Content Ids
    /// </summary>
    [JsonPropertyName("content_ids")]
    public List<int> ContentIds { get; set; } = new List<int>();
}

