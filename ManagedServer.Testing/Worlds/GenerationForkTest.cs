using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Worlds;

/// <summary>
/// Terrain a generator writes outside the chunk it was handed.
/// </summary>
/// <remarks>
/// A generator only ever sees one chunk, so anything spanning a border, a tree or a vein or a
/// structure, has to be able to say "and this bit goes over there". Where "over there" is depends on
/// timing: it may be the chunk being generated, a chunk already delivered to players, or a chunk that
/// does not exist yet.
/// <p/>
/// <see cref="ForkPostedDuringTheTargetsOwnGeneration"/> is the one that matters. Everything else here
/// would pass against the obvious implementation, and that implementation loses the fork whenever the
/// target finishes loading between "is it loaded?" and "park it", with nothing thrown and no way to
/// notice until someone reports a tree with a flat side.
/// </remarks>
[TestFixture]
public class GenerationForkTest {
    private const int PlantY = 0;

    /// <summary>A cell in the chunk to the east, deliberately not that chunk's own corner.</summary>
    private const int ForkX = 20;
    private const int ForkZ = 3;

    private static readonly Vec2<int> Origin = new(0, 0);
    private static readonly Vec2<int> East = new(1, 0);

    /// <summary>
    /// Marks its own chunk's corner, and, only while generating the chunk at the origin, forks a
    /// block into a cell that is not that corner. Keeping the two apart is what makes it visible
    /// whether a fork overlaid the target or replaced it.
    /// </summary>
    private sealed class ForkingGenerator(int forkX = ForkX) : IGenerator {
        public void Generate(IGenerationUnit unit) {
            unit.Modifier.SetBlock(unit.AbsoluteStart.X, PlantY, unit.AbsoluteStart.Z, Block.Stone);

            if (unit.AbsoluteStart.X != 0 || unit.AbsoluteStart.Z != 0) {
                return;
            }

            unit.Fork(setter => setter.SetBlock(forkX, PlantY, ForkZ, Block.DiamondBlock));
        }
    }

    /// <summary>
    /// Holds one chunk until the test lets it through, either side of its generation.
    /// </summary>
    /// <remarks>
    /// The two sides are two different windows and only one of them is the hard case.
    /// <see cref="Before"/> parks the fork while the target has not started, so the target's own
    /// generation picks it up on the way past. <see cref="After"/> parks it once the target has
    /// finished generating but before the chunk store has published it, which is the narrow window
    /// where the answer to "is it loaded" is about to change. Only the second reaches the drain.
    /// </remarks>
    private sealed class GatedProvider(ITerrainProvider inner, Vec2<int> held, bool before)
        : ITerrainProvider {

        public const bool Before = true;
        public const bool After = false;

        public readonly ManualResetEventSlim Gate = new(false);
        public readonly ManualResetEventSlim Reached = new(false);

        public void GetChunk(ref ChunkData chunk) {
            bool isHeld = chunk.ChunkX == held.X && chunk.ChunkZ == held.Y;

            if (isHeld && before) {
                Reached.Set();
                Gate.Wait(TimeSpan.FromSeconds(30));
            }

            inner.GetChunk(ref chunk);

            if (isHeld && !before) {
                Reached.Set();
                Gate.Wait(TimeSpan.FromSeconds(30));
            }
        }

        public void Attach(ITerrainHost host) => inner.Attach(host);
    }

    private static (World World, GeneratorTerrainProvider Provider) NewWorld(IGenerator generator,
        Func<ITerrainProvider, ITerrainProvider>? wrap = null) {

        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.LogAction = _ => { };

        GeneratorTerrainProvider provider = new(generator);
        ITerrainProvider outer = wrap?.Invoke(provider) ?? provider;

        World world = server.CreateWorld(outer, "minecraft:overworld", new FullBrightLightingProvider());
        return (world, provider);
    }

    private static void Load(World world, Vec2<int> pos) {
        world.LoadChunk(pos).Wait(TimeSpan.FromSeconds(30));
    }

    /// <summary>Polls a condition that a background drain is expected to make true.</summary>
    private static bool Eventually(Func<bool> condition) {
        for (int i = 0; i < 300; i++) {
            if (condition()) {
                return true;
            }
            Thread.Sleep(10);
        }

        return condition();
    }

    /// <summary>
    /// A fork landing in the chunk being generated is applied there and then. No queue, no lock, and
    /// nothing to announce, because nobody can see the chunk yet.
    /// </summary>
    [Test]
    public void ForkIntoTheGeneratingChunkIsAppliedInline() {
        (World world, GeneratorTerrainProvider provider) = NewWorld(new ForkingGenerator(forkX: 5));
        Load(world, Origin);

        Assert.Multiple(() => {
            Assert.That(world.GetBlock(new Vec3<int>(5, PlantY, ForkZ)).StateId,
                Is.EqualTo(Block.DiamondBlock.StateId));
            Assert.That(provider.PendingForkChunks, Is.Zero, "nothing should have been parked");
        });
    }

