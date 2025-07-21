using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain.Providers;

public abstract class PerBlockTerrainProvider : ITerrainProvider {

    public abstract uint GetBlock(int x, int y, int z);
    
    public void GetChunk(ChunkData data) {
        for (int x = 0; x < ChunkSection.Size; x++) {
            for (int y = 0; y < data.WorldHeight; y++) {
                for (int z = 0; z < ChunkSection.Size; z++) {
                    int absX = data.ChunkX * ChunkSection.Size + x;
                    int absZ = data.ChunkZ * ChunkSection.Size + z;
                    data.SetBlock(x, y, z, GetBlock(absX, y, absZ));
                }
            }
        }
    }

    public void GetChunks(int start, int count, ChunkData[] chunks) {
        for (int i = start; i < start + count; i++) {
            GetChunk(chunks[i]);
        }
    }
}
