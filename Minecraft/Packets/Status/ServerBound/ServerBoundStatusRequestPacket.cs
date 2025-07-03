using Minecraft.Schemas;

namespace Minecraft.Packets.Status.ServerBound;

public class ServerBoundStatusRequestPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:status_request";

    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundStatusRequestPacket();
}
