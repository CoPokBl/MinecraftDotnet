using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Toggles a crafter's slot between enabled and disabled.</summary>
public class ServerBoundChangeContainerSlotStatePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:container_slot_state_changed";

    public required int SlotId { get; init; }
    public required int WindowId { get; init; }

    /// <summary>Whether the slot now takes part in the recipe.</summary>
    public required bool NewState { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(SlotId)
            .WriteVarInt(WindowId)
            .WriteBoolean(NewState);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChangeContainerSlotStatePacket {
        SlotId = r.ReadVarInt(),
        WindowId = r.ReadVarInt(),
        NewState = r.ReadBoolean()
    };
}
