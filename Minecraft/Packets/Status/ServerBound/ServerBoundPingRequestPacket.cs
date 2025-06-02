using Minecraft.Packets.Status.ClientBound;

namespace Minecraft.Packets.Status.ServerBound;

public class ServerBoundPingRequestPacket(long payload) : MinecraftPacket {
    public long Payload = payload;

    public ServerBoundPingRequestPacket() : this(0) { }

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

    public ClientBoundPingResponsePacket CreateResponse() {
        return new ClientBoundPingResponsePacket(Payload);
    }
}