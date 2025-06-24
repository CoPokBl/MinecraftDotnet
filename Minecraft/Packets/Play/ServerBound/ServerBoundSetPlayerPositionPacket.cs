using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerPositionPacket : ServerBoundPacket {
    public required MovePlayerFlags Flags;
    public required Vec3 Position;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVec3(Position)
            .WriteByte((int)Flags)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundSetPlayerPositionPacket {
        Position = r.ReadVec3(),
        Flags = (MovePlayerFlags)r.ReadByte()
    };
}
