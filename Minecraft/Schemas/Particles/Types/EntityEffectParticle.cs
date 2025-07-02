using Minecraft.NBT.Text;

namespace Minecraft.Schemas.Particles.Types;

public record EntityEffectParticle(int Id, TextColor Color = default) : IParticle {
    
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
