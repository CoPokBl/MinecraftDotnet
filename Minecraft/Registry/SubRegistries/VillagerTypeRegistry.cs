using Minecraft.Data.VillagerTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class VillagerTypeRegistry : MappedRegistry<VillagerTypeRegistry, IVillagerType> {
    public override Identifier RegistryId => "minecraft:villager_type";
}
