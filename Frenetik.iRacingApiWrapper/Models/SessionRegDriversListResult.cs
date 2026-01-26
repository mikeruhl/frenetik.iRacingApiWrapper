namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Session Reg Drivers List Result
/// </summary>
public class SessionRegDriversListResult
{
    /// <summary>
    /// Subscribed
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Entries
    /// </summary>
    [JsonPropertyName("entries")]
    public List<SessionRegDriverEntry> Entries { get; set; } = [];

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

/// <summary>
/// Session Reg Driver Entry
/// </summary>
public class SessionRegDriverEntry
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
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Car Class Name
    /// </summary>
    [JsonPropertyName("car_class_name")]
    public string CarClassName { get; set; } = string.Empty;

    /// <summary>
    /// Helmet
    /// </summary>
    [JsonPropertyName("helmet")]
    public SessionRegDriverHelmet Helmet { get; set; } = new();

    /// <summary>
    /// Crew Allowed
    /// </summary>
    [JsonPropertyName("crew_allowed")]
    public int CrewAllowed { get; set; }

    /// <summary>
    /// Crew Password Protected
    /// </summary>
    [JsonPropertyName("crew_password_protected")]
    public bool CrewPasswordProtected { get; set; }

    /// <summary>
    /// Reg Status
    /// </summary>
    [JsonPropertyName("reg_status")]
    public string RegStatus { get; set; } = string.Empty;

    /// <summary>
    /// Trusted Spotter
    /// </summary>
    [JsonPropertyName("trusted_spotter")]
    public bool TrustedSpotter { get; set; }

    /// <summary>
    /// Livery
    /// </summary>
    [JsonPropertyName("livery")]
    public SessionRegDriverLivery Livery { get; set; } = new();

    /// <summary>
    /// License
    /// </summary>
    [JsonPropertyName("license")]
    public SessionRegDriverLicense License { get; set; } = new();

    /// <summary>
    /// Session Id
    /// </summary>
    [JsonPropertyName("session_id")]
    public int SessionId { get; set; }

    /// <summary>
    /// Subsession Id
    /// </summary>
    [JsonPropertyName("subsession_id")]
    public int SubsessionId { get; set; }

    /// <summary>
    /// Event Type
    /// </summary>
    [JsonPropertyName("event_type")]
    public int EventType { get; set; }

    /// <summary>
    /// Event Type Name
    /// </summary>
    [JsonPropertyName("event_type_name")]
    public string EventTypeName { get; set; } = string.Empty;

    /// <summary>
    /// License Order
    /// </summary>
    [JsonPropertyName("license_order")]
    public int LicenseOrder { get; set; }

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
    public string FlairShortname { get; set; } = string.Empty;

    /// <summary>
    /// Country Code
    /// </summary>
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = string.Empty;

    /// <summary>
    /// Farm Display Name
    /// </summary>
    [JsonPropertyName("farm_display_name")]
    public string FarmDisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Elig
    /// </summary>
    [JsonPropertyName("elig")]
    public SessionRegDriverElig Elig { get; set; } = new();
}

/// <summary>
/// Session Reg Driver Helmet
/// </summary>
public class SessionRegDriverHelmet
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
/// Session Reg Driver Livery
/// </summary>
public class SessionRegDriverLivery
{
    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

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
    /// Number Font
    /// </summary>
    [JsonPropertyName("number_font")]
    public int NumberFont { get; set; }

    /// <summary>
    /// Number Color1
    /// </summary>
    [JsonPropertyName("number_color1")]
    public string NumberColor1 { get; set; } = string.Empty;

    /// <summary>
    /// Number Color2
    /// </summary>
    [JsonPropertyName("number_color2")]
    public string NumberColor2 { get; set; } = string.Empty;

    /// <summary>
    /// Number Color3
    /// </summary>
    [JsonPropertyName("number_color3")]
    public string NumberColor3 { get; set; } = string.Empty;

    /// <summary>
    /// Number Slant
    /// </summary>
    [JsonPropertyName("number_slant")]
    public int NumberSlant { get; set; }

    /// <summary>
    /// Sponsor1
    /// </summary>
    [JsonPropertyName("sponsor1")]
    public int Sponsor1 { get; set; }

    /// <summary>
    /// Sponsor2
    /// </summary>
    [JsonPropertyName("sponsor2")]
    public int Sponsor2 { get; set; }

    /// <summary>
    /// Car Number
    /// </summary>
    [JsonPropertyName("car_number")]
    public string? CarNumber { get; set; }

    /// <summary>
    /// Wheel Color
    /// </summary>
    [JsonPropertyName("wheel_color")]
    public string? WheelColor { get; set; }

    /// <summary>
    /// Rim Type
    /// </summary>
    [JsonPropertyName("rim_type")]
    public int? RimType { get; set; }
}

/// <summary>
/// Session Reg Driver License
/// </summary>
public class SessionRegDriverLicense
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
    /// Seq
    /// </summary>
    [JsonPropertyName("seq")]
    public int Seq { get; set; }

    /// <summary>
    /// Mpr Num Tts
    /// </summary>
    [JsonPropertyName("mpr_num_tts")]
    public int MprNumTts { get; set; }
}

/// <summary>
/// Session Reg Driver Elig
/// </summary>
public class SessionRegDriverElig
{
    /// <summary>
    /// Session Full
    /// </summary>
    [JsonPropertyName("session_full")]
    public bool SessionFull { get; set; }

    /// <summary>
    /// Can Spot
    /// </summary>
    [JsonPropertyName("can_spot")]
    public bool CanSpot { get; set; }

    /// <summary>
    /// Can Watch
    /// </summary>
    [JsonPropertyName("can_watch")]
    public bool CanWatch { get; set; }

    /// <summary>
    /// Can Drive
    /// </summary>
    [JsonPropertyName("can_drive")]
    public bool CanDrive { get; set; }

    /// <summary>
    /// Trusted Spotter
    /// </summary>
    [JsonPropertyName("trusted_spotter")]
    public bool TrustedSpotter { get; set; }

    /// <summary>
    /// Has Sess Password
    /// </summary>
    [JsonPropertyName("has_sess_password")]
    public bool HasSessPassword { get; set; }

    /// <summary>
    /// Has Crew Password
    /// </summary>
    [JsonPropertyName("has_crew_password")]
    public bool HasCrewPassword { get; set; }

    /// <summary>
    /// Needs Purchase
    /// </summary>
    [JsonPropertyName("needs_purchase")]
    public bool NeedsPurchase { get; set; }

    /// <summary>
    /// Purchase Skus
    /// </summary>
    [JsonPropertyName("purchase_skus")]
    public List<string> PurchaseSkus { get; set; } = [];

    /// <summary>
    /// Registered
    /// </summary>
    [JsonPropertyName("registered")]
    public bool Registered { get; set; }
}
