namespace Minecraft.Packets;

public class ServerBoundHandshakePacket() : ServerBoundPacket {
    public required string Hostname;
    public required ushort Port;
    public required int ProtocolVersion;
    public required Intention Intent;
    
    public enum Intention {
        Status = 1,
        Login = 2,
        Transfer = 3
    }

    public ServerBoundHandshakePacket(string hostname, Intention intent, ushort port = 25565, int protocolVersion = 770) : this() {
        Hostname = hostname;
        Port = port;
        ProtocolVersion = protocolVersion;
        Intent = intent;
    }

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WriteVarInt(ProtocolVersion);  // client version (-1 means we refuse to say, some servers may drop such a packet)
        w.WriteString(Hostname);
        w.WriteUShort(Port);
        w.WriteVarInt((int)Intent);  // next we want status
        return w.ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundHandshakePacket {
        ProtocolVersion = r.ReadVarInt(),
        Hostname = r.ReadString(),
        Port = r.ReadUShort(),
        Intent = (Intention)r.ReadVarInt()
    };
}
