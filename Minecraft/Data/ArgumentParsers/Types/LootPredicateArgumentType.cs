using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record LootPredicateArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:loot_predicate";
}
