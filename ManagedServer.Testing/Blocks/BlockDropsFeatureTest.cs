using System.Reflection;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Blocks;

/// <summary>
/// The wiring around the tables: which writes drop, which do not, and that the two handlers do not
/// both answer the same break.
/// <p/>
/// Driven through <c>World.DestroyBlock</c> rather than through a player, since the interesting cases
/// here are the flag and the deferral rather than the tool, and <c>BlockLootTest</c> already covers
/// what a given tool rolls.
/// </summary>
[TestFixture]
public class BlockDropsFeatureTest {
    private const int FloorIndex = 64;

    private sealed class FloorTerrain : ITerrainProvider {
        public void GetChunk(ref ChunkData chunk) {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    chunk.SetBlock(x, FloorIndex, z, Block.Stone.StateId);
                }
            }

            chunk.PackData();
        }
    }

    private ManagedMinecraftServer _server = null!;
    private World _world = null!;
    private int _floorY;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer {
            LogAction = _ => { }
        };
        // BlockDropsFeature listens for PlayerBreakBlockEvent, which is [NotCalledByDefault], so the
        // framework refuses the registration unless something declares it calls that event. Breaking
        // blocks is what makes drops mean anything, so needing the pair is right rather than awkward.
        _server.FeatureHandler.AddFeature(new BlockBreakingFeature());
        _server.FeatureHandler.AddFeature(new BlockDropsFeature());

        _world = _server.CreateWorld(new FloorTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait(TimeSpan.FromSeconds(30));
        _floorY = _world.Dimension.MinY + FloorIndex;

        // The rolls are deterministic so a case that says "one cobblestone" means it every run.
        _world.Random = new LegacyRandomSource(1234);
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    /// <summary>The scheduler compares against the tick counter, which only the real loop moves.</summary>
    private void AdvanceTicks(int count) {
        for (int i = 0; i < count; i++) {
            typeof(ManagedMinecraftServer)
                .GetProperty(nameof(ManagedMinecraftServer.CurrentTick))!
                .SetValue(_server, _server.CurrentTick + 1);

            _server.Events.CallEvent(new ServerTickEvent {
                Delta = TimeSpan.FromMilliseconds(50),
                TargetDelta = TimeSpan.FromMilliseconds(50),
                Server = _server
            });
        }
    }

    private Vec3<int> Floor(int x, int z) => new(x, _floorY, z);

    private string[] DroppedItems() {
        return _world.Entities.GetEntities()
            .OfType<ItemEntity>()
            .Select(e => e.Item!.Type.Identifier.ToString())
            .Order()
            .ToArray();
    }

    [Test]
    public void TestDestroyingABlockDropsIt() {
        _world.DestroyBlock(Floor(1, 1), dropResources: true);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.EqualTo(new[] { "minecraft:cobblestone" }));
    }

    /// <summary>
    /// The flag is the whole point of putting it on <c>WorldChangeEvent</c>: without it the two calls
    /// below are indistinguishable to a listener.
    /// </summary>
    [Test]
    public void TestSuppressedDropsDropNothing() {
        _world.DestroyBlock(Floor(2, 2), dropResources: false);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);
    }

    /// <summary>An ordinary write is not a break, so replacing a block does not drop the old one.</summary>
    [Test]
    public void TestReplacingABlockDropsNothing() {
        _world.SetBlock(Floor(3, 3), Block.Dirt);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);
    }

    /// <summary>
    /// Nor does writing air, which is what a consumer clearing an area does. Vanilla keeps
    /// <c>setBlock</c> and <c>destroyBlock</c> apart and only the second drops, so a minigame resetting
    /// its map does not shower the floor with the blocks it just removed.
    /// </summary>
    [Test]
    public void TestClearingABlockWithSetBlockDropsNothing() {
        _world.SetBlock(Floor(9, 9), Block.Air);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);
        Assert.That(_world.GetBlock(Floor(9, 9)).Air, Is.True);
    }

    /// <summary>
    /// A cancelled write leaves the block alone, so it must also leave the drop alone. This is the case
    /// the deferral exists for: the listener below runs after the feature's, and inline dropping would
    /// already have spawned the item by the time it says no.
    /// </summary>
    [Test]
    public void TestCancellingTheWriteDropsNothing() {
        _world.Events.AddListener<WorldChangeEvent>(e => e.Cancelled = true);

        _world.DestroyBlock(Floor(4, 4), dropResources: true);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);
        Assert.That(_world.GetBlock(Floor(4, 4)).Identifier, Is.EqualTo(Block.Stone.Identifier));
    }

    /// <summary>
    /// Breaking air is not a break. Worth pinning because the destroy handler sees every write in the
    /// world, including the ones a chunk load or a generator makes.
    /// </summary>
    [Test]
    public void TestWritingOverAirDropsNothing() {
        Vec3<int> above = new(5, _floorY + 1, 5);
        _world.SetBlock(above, Block.Stone);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);
    }

    /// <summary>
    /// A block with no loot table drops nothing, and does not throw on the way to not dropping.
    /// </summary>
    [Test]
    public void TestABlockWithNoTableDropsNothing() {
        Vec3<int> pos = Floor(6, 6);
        _world.SetBlock(pos, Block.Bedrock);
        _world.DestroyBlock(pos, dropResources: true);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);
    }

    /// <summary>
    /// A dropped stack lands inside the block it came from and is given the default pickup delay, so it
    /// cannot be collected on the tick it appears.
    /// </summary>
    [Test]
    public void TestDropsLandInsideTheBlockAndWaitToBeCollected() {
        Vec3<int> pos = Floor(7, 7);
        _world.DestroyBlock(pos, dropResources: true);
        AdvanceTicks(2);

        ItemEntity item = _world.Entities.GetEntities().OfType<ItemEntity>().Single();

        Assert.That(item.Position.X, Is.InRange(pos.X + 0.25, pos.X + 0.75));
        Assert.That(item.Position.Z, Is.InRange(pos.Z + 0.25, pos.Z + 0.75));
        Assert.That(item.PickupDelay, Is.GreaterThan(0));
    }

    /// <summary>
    /// One break is one set of drops. Both of the feature's handlers see a player break, and without
    /// the per tick guard between them a mined block would be worth twice what it should be.
    /// </summary>
    [Test]
    public void TestAPlayerBreakIsNotAlsoCountedAsADestroy() {
        Vec3<int> pos = Floor(8, 8);

        // The order BlockBreakingFeature produces: the player handler claims the position, then the
        // write it makes fires the destroy handler at the same position on the same tick. The claim is
        // reached directly because the player half needs a connected player.
        MarkHandledFor(pos);
        _world.DestroyBlock(pos, dropResources: true);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.Empty);

        // And the claim is only good for the tick it was made in, or a second break of the same
        // position would silently drop nothing.
        AdvanceTicks(1);
        _world.SetBlock(pos, Block.Stone);
        _world.DestroyBlock(pos, dropResources: true);
        AdvanceTicks(2);

        Assert.That(DroppedItems(), Is.EqualTo(new[] { "minecraft:cobblestone" }));
    }

    /// <summary>
    /// Reaches the feature's private guard directly, because the player half of it cannot be driven
    /// without a connection. What is being checked is that a marked position is skipped by the destroy
    /// handler within the same tick, which is the only thing standing between one break and two drops.
    /// </summary>
    private void MarkHandledFor(Vec3<int> position) {
        BlockDropsFeature feature = _server.FeatureHandler.Features.OfType<BlockDropsFeature>().Single();
        MethodInfo mark = typeof(BlockDropsFeature)
            .GetMethod("MarkHandled", BindingFlags.Instance | BindingFlags.NonPublic)!;
        mark.Invoke(feature, [_world, position]);
    }
}
