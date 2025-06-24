namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundKeepAlivePacketPlay : ServerBoundPacket {
    public required long Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundKeepAlivePacketPlay {
        Id = r.ReadLong()
    };
}
