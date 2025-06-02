namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetHeldItemPacket(short slot) : MinecraftPacket {
    public short Slot = slot;
    
    public ServerBoundSetHeldItemPacket() : this(0) { }
    
    public override int GetPacketId() {
        return 0x33;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUShort((ushort)Slot)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Slot = (short)new DataReader(data).ReadUShort();
        return this;
    }
}