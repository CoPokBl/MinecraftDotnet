using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record DialogArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:dialog";
}
