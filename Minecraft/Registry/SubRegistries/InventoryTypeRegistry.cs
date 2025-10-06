using Minecraft.Data.Inventories;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class InventoryTypeRegistry : ProtocolTypeRegistry<InventoryTypeRegistry, IInventoryType> {
    public override Identifier RegistryId => "minecraft:menu";
}
