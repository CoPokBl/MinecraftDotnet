using Minecraft.Data.ConsumeEffects;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class ConsumeEffectRegistry : ProtocolTypeRegistry<ConsumeEffectRegistry, IConsumeEffect> {
    public override Identifier RegistryId => "minecraft:consume_effect_type";
}
