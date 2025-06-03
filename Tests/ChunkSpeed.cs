using System.Diagnostics;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Implementations.Server.Worlds.TerrainProviders;
using Minecraft.Packets;
using Minecraft.Schemas;

namespace Tests;

public class ChunkSpeed {

    [Test]
    public void GenerateChunksSpeed() {
        const int viewDistance = 32;
        World world = new(new TestingProvider());
        
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < viewDistance*2; i++) {
            for (int j = 0; j < viewDistance*2; j++) {
                world.GetChunkPacket(new ChunkPosition(i, j));
            }
        }

        TimeSpan time = sw.Elapsed;
        int chunks = 4 * viewDistance * viewDistance;
        double msPerChunk = time.TotalMilliseconds / chunks;
        Console.WriteLine($"Took {time} to generate {chunks} chunks ({msPerChunk}ms/chunk)");
    }
    
    [Test]
    public void GenerateMultiChunksSpeed() {
        const int viewDistance = 32;
        ITerrainProvider world = new TestingProvider();
        
        Stopwatch sw = Stopwatch.StartNew();

        ChunkPosition[] poses = new ChunkPosition[viewDistance * viewDistance * 4];
        int index = 0;
        for (int i = 0; i < viewDistance*2; i++) {
            for (int j = 0; j < viewDistance*2; j++) {
                poses[index++] = new ChunkPosition(i, j);
            }
        }

        world.GetChunks(poses);

        TimeSpan time = sw.Elapsed;
        int chunks = 4 * viewDistance * viewDistance;
        double msPerChunk = time.TotalMilliseconds / chunks;
        Console.WriteLine($"Took {time} to generate {chunks} chunks ({msPerChunk}ms/chunk)");
    }
}