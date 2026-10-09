using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// What a terrain provider can ask of the world driving it.
/// </summary>
/// <remarks>
/// Most providers never need this: one that only answers "what is in this chunk" is handed everything
/// it needs on the chunk itself. It is for the ones that have something to say back, which means
/// terrain landing in a chunk other than the one being generated.
/// </remarks>
public interface ITerrainHost {
    /// <summary>The lowest block a position can be at, the dimension's min y.</summary>
    int MinY { get; }

    /// <summary>One past the highest, <see cref="MinY"/> plus the dimension's height.</summary>
    int MaxY { get; }

    MinecraftRegistry Registry { get; }

    /// <summary>
    /// Applies a change to a chunk that has already been generated and marks everything derived from
    /// it stale. False when the chunk is not loaded, which is the caller's cue to park the change
    /// until it is.
    /// </summary>
    /// <remarks>
    /// Telling anyone about the change is <see cref="NotifyChunkChanged"/>'s job, not this one's. The
    /// caller may hold a lock across this, and does.
    /// </remarks>
    bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply);

    /// <summary>
    /// A chunk has finished changing and whoever holds it should be given it again.
    /// </summary>
    /// <remarks>
    /// Separate from <see cref="TryApplyToLoadedChunk"/> because it walks every player in the world
    /// and takes each of their queues, while the apply runs under a lock every chunk generating in
    /// the world posts through. Called once per chunk however many changes landed in it, and never
    /// with a lock held.
    /// <p/>
    /// Defaulted, so a host that has nobody to tell implements nothing.
    /// </remarks>
    void NotifyChunkChanged(Vec2<int> chunk) { }

    /// <summary>
    /// Something went wrong that the provider recovered from and carried on past, which whoever runs
    /// the world should still hear about. Defaulted, so a host with nowhere to report implements
    /// nothing.
    /// </summary>
    void ReportError(Exception error) { }

    /// <summary>
    /// Raised once per chunk, off the tick thread, <b>strictly after</b> it becomes visible to
    /// <see cref="TryApplyToLoadedChunk"/>.
    /// </summary>
    /// <remarks>
    /// That ordering is the whole safety property for a parked change. Given it, a poster holding one
    /// lock across "is it loaded, and if not park it" cannot lose: either it sees the chunk and
    /// applies, or it parks and this has not run yet, so the drain finds it. Fire it before the chunk
    /// is reachable and a fork posted in the gap is stranded for the world's lifetime with nothing
    /// thrown.
    /// </remarks>
    event Action<Vec2<int>> ChunkAvailable;
}
