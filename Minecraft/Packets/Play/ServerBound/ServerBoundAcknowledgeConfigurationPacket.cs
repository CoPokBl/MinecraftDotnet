namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundAcknowledgeConfigurationPacket : ServerBoundPacket {
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = _ => new ServerBoundAcknowledgeConfigurationPacket();
}
