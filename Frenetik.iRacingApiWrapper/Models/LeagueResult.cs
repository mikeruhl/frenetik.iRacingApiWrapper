namespace Frenetik.iRacingApiWrapper.Models;
public class LeagueResult
{
    [JsonPropertyName("results_page")]
    public List<League> ResultsPage { get; set; } = new List<League>();

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("lowerbound")]
    public int LowerBound { get; set; }

    [JsonPropertyName("upperbound")]
    public int UpperBound { get; set; }

    [JsonPropertyName("row_count")]
    public int RowCount { get; set; }
}
