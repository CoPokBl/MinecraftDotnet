using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record NbtPathArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:nbt_path";
}
