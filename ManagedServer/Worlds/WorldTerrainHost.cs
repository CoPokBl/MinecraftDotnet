using Minecraft.Implementations.Server.Terrain;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds;

/// <summary>
/// A world, as its terrain provider sees it.
/// </summary>
/// <remarks>
/// Exists so that <see cref="World"/> and <see cref="ChunkStore"/> do not have to know what a fork is.
/// The store's job is the chunk, the light over it and the packet built from both; parking terrain for
/// a chunk that has not been generated is a generation concern with a generation lifetime, and lives
/// on the provider.
/// </remarks>
internal sealed class WorldTerrainHost(World world, ChunkStore chunks) : ITerrainHost {
    public int MinY => world.MinY;
    public int MaxY => world.MaxY;
    public MinecraftRegistry Registry => world.Server.Registry;

    /// <summary>
    /// Raised by the store once a chunk's terrain has arrived, which is strictly after the chunk
    /// became reachable through <see cref="TryApplyToLoadedChunk"/>. See the remarks on
    /// <see cref="ITerrainHost.ChunkAvailable"/> for why that order is load bearing.
    /// </summary>
    public event Action<Vec2<int>>? ChunkAvailable {
        add => chunks.ChunkLoaded += value;
        remove => chunks.ChunkLoaded -= value;
    }

    event Action<Vec2<int>> ITerrainHost.ChunkAvailable {
        add => ChunkAvailable += value;
        remove => ChunkAvailable -= value;
    }

    public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) {
        if (!chunks.IsLoaded(chunk)) {
            return false;
        }

        // Through the store, which holds the chunk's write lock across the change and then marks the
        // chunk and its eight neighbours stale, so the cached packet and the light over it are both
        // discarded.
        chunks.Write(chunk, apply);
        return true;
    }

    public void NotifyChunkChanged(Vec2<int> chunk) {
        world.ResendChunk(chunk);
    }
}
