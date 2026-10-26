using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ObjectiveArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:objective";
}
