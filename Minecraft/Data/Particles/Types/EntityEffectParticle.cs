using Minecraft.NBT.Text;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record EntityEffectParticle(Identifier Identifier, int ProtocolId, TextColor Color = default) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteInteger(Color.ToDecimal());
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Color = TextColor.FromDecimal(reader.ReadInteger())
        };
    }
}
