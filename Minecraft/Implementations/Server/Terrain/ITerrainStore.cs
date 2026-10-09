using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Somewhere chunks are both read from and written to.
/// </summary>
public interface ITerrainStore : ITerrainProvider, IChunkSink {
    /// <summary>
    /// <see cref="ITerrainProvider.GetChunk"/> with a miss signalled rather than swallowed, which is
    /// what lets a generator stand behind a store: <c>false</c> means nothing has been saved here yet
    /// and the chunk is untouched.
    /// </summary>
    public bool TryGetChunk(ref ChunkData chunk);

    void ITerrainProvider.GetChunk(ref ChunkData chunk) {
        TryGetChunk(ref chunk);
    }
}
