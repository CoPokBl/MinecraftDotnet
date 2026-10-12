using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ParticleArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:particle";
}
