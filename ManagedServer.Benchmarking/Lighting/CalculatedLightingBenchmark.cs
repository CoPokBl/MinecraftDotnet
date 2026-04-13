using BenchmarkDotNet.Attributes;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Benchmarking.Lighting;

/// <summary>
/// Measures <see cref="CalculatedLightingProvider.GetLighting"/> across four representative
/// chunk configurations.  Each benchmark invalidates the cache entry before calling
/// <see cref="ILightingProvider.GetLighting"/> so the full BFS computation is timed,
/// not the cached result.
///
/// Configurations:
/// <list type="bullet">
///   <item>Empty — all air; maximum sky-light BFS work.</item>
///   <item>Solid — all stone; no propagation (baseline).</item>
///   <item>Terrain — lower half stone, upper half air; typical surface chunk.</item>
///   <item>LightSources — scattered glowstone in air; block-light BFS work.</item>
/// </list>
/// </summary>
[MemoryDiagnoser]
public class CalculatedLightingBenchmark {
    private const int WorldHeight = 384;

    private CalculatedLightingProvider _provider = null!;
    private MinecraftRegistry _registry = null!;

    private ChunkData _emptyChunk = null!;
    private ChunkData _solidChunk = null!;
    private ChunkData _terrainChunk = null!;
    private ChunkData _lightSourcesChunk = null!;

    private static readonly Vec2<int> PosEmpty = new(0, 0);
    private static readonly Vec2<int> PosSolid = new(1, 0);
    private static readonly Vec2<int> PosTerrain = new(2, 0);
    private static readonly Vec2<int> PosLights = new(3, 0);

    [GlobalSetup]
    public void Setup() {
        _registry = VanillaRegistry.Data;
        _provider = new CalculatedLightingProvider(_registry);

        _emptyChunk = BuildChunk(fill: null);
        _solidChunk = BuildChunk(fill: Block.Stone.StateId);
        _terrainChunk = BuildTerrainChunk();
        _lightSourcesChunk = BuildLightSourcesChunk();
    }

    // ── Benchmarks ────────────────────────────────────────────────────────────

    [Benchmark(Description = "Empty chunk (all air, full sky-light BFS)")]
    public LightData Empty() {
        _provider.Invalidate(PosEmpty);
        return _provider.GetLighting(PosEmpty, _emptyChunk, null, _registry, hasSkyLight: true);
    }

    [Benchmark(Description = "Solid chunk (all stone, no propagation)")]
    public LightData Solid() {
        _provider.Invalidate(PosSolid);
        return _provider.GetLighting(PosSolid, _solidChunk, null, _registry, hasSkyLight: true);
    }

    [Benchmark(Description = "Terrain chunk (lower half stone, upper half air)")]
    public LightData Terrain() {
        _provider.Invalidate(PosTerrain);
        return _provider.GetLighting(PosTerrain, _terrainChunk, null, _registry, hasSkyLight: true);
    }

    [Benchmark(Description = "Light sources chunk (scattered glowstone in air)")]
    public LightData LightSources() {
        _provider.Invalidate(PosLights);
        return _provider.GetLighting(PosLights, _lightSourcesChunk, null, _registry, hasSkyLight: true);
    }

    // ── Chunk builders ────────────────────────────────────────────────────────

    private static ChunkData BuildChunk(uint? fill) {
        ChunkData chunk = new(WorldHeight);
        if (fill.HasValue) {
            chunk.Fill(fill.Value);
        }
        chunk.PackData();
        return chunk;
    }

    private static ChunkData BuildTerrainChunk() {
        ChunkData chunk = new(WorldHeight);
        int halfSections = chunk.Sections.Length / 2;
        for (int s = 0; s < halfSections; s++) {
            chunk.Sections[s].Fill(Block.Stone.StateId);
        }
        chunk.PackData();
        return chunk;
    }

    private static ChunkData BuildLightSourcesChunk() {
        Random rng = new(42);
        ChunkData chunk = new(WorldHeight);
        for (int i = 0; i < 200; i++) {
            int x = rng.Next(16);
            int y = rng.Next(WorldHeight);
            int z = rng.Next(16);
            chunk.SetBlock(x, y, z, Block.Glowstone.StateId);
        }
        chunk.PackData();
        return chunk;
    }
}

