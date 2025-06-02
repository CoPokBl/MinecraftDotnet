namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundPingResponsePacket(long payload) : MinecraftPacket {
    public long Payload = payload;

    public ClientBoundPingResponsePacket() : this(0) { }

    public override int GetPacketId() {
        return 0x01;
    }

    protected override byte[] GetData() {
        return new DataWriter().WriteLong(Payload).ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Payload = new DataReader(data).ReadLong();
        return this;
    }
}