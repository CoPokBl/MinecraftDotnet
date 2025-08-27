using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundTransferPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:transfer";
    
    public required string Host { get; init; }
    public required int Port { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Host)
            .WriteVarInt(Port);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundTransferPacket {
        Host = r.ReadString(),
        Port = r.ReadVarInt()
    };
}
