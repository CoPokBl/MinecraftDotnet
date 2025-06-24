namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkBatchStartPacket : ClientBoundPacket {

    protected override byte[] GetData() {
        return [];
    }

    public static readonly PacketDataDeserialiser Deserialiser = _ => new ClientBoundChunkBatchStartPacket();
}