    /// <summary>A fork into a chunk that is already there is applied to it straight away.</summary>
    [Test]
    public void ForkIntoALoadedChunkIsAppliedImmediately() {
        (World world, GeneratorTerrainProvider provider) = NewWorld(new ForkingGenerator());

        Load(world, East);
        Assert.That(world.GetBlock(new Vec3<int>(ForkX, PlantY, ForkZ)).StateId, Is.EqualTo(0u),
            "the target should start empty");

        Load(world, Origin);

        Assert.Multiple(() => {
            Assert.That(world.GetBlock(new Vec3<int>(ForkX, PlantY, ForkZ)).StateId,
                Is.EqualTo(Block.DiamondBlock.StateId));
            Assert.That(provider.PendingForkChunks, Is.Zero);
        });
    }

    /// <summary>
    /// A fork into a chunk nobody has asked for is parked, and lands when that chunk is generated.
    /// </summary>
    [Test]
    public void ForkIntoAnUnloadedChunkIsParkedThenApplied() {
        (World world, GeneratorTerrainProvider provider) = NewWorld(new ForkingGenerator());

        Load(world, Origin);
        Assert.That(provider.PendingForkChunks, Is.EqualTo(1), "the fork should be waiting");

        Load(world, East);

        Assert.Multiple(() => {
            Assert.That(world.GetBlock(new Vec3<int>(ForkX, PlantY, ForkZ)).StateId,
                Is.EqualTo(Block.DiamondBlock.StateId));
            Assert.That(provider.PendingForkChunks, Is.Zero, "and should no longer be");
        });
    }

    /// <summary>The chunk's own terrain survives a fork landing on top of it.</summary>
    [Test]
    public void AForkOverlaysRatherThanReplaces() {
        (World world, _) = NewWorld(new ForkingGenerator());

        Load(world, Origin);
        Load(world, East);

        Assert.Multiple(() => {
            Assert.That(world.GetBlock(new Vec3<int>(ForkX, PlantY, ForkZ)).StateId,
                Is.EqualTo(Block.DiamondBlock.StateId), "the fork's own block");

            // The target chunk's own corner marker, in the same section the fork landed in. A fork
            // that replaced the section rather than overlaying it takes this with it.
            Assert.That(world.GetBlock(new Vec3<int>(16, PlantY, 0)).StateId,
                Is.EqualTo(Block.Stone.StateId), "the target's own terrain");

            Assert.That(world.GetBlock(new Vec3<int>(0, PlantY, 0)).StateId,
                Is.EqualTo(Block.Stone.StateId), "the generating chunk's own terrain");
        });
    }

    /// <summary>
    /// The race. Chunk B is held mid generation; chunk A is generated and forks into it; B is then
    /// released. Whichever way the two threads interleave, the fork has to arrive.
    /// </summary>
    /// <remarks>
    /// The window is between the poster asking whether B is loaded and the poster parking the fork. If
    /// B publishes in there and its drain has already run, an implementation that does not hold one
    /// lock across both loses the fork silently and forever.
    /// </remarks>
    [TestCase(GatedProvider.Before, TestName = "parked before the target starts generating")]
    [TestCase(GatedProvider.After, TestName = "parked after it generates but before it is published")]
    [Repeat(25)]
    public void ForkPostedDuringTheTargetsOwnGeneration(bool before) {
        GatedProvider? gate = null;
        (World world, GeneratorTerrainProvider provider) = NewWorld(new ForkingGenerator(),
            inner => gate = new GatedProvider(inner, East, before));

        // Start the east chunk and wait until it is genuinely inside the provider, so the fork below
        // is posted while it is in flight rather than before it started.
        Task east = world.LoadChunk(East);
        Assert.That(gate!.Reached.Wait(TimeSpan.FromSeconds(30)), Is.True, "the target never started");

        Load(world, Origin);

        gate.Gate.Set();
        Assert.That(east.Wait(TimeSpan.FromSeconds(30)), Is.True, "the target never finished");

        // Waiting on the block rather than on PendingForkChunks. The load task completes when the
        // chunk is published, which is before the drain that runs off it, and the drain takes its
        // list out of the queue before applying it, so neither is a signal that the fork has landed.
        Assert.That(Eventually(() => world.GetBlock(new Vec3<int>(ForkX, PlantY, ForkZ)).StateId
            == Block.DiamondBlock.StateId), Is.True, "the fork was lost");

        Assert.That(provider.PendingForkChunks, Is.Zero);
    }

