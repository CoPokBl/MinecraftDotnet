using System.Collections.Concurrent;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using ManagedServer.Worlds.Saving;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Storage;
using Minecraft.Implementations.Storage.Stores;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Worlds;

public class AutosaveFeatureTest {
    private static readonly TimeSpan Interval = TimeSpan.FromMilliseconds(30);

    private sealed class FlatTerrain : ITerrainProvider {
        public void GetChunk(ref ChunkData chunk) {
            chunk.SetBlock(0, 0, 0, Block.Stone);
        }
    }

    private static ManagedMinecraftServer NewServer() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.LogAction = _ => { };
        return server;
    }

    private static World NewWorld(ManagedMinecraftServer server, bool withSink, out MemoryChunkBlobStore blobs) {
        World world = server.CreateWorld(new FlatTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
        blobs = new MemoryChunkBlobStore();
        if (withSink) {
            world.Sink = new CodecTerrainStore(new AnvilChunkCodec(VanillaRegistry.Data), blobs);
        }

        world.LoadChunks([new Vec2<int>(0, 0)]).Wait(TimeSpan.FromSeconds(30));
        return world;
    }

    /// <summary>Registered on the server it saves every world that has a sink, and passes over one that does not.</summary>
    [Test]
    public void OnTheServerItSavesEveryWorldWithASink() {
        ManagedMinecraftServer server = NewServer();
        World first = NewWorld(server, true, out MemoryChunkBlobStore firstBlobs);
        World second = NewWorld(server, true, out MemoryChunkBlobStore secondBlobs);
        World unsaved = NewWorld(server, false, out _);

        ConcurrentDictionary<World, SaveReport> reports = new();
        using ManualResetEventSlim bothSaved = new(false);

        AutosaveFeature autosave = new(Interval);
        autosave.Saved += (world, report) => {
            reports.TryAdd(world, report);
            if (reports.ContainsKey(first) && reports.ContainsKey(second)) {
                bothSaved.Set();
            }
        };

        server.AddFeature(autosave);
        try {
            Assert.That(bothSaved.Wait(TimeSpan.FromSeconds(10)), Is.True, "not every world with a sink was saved");
        } finally {
            autosave.Unregister();
        }

        Assert.That(firstBlobs.Count, Is.EqualTo(1));
        Assert.That(secondBlobs.Count, Is.EqualTo(1));
        Assert.That(reports.ContainsKey(unsaved), Is.False, "a world with no sink was saved");
    }

    [Test]
    public void OnAWorldItSavesOnlyThatWorld() {
        ManagedMinecraftServer server = NewServer();
        World saved = NewWorld(server, true, out MemoryChunkBlobStore savedBlobs);
        World other = NewWorld(server, true, out MemoryChunkBlobStore otherBlobs);

        using ManualResetEventSlim done = new(false);
        AutosaveFeature autosave = new(Interval);
        autosave.Saved += (_, _) => done.Set();

        saved.AddFeature(autosave);
        try {
            Assert.That(done.Wait(TimeSpan.FromSeconds(10)), Is.True);
        } finally {
            autosave.Unregister();
        }

        Assert.That(savedBlobs.Count, Is.EqualTo(1));
        Assert.That(otherBlobs.Count, Is.Zero);
        Assert.That(other.IsChunkDirty(new Vec2<int>(0, 0)), Is.True);
    }

    /// <summary>
    /// A world scoped feature is not unregistered by a stop, and its timer must not go on saving into a
    /// sink the consumer may be about to dispose.
    /// </summary>
    [Test]
    public void AWorldScopedAutosaveStopsWithTheServer() {
        ManagedMinecraftServer server = NewServer();
        World world = NewWorld(server, true, out _);

        int saves = 0;
        using ManualResetEventSlim first = new(false);
        AutosaveFeature autosave = new(Interval, new SaveOptions { Scope = SaveScope.Loaded });
        autosave.Saved += (_, _) => {
            Interlocked.Increment(ref saves);
            first.Set();
        };

        world.AddFeature(autosave);
        Assert.That(first.Wait(TimeSpan.FromSeconds(10)), Is.True);

        server.Stop();
        Thread.Sleep(Interval * 3);
        int afterStop = Volatile.Read(ref saves);

        Thread.Sleep(Interval * 10);
        Assert.That(Volatile.Read(ref saves), Is.EqualTo(afterStop), "the autosave kept running after the server stopped");
    }
}
