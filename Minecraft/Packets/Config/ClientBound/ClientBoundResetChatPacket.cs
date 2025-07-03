using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundResetChatPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:reset_chat";
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundResetChatPacket();
}
