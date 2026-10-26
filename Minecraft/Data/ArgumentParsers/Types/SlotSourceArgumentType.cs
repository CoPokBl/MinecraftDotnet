using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record SlotSourceArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:slot_source";
}
