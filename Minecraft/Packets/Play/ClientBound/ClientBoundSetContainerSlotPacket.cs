using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetContainerSlotPacket : ClientBoundPacket {
    public required int WindowId;
    public required int StateId;
    public required short SlotId;
    public required Slot Data;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(WindowId)
            .WriteVarInt(StateId)
            .WriteShort(SlotId)
            .Write(Data)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSetContainerSlotPacket {
        WindowId = r.ReadVarInt(),
        StateId = r.ReadVarInt(),
        SlotId = r.ReadShort(),
        Data = new Slot().Read(r)
    };
}
