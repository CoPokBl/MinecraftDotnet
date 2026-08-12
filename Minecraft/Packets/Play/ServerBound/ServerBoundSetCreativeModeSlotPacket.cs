using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// Sent when a creative mode player takes an item out of the item list or drops one into it.
/// The client asserts what the slot now holds, so a server has to check it is allowed to.
/// </summary>
public class ServerBoundSetCreativeModeSlotPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_creative_mode_slot";

    /// <summary>Inventory slot index, or -1 when the item is being thrown away.</summary>
    public required short Slot { get; init; }

    public required ItemStack Item { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteShort(Slot)
            .Write(Item, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ServerBoundSetCreativeModeSlotPacket {
        Slot = r.ReadShort(),
        Item = r.Read<ItemStack>(reg)
    };
}
