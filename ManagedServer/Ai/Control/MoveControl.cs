using ManagedServer.Entities.Types;
using ManagedServer.Pathfinding;
using ManagedServer.Physics;
using Minecraft.Physics;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Ai.Control;

/// <summary>
/// What turns "go to this point" into movement, vanilla's <c>MoveControl</c>. It never touches the
/// mob's velocity: it writes <see cref="LivingEntity.Yaw"/>, <see cref="LivingEntity.Speed"/> and
/// <see cref="LivingEntity.Zza"/>, and the travel step in <see cref="EntityPhysics"/> turns those into
/// velocity on the same tick. That coupling is why the AI step lives inside the physics tick.
/// </summary>
public class MoveControl(Mob mob) {
    /// <summary>
    /// <c>MIN_SPEED_SQR</c>. The literal in the bytecode is the <b>double</b> widening of vanilla's
    /// <c>2.5000003E-7f</c>, so it is written out rather than recomputed from the float: squaring
    /// <c>5.0E-4f</c> here would land somewhere else.
    /// </summary>
    private const double MinSpeedSqr = 2.500000277905201E-7;

    /// <summary>How far the mob may turn towards where it is going in one tick.</summary>
    private const float MaxTurn = 90.0f;

    /// <summary>
    /// Vanilla's radians to degrees conversion <b>as it appears in this method</b>. It is written
    /// upstream as <c>x * 180.0F / (float)Math.PI</c>: a multiply and a divide, both in double, by the
    /// <b>float</b> pi. That is not <c>x * (180 / Math.PI)</c> and it is not one multiply by a folded
    /// constant either, so the two operations are kept apart here and <see cref="PiF"/> is the float
    /// pi widened. Folding them moves the answer in the last few bits, which is enough to disagree
    /// with the client at the edge of a turn.
    /// </summary>
    private const double PiF = 3.1415927410125732;

    public enum Operation {
        Wait,
        MoveTo,
        Strafe,
        Jumping
    }

    protected readonly Mob Mob = mob;

    public double WantedX { get; private set; }
    public double WantedY { get; private set; }
    public double WantedZ { get; private set; }
    public double SpeedModifier { get; private set; }

    private float _strafeForwards;
    private float _strafeRight;

    public Operation CurrentOperation { get; protected set; } = Operation.Wait;

    /// <summary>Whether the control is heading somewhere, vanilla's <c>hasWanted</c>.</summary>
    public bool HasWanted => CurrentOperation == Operation.MoveTo;

    /// <param name="speedModifier">
    /// Multiplied by <c>minecraft:movement_speed</c>, so it is a fraction of the mob's own pace rather
    /// than an absolute speed. Goals pass numbers like 1.0 for a walk and 1.2 for a run.
    /// </param>
    public void SetWantedPosition(double x, double y, double z, double speedModifier) {
        WantedX = x;
        WantedY = y;
        WantedZ = z;
        SpeedModifier = speedModifier;

        // A jump in progress is not interrupted by a new destination; it finishes and the destination
        // is picked up on the tick after it lands.
        if (CurrentOperation != Operation.Jumping) {
            CurrentOperation = Operation.MoveTo;
        }
    }

    public void Strafe(float forwards, float right) {
        CurrentOperation = Operation.Strafe;
        _strafeForwards = forwards;
        _strafeRight = right;
        SpeedModifier = 0.25;
    }

    public void SetWait() {
        CurrentOperation = Operation.Wait;
    }

    public virtual void Tick() {
        switch (CurrentOperation) {
            case Operation.Strafe:
                TickStrafe();
                return;

            case Operation.MoveTo:
                TickMoveTo();
                return;

            case Operation.Jumping:
                TickJumping();
                return;

            default:
                Mob.Zza = 0.0f;
                return;
        }
    }

    private void TickStrafe() {
        float movementSpeed = (float)Mob.GetAttributeValue(Attribute.MovementSpeed);
        float speed = (float)SpeedModifier * movementSpeed;
        float forwards = _strafeForwards;
        float right = _strafeRight;

        // Vanilla clamps the divisor up to one rather than the length down, so a short input keeps its
        // direction and moves slower instead of being normalised up to full speed.
        float length = Mth.Sqrt(forwards * forwards + right * right);
        if (length < 1.0f) {
            length = 1.0f;
        }

        length = speed / length;
        forwards *= length;
        right *= length;

        float sin = Mth.Sin(Mob.Yaw.DegreesF * 0.017453292f);
        float cos = Mth.Cos(Mob.Yaw.DegreesF * 0.017453292f);
        float worldX = forwards * cos - right * sin;
        float worldZ = right * cos + forwards * sin;

        if (!IsWalkable(worldX, worldZ)) {
            _strafeForwards = 1.0f;
            _strafeRight = 0.0f;
        }

        Mob.Speed = speed;
        Mob.Zza = _strafeForwards;
        Mob.Xxa = _strafeRight;
        CurrentOperation = Operation.Wait;
    }

