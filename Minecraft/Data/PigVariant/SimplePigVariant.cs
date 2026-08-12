using Minecraft.Schemas;

namespace Minecraft.Data.PigVariant;

public record SimplePigVariant(
    Identifier Identifier,
    PigVariantModel Model,
    Identifier AssetId,
    Identifier BabyAssetId) : IPigVariant;
