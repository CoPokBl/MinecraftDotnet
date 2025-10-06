using Minecraft.Data.Attributes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class AttributeRegistry : ProtocolTypeRegistry<AttributeRegistry, IAttribute> {
    public override Identifier RegistryId => "minecraft:attribute";
}
