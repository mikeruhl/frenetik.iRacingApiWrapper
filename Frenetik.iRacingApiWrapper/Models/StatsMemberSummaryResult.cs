namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsMemberSummaryResult
/// </summary>
public class StatsMemberSummaryResult
{
    /// <summary>
    /// This Year
    /// </summary>
    [JsonPropertyName("this_year")]
    public ThisYear ThisYear { get; set; } = new ThisYear();

    /// <summary>
    /// Customer Id
    /// </summary>
    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }
}

/// <summary>
/// ThisYear
/// </summary>
public class ThisYear
{
    /// <summary>
    /// Num Official Sessions
    /// </summary>
    [JsonPropertyName("num_official_sessions")]
    public int NumOfficialSessions { get; set; }

    /// <summary>
    /// Num League Sessions
    /// </summary>
    [JsonPropertyName("num_league_sessions")]
    public int NumLeagueSessions { get; set; }

    /// <summary>
    /// Num Official Wins
    /// </summary>
    [JsonPropertyName("num_official_wins")]
    public int NumOfficialWins { get; set; }

    /// <summary>
    /// Num League Wins
    /// </summary>
    [JsonPropertyName("num_league_wins")]
    public int NumLeagueWins { get; set; }
}
