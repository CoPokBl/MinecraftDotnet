using System.Collections.Concurrent;
using System.Diagnostics;
using ManagedServer.Terrain;
using Minecraft.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

using ManagedServer.Benchmarking.Terrain;

namespace ManagedServer.Benchmarking.Worlds;

/// <summary>
/// Wall time for every stage a chunk passes through on its way to a client, over a whole viewport.
/// </summary>
/// <remarks>
/// A stopwatch runner rather than a BenchmarkDotNet fixture because the thing being measured is a
/// join: 289 chunks generated once each and then serialised once per recipient, with the lighting of
/// each depending on whether its neighbours arrived first. BenchmarkDotNet measures a repeated call
/// against warm caches, which is the one shape this pipeline never runs in.
/// <p/>
/// Stages are timed against the same chunks in the order the server does them, so the totals add up
/// to what a join costs and each line is a share of it.
/// <p/>
/// Generation dominates and everything after it is noise: a 384 tall overworld chunk costs about 41ms
/// to generate against 1.2ms to light and 0.6ms to serialise. So a change to the chunk pipeline that
/// is not a change to <see cref="VanillaTerrainGenerator"/> is worth single digit percentages of a
/// join, and this is what says so rather than a guess about which stage looks expensive.
/// <p/>
/// The re-serialise line is what an extra recipient or a resend costs, and it is small because a
/// palette holds on to its wire form and its counts. It is the line to watch when changing anything
/// about how a chunk is written, since the first serialise hides that behind the heightmap pass.
/// <see cref="Terrain.VanillaTerrainBenchmark"/> is the same measurement for one chunk, as a
/// BenchmarkDotNet fixture.
/// </remarks>
public static class ChunkPipelineQuickBench {
    private const long Seed = 1234567890L;
    private const int WorldHeight = 384;
    private const int MinY = -64;

    /// <summary>Vanilla's default view distance of 8, so 17x17 chunks.</summary>
    private const int ViewDistance = 8;

