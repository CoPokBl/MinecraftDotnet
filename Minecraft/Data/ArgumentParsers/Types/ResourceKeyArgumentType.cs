using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ResourceKeyArgumentType(Identifier Registry) : RegistryTokenArgumentType(Registry) {
    public ResourceKeyArgumentType() : this("minecraft:item") { }

    public override Identifier Identifier => "minecraft:resource_key";
}
