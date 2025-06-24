namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkBatchFinishedPacket : ClientBoundPacket {
    public required int BatchSize;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(BatchSize)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundChunkBatchFinishedPacket {
        BatchSize = r.ReadVarInt()
    };
}
