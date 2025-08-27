using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundKeepAlivePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:keep_alive";
    
    public required long Id { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteLong(Id);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundKeepAlivePacket {
        Id = r.ReadLong()
    };
}
