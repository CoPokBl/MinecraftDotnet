namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPluginMessagePacketConfig : ServerBoundPacket {
    public required byte[] Data;
    public required string Channel;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Channel)
            .Write(Data)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPluginMessagePacketConfig {
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
