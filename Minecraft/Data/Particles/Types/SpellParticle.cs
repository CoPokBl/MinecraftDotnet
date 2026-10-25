using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

/// <summary><c>SpellParticleOption</c>: an RGB colour, white by default, and how hard the particle is thrown.</summary>
public record SpellParticle(Identifier Identifier, int Rgb = -1, float Power = 1.0F) : IParticle {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteInteger(Rgb)
            .WriteFloat(Power);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Rgb = reader.ReadInteger(),
            Power = reader.ReadFloat()
        };
    }
}
