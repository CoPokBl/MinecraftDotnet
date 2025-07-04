using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPluginMessagePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:custom_payload";
    
    public required byte[] Data;
    public required string Channel;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Channel)
            .Write(Data);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPluginMessagePacket {
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
