using Minecraft.Data.Sounds;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class SoundTypeRegistry : MappedRegistry<SoundTypeRegistry, ISoundType> {
    public override Identifier RegistryId => "minecraft:sound_event";
}
