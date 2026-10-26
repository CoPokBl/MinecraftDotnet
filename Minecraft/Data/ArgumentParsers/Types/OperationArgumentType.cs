using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record OperationArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:operation";
}
