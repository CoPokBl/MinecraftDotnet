using Minecraft.Data.Entities;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class EntityTypeRegistry : ProtocolTypeRegistry<EntityTypeRegistry, IEntityType> {
    public override Identifier RegistryId => "minecraft:entity_type";
}
