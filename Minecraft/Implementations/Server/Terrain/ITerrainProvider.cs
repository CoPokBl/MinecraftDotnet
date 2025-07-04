using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain;

public interface ITerrainProvider {
    public ChunkData GetChunk(ChunkPosition chunk);
    public IEnumerable<ChunkData> GetChunks(int count, params ChunkPosition[] chunks);
}
