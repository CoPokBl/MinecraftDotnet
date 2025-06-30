namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundClearTitlesPacket : ClientBoundPacket {
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = _ => new ClientBoundClearTitlesPacket();
}
