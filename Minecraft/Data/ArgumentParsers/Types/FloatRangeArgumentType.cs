using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record FloatRangeArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:float_range";
}
