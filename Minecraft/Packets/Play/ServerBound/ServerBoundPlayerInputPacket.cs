namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerInputPacket(ServerBoundPlayerInputPacket.Input flags) : MinecraftPacket {
    public Input Flags = flags;

    public ServerBoundPlayerInputPacket() : this(Input.Jump) { }

    [Flags]
    public enum Input {
        Forward = 0x01,
        Backward = 0x02,
        Left = 0x04,
        Right = 0x08,
        Jump = 0x10,
        Sneak = 0x20,
        Sprint = 0x40
    }

    public override int GetPacketId() {
        return 0x29;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUnsignedByte((byte)Flags)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Flags = (Input)new DataReader(data).Read();
        return this;
    }
}