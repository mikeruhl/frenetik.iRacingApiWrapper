namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsSeasonTtStandingsResult
/// </summary>
public class StatsSeasonTtStandingsResult : IChunkInfo<StatsSeasonTtStandingsChunkInfoData>
{
    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Season Name
    /// </summary>
    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    /// <summary>
    /// Season Short Name
    /// </summary>
    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    /// <summary>
    /// Series Id
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    /// <summary>
    /// Series Name
    /// </summary>
    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Race Week Num
    /// </summary>
    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    /// <summary>
    /// Division
    /// </summary>
    [JsonPropertyName("division")]
    public int Division { get; set; }

    /// <summary>
    /// Customer Rank
    /// </summary>
    [JsonPropertyName("customer_rank")]
    public int CustomerRank { get; set; }

    /// <summary>
    /// Chunk Info
    /// </summary>
    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

    /// <summary>
    /// Last Updated
    /// </summary>
    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }
}

