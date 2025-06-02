namespace Minecraft.Packets;

public class ServerBoundHandshakePacket(string hostname, ServerBoundHandshakePacket.Intention intent, ushort port = 25565, int protocolVersion = 770) : MinecraftPacket {
    public string Hostname = hostname;
    public ushort Port = port;
    public int ProtocolVersion = protocolVersion;
    public Intention Intent = intent;
    
    public enum Intention {
        Status = 1,
        Login = 2,
        Transfer = 3
    }

    public ServerBoundHandshakePacket() : this(null!, 0, 0, 0) { }

    public override int GetPacketId() {
        return 0x00;
    }

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WriteVarInt(ProtocolVersion);  // client version (-1 means we refuse to say, some servers may drop such a packet)
        w.WriteString(Hostname);
        w.WriteUShort(Port);
        w.WriteVarInt(1);  // next we want status
        return w.ToArray();
    }

    protected override ServerBoundHandshakePacket ParseData(byte[] data) {
        DataReader r = new(data);
        ProtocolVersion = r.ReadVarInt();
        Hostname = r.ReadString();
        Port = r.ReadUShort();
        Intent = (Intention)r.ReadVarInt();
        return this;
    }
}