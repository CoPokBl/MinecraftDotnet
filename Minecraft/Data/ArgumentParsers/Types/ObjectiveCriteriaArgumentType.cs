using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ObjectiveCriteriaArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:objective_criteria";
}
