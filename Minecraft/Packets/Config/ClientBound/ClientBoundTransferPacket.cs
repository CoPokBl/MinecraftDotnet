namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundTransferPacket : ClientBoundPacket {
    public required string Host;
    public required int Port;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Host)
            .WriteVarInt(Port)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundTransferPacket {
        Host = r.ReadString(),
        Port = r.ReadVarInt()
    };
}
