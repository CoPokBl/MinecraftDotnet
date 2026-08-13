using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Ai.Targeting;

/// <summary>
/// What makes something a valid target, vanilla's <c>TargetingConditions</c>. It is a builder of the
/// immutable kind: every <c>With</c> returns a new one, so a goal can keep a shared static instance
/// and narrow it per call without anyone else seeing the change.
/// <p/>
/// Two vanilla checks have nothing to test here and are left out rather than faked: peaceful
/// difficulty (there is no difficulty setting) and team alliance (there are no teams). Invisibility is
/// modelled as a plain on or off rather than vanilla's <c>getVisibilityPercent</c>, which also weighs
/// armour and sneaking; that is noted at the check.
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
            // Vanilla scales the range by getVisibilityPercent, which weighs invisibility against worn
            // armour and whether the target is sneaking. Only the effect is modelled here, as a flat
            // half: the armour term needs equipment weights nothing else reads, and being wrong makes
            // an invisible target noticed from the wrong distance rather than noticed at all.
            double visibility = TestInvisible && IsInvisible(target) ? 0.5 : 1.0;
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
