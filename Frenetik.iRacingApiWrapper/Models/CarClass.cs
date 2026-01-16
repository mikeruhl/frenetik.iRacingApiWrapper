namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Represents a car class grouping
/// </summary>
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
    /// Customer Id
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

    /// <summary>
    /// Reference to a car within the class
    /// </summary>
    public class CarRef
    {
        /// <summary>
        /// Car directory path
        /// </summary>
        [JsonPropertyName("car_dirpath")]
        public string CarDirPath { get; set; } = string.Empty;

        /// <summary>
        /// Car Id
        /// </summary>
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        /// <summary>
        /// Whether car is retired
        /// </summary>
        [JsonPropertyName("retired")]
        public bool IsRetired { get; set; }
    }
}

