using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ResourceSelectorArgumentType(Identifier Registry) : RegistryTokenArgumentType(Registry) {
    public ResourceSelectorArgumentType() : this("minecraft:item") { }

    public override Identifier Identifier => "minecraft:resource_selector";
}
