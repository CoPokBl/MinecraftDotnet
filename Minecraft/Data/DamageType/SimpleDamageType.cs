using Minecraft.Schemas;

namespace Minecraft.Data.DamageType;

public record SimpleDamageType(
    Identifier Identifier,
    float Exhaustion,
    string MessageId,
    DamageScaling Scaling,
    DamageEffectType Effects,
    DeathMessageType DeathMessageType) : IDamageType;
