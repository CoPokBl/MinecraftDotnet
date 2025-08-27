using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundKeepAlivePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:keep_alive";
    
    public required long Id { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteLong(Id);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundKeepAlivePacket {
        Id = r.ReadLong()
    };
}
