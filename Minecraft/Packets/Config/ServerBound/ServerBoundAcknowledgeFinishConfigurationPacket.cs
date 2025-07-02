namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundAcknowledgeFinishConfigurationPacket : ServerBoundPacket {

    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundAcknowledgeFinishConfigurationPacket();
}
