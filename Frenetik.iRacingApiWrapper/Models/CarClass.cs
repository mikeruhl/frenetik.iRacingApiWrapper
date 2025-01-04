namespace Frenetik.iRacingApiWrapper.Models;

public class CarClass
{
    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Collection of cars in class
    /// </summary>
    [JsonPropertyName("cars_in_class")]
    public List<CarRef> CarsInClass { get; set; } = new List<CarRef>();

    /// <summary>
    /// Cust Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Rain Enabled
    /// </summary>
    [JsonPropertyName("rain_enabled")]
    public bool RainEnabled { get; set; }

    /// <summary>
    /// Relative speed
    /// </summary>
    [JsonPropertyName("relative_speed")]
    public int RelativeSpeed { get; set; }

    /// <summary>
    /// Short name
    /// </summary>
    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    public class CarRef
    {
        [JsonPropertyName("car_dirpath")]
        public string CarDirPath { get; set; } = string.Empty;

        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("retired")]
        public bool IsRetired { get; set; }
    }
}
