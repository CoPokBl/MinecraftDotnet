using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record TemplateRotationArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:template_rotation";
}
