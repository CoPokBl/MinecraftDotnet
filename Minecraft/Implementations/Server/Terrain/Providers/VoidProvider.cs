using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain.Providers;

/// <summary>Nothing anywhere. A chunk starts empty, so this has nothing to do.</summary>
public class VoidProvider : ITerrainProvider {
    public void GetChunk(ref ChunkData chunk) {
    }
}
