using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.PaintingVariant;

public record SimplePaintingVariant(
    Identifier Identifier,
    Identifier AssetId,
    int Width,
    int Height,
    TextComponent? Title,
    TextComponent? Author) : IPaintingVariant;