    private void TickMoveTo() {
        // Reset first: a MOVE_TO is spent in one tick and has to be renewed by whatever set it, which
        // is what makes a goal that stops calling SetWantedPosition stop the mob.
        CurrentOperation = Operation.Wait;

        double dx = WantedX - Mob.Position.X;
        double dz = WantedZ - Mob.Position.Z;
        double dy = WantedY - Mob.Position.Y;
        double distanceSqr = dx * dx + dy * dy + dz * dz;

        if (distanceSqr < MinSpeedSqr) {
            Mob.Zza = 0.0f;
            return;
        }

        float wantedYaw = (float)(Mth.Atan2(dz, dx) * 180.0f / PiF) - 90.0f;
        Mob.Yaw = Angle.FromDegrees(RotLerp(Mob.Yaw.DegreesF, wantedYaw, MaxTurn));
        Mob.Speed = (float)(SpeedModifier * Mob.GetAttributeValue(Attribute.MovementSpeed));

        if (ShouldJump(dx, dy, dz)) {
            Mob.JumpControl.Jump();
            CurrentOperation = Operation.Jumping;
        }
    }

    /// <summary>
    /// The two reasons vanilla jumps while walking: the destination is a step up too tall to walk onto
    /// and near enough to reach, or the mob is standing in something whose collision shape it is
    /// already partly inside and which is not a door or a fence.
    /// <p/>
    /// Note the first test compares a <b>squared</b> horizontal distance against an unsquared width.
    /// That is vanilla's, quirk included, and it is what makes the reach for a step up about one block
    /// for anything narrower than one.
    /// </summary>
    private bool ShouldJump(double dx, double dy, double dz) {
        World world = Mob.World!;
        MinecraftRegistry registry = world.Server.Registry;

        float stepHeight = (float)Mob.GetAttributeValue(Attribute.StepHeight);
        if (dy > stepHeight && dx * dx + dz * dz < Math.Max(1.0f, Mob.Type.Width)) {
            return true;
        }

        Vec3<int> pos = new((int)Math.Floor(Mob.Position.X), (int)Math.Floor(Mob.Position.Y),
            (int)Math.Floor(Mob.Position.Z));

        IBlock block = world.GetBlockOr(pos, Block.Air);
        Box[] boxes = BlockPhysicsData.ShapeBoxesOf(block.CollisionShape);
        if (boxes.Length == 0) {
            return false;
        }

        double top = pos.Y + boxes.Max(box => box.MaxY);
        if (Mob.Position.Y >= top) {
            return false;
        }

        return !registry.Blocks.Tags.Contains(registry, DoorsTag, block.Identifier)
               && !registry.Blocks.Tags.Contains(registry, FencesTag, block.Identifier);
    }

    private static readonly Identifier DoorsTag = "minecraft:doors";
    private static readonly Identifier FencesTag = "minecraft:fences";

    private void TickJumping() {
        Mob.Speed = (float)(SpeedModifier * Mob.GetAttributeValue(Attribute.MovementSpeed));

        // Landing ends the jump. Vanilla also ends it in a liquid, which is not modelled here because
        // nothing tells a mob it is in one yet; see PathNavigation for the same gap.
        if (Mob.OnGround) {
            CurrentOperation = Operation.Wait;
        }
    }

    /// <summary>
    /// Whether a strafe would walk the mob into something. The node evaluator is asked what the
    /// block one step away is and anything other than <c>WALKABLE</c> refuses the strafe, which is
    /// stricter than it sounds: a square next to water or fire classifies as a border type and stops
    /// a mob strafing along it.
    /// <p/>
    /// The <b>y is the mob's own block y, not the floor under the step</b>, so this asks about the
    /// square the mob's feet would be in rather than what it would be standing on.
    /// </summary>
    private bool IsWalkable(float x, float z) {
        if (Mob.World is not { } world) {
            return true;
        }

        PathfindingContext context = new(world, Mob);
        PathType type = Mob.Navigation.NodeEvaluator.GetPathType(context,
            Mth.Floor(Mob.Position.X + x), Mth.Floor(Mob.Position.Y), Mth.Floor(Mob.Position.Z + z));

        return type == PathType.Walkable;
    }

    /// <summary>
    /// <c>MoveControl.rotlerp</c>, which is not <see cref="Mth.RotLerp"/>: it steps by at most
    /// <paramref name="maxDelta"/> degrees and then folds the result into [0, 360] with a single
    /// add or subtract rather than a modulo, so an input well outside one turn comes out unwrapped.
    /// </summary>
    protected static float RotLerp(float current, float target, float maxDelta) {
        float difference = Mth.WrapDegrees(target - current);
        if (difference > maxDelta) {
            difference = maxDelta;
        }

        if (difference < -maxDelta) {
            difference = -maxDelta;
        }

        float result = current + difference;
        if (result < 0.0f) {
            result += 360.0f;
        }
        else if (result > 360.0f) {
            result -= 360.0f;
        }

        return result;
    }
}
