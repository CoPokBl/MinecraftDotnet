using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Asks for an entity's NBT, which the debug screen's copy shortcut uses.</summary>
public class ServerBoundQueryEntityTagPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:entity_tag_query";

    /// <summary>Echoed back in the response so the client can match them up.</summary>
    public required int TransactionId { get; init; }

    public required int EntityId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(TransactionId)
            .WriteVarInt(EntityId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundQueryEntityTagPacket {
        TransactionId = r.ReadVarInt(),
        EntityId = r.ReadVarInt()
    };
}
