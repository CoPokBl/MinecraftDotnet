using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUnloadChunkPacket(int x, int z) : MinecraftPacket {
    public int X { get; private set; } = x;
    public int Z { get; private set; } = z;

    public ClientBoundUnloadChunkPacket(ChunkPosition pos) : this(pos.X, pos.Z) { }
    
    public ClientBoundUnloadChunkPacket() : this(0, 0) { }
    
    public override int GetPacketId() {
        return 0x21;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(Z)
            .WriteInteger(X)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Z = r.ReadInteger();
        X = r.ReadInteger();
        return this;
    }
}