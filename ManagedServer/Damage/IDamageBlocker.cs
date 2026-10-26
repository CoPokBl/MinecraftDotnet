using ManagedServer.Entities.Types;

namespace ManagedServer.Damage;

/// <summary>
/// Something the entity is holding up that stops part of a hit, vanilla's
/// <c>LivingEntity.applyItemBlocking</c>. <see cref="Features.Impl.ShieldFeature"/> is the one that
/// exists; nothing else in the reduction chain sits here.
/// <p/>
/// Deliberately not an <see cref="IDamageModifier"/>, because blocking is not a reduction:
/// <list type="bullet">
/// <item>it happens <b>before</b> the invulnerable window is judged, so what a shield stops is not
/// counted as what the entity was last hurt for,</item>
/// <item>and a blocked hit replaces the client's damage feedback with the blocking item's own sound,
/// which is why <see cref="LivingEntity.Damage(DamageSource,float)"/> has to know a hit was blocked
/// rather than only what is left of it.</item>
/// </list>
/// </summary>
public interface IDamageBlocker {
    /// <summary>
    /// How much of <paramref name="amount"/> the entity's blocking item stops. Zero when it is not
    /// blocking, when the item does not cover this damage type, or when the hit came from behind.
    /// <p/>
    /// Called before the invulnerable window and before <see cref="Events.EntityDamageEvent"/>, so a
    /// hit that either of those throws away has still been blocked, exactly as vanilla's is.
    /// </summary>
    float Block(LivingEntity entity, DamageSource source, float amount);

    /// <summary>
    /// That a hit this blocker stopped some of was a fresh one rather than a top up inside the
    /// invulnerable window, vanilla's <c>BlocksAttacks.onBlocked</c> and the <c>tookFullDamage</c> it
    /// sits behind. Only what the block looks and sounds like belongs here; whether a hit was blocked
    /// is settled in <see cref="Block"/>, before any of that is known.
    /// </summary>
    void OnBlocked(LivingEntity entity, DamageSource source) { }
}
