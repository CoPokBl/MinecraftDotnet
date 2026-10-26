using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record NbtTagArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:nbt_tag";
}
