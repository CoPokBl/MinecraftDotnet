using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft;

namespace ManagedServer.Ai.Goals.Impl;

/// <summary>
/// Chase what the mob is fighting and hit it, vanilla's <c>MeleeAttackGoal</c>. It is what turns a
/// target picked by a target goal into an attack, and it is the goal almost every hostile mob has.
/// <p/>
/// It claims <see cref="GoalFlag.Move"/> and <see cref="GoalFlag.Look"/> together, which is the
/// all-or-nothing claim <see cref="GoalSelector"/> is careful about: a mob whose look is held by
/// something uninterruptable cannot start attacking at all.
/// </summary>
public class MeleeAttackGoal : Goal {
    protected readonly Mob Mob;
    private readonly double _speedModifier;
    private readonly bool _followingTargetEvenIfNotSeen;

    private double _pathedTargetX, _pathedTargetY, _pathedTargetZ;
    private int _ticksUntilNextPathRecalculation;
    private int _ticksUntilNextAttack;
    private long _lastCanUseCheck;
    private bool _hasPath;

    /// <summary>
    /// How rarely the goal is allowed to even ask, <c>COOLDOWN_BETWEEN_CAN_USE_CHECKS</c>. Vanilla
    /// puts it here rather than in the selector because deciding involves a pathfind, which is the
    /// expensive part of the whole system.
    /// </summary>
    private const long CooldownBetweenCanUseChecks = 20L;

    /// <param name="followingTargetEvenIfNotSeen">
    /// Whether the mob keeps coming when it loses sight of the target. False makes it give up as soon
    /// as the route runs out, which is what a mob that hunts by sight does.
    /// </param>
    public MeleeAttackGoal(Mob mob, double speedModifier, bool followingTargetEvenIfNotSeen) {
        Mob = mob;
        _speedModifier = speedModifier;
        _followingTargetEvenIfNotSeen = followingTargetEvenIfNotSeen;
        SetFlags(GoalFlag.Move | GoalFlag.Look);
    }

    public override bool CanUse() {
        // Vanilla measures this against the level's game time. There is no monotonic world clock here
        // (World._time is the settable time of day and can go backwards), and the mob's own tick count
        // advances at the same rate, so the difference is a constant offset that a difference against
        // a stored value cannot see.
        long time = Mob.TickCount;
        if (time - _lastCanUseCheck < CooldownBetweenCanUseChecks) {
            return false;
        }

        _lastCanUseCheck = time;

        if (Mob.Target is not { IsAlive: true } target) {
            return false;
        }

        // Vanilla builds the path here and keeps it for Start, so the route is computed once rather
        // than twice. Being unable to route is not on its own a refusal: a mob already in range
        // attacks from where it stands.
        _hasPath = Mob.Navigation.MoveTo(target, _speedModifier);
        return _hasPath || Mob.IsWithinMeleeAttackRange(target);
    }

    public override bool CanContinueToUse() {
        if (Mob.Target is not { IsAlive: true } target) {
            return false;
        }

        if (!_followingTargetEvenIfNotSeen) {
            return !Mob.Navigation.IsDone;
        }

        // A mob that follows regardless keeps going until the target stops being a target at all. The
        // creative and spectator check vanilla does here is already inside Mob.Target.
        return target.CanBeSeenAsEnemy;
    }

    public override void Start() {
        // CanUse already asked the navigation for this route, so vanilla replays the stored path here
        // rather than recomputing. Reissuing it is the same thing given a navigation that holds one
        // destination, and it also covers the in-range-but-unroutable case CanUse allows through.
        if (_hasPath) {
            Mob.Navigation.MoveTo(Mob.Target!, _speedModifier);
        }

        Mob.Aggressive = true;
        _ticksUntilNextPathRecalculation = 0;
        _ticksUntilNextAttack = 0;
    }

    public override void Stop() {
        // Vanilla only clears the target when it is still something worth clearing; a target that went
        // creative or spectator is left alone so the target goal sees it go rather than finding null.
        if (Mob.Target is { } target && target.CanBeSeenAsEnemy) {
            Mob.Target = null;
        }

        Mob.Aggressive = false;
        Mob.Navigation.Stop();
    }

    public override bool RequiresUpdateEveryTick => true;

    public override void Tick() {
        if (Mob.Target is not { } target) {
            return;
        }

        Mob.LookControl.SetLookAt(target, 30.0f, 30.0f);
        _ticksUntilNextPathRecalculation = Math.Max(_ticksUntilNextPathRecalculation - 1, 0);

        bool canSee = _followingTargetEvenIfNotSeen || Mob.Sensing.HasLineOfSight(target);
        bool targetMoved = (_pathedTargetX == 0.0 && _pathedTargetY == 0.0 && _pathedTargetZ == 0.0)
                           || SquaredDistanceFromPathedTarget(target) >= 1.0
                           || Mob.Random.NextFloat() < 0.05f;

        if (canSee && _ticksUntilNextPathRecalculation <= 0 && targetMoved) {
            _pathedTargetX = target.Position.X;
            _pathedTargetY = target.Position.Y;
            _pathedTargetZ = target.Position.Z;
            _ticksUntilNextPathRecalculation = 4 + Mob.Random.NextInt(7);

            // A distant target is repathed less often, because the route is long and the target moving
            // a block barely changes it. The thresholds are squared distances: 32 and 16 blocks.
            double targetDistanceSqr = SquaredDistanceTo(target);
            if (targetDistanceSqr > 1024.0) {
                _ticksUntilNextPathRecalculation += 10;
            }
            else if (targetDistanceSqr > 256.0) {
                _ticksUntilNextPathRecalculation += 5;
            }

            if (!Mob.Navigation.MoveTo(target, _speedModifier)) {
                _ticksUntilNextPathRecalculation += 15;
            }

            _ticksUntilNextPathRecalculation = AdjustedTickDelay(_ticksUntilNextPathRecalculation);
        }

        _ticksUntilNextAttack = Math.Max(_ticksUntilNextAttack - 1, 0);
        CheckAndPerformAttack(target);
    }

    protected virtual void CheckAndPerformAttack(LivingEntity target) {
        if (!CanPerformAttack(target)) {
            return;
        }

        ResetAttackCooldown();
        Mob.Swing();
        Mob.DoHurtTarget(World, target);
    }

    protected void ResetAttackCooldown() {
        _ticksUntilNextAttack = AdjustedTickDelay(20);
    }

    protected bool IsTimeToAttack => _ticksUntilNextAttack <= 0;

    protected int TicksUntilNextAttack => _ticksUntilNextAttack;

    protected virtual bool CanPerformAttack(LivingEntity target) {
        return IsTimeToAttack && Mob.IsWithinMeleeAttackRange(target) && Mob.Sensing.HasLineOfSight(target);
    }

    private World World => Mob.World.ThrowIfNull();

    private double SquaredDistanceFromPathedTarget(LivingEntity target) {
        double dx = target.Position.X - _pathedTargetX;
        double dy = target.Position.Y - _pathedTargetY;
        double dz = target.Position.Z - _pathedTargetZ;
        return dx * dx + dy * dy + dz * dz;
    }

    private double SquaredDistanceTo(LivingEntity target) {
        double dx = target.Position.X - Mob.Position.X;
        double dy = target.Position.Y - Mob.Position.Y;
        double dz = target.Position.Z - Mob.Position.Z;
        return dx * dx + dy * dy + dz * dz;
    }
}
