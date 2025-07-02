namespace Minecraft.Packets.Status.ServerBound;

public class ServerBoundStatusRequestPacket : ServerBoundPacket {

    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundStatusRequestPacket();
}
