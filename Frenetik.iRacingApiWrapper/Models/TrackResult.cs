namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// TrackResult
/// </summary>
public class TrackResult
{
    /// <summary>
    /// Ai Enabled
    /// </summary>
    [JsonPropertyName("ai_enabled")]
    public bool AiEnabled { get; set; }

    /// <summary>
    /// Allow Pitlane Collisions
    /// </summary>
    [JsonPropertyName("allow_pitlane_collisions")]
    public bool AllowPitlaneCollisions { get; set; }

    /// <summary>
    /// Allow Rolling Start
    /// </summary>
    [JsonPropertyName("allow_rolling_start")]
    public bool AllowRollingStart { get; set; }

    /// <summary>
    /// Allow Standing Start
    /// </summary>
    [JsonPropertyName("allow_standing_start")]
    public bool AllowStandingStart { get; set; }

    /// <summary>
    /// Award Exempt
    /// </summary>
    [JsonPropertyName("award_exempt")]
    public bool AwardExempt { get; set; }

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Closes
    /// </summary>
    [JsonPropertyName("closes")]
    public DateTime Closes { get; set; }

    /// <summary>
    /// Config Name
    /// </summary>
    [JsonPropertyName("config_name")]
    public string ConfigName { get; set; } = string.Empty;

    /// <summary>
    /// Corners Per Lap
    /// </summary>
    [JsonPropertyName("corners_per_lap")]
    public int CornersPerLap { get; set; }

    /// <summary>
    /// Created
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// First Sale
    /// </summary>
    [JsonPropertyName("first_sale")]
    public DateTime FirstSale { get; set; }

    /// <summary>
    /// Free With Subscription
    /// </summary>
    [JsonPropertyName("free_with_subscription")]
    public bool FreeWithSubscription { get; set; }

    /// <summary>
    /// Fully Lit
    /// </summary>
    [JsonPropertyName("fully_lit")]
    public bool FullyLit { get; set; }

    /// <summary>
    /// Grid Stalls
    /// </summary>
    [JsonPropertyName("grid_stalls")]
    public int GridStalls { get; set; }

    /// <summary>
    /// Has Opt Path
    /// </summary>
    [JsonPropertyName("has_opt_path")]
    public bool HasOptPath { get; set; }

    /// <summary>
    /// Has Short Parade Lap
    /// </summary>
    [JsonPropertyName("has_short_parade_lap")]
    public bool HasShortParadeLap { get; set; }

    /// <summary>
    /// Has Start Zone
    /// </summary>
    [JsonPropertyName("has_start_zone")]
    public bool HasStartZone { get; set; }

    /// <summary>
    /// Has Svg Map
    /// </summary>
    [JsonPropertyName("has_svg_map")]
    public bool HasSvgMap { get; set; }

    /// <summary>
    /// Is Dirt
    /// </summary>
    [JsonPropertyName("is_dirt")]
    public bool IsDirt { get; set; }

    /// <summary>
    /// Is Oval
    /// </summary>
    [JsonPropertyName("is_oval")]
    public bool IsOval { get; set; }

    /// <summary>
    /// Is Ps Purchasable
    /// </summary>
    [JsonPropertyName("is_ps_purchasable")]
    public bool IsPsPurchasable { get; set; }

    /// <summary>
    /// Lap Scoring
    /// </summary>
    [JsonPropertyName("lap_scoring")]
    public int LapScoring { get; set; }

    /// <summary>
    /// Latitude
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    /// <summary>
    /// Location
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Longitude
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    /// <summary>
    /// Max Cars
    /// </summary>
    [JsonPropertyName("max_cars")]
    public int MaxCars { get; set; }

    /// <summary>
    /// Night Lighting
    /// </summary>
    [JsonPropertyName("night_lighting")]
    public bool NightLighting { get; set; }

    /// <summary>
    /// Nominal Lap Time
    /// </summary>
    [JsonPropertyName("nominal_lap_time")]
    public double NominalLapTime { get; set; }

    /// <summary>
    /// Number Pitstalls
    /// </summary>
    [JsonPropertyName("number_pitstalls")]
    public int NumberPitStalls { get; set; }

    /// <summary>
    /// Opens
    /// </summary>
    [JsonPropertyName("opens")]
    public DateTime Opens { get; set; }

    /// <summary>
    /// Package Id
    /// </summary>
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    /// <summary>
    /// Pit Road Speed Limit
    /// </summary>
    [JsonPropertyName("pit_road_speed_limit")]
    public int PitRoadSpeedLimit { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonPropertyName("price")]
    public double Price { get; set; }

    /// <summary>
    /// Price Display
    /// </summary>
    [JsonPropertyName("price_display")]
    public string PriceDisplay { get; set; } = string.Empty;

    /// <summary>
    /// Priority
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    /// <summary>
    /// Purchasable
    /// </summary>
    [JsonPropertyName("purchasable")]
    public bool Purchasable { get; set; }

    /// <summary>
    /// Qualify Laps
    /// </summary>
    [JsonPropertyName("qualify_laps")]
    public int QualifyLaps { get; set; }

    /// <summary>
    /// Restart On Left
    /// </summary>
    [JsonPropertyName("restart_on_left")]
    public bool RestartOnLeft { get; set; }

    /// <summary>
    /// Retired
    /// </summary>
    [JsonPropertyName("retired")]
    public bool Retired { get; set; }

    /// <summary>
    /// Search Filters
    /// </summary>
    [JsonPropertyName("search_filters")]
    public string SearchFilters { get; set; } = string.Empty;

    /// <summary>
    /// Site Url
    /// </summary>
    [JsonPropertyName("site_url")]
    public string SiteUrl { get; set; } = string.Empty;

    /// <summary>
    /// Sku
    /// </summary>
    [JsonPropertyName("sku")]
    public int Sku { get; set; }

    /// <summary>
    /// Solo Laps
    /// </summary>
    [JsonPropertyName("solo_laps")]
    public int SoloLaps { get; set; }

    /// <summary>
    /// Start On Left
    /// </summary>
    [JsonPropertyName("start_on_left")]
    public bool StartOnLeft { get; set; }

    /// <summary>
    /// Supports Grip Compound
    /// </summary>
    [JsonPropertyName("supports_grip_compound")]
    public bool SupportsGripCompound { get; set; }

    /// <summary>
    /// Tech Track
    /// </summary>
    [JsonPropertyName("tech_track")]
    public bool TechTrack { get; set; }

    /// <summary>
    /// Time Zone
    /// </summary>
    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; } = string.Empty;

    /// <summary>
    /// Track Config Length
    /// </summary>
    [JsonPropertyName("track_config_length")]
    public double TrackConfigLength { get; set; }

    /// <summary>
    /// Track Dirpath
    /// </summary>
    [JsonPropertyName("track_dirpath")]
    public string TrackDirPath { get; set; } = string.Empty;

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
    /// Track Types
    /// </summary>
    [JsonPropertyName("track_types")]
    public List<TrackType> TrackTypes { get; set; } = new List<TrackType>();
}

/// <summary>
/// TrackType
/// </summary>
public class TrackType
{
    /// <summary>
    /// Track Type
    /// </summary>
    [JsonPropertyName("track_type")]
    public string Type { get; set; } = string.Empty;
}

