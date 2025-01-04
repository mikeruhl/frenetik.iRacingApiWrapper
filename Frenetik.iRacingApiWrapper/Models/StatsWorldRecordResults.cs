namespace Frenetik.iRacingApiWrapper.Models;

public class StatsWorldRecordResults : IChunkInfo<StatsWorldRecordResultsChunkInfoData>
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public StatsWorldRecordResultsData Data { get; set; } = new StatsWorldRecordResultsData();
    public ChunkInfo ChunkInfo => Data.ChunkInfo;
}

public class StatsWorldRecordResultsData
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("track_id")]
    public int TrackId { get; set; }

    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }
}