namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Driver
/// </summary>
public class Driver
{
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("helmet")]
    public HelmetResult Helmet { get; set; } = new HelmetResult();

    [JsonPropertyName("profile_disabled")]
    public bool ProfileDisabled { get; set; }

    public class HelmetResult
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
