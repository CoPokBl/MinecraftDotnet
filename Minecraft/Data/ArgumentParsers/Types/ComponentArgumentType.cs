using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ComponentArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:component";
}
