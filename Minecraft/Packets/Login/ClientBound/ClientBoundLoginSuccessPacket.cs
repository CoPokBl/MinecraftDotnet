namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginSuccessPacket(Guid uuid, string username) : MinecraftPacket {
    public string Username = username;
    public Guid Uuid = uuid;

    public ClientBoundLoginSuccessPacket() : this(Guid.Empty, "") { }


    public override int GetPacketId() {
        return 0x02;
    }

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WriteUuid(Uuid);
        w.WriteString(Username);
        w.WritePrefixedArray(Array.Empty<int>(), (_, _) => { });
        return w.ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Uuid = r.ReadUuid();
        Username = r.ReadString();
        return this;
    }
}