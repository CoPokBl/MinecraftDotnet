using Minecraft.Data.MapDecorationTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class MapDecorationTypeRegistry : MappedRegistry<MapDecorationTypeRegistry, IMapDecorationType> {
    public override Identifier RegistryId => "minecraft:map_decoration_type";
}
