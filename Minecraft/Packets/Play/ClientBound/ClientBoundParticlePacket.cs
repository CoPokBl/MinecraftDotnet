using Minecraft.Schemas.Particles;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundParticlePacket : ClientBoundPacket {
    public required bool LongDistance;
    public required bool AlwaysVisible;
    public required Vec3 Position;
    public required FVec3 Offset;
    public required float MaxSpeed;
    public required int ParticleCount;
    public required IParticle Particle;
    public byte[] Data = [];  // extra data, TODO: Remove when particles are implemented properly
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteBoolean(LongDistance)
            .WriteBoolean(AlwaysVisible)
            .WriteVec3(Position)
            .WriteVec3(Offset)
            .WriteFloat(MaxSpeed)
            .WriteInteger(ParticleCount)
            .WriteVarInt(Particle.Id)
            .Write(Particle.WriteData)
            .Write(Data)  // TODO: Remove when particles are implemented properly
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundParticlePacket {
        LongDistance = r.ReadBoolean(),
        AlwaysVisible = r.ReadBoolean(),
        Position = r.ReadVec3(),
        Offset = r.ReadFVec3(),
        MaxSpeed = r.ReadFloat(),
        ParticleCount = r.ReadInteger(),
        Particle = IParticle.DefaultOfType(r.ReadVarInt()).ReadData(r),
        Data = r.ReadRemaining()  // extra data, TODO: Remove when particles are implemented properly
    };
}
