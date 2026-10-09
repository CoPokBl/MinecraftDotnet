using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Where a world's chunks go, the counterpart of <see cref="ITerrainProvider"/>.
/// </summary>
/// <remarks>
/// Same concurrency contract as <see cref="ITerrainProvider.GetChunk"/>: called from pool threads,
/// several at once, and must not start threads of its own.
/// <p/>
/// The chunk handed over is a snapshot: its palettes are immutable, so it can be read from any thread
/// and kept, which is what a sink holding a world in memory does. <b>Writing to one is not allowed</b>,
/// because the same object is shared with every player the chunk is being sent to.
/// </remarks>
public interface IChunkSink {
    public void PutChunk(ChunkData chunk);

    /// <summary>
    /// Removes a chunk, so a world that has been reset does not load the old one back.
    /// </summary>
    public void DeleteChunk(Vec2<int> pos) { }

    /// <summary>
    /// Makes everything written so far durable. Called at the end of a save rather than per chunk,
    /// so a store that batches can hold its writes until here.
    /// </summary>
    public void Flush() { }
}
