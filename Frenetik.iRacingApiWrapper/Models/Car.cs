namespace Frenetik.iRacingApiWrapper.Models;
public class Car
{
    /// <summary>
    /// AI Enabled
    /// </summary>
    [JsonPropertyName("ai_enabled")]
    public bool AiEnabled { get; set; } = false;

    /// <summary>
    /// Allow Number Colors
    /// </summary>
    [JsonPropertyName("allow_number_colors")]
    public bool AllowNumberColors { get; set; } = false;

    /// <summary>
    /// Allow Number Font
    /// </summary>
    [JsonPropertyName("allow_number_font")]
    public bool AllowNumberFont { get; set; } = false;

    /// <summary>
    /// Allow Sponsor 1
    /// </summary>
    [JsonPropertyName("allow_sponsor1")]
    public bool AllowSponsor1 { get; set; } = false;

    /// <summary>
    /// Allow Sponsor 2
    /// </summary>
    [JsonPropertyName("allow_sponsor2")]
    public bool AllowSponsor2 { get; set; } = false;

    /// <summary>
    /// Allow Wheel Color
    /// </summary>
    [JsonPropertyName("allow_wheel_color")]
    public bool AllowWheelColor { get; set; } = false;

    /// <summary>
    /// Award Exempt
    /// </summary>
    [JsonPropertyName("award_exempt")]
    public bool AwardExempt { get; set; } = false;

    /// <summary>
    /// Car Directory Path
    /// </summary>
    [JsonPropertyName("car_dirpath")]
    public string CarDirPath { get; set; } = string.Empty;

    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; } = 0;

    /// <summary>
    /// Car Name
    /// </summary>
    [JsonPropertyName("car_name")]
    public string CarName { get; set; } = string.Empty;

    /// <summary>
    /// Abbreviated Car Name
    /// </summary>
    [JsonPropertyName("car_name_abbreviated")]
    public string CarNameAbbreviated { get; set; } = string.Empty;

    /// <summary>
    /// Car Types
    /// </summary>
    [JsonPropertyName("car_types")]
    public List<CarTypeResult> CarTypes { get; set; } = new List<CarTypeResult>();

    /// <summary>
    /// Car Weight
    /// </summary>
    [JsonPropertyName("car_weight")]
    public int CarWeight { get; set; } = 0;

    /// <summary>
    /// Race Categories
    /// </summary>
    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; } = new List<string>();

    /// <summary>
    /// Created Date
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; } = DateTime.MinValue;

    /// <summary>
    /// First Sale Date
    /// </summary>
    [JsonPropertyName("first_sale")]
    public DateTime FirstSale { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Forum URL
    /// </summary>
    [JsonPropertyName("forum_url")]
    public string ForumUrl { get; set; } = string.Empty;

    /// <summary>
    /// Car free with subscription
    /// </summary>
    [JsonPropertyName("free_with_subscription")]
    public bool FreeWithSubscription { get; set; } = false;

    /// <summary>
    /// Has headlights
    /// </summary>
    [JsonPropertyName("has_headlights")]
    public bool HasHeadlights { get; set; } = false;

    /// <summary>
    /// Has multiple dry tire types
    /// </summary>
    [JsonPropertyName("has_multiple_dry_tire_types")]
    public bool HasMultipleDryTireTypes { get; set; } = false;

    /// <summary>
    /// Has multiple wet tire types
    /// </summary>
    [JsonPropertyName("has_rain_capable_tire_types")]
    public bool HasRainCapableTireTypes { get; set; } = false;

    /// <summary>
    /// Horsepower
    /// </summary>
    [JsonPropertyName("hp")]
    public int Hp { get; set; } = 0;

    /// <summary>
    /// Is purchasable
    /// </summary>
    [JsonPropertyName("is_ps_purchasable")]
    public bool IsPsPurchasable { get; set; } = false;

    /// <summary>
    /// Max power Adjustment Percentage
    /// </summary>
    [JsonPropertyName("max_power_adjust_pct")]
    public int MaxPowerAdjustPct { get; set; } = 0;

    /// <summary>
    /// Max Weight Penalty in Kg
    /// </summary>
    [JsonPropertyName("max_weight_penalty_kg")]
    public int MaxWeightPenaltyKg { get; set; } = 0;

    /// <summary>
    /// Min power Adjustment Percentage
    /// </summary>
    [JsonPropertyName("min_power_adjust_pct")]
    public int MinPowerAdjustPct { get; set; } = 0;

    /// <summary>
    /// Package Id
    /// </summary>
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; } = 0;

    /// <summary>
    /// Patterns
    /// </summary>
    [JsonPropertyName("patterns")]
    public int Patterns { get; set; } = 0;

    /// <summary>
    /// Price
    /// </summary>
    [JsonPropertyName("price")]
    public double Price { get; set; } = 0.0;

    /// <summary>
    /// Price Display
    /// </summary>
    [JsonPropertyName("price_display")]
    public string PriceDisplay { get; set; } = string.Empty;

    [JsonPropertyName("rain_enabled")]
    public bool RainEnabled { get; set; }

    /// <summary>
    /// Retired
    /// </summary>
    [JsonPropertyName("retired")]
    public bool Retired { get; set; } = false;

    /// <summary>
    /// Search Filters
    /// </summary>
    [JsonPropertyName("search_filters")]
    public string SearchFilters { get; set; } = string.Empty;

    /// <summary>
    /// Sku
    /// </summary>
    [JsonPropertyName("sku")]
    public int Sku { get; set; } = 0;

    public class CarTypeResult
    {
        [JsonPropertyName("car_type")]
        public string CarType { get; set; } = string.Empty;
    }
}
