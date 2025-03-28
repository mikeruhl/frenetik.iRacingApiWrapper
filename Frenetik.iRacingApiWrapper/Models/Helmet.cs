﻿namespace Frenetik.iRacingApiWrapper.Models
{
    public class Helmet
    {
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }
}
