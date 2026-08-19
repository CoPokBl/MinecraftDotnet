using System.Diagnostics;
using ManagedServer.Terrain;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

using ManagedServer.Benchmarking.Terrain;

namespace ManagedServer.Benchmarking.Worlds;

/// <summary>
/// Whether the server can still answer anything while a join generates a viewport.
/// </summary>
/// <remarks>
/// A whole viewport is asked for in one tick, so the question is not how long the terrain takes but
/// what happens to everything else while it does. A work item is posted to the pool every 50ms and
/// timed: a packet read resumes as a pool work item and <c>HandlePacket</c> runs inline on it, so
/// that latency is what a player's chat message, movement and keepalive wait for.
/// <p/>
/// 65x65 chunks on 16 cores, which is view distance 32: 4225 chunks in 21.2s either way, and pool
/// latency of 3.1ms median, 7.3ms p90, 31.7ms max. Posting the same chunks straight to the pool
/// instead of through <see cref="ChunkGenerationQueue"/> gives the same 21.2s and a max of 20.2
/// <em>seconds</em>, because the pool's queue is global and first in first out. The generation total
/// is what this must not regress and the latency is what it exists to measure.
/// <p/>
/// Only generation, so the numbers are a floor: the real path also lights and serialises each chunk,
/// and both of those are pool work that queues behind the same backlog.
/// </remarks>
public static class JoinResponsivenessQuickBench {
    private const long Seed = 1234567890L;

    public static void Run(string[] args) {
        int viewDistance = args.Length > 0 && int.TryParse(args[0], out int vd) ? vd : 32;
        int side = viewDistance * 2 + 1;
        int count = side * side;

        MinecraftRegistry registry = VanillaRegistry.Data;
        ITerrainProvider provider = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed, registry).AsProvider();

        Console.WriteLine($"cores {Environment.ProcessorCount}, server gc {System.Runtime.GCSettings.IsServerGC}");
        Console.WriteLine($"view distance {viewDistance}, {side}x{side} = {count} chunks");
        Console.WriteLine();

        // Held, as the chunk store holds every chunk it has loaded.
        List<ChunkData> loaded = [];

        // Models a chat packet: a work item posted to the pool from outside, every 50ms. Its latency
        // is how long a player waits for anything the server does off the tick thread.
        List<double> heartbeats = [];
        CancellationTokenSource stop = new();
        Thread heartbeat = new(() => {
            while (!stop.IsCancellationRequested) {
                Stopwatch sw = Stopwatch.StartNew();
                ManualResetEventSlim done = new();
                _ = Task.Run(() => done.Set());
                done.Wait(TimeSpan.FromSeconds(120));
                lock (heartbeats) heartbeats.Add(sw.Elapsed.TotalMilliseconds);
                Thread.Sleep(50);
            }
        }) { IsBackground = true };
        heartbeat.Start();

        long before = GC.GetTotalAllocatedBytes();
        Stopwatch total = Stopwatch.StartNew();

        // Exactly what ReconcileViewport does on the first tick: every chunk of the viewport asked
        // for at once.
        ChunkGenerationQueue generation = new(e => Console.WriteLine(e));
        Console.WriteLine($"generation concurrency {generation.MaxConcurrency}");
        Console.WriteLine();

        List<Task> loads = [];
        for (int dx = -viewDistance; dx <= viewDistance; dx++) {
            for (int dz = -viewDistance; dz <= viewDistance; dz++) {
                Vec2<int> pos = new(dx, dz);

                // ChunkStore.StartLoad and LoadCore.
                TaskCompletionSource done = new(TaskCreationOptions.RunContinuationsAsynchronously);
                loads.Add(done.Task);
                generation.Post(() => {
                    ChunkData data = new(384) { ChunkX = pos.X, ChunkZ = pos.Y, MinY = -64 };
                    provider.GetChunk(ref data);
                    data.MinY = -64;
                    data.PackData(registry);
                    lock (loaded) loaded.Add(data);
                    done.SetResult();
                });
            }
        }

        int reported = 0;
        while (!Task.WhenAll(loads).IsCompleted) {
            Thread.Sleep(1000);
            int done = loads.Count(t => t.IsCompleted);
            if (done == reported) continue;
            reported = done;
            Console.WriteLine($"  {total.Elapsed.TotalSeconds,6:F1}s  {done,5}/{count} chunks  "
                + $"heap {GC.GetTotalMemory(false) / (1024 * 1024),6} MB  "
                + $"rss {Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024),6} MB  "
                + $"pool queue {ThreadPool.PendingWorkItemCount,4} gen queue {generation.Pending,5}  threads {ThreadPool.ThreadCount,3}");
        }

        total.Stop();
        stop.Cancel();

        Console.WriteLine();
        Console.WriteLine($"generated {count} chunks in {total.Elapsed.TotalSeconds:F1}s "
            + $"({total.Elapsed.TotalMilliseconds / count:F1} ms/chunk of wall time)");
        Console.WriteLine($"allocated {(GC.GetTotalAllocatedBytes() - before) / (1024 * 1024)} MB, "
            + $"live heap {GC.GetTotalMemory(false) / (1024 * 1024)} MB, "
            + $"rss {Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024)} MB");
        Console.WriteLine($"gc gen0 {GC.CollectionCount(0)} gen1 {GC.CollectionCount(1)} gen2 {GC.CollectionCount(2)}");

        lock (heartbeats) {
            heartbeats.Sort();
            Console.WriteLine();
            Console.WriteLine($"pool latency over {heartbeats.Count} samples (this is what chat waits on):");
            Console.WriteLine($"  median {heartbeats[heartbeats.Count / 2]:F1} ms");
            Console.WriteLine($"  p90    {heartbeats[(int)(heartbeats.Count * 0.9)]:F1} ms");
            Console.WriteLine($"  max    {heartbeats[^1]:F1} ms");
        }
    }
}
