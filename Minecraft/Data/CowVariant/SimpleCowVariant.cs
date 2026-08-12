using Minecraft.Schemas;

namespace Minecraft.Data.CowVariant;

public record SimpleCowVariant(
    Identifier Identifier,
    CowVariantModel Model,
    Identifier AssetId,
    Identifier BabyAssetId) : ICowVariant;
