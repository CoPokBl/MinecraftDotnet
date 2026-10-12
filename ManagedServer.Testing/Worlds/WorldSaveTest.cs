using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Lighting;
using ManagedServer.Worlds.Saving;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Storage;
using Minecraft.Implementations.Storage.Stores;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Worlds;

/// <summary>
/// What a save takes and what it leaves, which is decided by the dirty flag rather than by the sink.
/// </summary>
/// <remarks>
/// The flag cannot be the chunk's packet version. That one moves whenever a neighbour loads, because
/// light crosses chunk borders, so keying persistence off it saves most of a generated world every
/// time anybody walks anywhere.
/// </remarks>
public class WorldSaveTest {
    /// <summary>A generator, so every chunk it makes starts out owed a save.</summary>
    private sealed class FlatTerrain : ITerrainProvider {
        public int Generated;

        public void GetChunk(ref ChunkData chunk) {
            Interlocked.Increment(ref Generated);
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    chunk.SetBlock(x, 0, z, Block.Stone);
                }
            }
        }
    }

    /// <summary>
    /// Full bright light with a hook in <see cref="Invalidate"/>, which a block write calls after it has
    /// released the chunk's lock and before it moves the chunk's packet version. Anything run from the
    /// hook runs in exactly that gap.
    /// </summary>
    private sealed class GapLighting : ILightingProvider {
        private readonly FullBrightLightingProvider _inner = new();

        public Action? OnInvalidate;

        public LightData GetLighting(Vec2<int> chunkPos, ChunkData chunk,
            Func<Vec2<int>, ChunkData?>? neighborLookup, MinecraftRegistry registry, bool hasSkyLight) {
            return _inner.GetLighting(chunkPos, chunk, neighborLookup, registry, hasSkyLight);
        }

        public void Invalidate(Vec2<int> chunkPos) {
            Action? hook = Interlocked.Exchange(ref OnInvalidate, null);
            hook?.Invoke();
            _inner.Invalidate(chunkPos);
        }
    }

    /// <summary>Holds every chunk handed to it until released, and counts how many have been.</summary>
    private sealed class GatedSink : IChunkSink {
        public readonly ManualResetEventSlim Release = new(false);
        public readonly SemaphoreSlim Entered = new(0);
        public int Puts;

        public void PutChunk(ChunkData chunk) {
            Interlocked.Increment(ref Puts);
            Entered.Release();
            Release.Wait(TimeSpan.FromSeconds(30));
        }
    }

    /// <summary>A store that fails the way a bug does rather than the way damaged data does.</summary>
    private sealed class FaultyStore : ITerrainStore {
        public bool TryGetChunk(ref ChunkData chunk) => throw new InvalidOperationException("a fault, not damage");

        public void PutChunk(ChunkData chunk) { }
    }

    private static World NewWorld(ITerrainProvider provider, ILightingProvider? lighting = null) {
        return NewWorld(provider, out _, lighting);
    }

    private static World NewWorld(ITerrainProvider provider, out List<string> log, ILightingProvider? lighting = null) {
        List<string> lines = log = [];
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.LogAction = line => {
            lock (lines) {
                lines.Add(line);
            }
        };
        return server.CreateWorld(provider, "minecraft:overworld", lighting ?? new FullBrightLightingProvider());
    }

    private static CodecTerrainStore NewStore(out MemoryChunkBlobStore blobs) {
        blobs = new MemoryChunkBlobStore();
        return new CodecTerrainStore(new AnvilChunkCodec(VanillaRegistry.Data), blobs);
    }

    private static World NewSavingWorld(out CodecTerrainStore store, out MemoryChunkBlobStore blobs,
        ILightingProvider? lighting = null) {
        World world = NewWorld(new FlatTerrain(), lighting);
        store = NewStore(out blobs);
        world.Sink = store;
        return world;
    }

    private static void Load(World world, params Vec2<int>[] positions) {
        world.LoadChunks(positions).Wait(TimeSpan.FromSeconds(30));
    }

    private static ChunkData ReadBack(CodecTerrainStore store, Vec2<int> pos) {
        ChunkData chunk = new(384) { ChunkX = pos.X, ChunkZ = pos.Y, MinY = -64 };
        Assert.That(store.TryGetChunk(ref chunk), Is.True, $"chunk {pos} was never stored");
        return chunk;
    }

    [Test]
    public void AGeneratedChunkIsOwedASave() {
        World world = NewWorld(new FlatTerrain());
        Load(world, new Vec2<int>(0, 0));

        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.True);
    }

    [Test]
    public void ASavedChunkIsCleanAndASecondSaveWritesNothing() {
        World world = NewSavingWorld(out _, out MemoryChunkBlobStore blobs);
        Load(world, new Vec2<int>(0, 0), new Vec2<int>(1, 0));

        SaveReport first = world.SaveAsync().Result;
        Assert.That(first.Written, Is.EqualTo(2));
        Assert.That(first.Failed, Is.Zero);
        Assert.That(blobs.Count, Is.EqualTo(2));
        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.False);

        SaveReport second = world.SaveAsync().Result;
        Assert.That(second.Written, Is.Zero);
        Assert.That(second.Skipped, Is.EqualTo(2));
    }

    [Test]
    public void AWrittenBlockMakesItsChunkDirtyAgain() {
        World world = NewSavingWorld(out _, out _);
        Load(world, new Vec2<int>(0, 0), new Vec2<int>(1, 0));

        world.SaveAsync().Wait(TimeSpan.FromSeconds(30));
        world.SetBlock(new Vec3<int>(3, 40, 3), Block.OakPlanks);

        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.True);
        Assert.That(world.IsChunkDirty(new Vec2<int>(1, 0)), Is.False,
            "a write in one chunk marked its neighbour as well");

        SaveReport report = world.SaveAsync().Result;
        Assert.That(report.Written, Is.EqualTo(1));
    }

    /// <summary>
    /// The whole point of the flag: a chunk two chunks away loading moves the light over an already
    /// saved chunk, and that must not count as a change to it.
    /// </summary>
    [Test]
    public void ANeighbourLoadingDoesNotDirtyASavedChunk() {
        World world = NewSavingWorld(out _, out _);
        Load(world, new Vec2<int>(0, 0));

        world.SaveAsync().Wait(TimeSpan.FromSeconds(30));
        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.False);

        Load(world, new Vec2<int>(1, 0), new Vec2<int>(0, 1), new Vec2<int>(1, 1));
        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.False);
    }

    [Test]
    public void EveryLoadedChunkGoesOutUnderTheLoadedScope() {
        World world = NewSavingWorld(out _, out _);
        Load(world, new Vec2<int>(0, 0), new Vec2<int>(1, 0));

        world.SaveAsync().Wait(TimeSpan.FromSeconds(30));

        SaveReport report = world.SaveAsync(new SaveOptions { Scope = SaveScope.Loaded }).Result;
        Assert.That(report.Written, Is.EqualTo(2));
    }

    [Test]
    public void APredicateHasTheLastSay() {
        World world = NewSavingWorld(out _, out MemoryChunkBlobStore blobs);
        Load(world, new Vec2<int>(0, 0), new Vec2<int>(1, 0));

        SaveReport report = world.SaveAsync(new SaveOptions {
            Chunks = pos => pos.X == 0
        }).Result;

        Assert.That(report.Written, Is.EqualTo(1));
        Assert.That(blobs.EnumerateChunks(), Is.EquivalentTo(new[] { new Vec2<int>(0, 0) }));
    }

    /// <summary>
    /// A copy made somewhere other than the world's sink must not mark anything clean, or the sink
    /// never receives what the copy took.
    /// </summary>
    [Test]
    public void ACopyToAnotherSinkLeavesChunksOwedToTheWorldsOwn() {
        World world = NewSavingWorld(out _, out MemoryChunkBlobStore blobs);
        Load(world, new Vec2<int>(0, 0));

        CodecTerrainStore copy = NewStore(out MemoryChunkBlobStore copied);
        SaveReport report = world.SaveAsync(copy).Result;
        Assert.That(report.Written, Is.EqualTo(1));
        Assert.That(copied.Count, Is.EqualTo(1));
        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.True, "a copy marked the chunk saved");

        world.SaveAsync().Wait(TimeSpan.FromSeconds(30));
        Assert.That(blobs.Count, Is.EqualTo(1));
        Assert.That(world.IsChunkDirty(new Vec2<int>(0, 0)), Is.False);
    }

    /// <summary>
    /// A block write moves the chunk's content version under its lock and its packet version only
    /// afterwards. A save landing between the two must not be handed the snapshot cached for the old
    /// packet version, which is from before the write, and mark the chunk clean against the new
    /// content version: the block would then never be written anywhere.
    /// </summary>
    [Test]
    public void ASaveBetweenAWriteAndItsLightInvalidationStoresTheWrite() {
        GapLighting lighting = new();
        World world = NewSavingWorld(out CodecTerrainStore store, out _, lighting);
        Vec2<int> pos = new(0, 0);
        Vec3<int> block = new(3, 40, 3);
        Load(world, pos);

        // Caches a snapshot for the current packet version.
        world.SaveAsync().Wait(TimeSpan.FromSeconds(30));

        lighting.OnInvalidate = () => world.Save(store);
        world.SetBlock(block, Block.OakPlanks);
        Assert.That(lighting.OnInvalidate, Is.Null, "the hook never ran, so the gap was not exercised");

        if (!world.IsChunkDirty(pos)) {
            Assert.That(ReadBack(store, pos).GetBlock(3, 40 + 64, 3), Is.EqualTo(Block.OakPlanks.StateId),
                "the chunk was marked saved, but what was stored is from before the write");
        }
    }

    /// <summary>
    /// Two saves of one world overlapping could each mark a chunk against its own snapshot in
    /// whichever order they finished, so the second waits for the first.
    /// </summary>
    [Test]
    public void SavesOfOneWorldDoNotOverlap() {
        World world = NewWorld(new FlatTerrain());
        GatedSink sink = new();
        world.Sink = sink;
        Load(world, new Vec2<int>(0, 0));

        SaveOptions options = new() { Scope = SaveScope.Loaded, MaxConcurrency = 1 };
        Task<SaveReport> first = world.SaveAsync(options);
        Assert.That(sink.Entered.Wait(TimeSpan.FromSeconds(30)), Is.True, "the first save never reached the sink");

        Task<SaveReport> second = world.SaveAsync(options);
        Assert.That(sink.Entered.Wait(TimeSpan.FromMilliseconds(500)), Is.False,
            "the second save reached the sink while the first was still in it");

        sink.Release.Set();
        Assert.That(Task.WaitAll([first, second], TimeSpan.FromSeconds(30)), Is.True);
        Assert.That(sink.Puts, Is.EqualTo(2));
    }

    /// <summary>
    /// A world in front of a store reads back what it saved, and only asks the generator for what the
    /// store has never held.
    /// </summary>
    [Test]
    public void APersistentWorldReadsBackWhatItSaved() {
        CodecTerrainStore store = NewStore(out _);
        Vec2<int> pos = new(2, 2);
        Vec3<int> block = new(2 * 16 + 5, 40, 2 * 16 + 5);

        World first = NewWorld(new PersistentTerrainProvider(store, new FlatTerrain()));
        first.Sink = store;
        Load(first, pos);
        first.SetBlock(block, Block.OakPlanks);
        first.SaveAsync().Wait(TimeSpan.FromSeconds(30));

        World second = NewWorld(new PersistentTerrainProvider(store, new FlatTerrain()));
        Load(second, pos);

        Assert.That(second.GetBlock(block).Identifier, Is.EqualTo(Block.OakPlanks.Identifier));
        Assert.That(second.IsChunkDirty(pos), Is.False, "a chunk read back from a store is not owed a save");
    }

    /// <summary>
    /// A stored chunk that is damaged is what <c>ChunkMap.handleChunkLoadFailure</c> regenerates: the
    /// world carries on with fresh terrain, says so, and owes the chunk a save that replaces the damage.
    /// </summary>
    [Test]
    public void ADamagedStoredChunkIsGeneratedAgainAndReported() {
        CodecTerrainStore store = NewStore(out MemoryChunkBlobStore blobs);
        Vec2<int> pos = new(0, 0);

        ChunkData original = new(384) { ChunkX = 0, ChunkZ = 0, MinY = -64 };
        original.PackData(VanillaRegistry.Data);
        DataWriter writer = new();
        store.Codec.Encode(original, writer);
        byte[] encoded = writer.ToArray();
        blobs.Write(pos, encoded.AsSpan(0, encoded.Length / 2));

        FlatTerrain generator = new();
        World world = NewWorld(new PersistentTerrainProvider(store, generator), out List<string> log);
        Load(world, pos);

        Assert.That(world.IsChunkLoaded(pos), Is.True);
        Assert.That(generator.Generated, Is.EqualTo(1));
        Assert.That(world.GetBlock(new Vec3<int>(0, -64, 0)).Identifier, Is.EqualTo(Block.Stone.Identifier));
        Assert.That(world.IsChunkDirty(pos), Is.True);

        lock (log) {
            Assert.That(log.Any(line => line.Contains("could not be read")), Is.True, "the damage was not reported");
        }
    }

    /// <summary>
    /// Anything that is not damaged data is a fault, and a fault must fail the load rather than
    /// replace a stored chunk with fresh terrain the next save writes over it.
    /// </summary>
    [Test]
    public void AFaultReadingAStoredChunkFailsTheLoadRatherThanRegenerating() {
        FlatTerrain generator = new();
        World world = NewWorld(new PersistentTerrainProvider(new FaultyStore(), generator));
        Vec2<int> pos = new(0, 0);

        Assert.Catch(() => world.LoadChunks([pos]).Wait(TimeSpan.FromSeconds(30)));
        Assert.That(generator.Generated, Is.Zero);
        Assert.That(world.IsChunkLoaded(pos), Is.False);
    }

    /// <summary>
    /// A world never takes its sink from its terrain provider, even one that could be written to: a map
    /// shared between rounds would otherwise be saved into by the first save policy registered.
    /// </summary>
    [Test]
    public void AWorldNeverTakesItsSinkFromItsProvider() {
        World world = NewWorld(new PersistentTerrainProvider(NewStore(out _), new FlatTerrain()));
        Assert.That(world.Sink, Is.Null);
        Assert.Throws<InvalidOperationException>(() => _ = world.SaveAsync());
    }

    [Test]
    public void ThePersistenceFeatureGivesAWorldASinkAndTakesItBack() {
        World world = NewWorld(new FlatTerrain());
        CodecTerrainStore store = NewStore(out _);

        WorldPersistenceFeature feature = new(store);
        world.AddFeature(feature);
        Assert.That(world.Sink, Is.SameAs(store));

        feature.Unregister();
        Assert.That(world.Sink, Is.Null);
    }
}
