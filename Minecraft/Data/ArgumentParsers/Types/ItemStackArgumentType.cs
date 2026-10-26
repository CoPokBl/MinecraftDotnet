using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ItemStackArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:item_stack";
}
