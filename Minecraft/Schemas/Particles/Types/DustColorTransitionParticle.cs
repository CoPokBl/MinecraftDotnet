using Minecraft.NBT.Text;

namespace Minecraft.Schemas.Particles.Types;

public record DustColorTransitionParticle(int Id, 
    TextColor FromColor = default, 
    TextColor ToColor = default, 
    float Scale = 1f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteInteger(FromColor.ToDecimal())
            .WriteInteger(ToColor.ToDecimal())
            .WriteFloat(Scale);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            FromColor = TextColor.FromDecimal(reader.ReadInteger()),
            ToColor = TextColor.FromDecimal(reader.ReadInteger()),
            Scale = reader.ReadFloat()
        };
    }
}
