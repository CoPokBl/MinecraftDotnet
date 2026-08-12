using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Opens the inventory screen of a ridden entity, such as a horse or a llama.</summary>
public class ClientBoundOpenMountScreenPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:mount_screen_open";

    public required int WindowId { get; init; }
    public required int InventoryColumns { get; init; }
    public required int EntityId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(InventoryColumns)
            .WriteInteger(EntityId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundOpenMountScreenPacket {
        WindowId = r.ReadVarInt(),
        InventoryColumns = r.ReadVarInt(),
        EntityId = r.ReadInteger()
    };
}
