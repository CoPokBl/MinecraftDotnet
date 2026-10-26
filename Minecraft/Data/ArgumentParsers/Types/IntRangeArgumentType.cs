using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record IntRangeArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:int_range";
}
