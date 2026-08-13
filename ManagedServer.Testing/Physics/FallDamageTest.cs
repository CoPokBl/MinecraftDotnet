using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Physics;

/// <summary>
/// <c>LivingEntity.causeFallDamage</c> and the <c>fallOn</c> overrides that soften a landing, over a
/// fall the physics simulates rather than one written down: the drop is ten blocks onto a floor, so
/// the distance that reaches the damage is exactly ten and the numbers below are vanilla's formula
/// applied to it.
/// </summary>
[TestFixture]
public class FallDamageTest {
    private const int FloorTop = 65;
    private const int MinY = -64;
    private const double DropFrom = FloorTop + 10;

    /// <summary>A floor of the given block, optionally with a few blocks of something standing on it.</summary>
    private sealed class FloorTerrain(uint floorState, uint aboveState, int aboveTop) : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            int worldY = y + MinY;
            if (worldY < FloorTop) {
                return floorState;
            }

            return worldY < aboveTop ? aboveState : Block.Air.StateId;
        }
    }

    /// <summary>
    /// The same floor with a block deep pool of water standing on it, in every column left of
    /// <paramref name="poolMaxX"/>. Landing against that edge puts part of the box in the water and
    /// leaves the position itself over dry ground.
    /// </summary>
    private sealed class PoolTerrain(int poolMaxX) : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            int worldY = y + MinY;
            if (worldY < FloorTop) {
                return Block.Stone.StateId;
            }

            return worldY == FloorTop && x < poolMaxX ? Block.Water.StateId : Block.Air.StateId;
        }
    }

    private static (World World, ManagedMinecraftServer Server) CreateWorld(uint floorState,
        uint aboveState = 0, int aboveTop = FloorTop) {
        return CreateWorld(new FloorTerrain(floorState, aboveState, aboveTop));
    }

    private static (World World, ManagedMinecraftServer Server) CreateWorld(PerBlockTerrainProvider terrain) {
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.AddFeature(new FallDamageFeature());

        World world = server.CreateWorld(terrain, "minecraft:overworld", new FullBrightLightingProvider());
        world.LoadChunk(new Vec2<int>(0, 0)).Wait();
        return (world, server);
    }

    /// <summary>Drops the entity from ten blocks up and runs until it has been on the ground a tick.</summary>
    private static LivingEntity Drop(World world, IEntityType type, double x = 8.5) {
        LivingEntity entity = new(type) {
            Position = new Vec3<double>(x, DropFrom, 8.5)
        };
        entity.SetWorld(world);

        for (int tick = 0; tick < 40 && !(entity.OnGround && entity.FallDistance == 0.0); tick++) {
            EntityPhysics.Tick(world, entity);
        }

        return entity;
    }

    /// <summary>Ten blocks less the three of <c>safe_fall_distance</c> is seven hearts of damage.</summary>
    [Test]
    public void TestFallOntoStoneHurts() {
        (World world, ManagedMinecraftServer server) = CreateWorld(Block.Stone.StateId);
        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.That(zombie.Health, Is.EqualTo(13f));
        server.Stop();
    }

    /// <summary><c>HayBlock.fallOn</c> passes a fifth of the damage on, so seven becomes one.</summary>
    [Test]
    public void TestHayBlockSoftensTheLanding() {
        (World world, ManagedMinecraftServer server) = CreateWorld(Block.HayBlock.StateId);
        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.That(zombie.Health, Is.EqualTo(19f));
        server.Stop();
    }

    /// <summary><c>BedBlock.fallOn</c> halves the distance rather than the damage, so five less three.</summary>
    [Test]
    public void TestBedHalvesTheDistance() {
        (World world, ManagedMinecraftServer server) = CreateWorld(Block.RedBed.StateId);
        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.That(zombie.Health, Is.EqualTo(18f));
        server.Stop();
    }

    /// <summary><c>SlimeBlock.fallOn</c> multiplies the damage by nothing at all.</summary>
    [Test]
    public void TestSlimeBlockTakesTheWholeFall() {
        (World world, ManagedMinecraftServer server) = CreateWorld(Block.SlimeBlock.StateId);
        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.That(zombie.Health, Is.EqualTo(20f));
        server.Stop();
    }

    /// <summary>
    /// Entering water ends the fall, which is what makes one block of it enough to survive anything.
    /// </summary>
    [Test]
    public void TestWaterEndsTheFall() {
        (World world, ManagedMinecraftServer server) =
            CreateWorld(Block.Stone.StateId, Block.Water.StateId, FloorTop + 1);
        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.That(zombie.Health, Is.EqualTo(20f));
        server.Stop();
    }

    /// <summary>
    /// Water is a question about the whole bounding box, as <c>isInWater</c> is: an entity landing
    /// against the edge of a pool with most of itself over dry ground is still in it. The block under
    /// the position is the dry one, so this is the case the feet alone get wrong.
    /// </summary>
    [Test]
    public void TestWaterEndsTheFallFromTheEdge() {
        (World world, ManagedMinecraftServer server) = CreateWorld(new PoolTerrain(9));
        // The box is 0.6 wide, so landing at nine straddles the water at eight and the floor at nine.
        LivingEntity zombie = Drop(world, EntityType.Zombie, 9.0);

        Assert.That(zombie.Health, Is.EqualTo(20f));
        server.Stop();
    }

    /// <summary>
    /// The other side of it: a pool the box does not reach is still someone else's water. Landing one
    /// block clear of the edge takes the whole fall.
    /// </summary>
    [Test]
    public void TestWaterBesideTheLandingDoesNotEndTheFall() {
        (World world, ManagedMinecraftServer server) = CreateWorld(new PoolTerrain(9));
        LivingEntity zombie = Drop(world, EntityType.Zombie, 10.5);

        Assert.That(zombie.Health, Is.EqualTo(13f));
        server.Stop();
    }

    /// <summary>
    /// A ladder ends a fall the same way water does, which is the whole of
    /// <c>minecraft:fall_damage_resetting</c>: without it, climbing down twenty blocks arrives as
    /// twenty blocks of falling.
    /// </summary>
    [Test]
    public void TestClimbablesEndTheFall() {
        (World world, ManagedMinecraftServer server) =
            CreateWorld(Block.Stone.StateId, Block.Ladder.StateId, FloorTop + 1);
        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.That(zombie.Health, Is.EqualTo(20f));
        server.Stop();
    }

    /// <summary>
    /// A chicken is in <c>minecraft:fall_damage_immune</c>, so the tag has to have survived generation
    /// for this to be anything other than the stone case.
    /// </summary>
    [Test]
    public void TestImmuneEntityTypesAreNotHurt() {
        (World world, ManagedMinecraftServer server) = CreateWorld(Block.Stone.StateId);
        LivingEntity chicken = Drop(world, EntityType.Chicken);

        Assert.That(chicken.Health, Is.EqualTo(20f));
        server.Stop();
    }

    /// <summary>
    /// The fall itself, without the damage: the distance that reaches a landing is the drop, and it
    /// goes back to nothing afterwards.
    /// </summary>
    [Test]
    public void TestFallDistanceIsTheDrop() {
        (World world, ManagedMinecraftServer server) = CreateWorld(Block.Stone.StateId);

        double landedWith = -1;
        server.Events.AddListener<EntityLandEvent>(e => landedWith = e.FallDistance);

        LivingEntity zombie = Drop(world, EntityType.Zombie);

        Assert.Multiple(() => {
            // A tick's worth of movement at a time, so the sum is the drop give or take the last bit.
            Assert.That(landedWith, Is.EqualTo(DropFrom - FloorTop).Within(1.0E-9));
            Assert.That(zombie.FallDistance, Is.Zero);
            Assert.That(zombie.Position.Y, Is.EqualTo((double)FloorTop));
        });

        server.Stop();
    }
}
