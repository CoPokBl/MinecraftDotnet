using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain.Providers;

public class ThreadedChunksTerrainProvider(ITerrainProvider child, int threadCount = 16) : ITerrainProvider {
    
    public void GetChunk(ref ChunkData chunk) {
        child.GetChunk(ref chunk);
    }

    public void GetChunks(int start, int count, ChunkData[] chunks) {
        Thread[] threads = new Thread[threadCount];
        
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * count / threadCount + start;
                
                for (int j = threadIndex * count / threadCount + start; j < end; j++) {
                    GetChunk(ref chunks[j]);
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
