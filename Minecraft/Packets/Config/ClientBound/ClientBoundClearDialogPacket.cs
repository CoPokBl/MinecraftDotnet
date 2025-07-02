namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundClearDialogPacket : ClientBoundPacket {
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundClearDialogPacket();
}
