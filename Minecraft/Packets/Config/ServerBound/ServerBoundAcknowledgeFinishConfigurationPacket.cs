namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundAcknowledgeFinishConfigurationPacket : MinecraftPacket {
    
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