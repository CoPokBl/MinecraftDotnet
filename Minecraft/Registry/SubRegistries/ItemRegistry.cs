using Minecraft.Data.Items;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class ItemRegistry : MappedRegistry<ItemRegistry, IItem> {
    public override Identifier RegistryId => "minecraft:item";
}
