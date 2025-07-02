namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundChunkBatchReceivedPacket : ServerBoundPacket {
    public required float ChunksPerTick;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteFloat(ChunksPerTick)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChunkBatchReceivedPacket {
        ChunksPerTick = r.ReadFloat()
    };
}
