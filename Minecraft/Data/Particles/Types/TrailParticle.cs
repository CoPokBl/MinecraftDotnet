using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Minecraft.Data.Particles.Types;

public record TrailParticle(Identifier Identifier, int ProtocolId, Vec3<double> Target = default, TextColor Color = default, int Duration = 0) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVec3(Target)
            .WriteInteger(Color.ToDecimal())
            .WriteVarInt(Duration);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            Target = reader.ReadVec3(),
            Color = TextColor.FromDecimal(reader.ReadInteger()),
            Duration = reader.ReadVarInt()
        };
    }
}
