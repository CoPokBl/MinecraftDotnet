using Minecraft.Schemas;

namespace Minecraft.Packets.Handshake;

public class ServerBoundHandshakePacket() : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:intention";

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

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteVarInt(ProtocolVersion);  // client version (-1 means we refuse to say, some servers may drop such a packet)
        w.WriteString(Hostname);
        w.WriteUShort(Port);
        w.WriteVarInt((int)Intent);  // next we want status
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundHandshakePacket {
        ProtocolVersion = r.ReadVarInt(),
        Hostname = r.ReadString(),
        Port = r.ReadUShort(),
        Intent = (Intention)r.ReadVarInt()
    };
}
