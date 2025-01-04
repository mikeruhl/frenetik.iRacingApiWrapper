namespace Frenetik.iRacingApiWrapper.Models;

public class SeriesStats
{
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("series_short_name")]
    public string SeriesShortName { get; set; } = string.Empty;

    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("official")]
    public bool Official { get; set; }

    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;

    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    [JsonPropertyName("license_group_types")]
    public List<LicenseGroupTypeResult> LicenseGroupTypes { get; set; } = new List<LicenseGroupTypeResult>();

    [JsonPropertyName("allowed_licenses")]
    public List<AllowedLicense> AllowedLicenses { get; set; } = new List<AllowedLicense>();

    [JsonPropertyName("seasons")]
    public List<Season> Seasons { get; set; } = new List<Season>();
}

public class LicenseGroupTypeResult
{
    [JsonPropertyName("license_group_type")]
    public int LicenseGroupType { get; set; }
}

public class AllowedLicense
{
    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }

    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    [JsonPropertyName("min_license_level")]
    public int MinLicenseLevel { get; set; }

    [JsonPropertyName("max_license_level")]
    public int MaxLicenseLevel { get; set; }

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;
}

public class Season
{
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    [JsonPropertyName("season_year")]
    public int SeasonYear { get; set; }

    [JsonPropertyName("season_quarter")]
    public int SeasonQuarter { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("official")]
    public bool Official { get; set; }

    [JsonPropertyName("driver_changes")]
    public bool DriverChanges { get; set; }

    [JsonPropertyName("fixed_setup")]
    public bool FixedSetup { get; set; }

    [JsonPropertyName("license_group")]
    public int LicenseGroup { get; set; }

    [JsonPropertyName("has_supersessions")]
    public bool HasSuperSessions { get; set; }

    [JsonPropertyName("license_group_types")]
    public List<LicenseGroupTypeResult> LicenseGroupTypes { get; set; } = new List<LicenseGroupTypeResult>();

    [JsonPropertyName("car_classes")]
    public List<StatCarClass> CarClasses { get; set; } = new List<StatCarClass>();
}

public class StatCarClass
{
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("relative_speed")]
    public int RelativeSpeed { get; set; }
}

public class StatRaceWeek
{
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    [JsonPropertyName("track")]
    public StatTrack Track { get; set; } = new StatTrack();
}

public class StatTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("config_name")]
    public string? ConfigName { get; set; }
}