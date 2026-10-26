using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when the player scrolls through the items inside a bundle.</summary>
public class ServerBoundSelectBundleItemPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:bundle_item_selected";

    /// <summary>The slot the bundle is in.</summary>
    public required int SlotId { get; init; }

    /// <summary>Index of the item inside the bundle, or -1 for none.</summary>
    public required int SelectedItemIndex { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(SlotId)
            .WriteVarInt(SelectedItemIndex);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSelectBundleItemPacket {
        SlotId = r.ReadVarInt(),
        SelectedItemIndex = r.ReadVarInt()
    };
}
