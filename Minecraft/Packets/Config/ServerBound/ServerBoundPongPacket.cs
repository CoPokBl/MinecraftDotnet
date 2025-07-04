using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPongPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:pong";
    
    public required int Id;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(Id);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPongPacket {
        Id = r.ReadInteger()
    };
}
