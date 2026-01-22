namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Member Awards Response
/// </summary>
public class MemberAwardsResponse<T> where T: class,new()
{
    /// <summary>
    /// Type of response
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;


    /// <summary>
    /// Data Url
    /// </summary>
    [JsonPropertyName("data_url")]
    public string DataUrl { get; set; } = string.Empty;

    /// <summary>
    /// Hydrated response data
    /// </summary>
    [JsonIgnore]
    public T Data { get; set; } = new T();
}
