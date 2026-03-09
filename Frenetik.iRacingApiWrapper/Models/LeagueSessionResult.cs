namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Result from GetCustLeagueSessionResults (/league/cust_league_sessions)
/// </summary>
public class LeagueSessionResult
{
    /// <summary>
    /// Mine — whether results are filtered to sessions created by the user
    /// </summary>
    [JsonPropertyName("mine")]
    public bool Mine { get; set; }

    /// <summary>
    /// Sequence
    /// </summary>
    [JsonPropertyName("sequence")]
    public int Sequence { get; set; }

    /// <summary>
    /// Sessions
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<LeagueSession> Sessions { get; set; } = new List<LeagueSession>();

    /// <summary>
    /// Subscribed
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

/// <summary>
/// A league session, extending the shared Session with league-specific properties
/// </summary>
public class LeagueSession : Session
{
    /// <summary>
    /// Session Description
    /// </summary>
    [JsonPropertyName("session_desc")]
    public string SessionDesc { get; set; } = string.Empty;

    /// <summary>
    /// League Name
    /// </summary>
    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

    /// <summary>
    /// League Season Name
    /// </summary>
    [JsonPropertyName("league_season_name")]
    public string LeagueSeasonName { get; set; } = string.Empty;

    /// <summary>
    /// AI Min Skill
    /// </summary>
    [JsonPropertyName("ai_min_skill")]
    public int AiMinSkill { get; set; }

    /// <summary>
    /// AI Max Skill
    /// </summary>
    [JsonPropertyName("ai_max_skill")]
    public int AiMaxSkill { get; set; }

    /// <summary>
    /// Image
    /// </summary>
    [JsonPropertyName("image")]
    public object? Image { get; set; }

    /// <summary>
    /// Owner
    /// </summary>
    [JsonPropertyName("owner")]
    public bool Owner { get; set; }

    /// <summary>
    /// Admin
    /// </summary>
    [JsonPropertyName("admin")]
    public bool Admin { get; set; }
}
