using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record RotationArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:rotation";
}
