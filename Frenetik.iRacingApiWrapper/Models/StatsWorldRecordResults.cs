namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// StatsWorldRecordResults
/// </summary>
public class StatsWorldRecordResults : IChunkInfo<StatsWorldRecordResultsChunkInfoData>
{
    /// <summary>
    /// Type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Data
    /// </summary>
    [JsonPropertyName("data")]
    public StatsWorldRecordResultsData Data { get; set; } = new StatsWorldRecordResultsData();

    /// <summary>
    /// Chunk info
    /// </summary>
    public ChunkInfo ChunkInfo => Data.ChunkInfo;
}

/// <summary>
/// StatsWorldRecordResultsData
/// </summary>
public class StatsWorldRecordResultsData
{
    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Track Id
    /// </summary>
    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

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
