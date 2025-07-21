using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Data.ConsumeEffects.Types;

public record PlaySoundConsumeEffect(Identifier Identifier, int ProtocolId, SoundEvent? Sound = null) : IConsumeEffect {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(Sound.ThrowIfNull());
    }

    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Sound = SoundEvent.Deserialise(reader, registry)
        };
    }
}
