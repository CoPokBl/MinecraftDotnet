namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginPluginResponsePacket : ServerBoundPacket {
    public required int MessageId;
    public required byte[]? Data;  // only sent if the request was 'understood', null otherwise

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(MessageId)
            .WritePrefixedOptional(Data, (bs, wr) => wr.Write(bs))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundLoginPluginResponsePacket {
        MessageId = r.ReadVarInt(),
        Data = r.ReadPrefixedOptional(re => re.ReadRemaining())
    };
}
