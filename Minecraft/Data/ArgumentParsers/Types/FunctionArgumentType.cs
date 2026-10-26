using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record FunctionArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:function";
}
