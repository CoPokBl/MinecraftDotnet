using Minecraft.Data.BlockEntityTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class BlockEntityTypeRegistry : ProtocolTypeRegistry<BlockEntityTypeRegistry, IBlockEntityType> {
    public override Identifier RegistryId => "minecraft:block_entity_type";
}
