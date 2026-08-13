namespace ManagedServer.Damage;

/// <summary>
/// The stages of vanilla's reduction chain, in the order <c>LivingEntity.actuallyHurt</c> runs them.
/// <p/>
/// The order is part of the pipeline rather than a priority each modifier picks, because it is the
/// only part of the chain that is not free to move:
/// <list type="bullet">
/// <item><see cref="Armour"/> has to see the raw amount. <c>CombatRules.getDamageAfterAbsorb</c> works
/// the armour factor out as <c>clamp(armor - damage / (2 + toughness / 4), armor * 0.2, 20)</c>, so a
/// reduction that ran before it would change how much a point of armour is worth.</item>
/// <item><see cref="Magic"/> is resistance and protection, both plain multipliers, so modifiers in
/// this stage commute and the order they registered in does not matter.</item>
/// <item><see cref="Absorption"/> subtracts rather than scales, so it has to be last.</item>
/// </list>
/// </summary>
public enum DamageStage {
    /// <summary>Armour points and toughness, <c>LivingEntity.getDamageAfterArmorAbsorb</c>.</summary>
    Armour,

    /// <summary>
    /// Resistance and protection, <c>LivingEntity.getDamageAfterMagicAbsorb</c>. Everything here is a
    /// multiplier, so anything that subtracts belongs in <see cref="Absorption"/> instead.
    /// </summary>
    Magic,

    /// <summary>The absorption hearts a hit eats before health, the tail of <c>actuallyHurt</c>.</summary>
    Absorption
}
