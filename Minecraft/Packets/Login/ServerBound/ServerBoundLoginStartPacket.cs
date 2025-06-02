namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginStartPacket(string name, Guid uuid) : MinecraftPacket {
    public Guid Uuid = uuid;
    public string Name = name;

    public ServerBoundLoginStartPacket() : this("", Guid.Empty) { }
    
    public override int GetPacketId() {
        return 0x00;
    }

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WriteString(Name);
        w.WriteUuid(Uuid);
        return w.ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Name = r.ReadString();
        Uuid = r.ReadUuid();
        return this;
    }
}