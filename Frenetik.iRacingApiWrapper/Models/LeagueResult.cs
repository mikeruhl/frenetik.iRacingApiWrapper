namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// LeagueResult
/// </summary>
public class LeagueResult
{
    /// <summary>
    /// Results Page
    /// </summary>
    [JsonPropertyName("results_page")]
    public List<League> ResultsPage { get; set; } = new List<League>();

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Lowerbound
    /// </summary>
    [JsonPropertyName("lowerbound")]
    public int LowerBound { get; set; }

    /// <summary>
    /// Upperbound
    /// </summary>
    [JsonPropertyName("upperbound")]
    public int UpperBound { get; set; }

    /// <summary>
    /// Row Count
    /// </summary>
    [JsonPropertyName("row_count")]
    public int RowCount { get; set; }
}

