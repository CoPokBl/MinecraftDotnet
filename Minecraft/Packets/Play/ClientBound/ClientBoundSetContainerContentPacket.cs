using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetContainerContentPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:container_set_content";
    
    public required int WindowId;
    public required int StateId;
    public required Slot[] SlotData;
    public required Slot CursorItem;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(WindowId)
            .WriteVarInt(StateId)
            .WritePrefixedArray(SlotData, (slot, writer) => writer.Write(slot))
            .Write(CursorItem)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetContainerContentPacket {
        WindowId = r.ReadVarInt(),
        StateId = r.ReadVarInt(),
        SlotData = r.ReadPrefixedArray(Slot.Read),
        CursorItem = Slot.Read(r)
    };
}
