using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Sets a slot of the player's own inventory without going through a container.</summary>
public class ClientBoundSetPlayerInventorySlotPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_player_inventory";

    public required int Slot { get; init; }
    public required ItemStack Contents { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(Slot)
            .Write(Contents, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetPlayerInventorySlotPacket {
        Slot = r.ReadVarInt(),
        Contents = r.Read<ItemStack>(reg)
    };
}
