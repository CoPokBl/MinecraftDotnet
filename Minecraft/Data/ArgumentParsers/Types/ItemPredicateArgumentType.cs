using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ItemPredicateArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:item_predicate";
}
