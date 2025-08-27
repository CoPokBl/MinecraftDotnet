using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundPingPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:ping";
    
    public required int Id { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(Id);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPingPacket {
        Id = r.ReadInteger()
    };
}
