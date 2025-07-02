using Minecraft.NBT.Text;

namespace Minecraft.Schemas.Particles.Types;

public record DustParticle(int Id, TextColor Color = default, float Scale = 1f) : IParticle {
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteInteger(Color.ToDecimal())
            .WriteFloat(Scale);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Color = TextColor.FromDecimal(reader.ReadInteger()),
            Scale = reader.ReadFloat()
        };
    }
}
