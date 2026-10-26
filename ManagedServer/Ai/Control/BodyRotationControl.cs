using ManagedServer.Entities.Types;
using Minecraft.Schemas;

namespace ManagedServer.Ai.Control;

/// <summary>
/// What keeps <see cref="Mob.BodyYaw"/> pointing sensibly while the head does the looking, vanilla's
/// <c>BodyRotationControl</c>. Three states, in this order:
/// <list type="bullet">
/// <item>Moving: the body faces the direction of travel and the head is clamped to it.</item>
/// <item>Standing, head turned more than fifteen degrees since it was last stable: the body turns to
/// follow the head.</item>
/// <item>Standing, head held still for more than ten ticks: the body eases round to face forwards over
/// the next ten ticks rather than snapping.</item>
/// </list>
/// The body rotation is never sent: the client runs this same control on its own copy of the mob. What
/// it decides matters here only because <see cref="LookControl"/> clamps the head against it, which is
/// how a mob ends up unable to look behind itself.
/// <p/>
/// Vanilla calls the method <c>clientTick</c> and then calls it from the server's
/// <c>Mob.tickHeadTurn</c> anyway; the name is a leftover.
/// </summary>
public class BodyRotationControl(Mob mob) {
    private const float HeadStableAngle = 15.0f;
    private const int DelayUntilStartingToFaceForward = 10;
    private const int HowLongItTakesToFaceForward = 10;

    /// <summary>The squared movement below which the mob counts as standing still, as in the move control.</summary>
    private const double MinSpeedSqr = 2.500000277905201E-7;

    protected readonly Mob Mob = mob;

    private int _headStableTime;
    private float _lastStableHeadYaw;

    public virtual void Tick() {
        if (IsMoving) {
            // Walking decides the body outright: whatever the move control turned Yaw to is the body,
            // and the head is pulled back to within the neck limit of it.
            Mob.BodyYaw = Mob.Yaw;
            RotateHeadIfNecessary();
            _lastStableHeadYaw = Mob.HeadYaw.DegreesF;
            _headStableTime = 0;
            return;
        }

        // Vanilla skips the rest while carrying a mob passenger, since the rider decides the body.
        // Nothing here models passengers, so that check has nothing to test and is left out.
        if (Math.Abs(Mob.HeadYaw.DegreesF - _lastStableHeadYaw) > HeadStableAngle) {
            _headStableTime = 0;
            _lastStableHeadYaw = Mob.HeadYaw.DegreesF;
            RotateBodyIfNecessary();
            return;
        }

        _headStableTime++;
        if (_headStableTime > DelayUntilStartingToFaceForward) {
            RotateHeadTowardsFront();
        }
    }

    private void RotateBodyIfNecessary() {
        Mob.BodyYaw = Angle.FromDegrees(
            Mth.RotateIfNecessary(Mob.BodyYaw.DegreesF, Mob.HeadYaw.DegreesF, Mob.MaxHeadYRot));
    }

    private void RotateHeadIfNecessary() {
        Mob.HeadYaw = Angle.FromDegrees(
            Mth.RotateIfNecessary(Mob.HeadYaw.DegreesF, Mob.BodyYaw.DegreesF, Mob.MaxHeadYRot));
    }

    /// <summary>
    /// Eases the allowed head to body separation down to zero over ten ticks. Shrinking the limit is
    /// what turns the body: <see cref="Mth.RotateIfNecessary"/> pulls whichever side is outside it.
    /// </summary>
    private void RotateHeadTowardsFront() {
        int elapsed = _headStableTime - DelayUntilStartingToFaceForward;
        float progress = Mth.Clamp((float)elapsed / HowLongItTakesToFaceForward, 0.0f, 1.0f);
        float allowed = Mob.MaxHeadYRot * (1.0f - progress);

        Mob.BodyYaw = Angle.FromDegrees(
            Mth.RotateIfNecessary(Mob.BodyYaw.DegreesF, Mob.HeadYaw.DegreesF, allowed));
    }

    /// <summary>
    /// Whether the mob moved horizontally this tick, against the same threshold the move control uses
    /// to decide it has arrived.
    /// </summary>
    private bool IsMoving {
        get {
            double dx = Mob.Position.X - Mob.LastTickPosition.X;
            double dz = Mob.Position.Z - Mob.LastTickPosition.Z;
            return dx * dx + dz * dz > MinSpeedSqr;
        }
    }
}
