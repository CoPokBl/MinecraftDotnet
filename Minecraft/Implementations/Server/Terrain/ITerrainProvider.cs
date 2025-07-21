using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain;

// chunk.ChunkX and chunk.ChunkZ must ALWAYS be set before calling GetChunk or GetChunks
public interface ITerrainProvider {
    public void GetChunk(ChunkData chunk);
    public void GetChunks(int start, int count, ChunkData[] chunks);
}
