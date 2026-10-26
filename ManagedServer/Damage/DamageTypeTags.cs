using Minecraft.Schemas;

namespace ManagedServer.Damage;

/// <summary>
/// The <c>minecraft:damage_type</c> tags the damage pipeline and the features built on it ask about,
/// vanilla's <c>DamageTypeTags</c>. They are read through <see cref="DamageSource.IsIn"/>, which
/// resolves them against the server's registry, so a tag that does not exist reads as empty rather
/// than throwing.
/// </summary>
public static class DamageTypeTags {
    /// <summary>Skips the ten tick invulnerable window, so every hit lands.</summary>
    public static readonly Identifier BypassesCooldown = "minecraft:bypasses_cooldown";

    /// <summary>Ignores armour points and toughness entirely, e.g. starving and the void.</summary>
    public static readonly Identifier BypassesArmor = "minecraft:bypasses_armor";

    /// <summary>Ignores resistance and protection both.</summary>
    public static readonly Identifier BypassesEffects = "minecraft:bypasses_effects";

    /// <summary>Ignores resistance but not protection.</summary>
    public static readonly Identifier BypassesResistance = "minecraft:bypasses_resistance";

    /// <summary>Ignores protection enchantments but not resistance.</summary>
    public static readonly Identifier BypassesEnchantments = "minecraft:bypasses_enchantments";

    /// <summary>Burning damage, which fire resistance stops outright.</summary>
    public static readonly Identifier IsFire = "minecraft:is_fire";

    /// <summary>Fall damage, which is what the fall distance is spent on.</summary>
    public static readonly Identifier IsFall = "minecraft:is_fall";

    /// <summary>
    /// Damage that does not make the victim remember who dealt it, so nothing retaliates for it.
    /// Vanilla has exactly <c>minecraft:mob_attack_no_aggro</c> in here.
    /// </summary>
    public static readonly Identifier NoAnger = "minecraft:no_anger";

    /// <summary>Damage that knocks nothing back, which is most environmental damage.</summary>
    public static readonly Identifier NoKnockback = "minecraft:no_knockback";

    /// <summary>
    /// Damage from something that was thrown or shot. Blocking one does not push the attacker's
    /// weapon back, since there was no swing to interrupt.
    /// </summary>
    public static readonly Identifier IsProjectile = "minecraft:is_projectile";
}
