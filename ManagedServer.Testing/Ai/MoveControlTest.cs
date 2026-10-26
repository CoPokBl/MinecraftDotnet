using ManagedServer.Ai.Control;
using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Testing.Ai;

/// <summary>
/// <see cref="MoveControl"/> against the numbers vanilla's produces. Every expected value in here came
/// out of <c>Conformance/movecontrol.sh</c>, which drives the real <c>MoveControl.rotlerp</c> and the
/// real yaw formula out of the 26.2 jar; none of them was computed by this port.
/// <p/>
/// That matters more here than the arithmetic looks. The control writes yaw, speed and forward input
/// for the travel step to spend on the same tick, so a yaw wrong in the last few bits is a heading
/// wrong by a fraction of a degree every tick, compounding, against a client that predicted the
/// vanilla answer.
/// </summary>
[TestFixture]
public class MoveControlTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };

        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    private Mob Spawn(double x = 0.5, double y = 64.0, double z = 0.5) {
        Mob mob = new(EntityType.Zombie) {
            Position = new Vec3<double>(x, y, z)
        };

        mob.SetWorld(_world);
        mob.Yaw = Angle.FromDegrees(0.0f);
        return mob;
    }

    /// <summary>Reaches the protected <c>rotlerp</c> without reflection.</summary>
    private sealed class ExposedMoveControl(Mob mob) : MoveControl(mob) {
        public static float Lerp(float current, float target, float maxDelta) {
            return RotLerp(current, target, maxDelta);
        }
    }

    private static readonly float[][] RotLerpCases = [
        [0.0f, 0.0f, 90.0f],
        [0.0f, 45.0f, 90.0f],
        [0.0f, 180.0f, 90.0f],
        [0.0f, -180.0f, 90.0f],
        [0.0f, 179.0f, 90.0f],
        [0.0f, -179.0f, 90.0f],
        [170.0f, -170.0f, 90.0f],
        [-170.0f, 170.0f, 90.0f],
        [350.0f, 10.0f, 90.0f],
        [10.0f, 350.0f, 90.0f],
        [0.0f, 30.0f, 10.0f],
        [0.0f, -30.0f, 10.0f],
        [359.0f, 5.0f, 90.0f],
        [-359.0f, -5.0f, 90.0f],
        [720.0f, 0.0f, 90.0f],
        [-720.0f, 0.0f, 90.0f],
        [45.5f, 46.25f, 90.0f]
    ];

    /// <summary>From <c>Conformance/movecontrol.sh</c>, the real <c>MoveControl.rotlerp</c>.</summary>
    private static readonly float[] RotLerpExpected = [
        0.0f, 45.0f, 270.0f, 270.0f, 90.0f, 270.0f, 190.0f, 170.0f, 10.0f, 350.0f,
        10.0f, 350.0f, 5.0f, -5.0f, 360.0f, -360.0f, 46.25f
    ];

    /// <summary>
    /// The turn cap and the wrap. Three of these look wrong and are not: a half turn resolves to 270
    /// rather than 90 because <c>wrapDegrees(180)</c> is -180 and the cap makes it -90, and the wrap at
    /// the end is a single add or subtract rather than a modulo, so -359 stays negative and 720 comes
    /// out as 360.
    /// </summary>
    [Test]
    public void TestRotLerpMatchesVanilla() {
        Assert.Multiple(() => {
            for (int i = 0; i < RotLerpCases.Length; i++) {
                float[] c = RotLerpCases[i];
                Assert.That(ExposedMoveControl.Lerp(c[0], c[1], c[2]), Is.EqualTo(RotLerpExpected[i]),
                    $"rotlerp({c[0]}, {c[1]}, {c[2]})");
            }
        });
    }

    private static readonly double[][] YawCases = [
        [1.0, 0.0], [0.0, 1.0], [-1.0, 0.0], [0.0, -1.0],
        [1.0, 1.0], [-1.0, 1.0], [1.0, -1.0], [-1.0, -1.0],
        [8.0, 3.0], [-8.0, 3.0], [0.25, -7.5], [123.456, -78.9]
    ];

    /// <summary>
    /// From <c>Conformance/movecontrol.sh</c>. Four of these disagree with an accurate
    /// <c>Math.Atan2</c> conversion, which is the point: the last of them is out by 1.5e-5 degrees and
    /// the diagonal is out by 4e-6, and those are the numbers the client predicted.
    /// </summary>
    private static readonly float[] YawExpected = [
        -90.0f, 0.0f, 90.0f, -180.0f, -45.000004f, 45.0f, -135.0f, -225.0f,
        -69.443954f, 69.443954f, -178.09082f, -122.58242f
    ];

    /// <summary>
    /// The heading, driven through the real control rather than through the formula. The mob starts at
    /// yaw zero and the offsets are all within 90 degrees or resolved by the cap, so what comes out of
    /// <see cref="Mob.Yaw"/> is <c>rotlerp(0, wanted, 90)</c> of the pinned value.
    /// </summary>
    [Test]
    public void TestWantedYawMatchesVanilla() {
        Assert.Multiple(() => {
            for (int i = 0; i < YawCases.Length; i++) {
                double dx = YawCases[i][0];
                double dz = YawCases[i][1];

                Mob mob = Spawn();
                mob.MoveControl.SetWantedPosition(mob.Position.X + dx, mob.Position.Y, mob.Position.Z + dz, 1.0);
                mob.MoveControl.Tick();

                float expected = ExposedMoveControl.Lerp(0.0f, YawExpected[i], 90.0f);
                Assert.That(mob.Yaw.DegreesF, Is.EqualTo(expected), $"dx={dx} dz={dz}");
            }
        });
    }

    /// <summary>
    /// A destination nearer than <c>MIN_SPEED_SQR</c> stops the mob rather than turning it. The
    /// threshold is the float <c>2.5000003E-7f</c> widened to <c>2.500000277905201E-7</c>, which is
    /// what a double squared distance is compared against; a distance either side of it has to fall on
    /// the right side.
    /// </summary>
    [Test]
    public void TestMinSpeedSqrIsTheWidenedFloat() {
        const double threshold = 2.500000277905201E-7;

        // Just inside: the mob must not turn, and Zza is zeroed.
        Mob still = Spawn();
        still.Zza = 1.0f;
        double justUnder = Math.Sqrt(threshold) * 0.999;
        still.MoveControl.SetWantedPosition(
            still.Position.X + justUnder, still.Position.Y, still.Position.Z, 1.0);
        still.MoveControl.Tick();

        Assert.Multiple(() => {
            Assert.That(still.Zza, Is.Zero, "too close to bother, so the forward input is cleared");
            Assert.That(still.Yaw.DegreesF, Is.Zero, "and the mob did not turn");
        });

        // Just outside: it turns towards a destination due east, which is yaw -90 wrapped to 270.
        Mob moving = Spawn();
        double justOver = Math.Sqrt(threshold) * 1.001;
        moving.MoveControl.SetWantedPosition(
            moving.Position.X + justOver, moving.Position.Y, moving.Position.Z, 1.0);
        moving.MoveControl.Tick();

        Assert.That(moving.Yaw.DegreesF, Is.EqualTo(270.0f));
    }

    /// <summary>
    /// The 90 degree cap, which is what stops a mob spinning to face a target behind it in one tick.
    /// A destination due west is 90 degrees of wanted yaw away from a mob facing due east, and one
    /// directly behind is 180 and is capped.
    /// </summary>
    [Test]
    public void TestTurnIsCappedAtNinetyDegrees() {
        Mob mob = Spawn();
        mob.Yaw = Angle.FromDegrees(0.0f);

        // Directly behind: wanted yaw is -180, wrapDegrees makes it -180, the cap makes it -90, and
        // the wrap turns that into 270.
        mob.MoveControl.SetWantedPosition(mob.Position.X, mob.Position.Y, mob.Position.Z - 8.0, 1.0);
        mob.MoveControl.Tick();

        Assert.That(mob.Yaw.DegreesF, Is.EqualTo(270.0f), "one tick may only turn 90 degrees");
    }

    /// <summary>
    /// The speed written is the modifier times the <c>minecraft:movement_speed</c> attribute, computed
    /// in double and narrowed once. It is what the travel step spends, so a mob with no destination
    /// leaves it alone rather than zeroing it.
    /// </summary>
    [Test]
    public void TestSpeedIsTheModifierTimesTheAttribute() {
        Mob mob = Spawn();
        mob.SetAttributeBaseValue(Attribute.MovementSpeed, 0.23);

        mob.MoveControl.SetWantedPosition(mob.Position.X + 8.0, mob.Position.Y, mob.Position.Z, 1.25);
        mob.MoveControl.Tick();

        Assert.That(mob.Speed, Is.EqualTo((float)(1.25 * 0.23)));
    }

    /// <summary>
    /// A MOVE_TO is spent in the tick it is used and has to be renewed, which is what makes a goal that
    /// stops calling <c>SetWantedPosition</c> stop the mob rather than leaving it walking.
    /// </summary>
    [Test]
    public void TestMoveToIsSpentInOneTick() {
        Mob mob = Spawn();
        mob.MoveControl.SetWantedPosition(mob.Position.X + 8.0, mob.Position.Y, mob.Position.Z, 1.0);

        Assert.That(mob.MoveControl.HasWanted, Is.True);

        mob.MoveControl.Tick();
        Assert.That(mob.MoveControl.HasWanted, Is.False);

        // And the next tick clears the forward input rather than repeating the last heading.
        mob.Zza = 1.0f;
        mob.MoveControl.Tick();
        Assert.That(mob.Zza, Is.Zero);
    }

    /// <summary>
    /// A jump in progress survives a new destination, so a mob told to go somewhere else mid hop
    /// finishes the hop first. Missing this makes a jumping mob stall against the block it is jumping
    /// over.
    /// </summary>
    [Test]
    public void TestANewDestinationDoesNotInterruptAJump() {
        Mob mob = Spawn();

        // Two blocks up and one across: over the step height, and inside the horizontal reach, which is
        // both halves of vanilla's first jump condition.
        mob.MoveControl.SetWantedPosition(mob.Position.X + 0.5, mob.Position.Y + 2.0, mob.Position.Z, 1.0);
        mob.MoveControl.Tick();

        Assert.That(mob.MoveControl.CurrentOperation, Is.EqualTo(MoveControl.Operation.Jumping));

        mob.MoveControl.SetWantedPosition(mob.Position.X - 8.0, mob.Position.Y, mob.Position.Z, 1.0);
        Assert.That(mob.MoveControl.CurrentOperation, Is.EqualTo(MoveControl.Operation.Jumping),
            "the destination is recorded but the operation stays JUMPING");

        // Landing ends it.
        mob.OnGround = true;
        mob.MoveControl.Tick();
        Assert.That(mob.MoveControl.CurrentOperation, Is.EqualTo(MoveControl.Operation.Wait));
    }
}
