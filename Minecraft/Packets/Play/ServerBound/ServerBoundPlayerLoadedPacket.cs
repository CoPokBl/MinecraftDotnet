namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerLoadedPacket : MinecraftPacket {
    
    public override int GetPacketId() {
        return 0x2A;
    }

    protected override byte[] GetData() {
        return [];
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        return this;
    }
}