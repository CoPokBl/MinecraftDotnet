using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ResourceOrTagArgumentType(Identifier Registry) : RegistryTokenArgumentType(Registry) {
    public ResourceOrTagArgumentType() : this("minecraft:item") { }

    public override Identifier Identifier => "minecraft:resource_or_tag";
}
