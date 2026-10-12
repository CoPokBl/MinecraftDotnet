using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ItemSlotArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:item_slot";
}
