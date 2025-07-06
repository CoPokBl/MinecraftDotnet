using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

public interface ITerrainProvider {
    public ChunkData GetChunk(IVec2 chunk);
    public IEnumerable<ChunkData> GetChunks(int count, params IVec2[] chunks);
}
