namespace Frenetik.iRacingApiWrapper.Models;

public class TrackResult
{
    [JsonPropertyName("ai_enabled")]
    public bool AiEnabled { get; set; }

    [JsonPropertyName("allow_pitlane_collisions")]
    public bool AllowPitlaneCollisions { get; set; }

    [JsonPropertyName("allow_rolling_start")]
    public bool AllowRollingStart { get; set; }

    [JsonPropertyName("allow_standing_start")]
    public bool AllowStandingStart { get; set; }

    [JsonPropertyName("award_exempt")]
    public bool AwardExempt { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("closes")]
    public DateTime Closes { get; set; }

    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;

    [JsonPropertyName("corners_per_lap")]
    public int CornersPerLap { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("first_sale")]
    public DateTime FirstSale { get; set; }

    [JsonPropertyName("free_with_subscription")]
    public bool FreeWithSubscription { get; set; }

    [JsonPropertyName("fully_lit")]
    public bool FullyLit { get; set; }

    [JsonPropertyName("grid_stalls")]
    public int GridStalls { get; set; }

    [JsonPropertyName("has_opt_path")]
    public bool HasOptPath { get; set; }

    [JsonPropertyName("has_short_parade_lap")]
    public bool HasShortParadeLap { get; set; }

    [JsonPropertyName("has_start_zone")]
    public bool HasStartZone { get; set; }

    [JsonPropertyName("has_svg_map")]
    public bool HasSvgMap { get; set; }

    [JsonPropertyName("is_dirt")]
    public bool IsDirt { get; set; }

    [JsonPropertyName("is_oval")]
    public bool IsOval { get; set; }

    [JsonPropertyName("is_ps_purchasable")]
    public bool IsPsPurchasable { get; set; }

    [JsonPropertyName("lap_scoring")]
    public int LapScoring { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; } = string.Empty;

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("max_cars")]
    public int MaxCars { get; set; }

    [JsonPropertyName("night_lighting")]
    public bool NightLighting { get; set; }

    [JsonPropertyName("nominal_lap_time")]
    public double NominalLapTime { get; set; }

    [JsonPropertyName("number_pitstalls")]
    public int NumberPitStalls { get; set; }

    [JsonPropertyName("opens")]
    public DateTime Opens { get; set; }

    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    [JsonPropertyName("pit_road_speed_limit")]
    public int PitRoadSpeedLimit { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("price_display")]
    public string PriceDisplay { get; set; } = string.Empty;

    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    [JsonPropertyName("purchasable")]
    public bool Purchasable { get; set; }

    [JsonPropertyName("qualify_laps")]
    public int QualifyLaps { get; set; }

    [JsonPropertyName("restart_on_left")]
    public bool RestartOnLeft { get; set; }

    [JsonPropertyName("retired")]
    public bool Retired { get; set; }

    [JsonPropertyName("search_filters")]
    public string SearchFilters { get; set; } = string.Empty;

    [JsonPropertyName("site_url")]
    public string SiteUrl { get; set; } = string.Empty;

    [JsonPropertyName("sku")]
    public int Sku { get; set; }

    [JsonPropertyName("solo_laps")]
    public int SoloLaps { get; set; }

    [JsonPropertyName("start_on_left")]
    public bool StartOnLeft { get; set; }

    [JsonPropertyName("supports_grip_compound")]
    public bool SupportsGripCompound { get; set; }

    [JsonPropertyName("tech_track")]
    public bool TechTrack { get; set; }

    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; } = string.Empty;

    [JsonPropertyName("track_config_length")]
    public double TrackConfigLength { get; set; }

    [JsonPropertyName("track_dirpath")]
    public string TrackDirPath { get; set; } = string.Empty;

    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("track_name")]
    public string TrackName { get; set; } = string.Empty;

    [JsonPropertyName("track_types")]
    public List<TrackType> TrackTypes { get; set; } = new List<TrackType>();
}

public class TrackType
{
    [JsonPropertyName("track_type")]
    public string Type { get; set; } = string.Empty;
}
