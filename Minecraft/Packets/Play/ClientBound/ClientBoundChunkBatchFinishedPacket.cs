namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkBatchFinishedPacket(int batchSize) : MinecraftPacket {
    public int BatchSize = batchSize;

    public ClientBoundChunkBatchFinishedPacket() : this(0) { }
    
    public override int GetPacketId() {
        return 0x0B;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(BatchSize)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        BatchSize = new DataReader(data).ReadVarInt();
        return this;
    }
}