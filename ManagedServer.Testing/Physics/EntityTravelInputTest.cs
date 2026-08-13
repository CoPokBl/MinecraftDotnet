using ManagedServer.Entities.Types;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Testing.Physics;

/// <summary>
/// Pins the movement input half of <c>LivingEntity.travel</c>, which is what turns a mob's forward
/// input into velocity. <see cref="EntityPhysicsTickTest"/> covers the entity path, which has no
/// input at all; everything here is on the living path.
/// <p/>
/// The expected positions came out of a Java harness run against the real server jar, so they carry
/// vanilla's <c>Mth</c> sine table and the order its float terms are multiplied in before they
/// widen. A live <c>LivingEntity</c> is out of reach without a <c>ServerLevel</c> (see CLAUDE.md),
/// so the harness transcribes <c>aiStep</c>, <c>travelInAir</c> and <c>moveRelative</c> with the
/// collision resolve reduced to the flat floor this world has. What it therefore pins is the
/// arithmetic rather than the method structure, and the structure is what gets diffed by eye.
/// </summary>
[TestFixture]
public class EntityTravelInputTest {
    private const int FloorTop = 65;
    private const int MinY = -64;

    /// <summary>A solid floor whose top face is at <see cref="FloorTop"/>, air above it.</summary>
    private sealed class FloorTerrain(uint floorState) : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            return y + MinY < FloorTop ? floorState : Block.Air.StateId;
        }
    }

    private static World CreateWorld(uint floorState, out ManagedMinecraftServer server) {
        server = ManagedMinecraftServer.New();
        server.LogAction = _ => { };
        World world = server.CreateWorld(new FloorTerrain(floorState), "minecraft:overworld",
            new FullBrightLightingProvider());
        world.LoadChunk(new Vec2<int>(0, 0)).Wait();
        return world;
    }

    /// <summary>
    /// A zombie standing on the floor with its forward input held down, facing +Z. It starts on the
    /// ground, loses that on the first tick because a zero vertical velocity never resolves a
    /// collision, and has it back from the second tick on, which is why the first two steps are the
    /// odd ones.
    /// </summary>
    private static LivingEntity Walker(World world) {
        LivingEntity zombie = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, FloorTop, 8.5),
            OnGround = true,
            Zza = 1.0f
        };
        zombie.SetWorld(world);
        zombie.Speed = (float)zombie.GetAttributeValue(Attribute.MovementSpeed);
        return zombie;
    }

    /// <summary>Stone is 0.6 friction, which is not slipperier than 0.6, so the speed is untouched.</summary>
    private static readonly double[] ExpectedOnStone = [
        8.72540000847578, 8.867676427867305, 9.213622157989505, 9.614653258673535,
        10.041518087007837, 10.478330103241891, 10.916498414874201, 11.351413894466639,
        11.780639813469959, 12.202923996723145, 12.61765945874739, 13.024589952255614
    ];

    /// <summary>
    /// Ice is 0.98, which is over the threshold, so <c>getFrictionInfluencedSpeed</c> divides by the
    /// cube of it. Slower off the mark and faster in the end, which is what ice feels like.
    /// </summary>
    private static readonly double[] ExpectedOnIce = [
        8.55172844838446, 8.617067881500555, 8.726206772988885, 8.87222324903776,
        9.050153429925146, 9.255590002336735, 9.48462160877997, 9.733778804499234,
        9.999985864996514, 10.280517823706996, 10.572962158196198, 10.875184631347352
    ];

    [Test]
    public void TestForwardInputWalksAtVanillaSpeedOnStone() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        LivingEntity zombie = Walker(world);

        for (int tick = 0; tick < ExpectedOnStone.Length; tick++) {
            EntityPhysics.Tick(world, zombie);
            Assert.That(zombie.Position.Z, Is.EqualTo(ExpectedOnStone[tick]), $"z after tick {tick}");
        }

        Assert.Multiple(() => {
            // Facing +Z with no sideways input, so it walks in a straight line.
            Assert.That(zombie.Position.X, Is.EqualTo(8.5));
            Assert.That(zombie.Position.Y, Is.EqualTo((double)FloorTop));
        });

        server.Stop();
    }

    /// <summary>
    /// The branch <c>getFrictionInfluencedSpeed</c> grew in 26.2: the friction division only applies
    /// above 0.6, so a port that divides unconditionally agrees with this on stone and disagrees here.
    /// </summary>
    [Test]
    public void TestForwardInputIsFrictionInfluencedOnIce() {
        World world = CreateWorld(Block.Ice.StateId, out ManagedMinecraftServer server);
        LivingEntity zombie = Walker(world);

        for (int tick = 0; tick < ExpectedOnIce.Length; tick++) {
            EntityPhysics.Tick(world, zombie);
            Assert.That(zombie.Position.Z, Is.EqualTo(ExpectedOnIce[tick]), $"z after tick {tick}");
        }

        server.Stop();
    }

    /// <summary>
    /// No input is the state every entity in this codebase was in before mob AI existed, and it has
    /// to stay exactly as it was: a living entity that nothing drives stands still.
    /// </summary>
    [Test]
    public void TestNoInputLeavesTheEntityWhereItIs() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        LivingEntity zombie = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, FloorTop, 8.5),
            OnGround = true
        };
        zombie.SetWorld(world);

        for (int tick = 0; tick < 20; tick++) {
            EntityPhysics.Tick(world, zombie);
        }

        Assert.Multiple(() => {
            Assert.That(zombie.Position.X, Is.EqualTo(8.5));
            Assert.That(zombie.Position.Z, Is.EqualTo(8.5));
            Assert.That(zombie.Position.Y, Is.EqualTo((double)FloorTop));
            Assert.That(zombie.OnGround, Is.True);
        });

        server.Stop();
    }

    /// <summary>
    /// The <c>MIN_MOVEMENT_DISTANCE</c> clamp. Vanilla throws away a velocity component under 0.003
    /// rather than letting it decay forever, so a pushed entity comes to a full stop.
    /// </summary>
    [Test]
    public void TestTinyVelocityIsThrownAway() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        LivingEntity zombie = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, FloorTop, 8.5),
            OnGround = true,
            Velocity = new Vec3<double>(0.002, 0, 0)
        };
        zombie.SetWorld(world);

        EntityPhysics.Tick(world, zombie);

        Assert.Multiple(() => {
            Assert.That(zombie.Velocity.X, Is.Zero, "under the threshold, so it is dropped outright");
            Assert.That(zombie.Position.X, Is.EqualTo(8.5), "and it never moved");
        });

        server.Stop();
    }

    /// <summary>
    /// A jump spends <see cref="LivingEntity.Jumping"/> once and then waits out
    /// <c>noJumpDelay</c>, which is what stops a held jump firing every tick.
    /// </summary>
    [Test]
    public void TestJumpingLeavesTheGroundAndTakesACooldown() {
        World world = CreateWorld(Block.Stone.StateId, out ManagedMinecraftServer server);
        LivingEntity zombie = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, FloorTop, 8.5),
            OnGround = true
        };
        zombie.SetWorld(world);

        // Settle so a downward velocity resolves against the floor and OnGround is genuinely set.
        EntityPhysics.Tick(world, zombie);
        EntityPhysics.Tick(world, zombie);
        Assert.That(zombie.OnGround, Is.True, "it should be resting on the floor before jumping");

        zombie.Jumping = true;
        EntityPhysics.Tick(world, zombie);

        Assert.Multiple(() => {
            Assert.That(zombie.Position.Y, Is.GreaterThan((double)FloorTop), "it left the ground");
            Assert.That(zombie.NoJumpDelay, Is.EqualTo(10), "and it owes ten ticks before the next one");
        });

        server.Stop();
    }
}
