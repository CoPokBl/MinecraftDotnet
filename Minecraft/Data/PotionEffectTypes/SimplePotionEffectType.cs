using Minecraft.Schemas;

namespace Minecraft.Data.PotionEffectTypes;

public record SimplePotionEffectType(Identifier Identifier, int ProtocolId) : IPotionEffectType;
