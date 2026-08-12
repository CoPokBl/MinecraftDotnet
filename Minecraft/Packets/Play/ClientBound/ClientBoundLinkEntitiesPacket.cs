using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Attaches a leashed entity to its holder.</summary>
public class ClientBoundLinkEntitiesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_entity_link";

    /// <summary>The leashed entity.</summary>
    public required int AttachedEntityId { get; init; }

    /// <summary>The entity holding the lead, or 0 to detach.</summary>
    public required int HoldingEntityId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(AttachedEntityId)
            .WriteInteger(HoldingEntityId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLinkEntitiesPacket {
        AttachedEntityId = r.ReadInteger(),
        HoldingEntityId = r.ReadInteger()
    };
}
