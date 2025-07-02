namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginSuccessPacket : ClientBoundPacket {
    public required string Username;
    public required Guid Uuid;

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WriteUuid(Uuid);
        w.WriteString(Username);
        w.WritePrefixedArray(Array.Empty<int>(), (_, _) => { });
        return w.ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginSuccessPacket {
        Uuid = r.ReadUuid(),
        Username = r.ReadString()
    };
}
