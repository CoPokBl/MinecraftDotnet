namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBundleDelimiterPacket : MinecraftPacket {
    
    public override int GetPacketId() {
        return 0x00;
    }

    protected override byte[] GetData() {
        return [];
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        return this;
    }
}