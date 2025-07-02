using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerRotationPacket : ServerBoundPacket {
    public required float Pitch;
    public required float Yaw;
    public required MovePlayerFlags Flags;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteFloat(Pitch)
            .WriteFloat(Yaw)
            .WriteByte((byte)Flags)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetPlayerRotationPacket {
        Pitch = r.ReadFloat(),
        Yaw = r.ReadFloat(),
        Flags = (MovePlayerFlags)r.ReadByte()
    };
}
