using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundPluginMessagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:custom_payload";
    
    public required string Channel { get; init; }
    public required byte[] Data { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Channel)
            .Write(Data);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPluginMessagePacket {
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
