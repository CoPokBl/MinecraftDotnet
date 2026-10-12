using ManagedServer.Ai.Targeting;
using ManagedServer.Entities.Types;
using Minecraft.Physics;

namespace ManagedServer.Ai.Goals.Target;

/// <summary>
/// Pick a fight with the nearest thing that qualifies, vanilla's <c>NearestAttackableTargetGoal</c>.
/// This is how a zombie finds a player.
/// <p/>
/// Vanilla says what to look for with a Java class (<c>NearestAttackableTargetGoal&lt;Player&gt;</c>).
/// There are four entity classes here, so it takes a predicate instead, the way
/// <see cref="Impl.LookAtPlayerGoal"/> does; <see cref="OnlyPlayers"/> is the common case.
/// </summary>
public class NearestAttackableTargetGoal : TargetGoal {
    private const int DefaultRandomInterval = 10;

    /// <summary>What vanilla's <c>Player.class</c> argument means here.</summary>
    public static readonly Func<LivingEntity, bool> OnlyPlayers = candidate => candidate is Player;

    private readonly Func<LivingEntity, bool> _matches;
    private readonly int _randomInterval;
    private readonly TargetingConditions _targetConditions;

    protected LivingEntity? Candidate;

    /// <param name="randomInterval">
    /// One in this many selection ticks the goal even looks, so a crowd of mobs does not all scan on
    /// the same tick. Already halved for the selector's cadence, as vanilla does in the constructor.
    /// </param>
    /// <param name="selector">An extra condition on the candidate, vanilla's <c>Selector</c>.</param>
    public NearestAttackableTargetGoal(Mob mob, Func<LivingEntity, bool>? matches = null,
        bool mustSee = true, bool mustReach = false, int randomInterval = DefaultRandomInterval,
        Func<LivingEntity, bool>? selector = null)
        : base(mob, mustSee, mustReach) {
        _matches = matches ?? OnlyPlayers;
        _randomInterval = ReducedTickDelay(randomInterval);
        SetFlags(GoalFlag.Target);
        _targetConditions = TargetingConditions.ForCombat().WithRange(FollowDistance).Selecting(selector);
    }

    public override bool CanUse() {
        if (_randomInterval > 0 && Mob.Random.NextInt(_randomInterval) != 0) {
            return false;
        }

        FindTarget();
        return Candidate != null;
    }

    /// <summary>
    /// The box searched, <c>getTargetSearchArea</c>. Vanilla inflates by the follow range on all three
    /// axes, so unlike the look goal's squat box this one is a cube and a mob does notice something
    /// directly above it.
    /// </summary>
    protected virtual Box TargetSearchArea(double followDistance) {
        return new Box(Mob.BoundingBox).Translate(Mob.Position).Inflate(followDistance);
    }

    protected virtual void FindTarget() {
        if (Mob.Manager == null) {
            Candidate = null;
            return;
        }

        double followDistance = FollowDistance;

        // The range is re-applied per call because the follow range is an attribute and a modifier may
        // have changed it since the constructor ran, which is exactly what vanilla's getTargetConditions
        // does.
        TargetingConditions conditions = _targetConditions.WithRange(followDistance);

        LivingEntity? best = null;
        double bestSqr = double.MaxValue;

        foreach (Entity entity in Mob.Manager.GetEntitiesInBox(TargetSearchArea(followDistance))) {
            if (entity is not LivingEntity candidate || !_matches(candidate)) {
                continue;
            }

            if (!CanAttack(candidate, conditions)) {
                continue;
            }

            // Measured from the mob's eye, which is where vanilla's getNearestEntity is given its
            // position, so a tall mob picks between two candidates slightly differently than its feet
            // would.
            double distanceSqr = SquaredDistanceToEye(candidate);
            if (distanceSqr >= bestSqr) {
                continue;
            }

            bestSqr = distanceSqr;
            best = candidate;
        }

        Candidate = best;
    }

    public override void Start() {
        Mob.Target = Candidate;
        base.Start();
    }

    public void SetTarget(LivingEntity? target) {
        Candidate = target;
    }

    private double SquaredDistanceToEye(LivingEntity target) {
        double dx = target.Position.X - Mob.Position.X;
        double dy = target.Position.Y - (Mob.Position.Y + Mob.Type.EyeHeight);
        double dz = target.Position.Z - Mob.Position.Z;
        return dx * dx + dy * dy + dz * dz;
    }
}
