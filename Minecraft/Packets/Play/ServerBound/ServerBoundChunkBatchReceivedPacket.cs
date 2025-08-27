using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundChunkBatchReceivedPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chunk_batch_received";
    
    public required float ChunksPerTick { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(ChunksPerTick);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChunkBatchReceivedPacket {
        ChunksPerTick = r.ReadFloat()
    };
}
