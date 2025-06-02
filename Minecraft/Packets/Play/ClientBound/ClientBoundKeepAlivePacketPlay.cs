namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundKeepAlivePacketPlay(long id) : MinecraftPacket {
    public long Id = id;
    
    public ClientBoundKeepAlivePacketPlay() : this(0) { }
    
    public override int GetPacketId() {
        return 0x26;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(Id)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Id = new DataReader(data).ReadLong();
        return this;
    }
}