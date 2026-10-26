using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record TemplateMirrorArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:template_mirror";
}
