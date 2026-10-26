using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record FeatureArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:feature";
}
