using Minecraft.Schemas;

namespace Minecraft.Data.CatVariant;

public record SimpleCatVariant(
    Identifier Identifier,
    Identifier AssetId,
    Identifier BabyAssetId) : ICatVariant;
