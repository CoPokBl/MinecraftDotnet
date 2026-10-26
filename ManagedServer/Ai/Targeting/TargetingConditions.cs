using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Entities;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Tags;

namespace ManagedServer.Ai.Targeting;

/// <summary>
/// What makes something a valid target, vanilla's <c>TargetingConditions</c>. It is a builder of the
/// immutable kind: every <c>With</c> returns a new one, so a goal can keep a shared static instance
/// and narrow it per call without anyone else seeing the change.
/// <p/>
/// Two vanilla checks have nothing to test here and are left out rather than faked: peaceful
/// difficulty (there is no difficulty setting) and team alliance (there are no teams).
/// <c>getVisibilityPercent</c> is only partly ported; that is noted where it is.
/// </summary>
public sealed record TargetingConditions {
    /// <summary>
    /// Whether this is a fight. A combat lookup rejects anything that cannot be attacked; the
    /// non combat form (vanilla's <c>forNonCombat</c>) is what "find the nearest player to look at"
    /// uses, and it will happily return something the mob could never hurt.
    /// </summary>
    public bool IsCombat { get; private init; }

    /// <summary>The range, or a non positive number for no limit at all.</summary>
    public double Range { get; private init; } = -1.0;

    public bool CheckLineOfSight { get; private init; } = true;

    public bool TestInvisible { get; private init; } = true;

    public Func<LivingEntity, bool>? Selector { get; private init; }

    public static TargetingConditions ForCombat() {
        return new TargetingConditions {
            IsCombat = true
        };
    }

    public static TargetingConditions ForNonCombat() {
        return new TargetingConditions {
            IsCombat = false
        };
    }

    public TargetingConditions WithRange(double range) {
        return this with {
            Range = range
        };
    }

    public TargetingConditions IgnoreLineOfSight() {
        return this with {
            CheckLineOfSight = false
        };
    }

    public TargetingConditions IgnoreInvisibilityTesting() {
        return this with {
            TestInvisible = false
        };
    }

    public TargetingConditions Selecting(Func<LivingEntity, bool>? selector) {
        return this with {
            Selector = selector
        };
    }

    /// <param name="looker">
    /// Who is looking. Null is vanilla's "is this thing targetable by anything at all" form, which
    /// skips the range and the line of sight because there is nowhere to measure from.
    /// </param>
    public bool Test(LivingEntity? looker, LivingEntity target) {
        if (ReferenceEquals(looker, target)) {
            return false;
        }

        if (!target.IsAlive) {
            return false;
        }

        if (Selector != null && !Selector(target)) {
            return false;
        }

        if (looker == null) {
            // Vanilla also rejects on peaceful difficulty here. There is no difficulty setting, so a
            // server that wants mobs not to fight leaves the target goals off instead.
            return !IsCombat || CanBeSeenAsEnemy(target);
        }

        if (IsCombat && !CanBeSeenAsEnemy(target)) {
            return false;
        }

        if (Range > 0.0) {
            double visibility = TestInvisible ? VisibilityPercent(target, looker) : 1.0;
            double effective = Math.Max(Range * visibility, 2.0);

            if (SquaredDistance(looker, target) > effective * effective) {
                return false;
            }
        }

        if (CheckLineOfSight && looker is Mob mob && !mob.Sensing.HasLineOfSight(target)) {
            return false;
        }

        return true;
    }

    /// <summary><c>LivingEntity.canBeSeenAsEnemy</c>, which <see cref="Player"/> narrows.</summary>
    private static bool CanBeSeenAsEnemy(LivingEntity target) {
        return target.CanBeSeenAsEnemy;
    }

    /// <summary>
    /// <c>LivingEntity.getVisibilityPercent</c>, in part. The worn <c>mob_visibility</c> term and the
    /// clamp are vanilla's. Invisibility is a flat half where vanilla weighs it against how much armour
    /// is worn (<c>0.7 * max(cover, 0.1)</c>), and sneaking's 0.8 is left out: the armour term needs
    /// equipment weights nothing else reads, and being wrong makes an invisible target noticed from the
    /// wrong distance rather than noticed at all.
    /// </summary>
    private static double VisibilityPercent(LivingEntity target, LivingEntity looker) {
        double visibility = IsInvisible(target) ? 0.5 : 1.0;
        MinecraftRegistry registry = target.Server.Registry;

        foreach (EquipmentSlot slot in Enum.GetValues<EquipmentSlot>()) {
            ItemStack item = target.GetEquipmentItem(slot);

            // Only while worn where the item is worn: a head carried in the hand hides nobody.
            if (item.GetOrNull(DataComponent.MobVisibility) is { } mobVisibility
                && item.GetOrNull(DataComponent.Equippable) is { } equippable
                && WornIn(equippable.Slot) == slot
                && Contains(registry, mobVisibility.TargetingEntityTypes, looker.Type)) {

                visibility *= mobVisibility.Visibility;
            }
        }

        return Math.Clamp(visibility, 0.0, 10.0);
    }

    private static EquipmentSlot WornIn(EquippableComponent.Slot slot) {
        return slot switch {
            EquippableComponent.Slot.MainHand => EquipmentSlot.MainHand,
            EquippableComponent.Slot.OffHand => EquipmentSlot.OffHand,
            EquippableComponent.Slot.Feet => EquipmentSlot.Boots,
            EquippableComponent.Slot.Legs => EquipmentSlot.Leggings,
            EquippableComponent.Slot.Chest => EquipmentSlot.Chestplate,
            EquippableComponent.Slot.Head => EquipmentSlot.Helmet,
            EquippableComponent.Slot.Body => EquipmentSlot.Body,
            _ => EquipmentSlot.Saddle
        };
    }

    private static bool Contains(MinecraftRegistry registry, IdSet set, IEntityType type) {
        return set switch {
            IdSet.Tag tag => registry.EntityTypes.Tags.Contains(registry, tag.TagName, type.Identifier),
            IdSet.Ids ids => ids.Values.Contains(registry.EntityTypes.GetProtocolId(type)),
            _ => false
        };
    }

    private static bool IsInvisible(LivingEntity target) {
        return target.Effects.Has(PotionEffectType.Invisibility);
    }

    private static double SquaredDistance(LivingEntity a, LivingEntity b) {
        double dx = a.Position.X - b.Position.X;
        double dy = a.Position.Y - b.Position.Y;
        double dz = a.Position.Z - b.Position.Z;
        return dx * dx + dy * dy + dz * dz;
    }
}
