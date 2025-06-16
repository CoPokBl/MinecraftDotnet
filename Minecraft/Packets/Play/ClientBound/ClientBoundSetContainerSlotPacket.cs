using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetContainerSlotPacket(int windowId, int stateId, short slot, Slot data) : MinecraftPacket {
    public int WindowId = windowId;
    public int StateId = stateId;
    public short SlotId = slot;
    public Slot Data = data;

    public ClientBoundSetContainerSlotPacket() : this(0, 0, 0, new Slot(0)) { }

    public override int GetPacketId() {
        return 0x14;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(WindowId)
            .WriteVarInt(StateId)
            .WriteShort(SlotId)
            .Write(Data)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        WindowId = r.ReadVarInt();
        StateId = r.ReadVarInt();
        SlotId = r.ReadShort();
        Data = new Slot().Read(r);
        return this;
    }
}