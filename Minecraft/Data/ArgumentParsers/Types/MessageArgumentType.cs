using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record MessageArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:message";

    protected override bool Greedy => true;
}
