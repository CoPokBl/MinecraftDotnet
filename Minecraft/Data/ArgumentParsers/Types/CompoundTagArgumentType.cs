using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record CompoundTagArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:nbt_compound_tag";
}
