namespace Frenetik.iRacingApiWrapper.Models;

public class StatsMemberSummaryResult
{
    [JsonPropertyName("this_year")]
    public ThisYear ThisYear { get; set; } = new ThisYear();

    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }
}

public class ThisYear
{
    [JsonPropertyName("num_official_sessions")]
    public int NumOfficialSessions { get; set; }

    [JsonPropertyName("num_league_sessions")]
    public int NumLeagueSessions { get; set; }

    [JsonPropertyName("num_official_wins")]
    public int NumOfficialWins { get; set; }

    [JsonPropertyName("num_league_wins")]
    public int NumLeagueWins { get; set; }
}