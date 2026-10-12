using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record LootTableArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:loot_table";
}
