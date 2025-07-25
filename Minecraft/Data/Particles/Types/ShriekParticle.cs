using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record ShriekParticle(Identifier Identifier, int ProtocolId, int Delay = 0) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(Delay);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            Delay = reader.ReadVarInt()
        };
    }
}
