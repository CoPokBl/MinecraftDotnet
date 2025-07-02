namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientTickEndPacket : ServerBoundPacket {

    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundClientTickEndPacket();
}
