using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;

namespace ManagedServer.Features.Impl;

/// <summary>
/// The Resistance effect takes a fifth of a hit per level, the first half of vanilla's
/// <c>LivingEntity.getDamageAfterMagicAbsorb</c>. Registered as a <see cref="DamageStage.Magic"/>
/// link of the damage pipeline.
/// <p/>
/// Nothing here grants the effect. <see cref="Basic.EffectsFeature"/> holds and expires effects; what
/// puts one on an entity is a potion, a beacon or server code calling
/// <c>entity.Effects.Add</c>.
/// </summary>
public class ResistanceFeature : ScopedFeature, IDamageModifier {
    public DamageStage Stage => DamageStage.Magic;

    public override void Register() {
        AddDamageModifier(this);
    }

    public float Modify(LivingEntity entity, DamageSource source, float amount) {
        if (source.IsIn(entity.Server.Registry, DamageTypeTags.BypassesEffects)
            || source.IsIn(entity.Server.Registry, DamageTypeTags.BypassesResistance)) {
            return amount;
        }

        if (entity.Effects.AmplifierOf(PotionEffectType.Resistance) is not { } amplifier) {
            return amount;
        }

        // Amplifiers are zero based, so Resistance I is a fifth off and Resistance V leaves nothing.
        // Vanilla multiplies before dividing, and the twenty five is a float while the factor is an
        // int, so the arithmetic is written the same way round here.
        int factor = 25 - (amplifier + 1) * 5;
        return Math.Max(amount * factor / 25.0f, 0);
    }
}
