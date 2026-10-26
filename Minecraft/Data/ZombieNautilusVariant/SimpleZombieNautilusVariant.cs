using Minecraft.Schemas;

namespace Minecraft.Data.ZombieNautilusVariant;

public record SimpleZombieNautilusVariant(
    Identifier Identifier,
    ZombieNautilusVariantModel Model,
    Identifier AssetId) : IZombieNautilusVariant;
