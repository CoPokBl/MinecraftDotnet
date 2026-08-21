using Minecraft.Data.Potions;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class PotionRegistry : MappedRegistry<PotionRegistry, IPotion> {
    public override Identifier RegistryId => "minecraft:potion";
}
