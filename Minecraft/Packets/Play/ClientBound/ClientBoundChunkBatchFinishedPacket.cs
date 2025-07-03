using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkBatchFinishedPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:chunk_batch_finished";
    
    public required int BatchSize;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(BatchSize)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundChunkBatchFinishedPacket {
        BatchSize = r.ReadVarInt()
    };
}
