using Minecraft.Schemas;

namespace Minecraft.Data.Particles;

public record SimpleParticle(Identifier Identifier, int ProtocolId) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        // No data for simple particles
        return writer;
    }

    public IParticle ReadData(DataReader reader) {
        // No data for simple particles
        return this;
    }
}
