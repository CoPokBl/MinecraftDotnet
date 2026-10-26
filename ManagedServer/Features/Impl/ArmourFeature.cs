using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Armour points soak damage, <c>LivingEntity.getDamageAfterArmorAbsorb</c> and the
/// <c>CombatRules.getDamageAfterAbsorb</c> it calls. Registered as the
/// <see cref="DamageStage.Armour"/> link of the damage pipeline, so it applies to everything that
/// hurts rather than to combat alone, which is what vanilla armour does.
/// <p/>
/// The points themselves come from the <c>minecraft:armor</c> and <c>minecraft:armor_toughness</c>
/// attributes, which is what <see cref="Basic.AttributeModifiersFeature"/> puts on a player from the
/// armour they are wearing. Without that feature registered nothing sets them and this reduces
/// nothing.
/// <p/>
/// Two parts of vanilla's method are not here. Armour durability (<c>hurtArmor</c>) is what a hit
/// costs the armour rather than what it saves the wearer, and the armour effectiveness enchantments
/// read off the weapon need an enchantment helper we do not have.
/// </summary>
public class ArmourFeature : ScopedFeature, IDamageModifier {
    /// <summary>Vanilla's <c>CombatRules</c> constants.</summary>
    private const float MaxArmour = 20f;
    private const float ArmourProtectionDivider = 25f;
    private const float BaseArmourToughness = 2f;
    private const float MinArmourRatio = 0.2f;

    public DamageStage Stage => DamageStage.Armour;

    public override void Register() {
        AddDamageModifier(this);
    }

    public float Modify(LivingEntity entity, DamageSource source, float amount) {
        if (source.IsIn(entity.Server.Registry, DamageTypeTags.BypassesArmor)) {
            return amount;
        }

        // getArmorValue floors to a whole point, toughness is used as it comes.
        float armour = (float)Math.Floor(entity.GetAttributeValue(Attribute.Armor));
        float toughness = (float)entity.GetAttributeValue(Attribute.ArmorToughness);
        return DamageAfterAbsorb(amount, armour, toughness);
    }

    /// <summary>
    /// <c>CombatRules.getDamageAfterAbsorb</c>. Note the incoming damage is part of working out what
    /// the armour is worth, which is why armour has to run before anything else reduces a hit and why
    /// a big hit gets through proportionally more of it.
    /// </summary>
    public static float DamageAfterAbsorb(float amount, float armour, float toughness) {
        float divider = BaseArmourToughness + toughness / 4f;
        float effective = Clamp(armour - amount / divider, armour * MinArmourRatio, MaxArmour);
        return amount * (1f - effective / ArmourProtectionDivider);
    }

    /// <summary>
    /// <c>Mth.clamp</c>, which lets the minimum win over the maximum rather than throwing the way
    /// <see cref="Math.Clamp(float,float,float)"/> does.
    /// </summary>
    private static float Clamp(float value, float min, float max) {
        return value < min ? min : Math.Min(value, max);
    }
}
