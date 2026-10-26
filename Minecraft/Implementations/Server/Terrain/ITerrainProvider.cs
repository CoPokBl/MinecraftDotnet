using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Where a world's chunks come from.
/// </summary>
/// <remarks>
/// <c>chunk.ChunkX</c>, <c>chunk.ChunkZ</c>, <c>chunk.WorldHeight</c> and <c>chunk.MinY</c> are all set
/// before the call, and between them say which chunk of which world is wanted. The chunk is taken by
/// reference so a provider that already holds one can hand it back rather than copying into the one
/// it was given.
/// <p/>
/// Called on a pool thread, one task per chunk, and for many chunks at once when a player joins. So an
/// implementation must be safe to call concurrently with itself, and must <b>not</b> start threads of
/// its own: the parallelism is already there, and adding a second layer of it multiplies the thread
/// count by the chunk count.
/// </remarks>
public interface ITerrainProvider {
    public void GetChunk(ref ChunkData chunk);

    /// <summary>
    /// Called once by whatever is driving this provider, before any chunk is asked for.
    /// </summary>
    /// <remarks>
    /// Defaults to nothing, since a provider that only answers questions has no use for it. One that
    /// has something to say back keeps the host: see <see cref="ITerrainHost"/>.
    /// </remarks>
    public void Attach(ITerrainHost host) { }
}
