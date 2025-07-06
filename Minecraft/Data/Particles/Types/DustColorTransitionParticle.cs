using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Particles.Types;

public record DustColorTransitionParticle(
    Identifier Identifier, 
    int ProtocolId, 
    TextColor FromColor = default, 
    TextColor ToColor = default, 
    float Scale = 1f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteInteger(FromColor.ToDecimal())
            .WriteInteger(ToColor.ToDecimal())
            .WriteFloat(Scale);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            FromColor = TextColor.FromDecimal(reader.ReadInteger()),
            ToColor = TextColor.FromDecimal(reader.ReadInteger()),
            Scale = reader.ReadFloat()
        };
    }
}
