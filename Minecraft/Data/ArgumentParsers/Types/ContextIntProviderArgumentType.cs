using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ContextIntProviderArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:context_int_provider";
}
