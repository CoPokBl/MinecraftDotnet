using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetContainerContentPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:container_set_content";
    
    public required int WindowId { get; init; }
    public required int StateId { get; init; }
    public required ItemStack[] SlotData { get; init; }
    public required ItemStack CursorItem { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(StateId)
            .WritePrefixedArray(SlotData, registry)
            .Write(CursorItem, registry);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetContainerContentPacket {
        WindowId = r.ReadVarInt(),
        StateId = r.ReadVarInt(),
        SlotData = r.ReadPrefixedArray<ItemStack>(reg),
        CursorItem = r.Read<ItemStack>(reg)
    };
}
