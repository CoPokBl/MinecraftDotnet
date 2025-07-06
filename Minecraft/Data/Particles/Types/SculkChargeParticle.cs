using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record SculkChargeParticle(Identifier Identifier, int ProtocolId, float Roll = 0f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteFloat(Roll);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            Roll = reader.ReadFloat()
        };
    }
}
