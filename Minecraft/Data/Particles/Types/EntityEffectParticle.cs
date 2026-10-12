using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

/// <param name="Argb">The colour with its alpha, packed as ARGB: <c>ColorParticleOption</c> sends all four channels.</param>
public record EntityEffectParticle(Identifier Identifier, int Argb = -1) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteInteger(Argb);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            Argb = reader.ReadInteger()
        };
    }
}
