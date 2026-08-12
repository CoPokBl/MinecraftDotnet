using ManagedServer.Entities.Types;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Physics;

/// <summary>
/// Drives the whole tick, world lookups and all, rather than the collision maths on its own.
/// <see cref="EntityCollisionTest"/> pins the sweep against vanilla; this pins what
/// <see cref="EntityPhysics"/> builds on top of it.
/// </summary>
[TestFixture]
public class EntityPhysicsTickTest {
    private const int FloorTop = 65;

    /// <summary>Stone up to <see cref="FloorTop"/>, air above it.</summary>
    private sealed class FloorTerrain(uint floorState) : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            // The provider is handed protocol y, counting up from the dimension's minimum.
            return y + MinY < FloorTop ? floorState : Block.Air.StateId;
        }
    }

    private const int MinY = -64;

    private static World CreateWorld(uint floorState, out ManagedMinecraftServer server) {
        server = ManagedMinecraftServer.New();
        World world = server.CreateWorld(new FloorTerrain(floorState), "minecraft:overworld", new FullBrightLightingProvider());
        world.LoadChunk(new Vec2<int>(0, 0)).Wait();
        return world;
    }

    private static Entity Spawn(World world, IEntityType type, Vec3<double> position) {
        Entity entity = new(type) {
            Position = position
        };
        entity.SetWorld(world);
        return entity;
    }

    /// <summary>
    /// Positions vanilla's <c>ItemEntity.tick</c> produces for an item dropped from y=70 onto stone,
    /// run out of the decompiled loop in Java so that its float terms stay floats: air drag is
    /// 0.98f, which is 0.98000001907 once widened, and the difference compounds every tick.
    /// </summary>
    private static readonly double[] ExpectedFall = [
        69.96, 69.88079999923706, 69.76318399697875, 69.60792031252227, 69.41576189879349,
        69.18744664967416, 68.92369770118245, 68.62522372662995, 68.29271922587557,
        67.92686480879426, 67.52832747307646, 67.09776087647151, 66.63580560358626,
        66.14308942734762, 65.62022756523594, 65.06782293039369, 65.0, 65.0, 65.0, 65.0
    ];

    [Test]
    public void TestItemFallsAndLandsOnTheBlockSurface() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(8.5, 70, 8.5));

        for (int tick = 0; tick < ExpectedFall.Length; tick++) {
            EntityPhysics.Tick(world, item);
            Assert.That(item.Position.Y, Is.EqualTo(ExpectedFall[tick]), $"y after tick {tick}");
        }

        Assert.Multiple(() => {
            Assert.That(item.OnGround, Is.True);
            Assert.That(item.Velocity.Y, Is.Zero);
            // It never drifts sideways, and it comes to rest exactly on the surface rather than
            // sinking into it or hovering above it.
            Assert.That(item.Position.X, Is.EqualTo(8.5));
            Assert.That(item.Position.Z, Is.EqualTo(8.5));
            Assert.That(item.SupportingBlockPos, Is.EqualTo(new Vec3<int>(8, FloorTop - 1, 8)));
        });

        server.Stop();
    }

    [Test]
    public void TestGroundFrictionComesFromTheBlockBelow() {
        // Stone drags a sliding item by 0.98 * 0.6, ice by 0.98 * 0.98.
        World stoneWorld = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer stoneServer);
        World iceWorld = CreateWorld(Block.Ice.StateId, out ManagedMinecraftServer iceServer);

        Entity onStone = Spawn(stoneWorld, EntityType.Item, new Vec3<double>(8.5, FloorTop, 8.5));
        Entity onIce = Spawn(iceWorld, EntityType.Item, new Vec3<double>(8.5, FloorTop, 8.5));

        // Land first so OnGround and the supporting block are set.
        EntityPhysics.Tick(stoneWorld, onStone);
        EntityPhysics.Tick(iceWorld, onIce);

        onStone.Velocity = new Vec3<double>(0.5, 0, 0);
        onIce.Velocity = new Vec3<double>(0.5, 0, 0);
        EntityPhysics.Tick(stoneWorld, onStone);
        EntityPhysics.Tick(iceWorld, onIce);

        Assert.Multiple(() => {
            // Vanilla multiplies the drag by the block friction in float before it widens.
            Assert.That(onStone.Velocity.X, Is.EqualTo(0.5 * (0.98f * Block.Stone.Friction)));
            Assert.That(onIce.Velocity.X, Is.EqualTo(0.5 * (0.98f * Block.Ice.Friction)));
            Assert.That(Block.Ice.Friction, Is.GreaterThan(Block.Stone.Friction));
        });

        stoneServer.Stop();
        iceServer.Stop();
    }

    [Test]
    public void TestWalkingIntoAWallStopsThatAxisOnly() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        world.SetBlock(new Vec3<int>(10, FloorTop, 8), Block.Stone);

        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(8.5, FloorTop, 8.5));
        EntityPhysics.Tick(world, item);

        item.Velocity = new Vec3<double>(2.0, 0, 0.1);
        EntityPhysics.Tick(world, item);

        Assert.Multiple(() => {
            // The item is 0.25 wide, so its edge stops flush against the block face at x=10.
            Assert.That(item.Position.X, Is.EqualTo(10.0 - 0.125));
            Assert.That(item.Velocity.X, Is.Zero);
            Assert.That(item.HorizontalCollision, Is.True);
            // Z is untouched by the X collision, only slowed by friction.
            Assert.That(item.Position.Z, Is.EqualTo(8.6));
            Assert.That(item.Velocity.Z, Is.Not.Zero);
        });

        server.Stop();
    }

    /// <summary>
    /// A slab collides where its own state says, not where the block's default state does. Two
    /// thirds of the block states in the game differ from their default in at least their shape, and
    /// the client predicts against the real one.
    /// </summary>
    [Test]
    public void TestSlabHalvesCollideWhereTheySit() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        world.SetBlock(new Vec3<int>(8, FloorTop, 8), Block.StoneSlab with { Type = SlabType.Bottom });
        world.SetBlock(new Vec3<int>(12, FloorTop, 8), Block.StoneSlab with { Type = SlabType.Top });

        Entity onBottom = Spawn(world, EntityType.Item, new Vec3<double>(8.5, 70, 8.5));
        Entity onTop = Spawn(world, EntityType.Item, new Vec3<double>(12.5, 70, 8.5));

        for (int tick = 0; tick < 25; tick++) {
            EntityPhysics.Tick(world, onBottom);
            EntityPhysics.Tick(world, onTop);
        }

        Assert.Multiple(() => {
            Assert.That(onBottom.Position.Y, Is.EqualTo(FloorTop + 0.5), "bottom slab");
            Assert.That(onTop.Position.Y, Is.EqualTo(FloorTop + 1.0), "top slab");
        });

        server.Stop();
    }

    /// <summary>
    /// Bamboo is placed off centre by a hash of the position it sits at, and the shape in the data
    /// has that taken back out of it, so the collision has to put it back.
    /// </summary>
    [Test]
    public void TestBambooCollidesWhereItsOffsetPutsIt() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        Vec3<int> stalk = new(7, FloorTop, 13);
        world.SetBlock(stalk, Block.Bamboo);

        // The stalk is 0.1875 wide around the centre of its block, and then moved by its offset.
        Vec3<double> offset = Block.Bamboo.Info.ShapeOffset(stalk);
        Assert.That(offset.X, Is.Not.Zero);

        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(5.5, FloorTop, 13.5 + offset.Z));
        EntityPhysics.Tick(world, item);

        item.Velocity = new Vec3<double>(2.0, 0, 0);
        EntityPhysics.Tick(world, item);

        Assert.Multiple(() => {
            // Flush against the offset stalk's west face, which is 0.1833 further east than the
            // shape in the data says on its own.
            Assert.That(item.Position.X, Is.EqualTo(7.40625 + offset.X - 0.125));
            Assert.That(item.HorizontalCollision, Is.True);
        });

        server.Stop();
    }

    [Test]
    public void TestNoGravityEntityDoesNotFall() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(8.5, 70, 8.5));
        item.Meta = item.Meta with { NoGravity = true };

        for (int tick = 0; tick < 10; tick++) {
            EntityPhysics.Tick(world, item);
        }

        Assert.That(item.Position.Y, Is.EqualTo(70));
        server.Stop();
    }

    [Test]
    public void TestUnloadedChunkIsSkipped() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(5000.5, 70, 5000.5));

        EntityPhysics.Tick(world, item);

        Assert.Multiple(() => {
            Assert.That(item.Position.Y, Is.EqualTo(70));
            Assert.That(item.Velocity, Is.EqualTo(Vec3<double>.Zero));
        });

        server.Stop();
    }
}
