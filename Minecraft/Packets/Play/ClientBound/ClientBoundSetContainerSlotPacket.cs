using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetContainerSlotPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:container_set_slot";
    
    public required int WindowId { get; init; }
    public required int StateId { get; init; }
    public required short SlotId { get; init; }
    public required ItemStack Data { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(StateId)
            .WriteShort(SlotId)
            .Write(Data, registry);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetContainerSlotPacket {
        WindowId = r.ReadVarInt(),
        StateId = r.ReadVarInt(),
        SlotId = r.ReadShort(),
        Data = r.Read<ItemStack>(reg)
    };
}
