using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Particles.Types;

public record DustColorTransitionParticle(
    Identifier Identifier, 
    
    TextColor FromColor = default, 
    TextColor ToColor = default, 
    float Scale = 1f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteInteger(FromColor.ToDecimal())
            .WriteInteger(ToColor.ToDecimal())
            .WriteFloat(Scale);
    }

    // The colour arrives with an opaque alpha above the RGB, which nothing reads.
    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            FromColor = TextColor.FromDecimal(reader.ReadInteger() & 0xFFFFFF),
            ToColor = TextColor.FromDecimal(reader.ReadInteger() & 0xFFFFFF),
            Scale = reader.ReadFloat()
        };
    }
}
