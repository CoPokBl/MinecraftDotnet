using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record StyleArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:style";
}
