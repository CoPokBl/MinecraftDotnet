using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Sets one of a container's properties, such as a furnace's burn time or an enchanting table's
/// level requirements. Which properties exist depends on the container.
/// </summary>
public class ClientBoundSetContainerPropertyPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:container_set_data";

    public required int WindowId { get; init; }
    public required short Property { get; init; }
    public required short Value { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(WindowId)
            .WriteShort(Property)
            .WriteShort(Value);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetContainerPropertyPacket {
        WindowId = r.ReadVarInt(),
        Property = r.ReadShort(),
        Value = r.ReadShort()
    };
}
