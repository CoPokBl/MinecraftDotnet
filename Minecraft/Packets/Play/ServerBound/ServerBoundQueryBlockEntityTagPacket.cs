using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Asks for a block entity's NBT, which the debug screen's copy shortcut uses.</summary>
public class ServerBoundQueryBlockEntityTagPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:block_entity_tag_query";

    /// <summary>Echoed back in the response so the client can match them up.</summary>
    public required int TransactionId { get; init; }

    public required Vec3<int> Location { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(TransactionId)
            .WritePosition(Location);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundQueryBlockEntityTagPacket {
        TransactionId = r.ReadVarInt(),
        Location = r.ReadPosition()
    };
}
