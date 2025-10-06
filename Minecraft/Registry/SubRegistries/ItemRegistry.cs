using Minecraft.Data.Items;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class ItemRegistry : ProtocolTypeRegistry<ItemRegistry, IItem> {
    public override Identifier RegistryId => "minecraft:item";
}
