using BenchmarkDotNet.Attributes;
using ManagedServer.Terrain;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Benchmarking.Terrain;

/// <summary>
/// One chunk of vanilla overworld terrain, and the same call against a provider that generates
/// nothing.
/// </summary>
/// <remarks>
/// The gap between the two is the generator; the baseline is what the generation API itself costs,
/// which is a staging buffer, a palette build per section and a heightmap pass. That split is the
/// point of having both here: an improvement to the API cannot be worth more than the baseline, and
/// on this shape the baseline rounds to nothing.
/// <p/>
/// Chunks are generated at moving positions rather than the same one repeatedly, because the
/// generator's caches are per chunk and a fixed position would measure a shape a joining player
/// never sees. Nothing is cached between chunks, so the position moving costs nothing beyond that.
/// <p/>
/// This measures a chunk. <see cref="Worlds.ChunkPipelineQuickBench"/> measures a join, which is the
/// thing actually complained about, and says what share of one this is.
/// </remarks>
[MemoryDiagnoser]
public class VanillaTerrainBenchmark {
    private const long Seed = 1234567890L;
    private const int WorldHeight = 384;
    private const int MinY = -64;

    private MinecraftRegistry _registry = null!;
    private ITerrainProvider _vanilla = null!;
    private ITerrainProvider _empty = null!;

    private int _next;

    [GlobalSetup]
    public void Setup() {
        _registry = VanillaRegistry.Data;
        _vanilla = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, _registry).AsProvider();
        _empty = new VoidProvider();

        // The datapack parse, the region tree build and every static registry, so the first
        // measured chunk is not paying for them.
        Generate(_vanilla);
    }

    [Benchmark(Description = "Vanilla overworld, one chunk")]
    public ChunkData Vanilla() => Generate(_vanilla);

    [Benchmark(Description = "Generation API only, one chunk")]
    public ChunkData Empty() => Generate(_empty);

    private ChunkData Generate(ITerrainProvider provider) {
        int at = _next++;
        ChunkData data = new(WorldHeight) { ChunkX = at & 1023, ChunkZ = at >> 10, MinY = MinY };
        provider.GetChunk(ref data);
        data.MinY = MinY;
        data.PackData(_registry);
        return data;
    }
}
