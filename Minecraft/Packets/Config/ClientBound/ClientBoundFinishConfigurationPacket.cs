namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundFinishConfigurationPacket : ClientBoundPacket {

    protected override byte[] GetData() {
        return [];
    }

    public static readonly PacketDataDeserialiser Deserialiser = _ => new ClientBoundFinishConfigurationPacket();
}
