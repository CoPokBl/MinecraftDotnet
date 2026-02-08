using BenchmarkDotNet.Attributes;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Benchmarking.Implementations.Server.Terrain;

public class TerrainGenerationBenchmark {
    private ITerrainProvider _world = null!;
    private const int ViewDistance = 32;
    
    [IterationSetup(Target = "GenerateMultiChunksSpeed")]
    public void SetupGenerateMultiChunksSpeed() {
        _world = new TestingProvider();
    }
    
    [Benchmark(OperationsPerInvoke = 1)]
    public void GenerateMultiChunksSpeed() {
        ChunkData[] data = new ChunkData[ViewDistance * ViewDistance * 4];
        int index = 0;
        for (int i = 0; i < ViewDistance*2; i++) {
            for (int j = 0; j < ViewDistance*2; j++) {
                data[index++] = new ChunkData(ChunkData.VanillaOverworldHeight) {
                    ChunkX = i,
                    ChunkZ = j
                };
            }
        }

        _world.GetChunks(0, data.Length, data);
    }
}
