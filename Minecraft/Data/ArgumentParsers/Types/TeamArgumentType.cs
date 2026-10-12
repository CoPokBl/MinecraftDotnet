using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record TeamArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:team";
}
