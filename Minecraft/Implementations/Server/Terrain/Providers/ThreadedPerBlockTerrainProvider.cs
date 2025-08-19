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
    /// <param name="data">The chunk.</param>
    /// <returns>The generated chunk data.</returns>
    public void GetChunk(ref ChunkData data) {
        Thread[] threads = new Thread[threadCount];
        
        ChunkData dat = data;
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * dat.WorldHeight / threadCount;
                
                for (int x = 0; x < ChunkSection.Size; x++) {
                    for (int y = threadIndex * dat.WorldHeight / threadCount; y < end; y++) {
                        for (int z = 0; z < ChunkSection.Size; z++) {
                            int absX = dat.ChunkX * ChunkSection.Size + x;
                            int absZ = dat.ChunkZ * ChunkSection.Size + z;
                            dat.SetBlock(x, y, z, GetBlock(absX, y, absZ));
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
        
        data = dat; // Update the original data reference with the modified chunk data
    }
    
    public void SingleThreadedGetChunk(ChunkData data) {
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
        Thread[] threads = new Thread[threadCount];
        
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * count / threadCount + start;
                
                for (int j = threadIndex * count / threadCount + start; j < end; j++) {
                    SingleThreadedGetChunk(chunks[j]);
                }
            });
            
            t.Start();
            threads[i] = t;
        }
    
        foreach (Thread t in threads) {
            t.Join();
        }
    }
}
