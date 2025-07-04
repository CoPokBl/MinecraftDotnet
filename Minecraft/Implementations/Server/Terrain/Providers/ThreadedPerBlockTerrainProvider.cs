using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain.Providers;

public abstract class ThreadedPerBlockTerrainProvider(int threadCount = 16) : ITerrainProvider {
    
    public abstract uint GetBlock(int x, int y, int z);
    
    /// <summary>
    /// Get a chunk by splitting sections into threads.
    /// <p/>
    /// This is incredibly slow while using a debugger due to
    /// the number of threads it creates.
    /// However, it is a fair bit faster without a debugger.
    /// </summary>
    /// <param name="pos">The chunk coords.</param>
    /// <returns>The generated chunk data.</returns>
    public ChunkData GetChunk(ChunkPosition pos) {
        ChunkData data = new() {
            ChunkX = pos.X,
            ChunkZ = pos.Z
        };
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
        ChunkData data = new() {
            ChunkX = pos.X,
            ChunkZ = pos.Z
        };

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
    
    public IEnumerable<ChunkData> GetChunks(int count, params ChunkPosition[] poses) {
        ChunkData[] chunks = new ChunkData[count];
        Thread[] threads = new Thread[threadCount];
        
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * count / threadCount;
                
                for (int j = threadIndex * count / threadCount; j < end; j++) {
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