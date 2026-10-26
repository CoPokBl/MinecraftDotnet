using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record BlockPredicateArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:block_predicate";
}
