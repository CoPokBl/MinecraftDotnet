namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginAcknowledgedPacket : ServerBoundPacket {

    protected override byte[] GetData() {
        return [];
    }

    public static readonly PacketDataDeserialiser Deserialiser = _ => new ServerBoundLoginAcknowledgedPacket();
}
