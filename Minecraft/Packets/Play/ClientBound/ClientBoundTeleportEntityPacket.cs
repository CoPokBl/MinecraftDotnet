using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundTeleportEntityPacket : ClientBoundPacket {
    public required int EntityId;
    public required Vec3 Position;
    public required Vec3 Velocity;
    public required Angle Yaw;
    public required Angle Pitch;
    public required bool OnGround;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteBoolean(OnGround)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundTeleportEntityPacket {
        EntityId = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Velocity = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        OnGround = r.ReadBoolean()
    };
}