    public static void Run(string[] args) {
        int viewDistance = args.Length > 0 && int.TryParse(args[0], out int vd) ? vd : ViewDistance;
        int side = viewDistance * 2 + 1;
        int count = side * side;

        MinecraftRegistry registry = VanillaRegistry.Data;

        Console.WriteLine($"Chunk pipeline, {side}x{side} = {count} chunks, height {WorldHeight}.");
        Console.WriteLine();

        // Warm every static registry and the generator's own one-time parsing, so the first chunk
        // measured is not paying for 700KB of JSON and a 7599 region search tree.
        Warm(registry);

        ITerrainProvider provider = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, registry).AsProvider();
        ITerrainProvider carved = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, registry).WithCarvers()
            .AsProvider();
        GeneratorTerrainProvider decorated = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, registry)
            .WithFeatures().AsProvider();

        // A feature spanning a chunk border forks, and a fork needs somewhere to go. Nothing here
        // reads the neighbouring chunks, so the host parks every one of them and they are never
        // drained: what is being timed is what a chunk costs to generate, not what it receives.
        decorated.Attach(new ParkingHost(registry));

        // The structure pass needs the feature pass, since vanilla interleaves the two per decoration
        // step, so what this measures against the decorated run is the structures alone.
        GeneratorTerrainProvider structured = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, registry)
            .WithFeatures().WithStructures().AsProvider();

        structured.Attach(new ParkingHost(registry));
        ITerrainProvider empty = new VoidProvider();

        Dictionary<Vec2<int>, ChunkData> chunks = new(count);

        // --- generation ---
        double voidMs = TimeGeneration(empty, registry, viewDistance, null);
        double genMs = TimeGeneration(provider, registry, viewDistance, chunks);

        // The pipeline below is measured against bare terrain, since what it costs does not depend on
        // whether there are trees in the chunk. The decorated run is here to say what the feature pass
        // adds to a chunk, which is the only number about it that matters.
        double decoratedMs = TimeGeneration(decorated, registry, viewDistance, null);
        double carvedMs = TimeGeneration(carved, registry, viewDistance, null);
        double structuredMs = TimeGeneration(structured, registry, viewDistance, null);

        Report("generate (vanilla terrain)", genMs, count);
        Report("generate (terrain + carvers)", carvedMs, count);
        Report("generate (terrain + features)", decoratedMs, count);
        Report("generate (features + structures)", structuredMs, count);
        Report("generate (void baseline)", voidMs, count);

        Console.WriteLine();
        CompareNeighbourReads(registry, viewDistance, count);
        Console.WriteLine();

        // --- everything after generation ---
        CalculatedLightingProvider lighting = new(registry);
        ChunkData? Lookup(Vec2<int> p) => chunks.GetValueOrDefault(p);

        Dictionary<Vec2<int>, ChunkData> snapshots = new(count);
        double snapshotMs = Time(() => {
            foreach ((Vec2<int> pos, ChunkData chunk) in chunks) {
                snapshots[pos] = chunk.Snapshot();
            }
        });
        Report("snapshot", snapshotMs, count);

        Dictionary<Vec2<int>, LightData> lights = new(count);
        double lightMs = Time(() => {
            foreach ((Vec2<int> pos, ChunkData snapshot) in snapshots) {
                lights[pos] = lighting.GetLighting(pos, snapshot, Lookup, registry, hasSkyLight: true);
            }
        });
        Report("light", lightMs, count);

        List<MinecraftPacket> packets = new(count);
        foreach ((Vec2<int> pos, ChunkData snapshot) in snapshots) {
            packets.Add(new ClientBoundChunkDataAndUpdateLightPacket {
                ChunkX = pos.X,
                ChunkZ = pos.Y,
                Data = snapshot,
                Light = lights[pos]
            });
        }

        // The heightmaps are computed by the first write and cached on the chunk, so this call is
        // what a first send costs and the ones after it are what a resend costs.
        long bytes = 0;
        double firstSerialiseMs = Time(() => {
            foreach (MinecraftPacket packet in packets) {
                bytes += packet.Serialise(ConnectionState.Play).Length;
            }
        });
        Report("serialise, first (incl. heightmaps)", firstSerialiseMs, count);

        double reserialiseMs = Time(() => {
            foreach (MinecraftPacket packet in packets) {
                packet.Serialise(ConnectionState.Play);
            }
        });
        Report("serialise, again (per extra recipient or resend)", reserialiseMs, count);

        double compressedMs = Time(() => {
            foreach (MinecraftPacket packet in packets) {
                packet.Serialise(ConnectionState.Play, 256);
            }
        });
        Report("serialise, compressed (threshold 256)", compressedMs, count);

        Console.WriteLine();
        Console.WriteLine($"{bytes / 1024.0 / 1024.0:F1} MB uncompressed over {count} chunks " +
            $"({bytes / (double)count / 1024.0:F0} KB each).");
        Console.WriteLine();

        double total = genMs + snapshotMs + lightMs + firstSerialiseMs;
        Console.WriteLine($"One player joining, best case (every stage once): {total:F0} ms.");
        Console.WriteLine($"  generate {genMs / total * 100:F0}%, snapshot {snapshotMs / total * 100:F0}%, " +
            $"light {lightMs / total * 100:F0}%, serialise {firstSerialiseMs / total * 100:F0}%.");
        Console.WriteLine();
        Console.WriteLine($"GC: gen0 {GC.CollectionCount(0)}, gen1 {GC.CollectionCount(1)}, " +
            $"gen2 {GC.CollectionCount(2)}, allocated {GC.GetTotalAllocatedBytes() / 1024.0 / 1024.0:F0} MB.");
    }

    /// <summary>
    /// The full pass into a host that holds what it generated, as a world does, once with neighbour
    /// reads served and once refused. Both apply every fork to a loaded chunk, so the difference is
    /// only the snapshots a decorating chunk takes of its generated neighbours.
    /// </summary>
    /// <remarks>
    /// A fork into a loaded chunk discards its snapshot, so a neighbour can be copied more than once.
    /// The parallel pair is the server's shape: there the snapshot is taken under the chunk's lock,
    /// which a fork landing in it from another thread waits on.
    /// <p/>
    /// Over 17x17 in order a pass takes about 1000 snapshots, 5ms of copying in all since a snapshot
    /// shares the chunk's immutable palettes. Reads on is about 1.5% slower across ten paired runs in
    /// order (9 of 10 slower, 31.0 against 31.5 ms per chunk), so nearly all of it is reading blocks
    /// through the snapshot and the features answering what they find there, not the copy. The
    /// parallel pair swings 15% run to run and shows nothing either way.
    /// </remarks>
    private static void CompareNeighbourReads(MinecraftRegistry registry, int viewDistance, int count) {
        foreach (bool parallel in (bool[])[false, true]) {
            string order = parallel ? "parallel" : "in order";

            foreach (bool reads in (bool[])[false, true]) {
                GeneratorTerrainProvider provider = VanillaTerrainGenerator
                    .Overworld(VanillaPack.Source, Seed, registry).WithFeatures().WithStructures().AsProvider();
                LoadedHost host = new(registry, reads);
                provider.Attach(host);

                long allocated = GC.GetTotalAllocatedBytes(true);
                double ms = Time(() => {
                    List<Vec2<int>> positions = [];
                    for (int x = -viewDistance; x <= viewDistance; x++) {
                        for (int z = -viewDistance; z <= viewDistance; z++) {
                            positions.Add(new Vec2<int>(x, z));
                        }
                    }

                    void Generate(Vec2<int> pos) {
                        ChunkData data = new(WorldHeight) { ChunkX = pos.X, ChunkZ = pos.Y, MinY = MinY };
                        provider.GetChunk(ref data);
                        data.MinY = MinY;
                        data.PackData(registry);
                        host.Publish(pos, data);
                    }

                    if (parallel) {
                        Parallel.ForEach(positions, Generate);
                    } else {
                        positions.ForEach(Generate);
                    }
                });
                double allocatedMb = (GC.GetTotalAllocatedBytes(true) - allocated) / 1024.0 / 1024.0;

                Report($"loaded host, {order}, neighbour reads {(reads ? "on" : "off")}", ms, count);
                Console.WriteLine($"{"",-48} {host.Reads,8} reads  {host.Snapshots,7} snapshots  " +
                    $"{host.CopyMs,5:F0} ms copying  {allocatedMb,6:F0} MB allocated");
            }
        }
    }

    private static double TimeGeneration(ITerrainProvider provider, MinecraftRegistry registry,
        int viewDistance, Dictionary<Vec2<int>, ChunkData>? into) {

        return Time(() => {
            for (int x = -viewDistance; x <= viewDistance; x++) {
                for (int z = -viewDistance; z <= viewDistance; z++) {
                    ChunkData data = new(WorldHeight) { ChunkX = x, ChunkZ = z, MinY = MinY };
                    provider.GetChunk(ref data);
                    data.MinY = MinY;
                    data.PackData(registry);
                    into?.Add(new Vec2<int>(x, z), data);
                }
            }
        });
    }

    /// <summary>
    /// One chunk through the generator and one through the lighting engine, so the measured run is
    /// not paying for a static constructor or a lazily parsed datapack.
    /// </summary>
    private static void Warm(MinecraftRegistry registry) {
        ITerrainProvider provider = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, registry).AsProvider();
        ChunkData data = new(WorldHeight) { ChunkX = 9999, ChunkZ = 9999, MinY = MinY };
        provider.GetChunk(ref data);
        data.MinY = MinY;
        data.PackData(registry);

        CalculatedLightingProvider lighting = new(registry);
        LightData light = lighting.GetLighting(new Vec2<int>(9999, 9999), data, null, registry, true);

        new ClientBoundChunkDataAndUpdateLightPacket {
            ChunkX = 9999, ChunkZ = 9999, Data = data, Light = light
        }.Serialise(ConnectionState.Play);
    }

    private static double Time(Action action) {
        Stopwatch sw = Stopwatch.StartNew();
        action();
        return sw.Elapsed.TotalMilliseconds;
    }

    private static void Report(string name, double totalMs, int chunks) {
        Console.WriteLine($"{name,-48} {totalMs,8:F0} ms total  {totalMs / chunks,7:F2} ms/chunk");
    }

    /// <summary>
    /// A host that has no chunks, so every fork parks. Enough for a measurement, and deliberately not
    /// enough for a world.
    /// </summary>
    private sealed class ParkingHost(MinecraftRegistry registry) : ITerrainHost {
        public event Action<Vec2<int>>? ChunkAvailable {
            add { }
            remove { }
        }

        public int MinY => -64;
        public int MaxY => -64 + WorldHeight;
        public MinecraftRegistry Registry => registry;

        public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) => false;
    }

    /// <summary>
    /// A host holding every chunk it is handed, with a snapshot cached per chunk and discarded by a
    /// write, as <c>ChunkStore</c> does.
    /// </summary>
    private sealed class LoadedHost(MinecraftRegistry registry, bool neighbourReads) : ITerrainHost {
        private readonly ConcurrentDictionary<Vec2<int>, Loaded> _chunks = new();
        private int _reads;
        private int _snapshots;
        private long _copyTicks;

        public event Action<Vec2<int>>? ChunkAvailable;

        public int MinY => -64;
        public int MaxY => -64 + WorldHeight;
        public MinecraftRegistry Registry => registry;
        public int Reads => _reads;
        public int Snapshots => _snapshots;
        public double CopyMs => TimeSpan.FromTicks(Interlocked.Read(ref _copyTicks)).TotalMilliseconds;

        public void Publish(Vec2<int> pos, ChunkData chunk) {
            _chunks[pos] = new Loaded(chunk);
            ChunkAvailable?.Invoke(pos);
        }

        public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) {
            if (!_chunks.TryGetValue(chunk, out Loaded? loaded)) {
                return false;
            }

            lock (loaded) {
                apply(loaded.Chunk);
                loaded.Snapshot = null;
            }

            return true;
        }

        public ChunkData? SnapshotLoadedChunk(Vec2<int> chunk) {
            if (!neighbourReads || !_chunks.TryGetValue(chunk, out Loaded? loaded)) {
                return null;
            }

            Interlocked.Increment(ref _reads);
            lock (loaded) {
                if (loaded.Snapshot is null) {
                    long start = Stopwatch.GetTimestamp();
                    loaded.Snapshot = loaded.Chunk.Snapshot();
                    loaded.Snapshot.PackData(registry);
                    Interlocked.Add(ref _copyTicks, Stopwatch.GetElapsedTime(start).Ticks);
                    Interlocked.Increment(ref _snapshots);
                }

                return loaded.Snapshot;
            }
        }

        private sealed class Loaded(ChunkData chunk) {
            public readonly ChunkData Chunk = chunk;
            public ChunkData? Snapshot;
        }
    }
}
