using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetContainerContentPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:container_set_content";
    
    public required int WindowId;
    public required int StateId;
    public required ItemStack[] SlotData;
    public required ItemStack CursorItem;

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(StateId)
            .WritePrefixedArray(SlotData, (slot, writer) => {
                slot.Write(writer, registry);
            })
            .Write(wr => CursorItem.Write(wr, registry));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetContainerContentPacket {
        WindowId = r.ReadVarInt(),
        StateId = r.ReadVarInt(),
        SlotData = r.ReadPrefixedArray(re => ItemStack.Read(re, reg)),
        CursorItem = ItemStack.Read(r, reg)
    };
}
