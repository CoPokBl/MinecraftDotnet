using ManagedServer.Ai.Targeting;
using ManagedServer.Entities.Types;
using ManagedServer.Physics;

namespace ManagedServer.Ai.Goals.Target;

/// <summary>
/// Fight back, vanilla's <c>HurtByTargetGoal</c>. It is what makes a cow run and a zombie turn round,
/// and it is the only goal that reads <see cref="LivingEntity.LastHurtByMob"/>.
/// <p/>
/// The trigger is a <b>changed timestamp</b>, not an age: the goal keeps its own copy of
/// <see cref="LivingEntity.LastHurtByMobTimestamp"/> and fires only when the two differ. That is what
/// stops it re-firing every tick for as long as the attacker is remembered, and it is why nothing
/// upstream needs to decay the reference.
/// </summary>
public class HurtByTargetGoal : TargetGoal {
    /// <summary>
    /// Revenge does not need line of sight and does not care about invisibility: something you cannot
    /// see just hit you. Vanilla's <c>HURT_BY_TARGETING</c>.
    /// </summary>
    private static readonly TargetingConditions HurtByTargeting =
        TargetingConditions.ForCombat().IgnoreLineOfSight().IgnoreInvisibilityTesting();

    /// <summary>How far up and down the shout for help carries, <c>ALERT_RANGE_Y</c>.</summary>
    private const double AlertRangeY = 10.0;

    private readonly Func<LivingEntity, bool>[] _toIgnoreDamage;
    private Func<LivingEntity, bool>[]? _toIgnoreAlert;
    private bool _alertSameType;
    private int _timestamp;

    /// <param name="ignoreDamageFrom">
    /// Attackers to shrug off. Vanilla names Java classes here (a piglin ignores other piglins); with
    /// no per mob classes these are predicates, and <see cref="OfType"/> builds the common one.
    /// </param>
    public HurtByTargetGoal(Mob mob, params Func<LivingEntity, bool>[] ignoreDamageFrom)
        : base(mob, true) {
        _toIgnoreDamage = ignoreDamageFrom;
        SetFlags(GoalFlag.Target);
    }

    /// <summary>
    /// Matches anything of one entity type, which is the nearest thing to vanilla's class arguments.
    /// It is narrower than the Java version for a hierarchy (<c>Raider.class</c> covers six types),
    /// so a goal wanting a family passes several of these combined.
    /// </summary>
    public static Func<LivingEntity, bool> OfType(Minecraft.Data.Entities.IEntityType type) {
        return candidate => candidate.Type.Identifier.Equals(type.Identifier);
    }

    public override bool CanUse() {
        int timestamp = Mob.LastHurtByMobTimestamp;
        LivingEntity? attacker = Mob.LastHurtByMob;

        if (timestamp == _timestamp || attacker == null) {
            return false;
        }

        // Vanilla also refuses when the attacker is a player and the universalAnger game rule is on.
        // There is no server side game rule state here, so the rule reads as its default of off.

        foreach (Func<LivingEntity, bool> ignore in _toIgnoreDamage) {
            if (ignore(attacker)) {
                return false;
            }
        }

        return CanAttack(attacker, HurtByTargeting);
    }

    /// <summary>
    /// Makes the mob shout for help, vanilla's <c>setAlertOthers</c>. The exceptions are the kinds of
    /// neighbour that do not join in.
    /// </summary>
    public HurtByTargetGoal SetAlertOthers(params Func<LivingEntity, bool>[] exceptTheseTypes) {
        _alertSameType = true;
        _toIgnoreAlert = exceptTheseTypes;
        return this;
    }

    public override void Start() {
        Mob.Target = Mob.LastHurtByMob;
        TargetMob = Mob.Target;
        _timestamp = Mob.LastHurtByMobTimestamp;

        // Five times the default. A mob that was hurt hunts far longer out of sight than one that
        // merely spotted something.
        UnseenMemoryTicks = 300;

        if (_alertSameType) {
            AlertOthers();
        }

        base.Start();
    }

    /// <summary>
    /// <c>HurtByTargetGoal.alertOthers</c>. Vanilla gathers by the mob's own Java class, so a zombie
    /// alerts zombies and not skeletons; the equivalent here is the same entity type, which is
    /// narrower for the handful of vanilla classes that cover several types.
    /// </summary>
    protected virtual void AlertOthers() {
        if (Mob.Manager == null || Mob.LastHurtByMob is not { } attacker) {
            return;
        }

        double within = FollowDistance;

        // Vanilla searches from a unit cube on the mob's position rather than from its bounding box,
        // so the range is the same for a tall mob as a short one.
        Box search = new Box(
                Mob.Position.X, Mob.Position.Y, Mob.Position.Z,
                Mob.Position.X + 1.0, Mob.Position.Y + 1.0, Mob.Position.Z + 1.0)
            .Inflate(within, AlertRangeY, within);

        foreach (Entity entity in Mob.Manager.GetEntitiesInBox(search)) {
            if (entity is not Mob other || ReferenceEquals(other, Mob)) {
                continue;
            }

            if (!other.Type.Identifier.Equals(Mob.Type.Identifier)) {
                continue;
            }

            // Something already fighting is left to it, which is what stops a chain of alerts pulling
            // a whole herd off whatever each of them was doing.
            if (other.Target != null) {
                continue;
            }

            if (IsIgnoredForAlert(other)) {
                continue;
            }

            AlertOther(other, attacker);
        }
    }

    private bool IsIgnoredForAlert(Mob other) {
        if (_toIgnoreAlert == null) {
            return false;
        }

        foreach (Func<LivingEntity, bool> ignore in _toIgnoreAlert) {
            if (ignore(other)) {
                return true;
            }
        }

        return false;
    }

    protected virtual void AlertOther(Mob other, LivingEntity hurtBy) {
        other.Target = hurtBy;
    }
}
