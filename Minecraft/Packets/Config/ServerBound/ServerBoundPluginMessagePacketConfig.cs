namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundPluginMessagePacketConfig(string channel, byte[] data) : MinecraftPacket {
    public byte[] Data = data;
    public string Channel = channel;

    public ServerBoundPluginMessagePacketConfig() : this("", []) { }
    
    public override int GetPacketId() {
        return 0x02;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Channel)
            .Write(Data)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Channel = r.ReadString();
        Data = r.ReadRemaining();
        return this;
    }
}