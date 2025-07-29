using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record BlockParticle(Identifier Identifier, int ProtocolId, IBlock? BlockState = null) : IParticle {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt((int)(BlockState?.StateId ?? 0));
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry reg) {
        return this with {
            BlockState = reg.Blocks.GetByStateId((uint)reader.ReadVarInt())
        };
    }
}
