using BenchmarkDotNet.Attributes;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Benchmarking.Implementations.Server.Terrain;

/// <summary>
/// A viewport's worth of chunks, generated the two ways a consumer can write a generator.
/// </summary>
/// <remarks>
/// <see cref="PerBlock"/> asks about every position; <see cref="Bulk"/> writes the same terrain
/// through the fills the generation API exposes. The gap between them is the point of the API.
/// </remarks>
public class TerrainGenerationBenchmark {
    private const int ViewDistance = 32;
    private const int ChunkCount = ViewDistance * ViewDistance * 4;

    /// <summary>The same cone <see cref="TestingProvider"/> makes, written as fills.</summary>
    private sealed class BulkCone : IGenerator {
        private static readonly uint Barrier = (Block.Barrier with { Waterlogged = true }).StateId;

        public void Generate(IGenerationUnit unit) {
            for (int x = unit.AbsoluteStart.X; x < unit.AbsoluteEnd.X; x++) {
                for (int z = unit.AbsoluteStart.Z; z < unit.AbsoluteEnd.Z; z++) {
                    int height = unit.MinY + (int)Math.Sqrt(x*x + z*z);
                    unit.Modifier.FillState(new(x, unit.MinY, z),
                        new(x + 1, Math.Min(height, unit.MaxY), z + 1), Barrier);
                }
            }
        }
    }

    private ITerrainProvider _perBlock = null!;
    private ITerrainProvider _bulk = null!;

    [GlobalSetup]
    public void Setup() {
        _perBlock = new TestingProvider();
        _bulk = new GeneratorTerrainProvider(new BulkCone());
    }

    [Benchmark(Baseline = true)]
    public void PerBlock() => Generate(_perBlock);

    [Benchmark]
    public void Bulk() => Generate(_bulk);

    private static void Generate(ITerrainProvider provider) {
        for (int i = 0; i < ViewDistance*2; i++) {
            for (int j = 0; j < ViewDistance*2; j++) {
                ChunkData data = new(ChunkData.VanillaOverworldHeight) {
                    ChunkX = i,
                    ChunkZ = j,
                    MinY = -64
                };
                provider.GetChunk(ref data);
            }
        }
    }
}
