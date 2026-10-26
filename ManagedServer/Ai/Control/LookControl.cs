using ManagedServer.Entities.Types;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Ai.Control;

/// <summary>
/// Where a mob's head points, vanilla's <c>LookControl</c>. It writes
/// <see cref="Entity.HeadYaw"/> and <see cref="Entity.Pitch"/> and never the body yaw;
/// <see cref="BodyRotationControl"/> is what drags the body after the head.
/// <p/>
/// A look request lasts two ticks (<c>lookAtCooldown</c>), so a goal that sets one every other tick
/// keeps the head on target without having to run every tick.
/// </summary>
public class LookControl(Mob mob) {
    /// <summary>
    /// The float pi widened. Both angle methods below convert the way <see cref="MoveControl"/> does,
    /// <c>x * 180.0F / (float)Math.PI</c>: two operations in double against the float pi, not one
    /// multiply by a folded constant.
    /// </summary>
    private const double PiF = 3.1415927410125732;

    /// <summary>
    /// The threshold both angle methods use before they bother computing anything, vanilla's
    /// <c>1.0E-5F</c> widened. Written out for the same reason the one in <see cref="MoveControl"/> is.
    /// </summary>
    private const double Tiny = 9.999999747378752E-6;

    protected readonly Mob Mob = mob;

    private float _yMaxRotSpeed;
    private float _xMaxRotAngle;
    private int _lookAtCooldown;

    public double WantedX { get; private set; }
    public double WantedY { get; private set; }
    public double WantedZ { get; private set; }

    /// <summary>Whether a look request is still in effect, vanilla's <c>isLookingAtTarget</c>.</summary>
    public bool IsLookingAtTarget => _lookAtCooldown > 0;

    public void SetLookAt(Vec3<double> target) {
        SetLookAt(target.X, target.Y, target.Z);
    }

    /// <summary>Looks at an entity's eyes, which is what makes a mob meet a player's gaze.</summary>
    public void SetLookAt(Entity target) {
        SetLookAt(target.Position.X, target.Position.Y + target.Type.EyeHeight, target.Position.Z);
    }

    public void SetLookAt(Entity target, float yMaxRotSpeed, float xMaxRotAngle) {
        SetLookAt(target.Position.X, target.Position.Y + target.Type.EyeHeight, target.Position.Z,
            yMaxRotSpeed, xMaxRotAngle);
    }

    public void SetLookAt(double x, double y, double z) {
        SetLookAt(x, y, z, Mob.HeadRotSpeed, Mob.MaxHeadXRot);
    }

    public void SetLookAt(double x, double y, double z, float yMaxRotSpeed, float xMaxRotAngle) {
        WantedX = x;
        WantedY = y;
        WantedZ = z;
        _yMaxRotSpeed = yMaxRotSpeed;
        _xMaxRotAngle = xMaxRotAngle;
        _lookAtCooldown = 2;
    }

    public virtual void Tick() {
        if (ResetXRotOnTick) {
            Mob.Pitch = Angle.FromDegrees(0.0f);
        }

        if (_lookAtCooldown > 0) {
            _lookAtCooldown--;

            if (WantedYaw() is { } yaw) {
                Mob.HeadYaw = Angle.FromDegrees(RotateTowards(Mob.HeadYaw.DegreesF, yaw, _yMaxRotSpeed));
            }

            if (WantedPitch() is { } pitch) {
                Mob.Pitch = Angle.FromDegrees(RotateTowards(Mob.Pitch.DegreesF, pitch, _xMaxRotAngle));
            }
        }
        else {
            // Nothing asked for a direction, so the head drifts back towards the body ten degrees a
            // tick. This is what makes a mob that has lost interest slowly face forwards again.
            Mob.HeadYaw = Angle.FromDegrees(RotateTowards(Mob.HeadYaw.DegreesF, Mob.BodyYaw.DegreesF, 10.0f));
        }

        ClampHeadRotationToBody();
    }

    /// <summary>
    /// The neck limit. Note the direction of the test: vanilla clamps only <b>while the mob is
    /// pathing</b> (<c>!navigation.isDone()</c>), and lets a standing mob's head turn as far as it
    /// likes. Reading it the other way round is easy and gives a mob that cranes its neck while
    /// walking and snaps forward when it stops, which is exactly backwards.
    /// </summary>
    protected virtual void ClampHeadRotationToBody() {
        if (!Mob.Navigation.IsDone) {
            Mob.HeadYaw = Angle.FromDegrees(
                Mth.RotateIfNecessary(Mob.HeadYaw.DegreesF, Mob.BodyYaw.DegreesF, Mob.MaxHeadYRot));
        }
    }

    /// <summary>
    /// Whether the pitch is zeroed before a look is applied, so a mob with nothing to look at ends up
    /// level. False for anything that keeps a pitch of its own.
    /// </summary>
    protected virtual bool ResetXRotOnTick => true;

    /// <summary>
    /// <c>getYRotD</c>: null when the target is directly above or below, where a yaw is meaningless.
    /// </summary>
    protected float? WantedYaw() {
        double dx = WantedX - Mob.Position.X;
        double dz = WantedZ - Mob.Position.Z;

        if (Math.Abs(dz) <= Tiny && Math.Abs(dx) <= Tiny) {
            return null;
        }

        return (float)(Mth.Atan2(dz, dx) * 180.0f / PiF) - 90.0f;
    }

    /// <summary><c>getXRotD</c>: measured from the mob's eyes, not its feet.</summary>
    protected float? WantedPitch() {
        double dx = WantedX - Mob.Position.X;
        double dy = WantedY - (Mob.Position.Y + Mob.Type.EyeHeight);
        double dz = WantedZ - Mob.Position.Z;
        double horizontal = Math.Sqrt(dx * dx + dz * dz);

        if (Math.Abs(dy) <= Tiny && Math.Abs(horizontal) <= Tiny) {
            return null;
        }

        return (float)-(Mth.Atan2(dy, horizontal) * 180.0f / PiF);
    }

    /// <summary>
    /// <c>Control.rotateTowards</c>, the default method on the interface both controls implement:
    /// step by at most <paramref name="maxDelta"/> the short way round.
    /// </summary>
    protected static float RotateTowards(float from, float to, float maxDelta) {
        float difference = Mth.DegreesDifference(from, to);
        float clamped = Mth.Clamp(difference, -maxDelta, maxDelta);
        return from + clamped;
    }
}
