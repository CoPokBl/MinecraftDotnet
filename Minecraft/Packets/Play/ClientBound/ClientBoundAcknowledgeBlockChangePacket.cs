namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundAcknowledgeBlockChangePacket(int sequenceId) : MinecraftPacket {
    public int SequenceId = sequenceId;
    
    public ClientBoundAcknowledgeBlockChangePacket() : this(0) { }

    public override int GetPacketId() {
        return 0x04;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(SequenceId)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        SequenceId = new DataReader(data).ReadVarInt();
        return this;
    }
}