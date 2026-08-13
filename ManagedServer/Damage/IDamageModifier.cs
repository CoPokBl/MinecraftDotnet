using ManagedServer.Entities.Types;

namespace ManagedServer.Damage;

/// <summary>
/// One link in the reduction chain a hit runs through, registered on the
/// <see cref="DamagePipeline"/> by whatever feature owns it. Armour, resistance, protection and
/// absorption are each one of these, which is what lets a server drop any of them by not
/// registering its feature.
/// </summary>
public interface IDamageModifier {
    /// <summary>Which part of vanilla's chain this belongs to. See <see cref="DamageStage"/>.</summary>
    DamageStage Stage { get; }

    /// <summary>
    /// The damage left after this link. Returning <paramref name="amount"/> unchanged is how a
    /// modifier opts out of a hit it does not apply to, such as one whose damage type bypasses it.
    /// </summary>
    float Modify(LivingEntity entity, DamageSource source, float amount);
}

/// <summary>A modifier written as a lambda, for when a whole class is more than the job needs.</summary>
public record DamageModifier(DamageStage Stage, Func<LivingEntity, DamageSource, float, float> Reduction)
    : IDamageModifier {
    public float Modify(LivingEntity entity, DamageSource source, float amount) {
        return Reduction(entity, source, amount);
    }
}
