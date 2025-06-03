using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetCenterChunkPacket(int x, int z) : MinecraftPacket {
    public int X = x;
    public int Z = z;
    
    public ClientBoundSetCenterChunkPacket() : this(0, 0) { }
    
    public ClientBoundSetCenterChunkPacket(ChunkPosition pos) : this(pos.X, pos.Z) { }
    
    public override int GetPacketId() {
        return 0x57;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(X)
            .WriteVarInt(Z)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        X = r.ReadVarInt();
        Z = r.ReadVarInt();
        return this;
    }
}