namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginAcknowledgedPacket : MinecraftPacket {
    
    public override int GetPacketId() {
        return 0x03;
    }

    protected override byte[] GetData() {
        return [];
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        return this;
    }
}