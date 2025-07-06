using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Particles.Types;

public record EntityEffectParticle(Identifier Identifier, int ProtocolId, TextColor Color = default) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteInteger(Color.ToDecimal());
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            Color = TextColor.FromDecimal(reader.ReadInteger())
        };
    }
}
