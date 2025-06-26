namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundKeepAlivePacket : ServerBoundPacket {
    public required long Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundKeepAlivePacket {
        Id = r.ReadLong()
    };
}
