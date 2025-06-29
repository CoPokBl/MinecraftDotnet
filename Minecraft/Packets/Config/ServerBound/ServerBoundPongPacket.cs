namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPongPacket : ServerBoundPacket {
    public required int Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPongPacket {
        Id = r.ReadInteger()
    };
}
