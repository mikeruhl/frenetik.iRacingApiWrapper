namespace Frenetik.iRacingApiWrapper.Models;
public class SeriesPastSeasonResult
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series")]
    public SeriesPastSeasonSeries Series { get; set; } = new SeriesPastSeasonSeries();
}

public class SeriesPastSeasonSeries
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
    public List<SeriesPastSeasonLicenseGroupTypeResponse> LicenseGroupTypes { get; set; } = new List<SeriesPastSeasonLicenseGroupTypeResponse>();

    [JsonPropertyName("allowed_licenses")]
    public List<SeriesPastSeasonAllowedLicense> AllowedLicenses { get; set; } = new List<SeriesPastSeasonAllowedLicense>();

    [JsonPropertyName("seasons")]
    public List<SeriesPastSeason> Seasons { get; set; } = new List<SeriesPastSeason>();
}

public class SeriesPastSeasonAllowedLicense
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

public class SeriesPastSeason
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
    public bool HasSupersessions { get; set; }

    [JsonPropertyName("license_group_types")]
    public List<SeriesPastSeasonLicenseGroupTypeResponse> LicenseGroupTypes { get; set; } = new List<SeriesPastSeasonLicenseGroupTypeResponse>();

    [JsonPropertyName("car_classes")]
    public List<CarClass> CarClasses { get; set; } = new List<CarClass>();

    [JsonPropertyName("race_weeks")]
    public List<SeriesPastSeasonRaceWeek> RaceWeeks { get; set; } = new List<SeriesPastSeasonRaceWeek>();
}

public class SeriesPastSeasonCarClass
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

public class SeriesPastSeasonRaceWeek
{
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    [JsonPropertyName("track")]
    public SeriesPastSeasonTrack Track { get; set; } = new SeriesPastSeasonTrack();
}

public class SeriesPastSeasonTrack
{
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;
}

public class SeriesPastSeasonLicenseGroupTypeResponse
{
    [JsonPropertyName("license_group_type")]
    public int LicenseGroupTypeId { get; set; }
}
