using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginPluginRequestPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:custom_query";
    
    public required int MessageId { get; init; }
    public required string Channel { get; init; }
    public required byte[] Data { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(MessageId)
            .WriteString(Channel)
            .Write(Data); // Length is implied from the packet length
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginPluginRequestPacket {
        MessageId = r.ReadVarInt(),
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
