using Minecraft.Schemas;

namespace Minecraft.Data.WolfVariant;

public record SimpleWolfVariant(
    Identifier Identifier,
    WolfAssetInfo Assets,
    WolfAssetInfo BabyAssets) : IWolfVariant;
