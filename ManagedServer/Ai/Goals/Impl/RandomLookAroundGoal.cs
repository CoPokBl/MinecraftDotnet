using ManagedServer.Entities.Types;

namespace ManagedServer.Ai.Goals.Impl;

/// <summary>
/// Glance somewhere for no reason, vanilla's <c>RandomLookAroundGoal</c>. It is what stops an idle mob
/// looking frozen, and it is the cheapest goal there is.
/// <p/>
/// The direction goes through <see cref="Math"/> rather than <c>Mth</c>'s table because vanilla's does:
/// it is <c>Math.cos</c> and <c>Math.sin</c> of a random angle, and nothing compares the result against
/// a threshold, so the table's error would be a gratuitous divergence rather than a matching one.
/// </summary>
public class RandomLookAroundGoal : Goal {
    private readonly Mob _mob;

    private double _relX;
    private double _relZ;
    private int _lookTime;

    public RandomLookAroundGoal(Mob mob) {
        _mob = mob;
        SetFlags(GoalFlag.Look);
    }

    public override bool CanUse() {
        return _mob.Random.NextFloat() < 0.02f;
    }

    public override bool CanContinueToUse() {
        return _lookTime >= 0;
    }

    public override void Start() {
        double angle = 2.0 * Math.PI * _mob.Random.NextDouble();
        _relX = Math.Cos(angle);
        _relZ = Math.Sin(angle);
        _lookTime = 20 + _mob.Random.NextInt(20);
    }

    /// <summary>
    /// Yes, so the countdown is in real ticks. Vanilla says so too, and it is why the twenty above is
    /// not put through <see cref="Goal.AdjustedTickDelay"/>.
    /// </summary>
    public override bool RequiresUpdateEveryTick => true;

    public override void Tick() {
        _lookTime--;
        _mob.LookControl.SetLookAt(
            _mob.Position.X + _relX,
            _mob.Position.Y + _mob.Type.EyeHeight,
            _mob.Position.Z + _relZ);
    }
}
