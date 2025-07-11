using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain.Providers;

public abstract class PerBlockTerrainProvider : ITerrainProvider {

    public abstract uint GetBlock(int x, int y, int z);
    
    public ChunkData GetChunk(IVec2 pos) {
        ChunkData data = new();
        for (int x = 0; x < 16; x++) {
            for (int y = 0; y < 384; y++) {
                for (int z = 0; z < 16; z++) {
                    int absX = pos.X * 16 + x;
                    int absZ = pos.Z * 16 + z;
                    data.SetBlock(x, y, z, GetBlock(absX, y, absZ));
                }
            }
        }

        return data;
    }

    public IEnumerable<ChunkData> GetChunks(int count, params IVec2[] poses) {
        ChunkData[] chunks = new ChunkData[count];
        for (int i = 0; i < count; i++) {
            chunks[i] = GetChunk(poses[i]);
        }

        return chunks;
    }
}