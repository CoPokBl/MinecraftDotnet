using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSynchronisePlayerPositionPacket : ClientBoundPacket {
    public required Angle Pitch;
    public required Angle Yaw;
    public required Vec3 Velocity;
    public required Vec3 Position;
    public required int TeleportId;
    public required TeleportFlags Flags;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(TeleportId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteInteger((int)Flags)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSynchronisePlayerPositionPacket {
        TeleportId = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Velocity = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        Flags = (TeleportFlags)r.ReadInteger()
    };
}
