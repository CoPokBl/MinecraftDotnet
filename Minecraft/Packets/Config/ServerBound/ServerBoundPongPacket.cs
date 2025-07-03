using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPongPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:pong";
    
    public required int Id;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(Id)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPongPacket {
        Id = r.ReadInteger()
    };
}
