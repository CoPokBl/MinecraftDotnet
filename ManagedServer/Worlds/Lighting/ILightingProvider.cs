using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Lighting;

public interface ILightingProvider {
    /// <summary>
    /// Returns lighting for the given chunk. Implementations may cache the result keyed by
    /// <paramref name="chunkPos"/> and return it directly on subsequent calls without recomputing.
    /// </summary>
    /// <param name="neighborLookup">
    /// Optional function that resolves neighbor chunk data by position.
    /// Used for cross-chunk light propagation. Pass null when neighbors are unavailable.
    /// </param>
    LightData GetLighting(Vec2<int> chunkPos, ChunkData chunk,
        Func<Vec2<int>, ChunkData?>? neighborLookup, MinecraftRegistry registry, bool hasSkyLight);

    /// <summary>
    /// Invalidates any cached lighting for <paramref name="chunkPos"/> and its neighbors.
    /// Must be called after block changes so the next <see cref="GetLighting"/> recomputes.
    /// </summary>
    void Invalidate(Vec2<int> chunkPos);
}
