using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Schemas;

namespace Minecraft.Data.Biomes;

public record SimpleBiome(
    Identifier Identifier,
    bool HasPrecipitation,
    float Temperature,
    TemperatureModifier TemperatureModifier,
    float Downfall,
    BiomeSpecialEffects Effects,
    EnvironmentAttributeMap Attributes) : IBiome;
