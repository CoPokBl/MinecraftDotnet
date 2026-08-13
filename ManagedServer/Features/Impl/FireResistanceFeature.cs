using ManagedServer.Damage;
using ManagedServer.Events;
using Minecraft.Data.Generated;

namespace ManagedServer.Features.Impl;

/// <summary>
/// The Fire Resistance effect stops burning damage outright, the early return near the top of
/// vanilla's <c>LivingEntity.hurtServer</c>.
/// <p/>
/// Not a pipeline modifier, because it is not a reduction: vanilla throws the hit away before any of
/// the reductions run, and a hit dropped on <see cref="EntityDamageEvent"/> leaves no invulnerable
/// window behind, which is the same thing the early return does.
/// <p/>
/// It covers everything in <c>minecraft:is_fire</c>, so standing in lava, burning afterwards, a
/// campfire and a blaze's fireball are all one rule rather than a check inside each of them.
/// </summary>
public class FireResistanceFeature : ScopedFeature {
    public override void Register() {
        AddEventHandler<EntityDamageEvent>(e => {
            if (e.LivingEntity.Effects.Has(PotionEffectType.FireResistance)
                && e.Source.IsIn(e.World.Server.Registry, DamageTypeTags.IsFire)) {
                e.Cancelled = true;
            }
        });
    }
}
