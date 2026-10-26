using Minecraft.Schemas;

namespace Minecraft.Data.FrogVariant;

public record SimpleFrogVariant(
    Identifier Identifier,
    Identifier AssetId) : IFrogVariant;
