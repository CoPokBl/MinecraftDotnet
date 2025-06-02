namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetCenterChunkPacket(int x, int y) : MinecraftPacket {
    public int X = x;
    public int Y = y;
    
    public ClientBoundSetCenterChunkPacket() : this(0, 0) { }
    
    public override int GetPacketId() {
        return 0x57;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(X)
            .WriteVarInt(Y)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        X = r.ReadVarInt();
        Y = r.ReadVarInt();
        return this;
    }
}