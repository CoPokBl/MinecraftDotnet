using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginPluginRequestPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:custom_query";
    
    public required int MessageId;
    public required string Channel;
    public required byte[] Data;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(MessageId)
            .WriteString(Channel)
            .Write(Data)  // Length is implied from the packet length
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginPluginRequestPacket {
        MessageId = r.ReadVarInt(),
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
