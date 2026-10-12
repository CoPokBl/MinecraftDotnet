using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record DimensionArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:dimension";
}
