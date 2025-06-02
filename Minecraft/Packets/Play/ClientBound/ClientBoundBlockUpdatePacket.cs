using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBlockUpdatePacket(BlockPosition location, int blockId) : MinecraftPacket {
    public BlockPosition Location = location;
    public int BlockId = blockId;
    
    public ClientBoundBlockUpdatePacket() : this(new BlockPosition(0, 0, 0), 0) { }

    public override int GetPacketId() {
        return 0x08;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteVarInt(BlockId)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Location = r.ReadPosition();
        BlockId = r.ReadVarInt();
        return this;
    }
}