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
        ChunkData dat = data;

        // The split has to land on section boundaries. A ChunkSection is not thread-safe: the
        // first write to one lazily unpacks its palette into a fresh block array, so two threads
        // writing the same section each allocate one and whichever stores last silently throws
        // the other's blocks away. Splitting by raw Y let that happen wherever a thread boundary
        // fell inside a section, which for the default 16 threads was most of them.
        int sectionCount = dat.WorldHeight / ChunkSection.Size;
        int usedThreads = Math.Min(threadCount, sectionCount);
        if (usedThreads <= 0) {
            return;
        }

        Thread[] threads = new Thread[usedThreads];

        for (int i = 0; i < usedThreads; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int firstSection = threadIndex * sectionCount / usedThreads;
                int lastSection = (threadIndex + 1) * sectionCount / usedThreads;

                int startY = firstSection * ChunkSection.Size;
                int endY = Math.Min(lastSection * ChunkSection.Size, dat.WorldHeight);

                for (int x = 0; x < ChunkSection.Size; x++) {
                    for (int y = startY; y < endY; y++) {
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
