namespace Minecraft.Packets.Status.ServerBound;

public class ServerBoundStatusRequestPacket : MinecraftPacket {

    public override int GetPacketId() {
        return 0x00;
    }

    protected override byte[] GetData() {
        return [];
    }

    protected override ServerBoundStatusRequestPacket ParseData(byte[] data) {
        return this;
    }
}