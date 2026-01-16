namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// MemberChartData
/// </summary>
public class MemberChartData
{
    /// <summary>
    /// Blackout
    /// </summary>
    [JsonPropertyName("blackout")]
    public bool Blackout { get; set; }

    /// <summary>
    /// Category Id
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Chart Type
    /// </summary>
    [JsonPropertyName("chart_type")]
    public int ChartType { get; set; }

    /// <summary>
    /// Data
    /// </summary>
    [JsonPropertyName("data")]
    public List<DataItem> Data { get; set; } = new List<DataItem>();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }
}

/// <summary>
/// DataItem
/// </summary>
public class DataItem
{
    /// <summary>
    /// When
    /// </summary>
    [JsonPropertyName("when")]
    public DateTime When { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }
}

