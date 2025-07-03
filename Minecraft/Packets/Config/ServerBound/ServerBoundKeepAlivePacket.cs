using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundKeepAlivePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:keep_alive";
    
    public required long Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundKeepAlivePacket {
        Id = r.ReadLong()
    };
}
