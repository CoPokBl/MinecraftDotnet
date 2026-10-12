using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record EntityAnchorArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:entity_anchor";
}
