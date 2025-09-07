using Minecraft.Data.Particles;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundParticlePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:level_particles";
    
    public required bool LongDistance { get; init; }
    public required bool AlwaysVisible { get; init; }
    public required Vec3<double> Position { get; init; }
    public required Vec3<float> Offset { get; init; }
    public required float MaxSpeed { get; init; }
    public required int ParticleCount { get; init; }
    public required IParticle Particle { get; init; }
    
    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteBoolean(LongDistance)
            .WriteBoolean(AlwaysVisible)
            .WriteVec3(Position)
            .WriteVec3(Offset)
            .WriteFloat(MaxSpeed)
            .WriteInteger(ParticleCount)
            .WriteVarInt(Particle.ProtocolId)
            .Write(wr => Particle.WriteData(wr, registry));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundParticlePacket {
        LongDistance = r.ReadBoolean(),
        AlwaysVisible = r.ReadBoolean(),
        Position = r.ReadVec3(),
        Offset = r.ReadFVec3(),
        MaxSpeed = r.ReadFloat(),
        ParticleCount = r.ReadInteger(),
        Particle = reg.Particles[r.ReadVarInt()].ReadData(r, reg)
    };
}
