using Minecraft.NBT.Text;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Particles.Types;

public record TrailParticle(int Id, Vec3 Target = default, TextColor Color = default, int Duration = 0) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteVec3(Target)
            .WriteInteger(Color.ToDecimal())
            .WriteVarInt(Duration);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Target = reader.ReadVec3(),
            Color = TextColor.FromDecimal(reader.ReadInteger()),
            Duration = reader.ReadVarInt()
        };
    }
}
