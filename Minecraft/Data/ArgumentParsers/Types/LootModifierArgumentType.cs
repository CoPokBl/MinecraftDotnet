using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record LootModifierArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:loot_modifier";
}
