using ManagedServer.Ai.Targeting;
using ManagedServer.Entities.Types;
using Minecraft.Physics;

namespace ManagedServer.Ai.Goals.Impl;

/// <summary>
/// Watch something go by, vanilla's <c>LookAtPlayerGoal</c>. It claims only <see cref="GoalFlag.Look"/>,
/// so a mob keeps strolling while it stares.
/// <p/>
/// Vanilla picks what to watch by Java class. There are no per mob classes here, so it takes a
/// predicate over the candidate instead; <see cref="OnlyPlayers"/> is the common case and the default.
/// </summary>
public class LookAtPlayerGoal : Goal {
    protected readonly Mob Mob;
    protected readonly float LookDistance;
    private readonly float _probability;
    private readonly bool _onlyHorizontal;
    private readonly Func<LivingEntity, bool> _matches;
    private readonly TargetingConditions _conditions;

    protected Entity? LookAt;
    private int _lookTime;

    /// <summary>What vanilla's <c>Player.class</c> argument means here.</summary>
    public static readonly Func<LivingEntity, bool> OnlyPlayers = candidate => candidate is Player;

    /// <param name="probability">
    /// The chance per selection tick of even considering it. Vanilla's default is 0.02, so a mob looks
    /// up rarely rather than tracking everything that moves.
    /// </param>
    /// <param name="onlyHorizontal">Whether the mob keeps its head level rather than tilting up or down.</param>
    public LookAtPlayerGoal(Mob mob, float lookDistance, float probability = 0.02f,
        bool onlyHorizontal = false, Func<LivingEntity, bool>? matches = null) {
        Mob = mob;
        LookDistance = lookDistance;
        _probability = probability;
        _onlyHorizontal = onlyHorizontal;
        _matches = matches ?? OnlyPlayers;

        // forNonCombat: a mob will watch something it could never fight.
        _conditions = TargetingConditions.ForNonCombat().WithRange(lookDistance);

        SetFlags(GoalFlag.Look);
    }

    public override bool CanUse() {
        if (Mob.Random.NextFloat() >= _probability) {
            return false;
        }

        // Whatever the mob is fighting wins outright, without a distance check: it is already looking
        // at it for other reasons and this keeps the head there.
        if (Mob.Target != null) {
            LookAt = Mob.Target;
        }
        else {
            LookAt = NearestMatch();
        }

        return LookAt != null;
    }

    private LivingEntity? NearestMatch() {
        if (Mob.Manager == null) {
            return null;
        }

        // Vanilla inflates the mob's own box by the look distance horizontally and three vertically,
        // which is a squat box rather than a sphere: a mob does not notice something far above it.
        Box search = new Box(Mob.BoundingBox).Translate(Mob.Position)
            .Inflate(LookDistance, 3.0, LookDistance);

        LivingEntity? best = null;
        double bestSqr = double.MaxValue;

        foreach (Entity candidate in Mob.Manager.GetEntitiesInBox(search)) {
            if (candidate is not LivingEntity living || !_matches(living) || !_conditions.Test(Mob, living)) {
                continue;
            }

            double distanceSqr = SquaredDistanceToEye(living);
            if (distanceSqr >= bestSqr) {
                continue;
            }

            bestSqr = distanceSqr;
            best = living;
        }

        return best;
    }

    public override bool CanContinueToUse() {
        if (LookAt is not LivingEntity { IsAlive: true }) {
            return false;
        }

        if (SquaredDistanceToEye(LookAt) > LookDistance * LookDistance) {
            return false;
        }

        return _lookTime > 0;
    }

    public override void Start() {
        _lookTime = AdjustedTickDelay(40 + Mob.Random.NextInt(40));
    }

    public override void Stop() {
        LookAt = null;
    }

    public override void Tick() {
        if (LookAt is not LivingEntity { IsAlive: true } target) {
            return;
        }

        // Horizontal-only watchers look at their own eye height rather than the target's, which is
        // what stops a tall mob craning down at a player's face.
        double y = _onlyHorizontal
            ? Mob.Position.Y + Mob.Type.EyeHeight
            : target.Position.Y + target.Type.EyeHeight;

        Mob.LookControl.SetLookAt(target.Position.X, y, target.Position.Z);
        _lookTime--;
    }

    /// <summary>
    /// Vanilla measures from the mob's eye height rather than its feet when picking the nearest, since
    /// <c>getNearestEntity</c> is given an eye position.
    /// </summary>
    private double SquaredDistanceToEye(Entity target) {
        double dx = target.Position.X - Mob.Position.X;
        double dy = target.Position.Y - (Mob.Position.Y + Mob.Type.EyeHeight);
        double dz = target.Position.Z - Mob.Position.Z;
        return dx * dx + dy * dy + dz * dz;
    }
}
