namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundPluginMessagePacket : ClientBoundPacket {
    public required string Channel;
    public required byte[] Data;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Channel)
            .Write(Data)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPluginMessagePacket {
        Channel = r.ReadString(),
        Data = r.ReadRemaining()
    };
}
