using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.TrimPattern;

public record SimpleTrimPattern(
    Identifier Identifier,
    Identifier AssetId,
    TextComponent Description,
    bool Decal) : ITrimPattern;
