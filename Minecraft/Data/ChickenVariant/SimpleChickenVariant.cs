using Minecraft.Schemas;

namespace Minecraft.Data.ChickenVariant;

public record SimpleChickenVariant(
    Identifier Identifier,
    ChickenVariantModel Model,
    Identifier AssetId,
    Identifier BabyAssetId) : IChickenVariant;
