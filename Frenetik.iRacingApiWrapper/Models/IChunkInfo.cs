namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// Interface for reponse objects that contain a ChunkInfo object
/// </summary>
/// <typeparam name="T">Chunk Info Data Type to return</typeparam>
/// <see cref="IRacingApiService.GetChunkInfoData{T}(IChunkInfo{T})"/>
public interface IChunkInfo<T> where T : class
{
    /// <summary>
    /// Chunk Info
    /// </summary>
    [JsonPropertyName("chunk_info")]
    public ChunkInfo ChunkInfo { get; }
}
