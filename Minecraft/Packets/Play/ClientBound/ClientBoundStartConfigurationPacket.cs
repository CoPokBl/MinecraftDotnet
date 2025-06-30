namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundStartConfigurationPacket : ClientBoundPacket {
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = _ => new ClientBoundStartConfigurationPacket();
}
