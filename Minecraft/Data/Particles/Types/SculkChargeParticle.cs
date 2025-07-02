using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record SculkChargeParticle(Identifier Identifier, int ProtocolId, float Roll = 0f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteFloat(Roll);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Roll = reader.ReadFloat()
        };
    }
}
