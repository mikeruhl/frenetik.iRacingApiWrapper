namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Represents a driver in iRacing
/// </summary>
public class Driver
{
    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Display name
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Helmet customization
    /// </summary>
    [JsonPropertyName("helmet")]
    public HelmetResult Helmet { get; set; } = new HelmetResult();

    /// <summary>
    /// Whether driver's profile is disabled
    /// </summary>
    [JsonPropertyName("profile_disabled")]
    public bool ProfileDisabled { get; set; }

    /// <summary>
    /// Helmet customization details
    /// </summary>
    public class HelmetResult
    {
        /// <summary>
        /// Helmet pattern Id
        /// </summary>
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        /// <summary>
        /// Primary color
        /// </summary>
        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        /// <summary>
        /// Secondary color
        /// </summary>
        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        /// <summary>
        /// Tertiary color
        /// </summary>
        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        /// <summary>
        /// Face type Id
        /// </summary>
        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        /// <summary>
        /// Helmet type Id
        /// </summary>
        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }
}

