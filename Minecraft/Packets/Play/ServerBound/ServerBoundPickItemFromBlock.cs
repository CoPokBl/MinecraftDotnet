using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromBlock(BlockPosition location, bool includeData) : MinecraftPacket {
    public BlockPosition Location = location;
    public bool IncludeData = includeData;
    
    public ServerBoundPickItemFromBlock() : this(BlockPosition.Zero, false) { }

    public override int GetPacketId() {
        return 0x22;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteBoolean(IncludeData)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Location = r.ReadPosition();
        IncludeData = r.ReadBoolean();
        return this;
    }
}