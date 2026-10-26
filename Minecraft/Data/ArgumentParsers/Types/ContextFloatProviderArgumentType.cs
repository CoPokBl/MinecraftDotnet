using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ContextFloatProviderArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:context_float_provider";
}