    /// <summary>
    /// A declared fork area covers whole sections and is sparse, so the blocks it does not write are
    /// left as the target had them.
    /// </summary>
    [Test]
    public void ADeclaredForkAreaIsSparse() {
        (World world, _) = NewWorld(new Lambda(unit => {
            unit.Modifier.SetBlock(unit.AbsoluteStart.X, PlantY, unit.AbsoluteStart.Z, Block.Stone);
            if (unit.AbsoluteStart.X != 0) {
                return;
            }

            // A box covering the whole of the east chunk's bottom section, of which one cell is
            // written.
            IGenerationUnit fork = unit.Fork(new Vec3<int>(16, PlantY, 0), new Vec3<int>(32, PlantY + 1, 16));
            fork.Modifier.SetBlock(ForkX, PlantY, ForkZ, Block.DiamondBlock);
        }));

        Load(world, East);
        Load(world, Origin);

        Assert.Multiple(() => {
            Assert.That(world.GetBlock(new Vec3<int>(ForkX, PlantY, ForkZ)).StateId,
                Is.EqualTo(Block.DiamondBlock.StateId), "the fork's own block");

            // Inside the box the fork declared but never wrote to, so the target keeps what it had.
            // A fork committing its whole declared area rather than only its writes puts air here.
            Assert.That(world.GetBlock(new Vec3<int>(16, PlantY, 0)).StateId,
                Is.EqualTo(Block.Stone.StateId), "the target's own block, inside the fork's box");
        });
    }

    /// <summary>Biomes are not a thing a sparse overlay can express, so asking says so.</summary>
    [Test]
    public void AForkRefusesToSetBiomes() {
        (World world, _) = NewWorld(new Lambda(unit => {
            if (unit.AbsoluteStart.X != 0) {
                return;
            }

            IGenerationUnit fork = unit.Fork(new Vec3<int>(ForkX, PlantY, ForkZ), new Vec3<int>(32, PlantY + 1, 16));
            Assert.Throws<InvalidOperationException>(() => fork.Modifier.FillBiome(Biome.Desert));
        }));

        Load(world, Origin);
    }

    /// <summary>
    /// Every chunk forks into the one to its east, and they are all generated at once.
    /// </summary>
    /// <remarks>
    /// A load test, and worth being clear about what it does and does not show. It exercises the
    /// whole path under real concurrency, with every chunk both posting and receiving, which catches
    /// an ordinary mistake in the routing or the section indexing.
    /// <p/>
    /// It does <b>not</b> catch the lock being in the wrong place, and neither do the two gated
    /// fixtures above: the window is a few instructions wide and load alone does not land in it.
    /// <c>Minecraft.Testing</c>'s <c>ForkRaceTest</c> produces that interleaving deliberately and is
    /// the only fixture that fails without the lock.
    /// </remarks>
    [Test]
    [Repeat(5)]
    public void ForksSurviveManyChunksGeneratingAtOnce() {
        const int Chunks = 96;

        (World world, GeneratorTerrainProvider provider) = NewWorld(new Lambda(unit => {
            int chunkX = unit.AbsoluteStart.X >> 4;
            unit.Modifier.SetBlock(unit.AbsoluteStart.X, PlantY, unit.AbsoluteStart.Z, Block.Stone);

            // Into the next chunk east, at a cell that chunk does not write itself.
            unit.Fork(setter =>
                setter.SetBlock((chunkX + 1) * 16 + ForkX % 16, PlantY, ForkZ, Block.DiamondBlock));
        }));

        Task[] loads = new Task[Chunks];
        for (int x = 0; x < Chunks; x++) {
            loads[x] = world.LoadChunk(new Vec2<int>(x, 0));
        }

        Assert.That(Task.WaitAll(loads, TimeSpan.FromSeconds(60)), Is.True, "chunks never finished");

        // Every chunk from 1 up was forked into by the one to its west.
        Assert.That(Eventually(() => Missing(world, Chunks).Count == 0), Is.True,
            $"forks lost into chunks {string.Join(", ", Missing(world, Chunks))}");

        Assert.That(provider.PendingForkChunks, Is.LessThanOrEqualTo(1),
            "only the chunk past the last one loaded may still be waiting");
    }

    private static List<int> Missing(World world, int chunks) {
        List<int> missing = [];
        for (int x = 1; x < chunks; x++) {
            Vec3<int> pos = new(x * 16 + ForkX % 16, PlantY, ForkZ);
            if (world.GetBlock(pos).StateId != Block.DiamondBlock.StateId) {
                missing.Add(x);
            }
        }

        return missing;
    }

    private sealed class Lambda(Action<IGenerationUnit> body) : IGenerator {
        public void Generate(IGenerationUnit unit) => body(unit);
    }
}
