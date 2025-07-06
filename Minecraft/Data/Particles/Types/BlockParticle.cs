using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record BlockParticle(Identifier Identifier, int ProtocolId, int BlockState = 0) : IParticle {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(BlockState);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            BlockState = reader.ReadVarInt()
        };
    }
}
