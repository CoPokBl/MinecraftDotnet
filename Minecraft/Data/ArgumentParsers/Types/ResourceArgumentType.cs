using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ResourceArgumentType(Identifier Registry) : RegistryTokenArgumentType(Registry) {
    public ResourceArgumentType() : this("minecraft:item") { }

    public override Identifier Identifier => "minecraft:resource";
}
