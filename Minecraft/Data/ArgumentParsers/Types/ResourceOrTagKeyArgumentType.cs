using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ResourceOrTagKeyArgumentType(Identifier Registry) : RegistryTokenArgumentType(Registry) {
    public ResourceOrTagKeyArgumentType() : this("minecraft:item") { }

    public override Identifier Identifier => "minecraft:resource_or_tag_key";
}
