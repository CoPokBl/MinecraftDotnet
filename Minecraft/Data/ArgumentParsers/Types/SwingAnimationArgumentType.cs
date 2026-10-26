using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record SwingAnimationArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:swing_animation";
}
