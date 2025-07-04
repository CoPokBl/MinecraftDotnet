using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginPluginResponsePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:custom_query_answer";
    
    public required int MessageId;
    public required byte[]? Data;  // only sent if the request was 'understood', null otherwise

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(MessageId)
            .WritePrefixedOptional(Data, (bs, wr) => wr.Write(bs));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundLoginPluginResponsePacket {
        MessageId = r.ReadVarInt(),
        Data = r.ReadPrefixedOptional(re => re.ReadRemaining())
    };
}
