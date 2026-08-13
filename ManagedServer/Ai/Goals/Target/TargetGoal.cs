using ManagedServer.Ai.Targeting;
using ManagedServer.Entities.Types;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Ai.Goals.Target;

/// <summary>
/// The shared half of every goal that picks a fight, vanilla's <c>TargetGoal</c>. Target goals go on
/// a mob's <c>TargetGoals</c> selector rather than its <c>Goals</c>, so choosing who to fight and
/// deciding what to do about it are arbitrated separately: a mob can acquire a target and keep
/// strolling in the same tick, and the melee goal picks the target up on its own schedule.
/// <p/>
/// What a subclass supplies is <see cref="Goal.CanUse"/>. Everything about giving up on a target,
/// remembering one that stepped out of sight, and the reachability cache is here.
/// </summary>
public abstract class TargetGoal : Goal {
    private const int EmptyReachCache = 0;
    private const int CanReachCache = 1;
    private const int CantReachCache = 2;

    protected readonly Mob Mob;

    /// <summary>Whether losing sight of the target eventually ends the goal.</summary>
    protected readonly bool MustSee;

    private readonly bool _mustReach;

    private int _reachCache;
    private int _reachCacheTime;
    private int _unseenTicks;

    /// <summary>
    /// The candidate a subclass found, kept so <see cref="CanContinueToUse"/> has something to fall
    /// back on when the mob's target was cleared out from under it.
    /// </summary>
    protected LivingEntity? TargetMob;

    /// <summary>
    /// How long the mob keeps chasing something it cannot see. <c>HurtByTargetGoal</c> raises it to
    /// 300, which is why a mob you shot from cover hunts you far longer than one that merely spotted
    /// you.
    /// </summary>
    protected int UnseenMemoryTicks = 60;

    /// <param name="mustReach">
    /// Whether the target has to be routable to. It costs a pathfind, cached for ten to fifteen ticks,
    /// which is why it is off by default.
    /// </param>
    protected TargetGoal(Mob mob, bool mustSee, bool mustReach = false) {
        Mob = mob;
        MustSee = mustSee;
        _mustReach = mustReach;
    }

    public override bool CanContinueToUse() {
        // The mob's target wins, and TargetMob is only consulted when something else cleared it. That
        // ordering is what lets one target goal hand over to another without the fight resetting.
        LivingEntity? target = Mob.Target ?? TargetMob;

        if (target == null) {
            return false;
        }

        if (!Mob.CanAttack(target)) {
            return false;
        }

        // Vanilla also gives up when the two are on the same scoreboard team. There are no teams here.

        double within = FollowDistance;
        if (SquaredDistanceTo(target) > within * within) {
            return false;
        }

        if (MustSee) {
            if (Mob.Sensing.HasLineOfSight(target)) {
                _unseenTicks = 0;
            }
            else if (++_unseenTicks > ReducedTickDelay(UnseenMemoryTicks)) {
                return false;
            }
        }

        // Re-set every tick rather than only on start, which is what makes the target survive
        // something else clearing it while this goal is still running.
        Mob.Target = target;
        return true;
    }

    /// <summary>
    /// How far the mob cares about, the <c>minecraft:follow_range</c> attribute. It is not a constant:
    /// this is the attribute a game raises to make a mob notice from further away.
    /// </summary>
    protected virtual double FollowDistance => Mob.GetAttributeValue(Attribute.FollowRange);

    public override void Start() {
        _reachCache = EmptyReachCache;
        _reachCacheTime = 0;
        _unseenTicks = 0;
    }

    public override void Stop() {
        Mob.Target = null;
        TargetMob = null;
    }

    /// <summary>
    /// Whether a candidate passes, <c>TargetGoal.canAttack</c>. A subclass calls this rather than
    /// testing the conditions itself, because the reachability cache lives here.
    /// </summary>
    protected bool CanAttack(LivingEntity? target, TargetingConditions conditions) {
        if (target == null) {
            return false;
        }

        if (!conditions.Test(Mob, target)) {
            return false;
        }

        // Vanilla also requires the target to be inside the mob's home radius. Nothing sets a home
        // here, and the check is unconditionally true without one.

        if (!_mustReach) {
            return true;
        }

        if (--_reachCacheTime <= 0) {
            _reachCache = EmptyReachCache;
        }

        if (_reachCache == EmptyReachCache) {
            _reachCache = CanReach(target) ? CanReachCache : CantReachCache;
        }

        return _reachCache != CantReachCache;
    }

    /// <summary>
    /// Whether a route gets close enough to count, <c>TargetGoal.canReach</c>. Asks the navigation
    /// for a path and measures where its <b>last node</b> landed: within 1.5 blocks horizontally
    /// (2.25 squared) of the target is a reach, anything further is the pathfinder having given up
    /// short.
    /// <p/>
    /// Note that it is the end node rather than <c>Path.CanReach</c>. The search returns its best
    /// effort either way, so a path exists towards a target across a chasm; what says the mob cannot
    /// get there is that the best effort stopped at the edge.
    /// <p/>
    /// Only the horizontal distance counts, so a target directly overhead reads as reachable.
    /// </summary>
    private bool CanReach(LivingEntity target) {
        _reachCacheTime = ReducedTickDelay(10 + Mob.Random.NextInt(5));

        Pathfinding.Path? path = Mob.Navigation.CreatePath(target, 0);
        if (path?.EndNode is not { } last) {
            return false;
        }

        Vec3<int> targetPos = target.Position.ToBlockPos();
        int dx = last.X - targetPos.X;
        int dz = last.Z - targetPos.Z;
        return dx * dx + dz * dz <= 2.25;
    }

    public TargetGoal WithUnseenMemoryTicks(int unseenMemoryTicks) {
        UnseenMemoryTicks = unseenMemoryTicks;
        return this;
    }

    private double SquaredDistanceTo(LivingEntity target) {
        double dx = target.Position.X - Mob.Position.X;
        double dy = target.Position.Y - Mob.Position.Y;
        double dz = target.Position.Z - Mob.Position.Z;
        return dx * dx + dy * dy + dz * dz;
    }
}
