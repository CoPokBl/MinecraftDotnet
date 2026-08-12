using ManagedServer.Entities.Types;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Physics;

/// <summary>
/// <c>Entity.restituteMovementAfterCollisions</c>: what a landing does with the velocity it had.
/// Only slime blocks and beds carry a bounce restitution, so everything else lands on the zero case
/// and simply stops.
/// </summary>
[TestFixture]
public class EntityBounceTest {
    private const int FloorTop = 65;
    private const int MinY = -64;

    private sealed class FloorTerrain(uint floorState) : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            return y + MinY < FloorTop ? floorState : Block.Air.StateId;
        }
    }

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
    /// An item dropped from y=70 onto slime, from the tick vanilla lands it on: the surface, then the
    /// bounce back up. Run out of <c>Entity.restituteMovementAfterCollisions</c> in Java, which gives
    /// back the part of the tick's gravity and drag that was spent falling rather than bouncing.
    /// </summary>
    private static readonly double[] ExpectedBounce = [
        65.06782293039369, 65.0, 65.41837011288283, 65.78837283148778, 66.11097550277786, 66.38712612679531
    ];

    [Test]
    public void TestItemBouncesOffSlime() {
        World world = CreateWorld(Block.SlimeBlock.StateId, out ManagedMinecraftServer server);
        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(8.5, 70, 8.5));

        // The landing is on the tick after these, so run up to it and then check the bounce out.
        for (int tick = 0; tick < 16; tick++) {
            EntityPhysics.Tick(world, item);
        }

        for (int tick = 0; tick < ExpectedBounce.Length; tick++) {
            Assert.That(item.Position.Y, Is.EqualTo(ExpectedBounce[tick]), $"y at bounce tick {tick}");
            EntityPhysics.Tick(world, item);
        }

        server.Stop();
    }

    [Test]
    public void TestItemDoesNotBounceOffStone() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        Entity item = Spawn(world, EntityType.Item, new Vec3<double>(8.5, 70, 8.5));

        for (int tick = 0; tick < 20; tick++) {
            EntityPhysics.Tick(world, item);
        }

        Assert.Multiple(() => {
            Assert.That(item.Position.Y, Is.EqualTo(FloorTop));
            Assert.That(item.Velocity.Y, Is.Zero);
        });

        server.Stop();
    }

    /// <summary>
    /// Bounciness reaches the physics off the block data and the block tags, so both have to have
    /// survived generation for a bounce to be possible at all.
    /// </summary>
    [Test]
    public void TestBounceDataReachesThePhysics() {
        MinecraftRegistry registry = VanillaRegistry.Data;

        Assert.Multiple(() => {
            Assert.That(BlockPhysicsData.Get(registry, Block.SlimeBlock.StateId).BounceRestitution, Is.EqualTo(1.0));
            Assert.That(BlockPhysicsData.Get(registry, Block.RedBed.StateId).BounceRestitution, Is.EqualTo(0.75));
            Assert.That(BlockPhysicsData.Get(registry, Block.Stone.StateId).BounceRestitution, Is.Zero);

            // A honey block stops a bounce that the entity's own bounciness would otherwise cause.
            Assert.That(BlockPhysicsData.Get(registry, Block.HoneyBlock.StateId).SuppressesBounce, Is.True);
            Assert.That(BlockPhysicsData.Get(registry, Block.SlimeBlock.StateId).SuppressesBounce, Is.False);
        });
    }
}
