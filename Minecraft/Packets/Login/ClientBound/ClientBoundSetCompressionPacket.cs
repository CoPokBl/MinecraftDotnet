namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundSetCompressionPacket(int threshold) : MinecraftPacket {
    public int Threshold = threshold;
    
    public ClientBoundSetCompressionPacket() : this(1) { }

    public override int GetPacketId() {
        return 0x03;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(Threshold)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Threshold = new DataReader(data).ReadVarInt();
        return this;
    }
}