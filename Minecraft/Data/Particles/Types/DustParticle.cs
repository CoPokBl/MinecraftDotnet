using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Particles.Types;

public record DustParticle(Identifier Identifier, int ProtocolId, TextColor Color = default, float Scale = 1f) : IParticle {
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
