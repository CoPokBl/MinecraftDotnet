namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginStartPacket : ServerBoundPacket {
    public required Guid Uuid;
    public required string Name;

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WriteString(Name);
        w.WriteUuid(Uuid);
        return w.ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundLoginStartPacket {
        Name = r.ReadString(),
        Uuid = r.ReadUuid()
    };
}
