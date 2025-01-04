namespace Frenetik.iRacingApiWrapper.Models;

public class MemberChartData
{
    [JsonPropertyName("blackout")]
    public bool Blackout { get; set; }

    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("chart_type")]
    public int ChartType { get; set; }

    [JsonPropertyName("data")]
    public List<DataItem> Data { get; set; } = new List<DataItem>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }
}

public class DataItem
{
    [JsonPropertyName("when")]
    public DateTime When { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }
}
