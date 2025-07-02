namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerLoadedPacket : ServerBoundPacket {

    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundPlayerLoadedPacket();
}
