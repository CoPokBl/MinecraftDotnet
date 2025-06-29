namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPluginMessagePacket : ServerBoundPacket {
    public required byte[] Data;
    public required string Channel;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Channel)
            .Write(Data)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPluginMessagePacket {
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
