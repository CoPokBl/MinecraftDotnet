using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles;

public record SimpleParticle(Identifier Identifier, int ProtocolId) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        // No data for simple particles
        return writer;
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        // No data for simple particles
        return this;
    }
}
