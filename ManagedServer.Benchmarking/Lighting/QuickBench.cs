using System.Diagnostics;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Benchmarking.Lighting;

public static class QuickBench {
    public static void Run() {
        const int worldHeight = 384;
        var registry = VanillaRegistry.Data;
        var provider = new CalculatedLightingProvider(registry);

        ChunkData emptyChunk = new(worldHeight);
        emptyChunk.PackData();

        ChunkData solidChunk = new(worldHeight);
        solidChunk.Fill(Block.Stone.StateId);
        solidChunk.PackData();

        ChunkData terrainChunk = new(worldHeight);
        for (int s = 0; s < terrainChunk.Sections.Length / 2; s++)
            terrainChunk.Sections[s].Fill(Block.Stone.StateId);
        terrainChunk.PackData();

        Random rng = new(42);
        ChunkData lightChunk = new(worldHeight);
        for (int i = 0; i < 200; i++)
            lightChunk.SetBlock(rng.Next(16), rng.Next(worldHeight), rng.Next(16), Block.Glowstone.StateId);
        lightChunk.PackData();

        // Realistic: half-stone terrain with 20 torches in the bottom half
        ChunkData realisticChunk = new(worldHeight);
        for (int s = 0; s < realisticChunk.Sections.Length / 2; s++)
            realisticChunk.Sections[s].Fill(Block.Stone.StateId);
        Random rng2 = new(123);
        for (int i = 0; i < 20; i++) {
            int x = rng2.Next(16), z = rng2.Next(16), y = rng2.Next(worldHeight / 2);
            realisticChunk.SetBlock(x, y, z, Block.Torch.StateId);
        }
        realisticChunk.PackData();

        // Warmup
        for (int i = 0; i < 20; i++) {
            provider.Invalidate(new Vec2<int>(0, 0));
            provider.GetLighting(new Vec2<int>(0, 0), emptyChunk, null, registry, true);
        }

        Bench("Empty (sky)",     provider, emptyChunk,     new(0, 0), registry, true);
        Bench("Solid (sky)",     provider, solidChunk,     new(1, 0), registry, true);
        Bench("Terrain (sky)",   provider, terrainChunk,   new(2, 0), registry, true);
        Bench("200 Lights (sky)",provider, lightChunk,     new(3, 0), registry, true);
        Bench("Realistic (sky)", provider, realisticChunk, new(6, 0), registry, true);
        Bench("Empty (no sky)",  provider, emptyChunk,     new(4, 0), registry, false);
        Bench("200 Lights (ns)", provider, lightChunk,     new(5, 0), registry, false);
        Bench("Realistic (ns)",  provider, realisticChunk, new(7, 0), registry, false);
    }

    private static void Bench(string name, CalculatedLightingProvider provider, ChunkData chunk,
        Vec2<int> pos, Minecraft.Registry.MinecraftRegistry registry, bool sky) {
        const int iters = 200;
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iters; i++) {
            provider.Invalidate(pos);
            provider.GetLighting(pos, chunk, null, registry, sky);
        }
        sw.Stop();
        Console.WriteLine($"{name,-20} {sw.Elapsed.TotalMilliseconds / iters:F3} ms/call");
    }
}
