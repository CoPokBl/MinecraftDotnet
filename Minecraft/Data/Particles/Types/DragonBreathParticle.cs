using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record DragonBreathParticle(Identifier Identifier, int ProtocolId, float Power = 1f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteFloat(Power);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Power = reader.ReadFloat()
        };
    }
}
