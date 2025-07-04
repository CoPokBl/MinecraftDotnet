using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain.Providers;

public class ThreadedChunksTerrainProvider(ITerrainProvider child, int threadCount = 16) : ITerrainProvider {
    public ChunkData GetChunk(ChunkPosition chunk) {
        return child.GetChunk(chunk);
    }

    public IEnumerable<ChunkData> GetChunks(int count, params ChunkPosition[] poses) {
        ChunkData[] chunks = new ChunkData[count];
        Thread[] threads = new Thread[threadCount];
        
        for (int i = 0; i < threadCount; i++) {
            int threadIndex = i;
            Thread t = new(() => {
                int end = (threadIndex + 1) * count / threadCount;
                
                for (int j = threadIndex * count / threadCount; j < end; j++) {
                    chunks[j] = GetChunk(poses[j]);
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
