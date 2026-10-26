using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ItemSlotsArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:item_slots";
}
