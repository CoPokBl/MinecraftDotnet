namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBundleDelimiterPacket : ClientBoundPacket {

    protected override byte[] GetData() {
        return [];
    }

    public static PacketDataDeserialiser Deserialiser => _ => new ClientBoundBundleDelimiterPacket();
}
