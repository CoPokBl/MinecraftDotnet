using Minecraft.Data.Components;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class DataComponentRegistry : ProtocolTypeRegistry<DataComponentRegistry, IDataComponent> {
    public override Identifier RegistryId => "minecraft:data_component_type";
}
