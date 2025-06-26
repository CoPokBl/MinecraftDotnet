using Minecraft.NBT;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundCustomClickActionPacket : ServerBoundPacket {
    public required string Id;
    public required ITag Payload;  // may be EmptyTag

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundCustomClickActionPacket {
        Id = r.ReadString(),
        Payload = r.ReadNbt()
    };
}
