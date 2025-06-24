namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPluginMessagePacketPlay : ServerBoundPacket {
    public required byte[] Data;
    public required string Channel;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Channel)
            .Write(Data)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPluginMessagePacketPlay {
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
