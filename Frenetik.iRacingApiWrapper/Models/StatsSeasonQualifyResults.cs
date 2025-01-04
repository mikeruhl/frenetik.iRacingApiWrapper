namespace Frenetik.iRacingApiWrapper.Models;

//TODO: Get the correct schema for chunk info data
public class StatsSeasonQualifyResults : IChunkInfo<string>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("season_name")]
    public string SeasonName { get; set; } = string.Empty;

    [JsonPropertyName("season_short_name")]
    public string SeasonShortName { get; set; } = string.Empty;

    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }

    [JsonPropertyName("series_name")]
    public string SeriesName { get; set; } = string.Empty;

    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    [JsonPropertyName("race_week_num")]
    public int RaceWeekNum { get; set; }

    [JsonPropertyName("division")]
    public int Division { get; set; }

    [JsonPropertyName("club_id")]
    public int ClubId { get; set; }

    [JsonPropertyName("customer_rank")]
    public int CustomerRank { get; set; }

    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; set; } = new ChunkInfo();

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }
}
