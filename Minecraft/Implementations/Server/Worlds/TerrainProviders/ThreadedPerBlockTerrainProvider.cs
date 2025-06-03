using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Worlds.TerrainProviders;

public abstract class ThreadedPerBlockTerrainProvider(int threadCount = 16) : ITerrainProvider {
    
    public abstract uint GetBlock(int x, int y, int z);
    
    public new ChunkData GetChunk(ChunkPosition pos) {
        ChunkData data = new();
        Thread[] threads = new Thread[threadCount];
        
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * 384 / threadCount;
                
                for (int x = 0; x < 16; x++) {
                    for (int y = threadIndex * 384 / threadCount; y < end; y++) {
                        for (int z = 0; z < 16; z++) {
                            int absX = pos.X * 16 + x;
                            int absZ = pos.Z * 16 + z;
                            data.SetBlock(x, y, z, GetBlock(absX, y, absZ));
                        }
                    }
                }
            });
            
            t.Start();
            threads[i] = t;
        }

        foreach (Thread t in threads) {
            t.Join();
        }

        return data;
    }
    
    public ChunkData SingleThreadedGetChunk(ChunkPosition pos) {
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

    public new IEnumerable<ChunkData> GetChunks(params ChunkPosition[] poses) {
        ChunkData[] chunks = new ChunkData[poses.Length];
        Thread[] threads = new Thread[threadCount];
        
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * poses.Length / threadCount;
                
                for (int j = threadIndex * poses.Length / threadCount; j < end; j++) {
                    chunks[j] = SingleThreadedGetChunk(poses[j]);
                }
            });
            
            t.Start();
            threads[i] = t;
        }

        foreach (Thread t in threads) {
            t.Join();
        }

        return chunks;
    }
}