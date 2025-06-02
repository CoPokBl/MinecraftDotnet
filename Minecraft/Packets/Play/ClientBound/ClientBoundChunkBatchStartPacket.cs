namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkBatchStartPacket : MinecraftPacket {
    
    public override int GetPacketId() {
        return 0x0C;
    }

    protected override byte[] GetData() {
        return [];
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        return this;
    }
}