using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ResourceLocationArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:resource_location";
}
