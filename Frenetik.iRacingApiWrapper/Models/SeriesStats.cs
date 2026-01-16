namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// SeriesStats
/// </summary>
public class SeriesStats
{
    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Series Name
    /// </summary>
    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    /// <summary>
    /// Series Short Name
    /// </summary>
    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;

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
    /// Active
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    /// <summary>
    /// Official
    /// </summary>
    [JsonPropertyName("official")]
    public bool Official { get; set; }

    /// <summary>
    /// Fixed Setup
    /// </summary>
    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    /// <summary>
    /// Logo
    /// </summary>
    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;

    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// License Group Types
    /// </summary>
    [JsonPropertyName("license_group_types")]
    public List<LicenseGroupTypeResult> LicenseGroupTypes { get; set; } = new List<LicenseGroupTypeResult>();

    /// <summary>
    /// Allowed Licenses
    /// </summary>
    [JsonPropertyName("allowed_licenses")]
    public List<AllowedLicense> AllowedLicenses { get; set; } = new List<AllowedLicense>();

    /// <summary>
    /// Seasons
    /// </summary>
    [JsonPropertyName("seasons")]
    public List<Season> Seasons { get; set; } = new List<Season>();
}

/// <summary>
/// LicenseGroupTypeResult
/// </summary>
public class LicenseGroupTypeResult
{
    /// <summary>
    /// License Group Type
    /// </summary>
    [JsonPropertyName("license_group_type")]
    public int LicenseGroupType { get; set; }
}

/// <summary>
/// AllowedLicense
/// </summary>
public class AllowedLicense
{
    /// <summary>
    /// Parent Id
    /// </summary>
    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }

    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// Min License Level
    /// </summary>
    [JsonPropertyName("min_license_level")]
    public int MinLicenseLevel { get; set; }

    /// <summary>
    /// Max License Level
    /// </summary>
    [JsonPropertyName("max_license_level")]
    public int MaxLicenseLevel { get; set; }

    /// <summary>
    /// Group Name
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;
}

/// <summary>
/// Season
/// </summary>
public class Season
{
    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Season Name
    /// </summary>
    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    /// <summary>
    /// Season Short Name
    /// </summary>
    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    /// <summary>
    /// Season Year
    /// </summary>
    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    /// <summary>
    /// Season Quarter
    /// </summary>
    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    /// <summary>
    /// Official
    /// </summary>
    [JsonPropertyName("official")]
    public bool Official { get; set; }

    /// <summary>
    /// Driver Changes
    /// </summary>
    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    /// <summary>
    /// Fixed Setup
    /// </summary>
    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    /// <summary>
    /// License Group
    /// </summary>
    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    /// <summary>
    /// Has Supersessions
    /// </summary>
    [JsonPropertyName("has_supersessions")]
    public bool HasSuperSessions { get; set; }

    /// <summary>
    /// License Group Types
    /// </summary>
    [JsonPropertyName("license_group_types")]
    public List<LicenseGroupTypeResult> LicenseGroupTypes { get; set; } = new List<LicenseGroupTypeResult>();

    /// <summary>
    /// Car Classes
    /// </summary>
    [JsonPropertyName("car_classes")]
    public List<StatCarClass> CarClasses { get; set; } = new List<StatCarClass>();
}

/// <summary>
/// StatCarClass
/// </summary>
public class StatCarClass
{
    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Short Name
    /// </summary>
    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Relative Speed
    /// </summary>
    [JsonPropertyName("relative_speed")]
    public int RelativeSpeed { get; set; }
}

/// <summary>
/// StatRaceWeek
/// </summary>
public class StatRaceWeek
{
    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    /// <summary>
    /// Track
    /// </summary>
    [JsonPropertyName("track")]
    public StatTrack Track { get; set; } = new StatTrack();
}

/// <summary>
/// StatTrack
/// </summary>
public class StatTrack
{
    /// <summary>
    /// Track Id
    /// </summary>
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    /// <summary>
    /// Track Name
    /// </summary>
    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    /// <summary>
    /// Config Name
    /// </summary>
    [JsonPropertyName("config_name")]
    public string? ConfigName { get; set; }
}
