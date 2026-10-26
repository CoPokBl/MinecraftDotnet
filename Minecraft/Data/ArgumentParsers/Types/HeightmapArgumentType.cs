using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record HeightmapArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:heightmap";
}
