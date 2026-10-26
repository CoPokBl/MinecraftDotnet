using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using Minecraft.Data.EnchantmentEffects;
using Minecraft.Data.EnchantmentEffects.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Impl;

/// <summary>
/// The protection enchantments take damage off, the second half of vanilla's
/// <c>LivingEntity.getDamageAfterMagicAbsorb</c> and the <c>EnchantmentHelper.getDamageProtection</c>
/// it calls. Registered as a <see cref="DamageStage.Magic"/> link of the damage pipeline, beside
/// <see cref="ResistanceFeature"/>; the two are plain multipliers so the order they run in does not
/// matter.
/// <p/>
/// Which enchantments protect against what is not written here. It comes out of the enchantment
/// registry as <see cref="DamageProtectionEnchantmentEffect"/>, so fire protection only counting
/// against fire is the datapack's statement rather than this feature's.
/// </summary>
public class ProtectionFeature : ScopedFeature, IDamageModifier {
    /// <summary>Vanilla caps the total at twenty points, which is a fifth off the top.</summary>
    private const float MaxProtection = 20f;
    private const float ProtectionDivider = 25f;

    /// <summary>
    /// Where a worn item comes from, vanilla's <c>getItemBySlot</c> inside
    /// <c>runIterationOnEquipment</c>. A player's armour lives in their inventory rather than in the
    /// equipment map, which is why this is not simply <see cref="LivingEntity.GetEquipmentItem"/>.
    /// </summary>
    public Func<LivingEntity, EquipmentSlot, ItemStack> Equipment { get; set; } = DefaultEquipment;

    public DamageStage Stage => DamageStage.Magic;

    public override void Register() {
        AddDamageModifier(this);
    }

    public float Modify(LivingEntity entity, DamageSource source, float amount) {
        if (source.IsIn(entity.Server.Registry, DamageTypeTags.BypassesEffects)) {
            return amount;
        }

        float protection = TotalProtection(entity, source);
        if (protection <= 0) {
            return amount;
        }

        // CombatRules.getDamageAfterMagicAbsorb.
        return amount * (1f - Math.Clamp(protection, 0f, MaxProtection) / ProtectionDivider);
    }

    /// <summary>
    /// <c>EnchantmentHelper.getDamageProtection</c>: every enchantment on everything worn, summed,
    /// counting only the slots the enchantment itself says it works in. A protection book in the
    /// off hand is worth nothing because the enchantment's slots are the armour ones.
    /// </summary>
    private float TotalProtection(LivingEntity entity, DamageSource source) {
        MinecraftRegistry registry = entity.Server.Registry;
        float protection = 0;

        foreach (EquipmentSlot slot in Enum.GetValues<EquipmentSlot>()) {
            ItemStack item = Equipment(entity, slot);
            foreach ((IEnchantment enchantment, int level) in item.GetOrDefault(DataComponent.Enchantments, [])) {
                if (!enchantment.Slots.Any(group => group.ContainsSlot(slot))) {
                    continue;
                }

                foreach (IEnchantmentEffect effect in enchantment.Effects) {
                    if (effect is not DamageProtectionEnchantmentEffect damageProtection) {
                        continue;
                    }

                    foreach (DamageProtectionEnchantmentEffect.Entry entry in damageProtection.Entries) {
                        if (Applies(entry, source, registry)) {
                            protection += entry.Amount.Calculate(level);
                        }
                    }
                }
            }
        }

        return protection;
    }

    private static bool Applies(DamageProtectionEnchantmentEffect.Entry entry, DamageSource source,
        MinecraftRegistry registry) {
        foreach (DamageProtectionEnchantmentEffect.Requirement requirement in entry.Requirements) {
            if (source.IsIn(registry, requirement.Tag) != requirement.Expected) {
                return false;
            }
        }

        return true;
    }

    private static ItemStack DefaultEquipment(LivingEntity entity, EquipmentSlot slot) {
        if (entity is not Player player) {
            return entity.GetEquipmentItem(slot);
        }

        return slot switch {
            EquipmentSlot.MainHand => player.HeldItem,
            EquipmentSlot.OffHand => player.Inventory.Offhand,
            EquipmentSlot.Helmet => player.Inventory.Helmet,
            EquipmentSlot.Chestplate => player.Inventory.Chestplate,
            EquipmentSlot.Leggings => player.Inventory.Leggings,
            EquipmentSlot.Boots => player.Inventory.Boots,
            _ => ItemStack.Air
        };
    }
}
