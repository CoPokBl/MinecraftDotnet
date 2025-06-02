namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientTickEndPacket : MinecraftPacket {
    
    public override int GetPacketId() {
        return 0x0B;
    }

    protected override byte[] GetData() {
        return [];
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        return this;
    }
}