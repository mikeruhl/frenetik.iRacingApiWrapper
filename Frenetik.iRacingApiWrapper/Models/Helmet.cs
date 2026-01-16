namespace Frenetik.iRacingApiWrapper.Models
{
    /// <summary>
    /// Helmet customization
    /// </summary>
    public class Helmet
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

