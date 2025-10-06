using Minecraft.Data.PotionEffectTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class PotionEffectTypeRegistry : ProtocolTypeRegistry<PotionEffectTypeRegistry, IPotionEffectType> {
    public override Identifier RegistryId => "minecraft:potion_effect";
}
