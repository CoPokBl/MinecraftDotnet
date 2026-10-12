using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record GameProfileArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:game_profile";
}
