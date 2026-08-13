using ManagedServer.Entities.Types;

namespace ManagedServer.Ai.Goals.Impl;

/// <summary>
/// A melee attack with the arms out, vanilla's <c>ZombieAttackGoal</c>. The only thing it adds is the
/// aggressive flag being driven off the attack cooldown rather than held for the whole chase, which is
/// what makes a zombie's arms drop between swings.
/// </summary>
public class ZombieAttackGoal(Mob mob, double speedModifier, bool followingTargetEvenIfNotSeen)
    : MeleeAttackGoal(mob, speedModifier, followingTargetEvenIfNotSeen) {
    private int _raiseArmTicks;

    public override void Start() {
        base.Start();
        _raiseArmTicks = 0;
    }

    public override void Stop() {
        base.Stop();
        Mob.Aggressive = false;
    }

    public override void Tick() {
        base.Tick();
        _raiseArmTicks++;

        // Five ticks of chasing, then the arms go up for the second half of every cooldown: the swing
        // is the arms coming back down.
        Mob.Aggressive = _raiseArmTicks >= 5 && TicksUntilNextAttack < AttackInterval / 2;
    }

    /// <summary><c>MeleeAttackGoal.getAttackInterval</c>, which is the twenty tick cooldown adjusted.</summary>
    private int AttackInterval => AdjustedTickDelay(20);
}
