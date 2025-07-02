namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundResetChatPacket : ClientBoundPacket {
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundResetChatPacket();
}
