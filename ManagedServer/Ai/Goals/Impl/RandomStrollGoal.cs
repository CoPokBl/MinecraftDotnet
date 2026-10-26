using ManagedServer.Ai.Util;
using ManagedServer.Entities.Types;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Ai.Goals.Impl;

/// <summary>
/// Wander somewhere nearby, vanilla's <c>RandomStrollGoal</c>. The bottom of almost every mob's goal
/// list: it is what a mob does when nothing else wants to happen.
/// </summary>
public class RandomStrollGoal : Goal {
    protected readonly Mob Mob;
    protected readonly double SpeedModifier;

    private double _wantedX, _wantedY, _wantedZ;

    /// <summary>
    /// One in this many ticks, on average, the mob picks somewhere new. Vanilla's default is 120, and
    /// it goes through <see cref="Goal.ReducedTickDelay"/> because the goal is only asked every other
    /// tick.
    /// </summary>
    private int _interval;

    /// <summary>
    /// Whether a mob that has been idle a long time stops strolling. Vanilla uses it to let a mob that
    /// nothing has interacted with for a hundred ticks settle down so it can be despawned.
    /// </summary>
    private readonly bool _checkNoActionTime;

    private bool _forceTrigger;

    public RandomStrollGoal(Mob mob, double speedModifier, int interval = 120, bool checkNoActionTime = true) {
        Mob = mob;
        SpeedModifier = speedModifier;
        _interval = interval;
        _checkNoActionTime = checkNoActionTime;
        SetFlags(GoalFlag.Move);
    }

    public override bool CanUse() {
        if (!_forceTrigger) {
            if (_checkNoActionTime && Mob.NoActionTime >= 100) {
                return false;
            }

            if (Mob.Random.NextInt(ReducedTickDelay(_interval)) != 0) {
                return false;
            }
        }

        if (GetPosition() is not { } target) {
            return false;
        }

        _wantedX = target.X;
        _wantedY = target.Y;
        _wantedZ = target.Z;
        _forceTrigger = false;
        return true;
    }

    /// <summary>Ten blocks out and seven up or down, which is vanilla's stroll radius.</summary>
    protected virtual Vec3<double>? GetPosition() {
        return RandomPos.GetPos(Mob, 10, 7);
    }

    public override bool CanContinueToUse() {
        return !Mob.Navigation.IsDone;
    }

    public override void Start() {
        Mob.Navigation.MoveTo(_wantedX, _wantedY, _wantedZ, SpeedModifier);
    }

    public override void Stop() {
        Mob.Navigation.Stop();
    }

    /// <summary>Makes the next <see cref="CanUse"/> skip the interval roll, vanilla's <c>trigger</c>.</summary>
    public void Trigger() {
        _forceTrigger = true;
    }

    public void SetInterval(int interval) {
        _interval = interval;
    }
}
