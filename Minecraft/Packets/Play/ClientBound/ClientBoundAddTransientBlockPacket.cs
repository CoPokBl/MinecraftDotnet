using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>A block the client shows at a position without it being part of the world.</summary>
public class ClientBoundAddTransientBlockPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:add_transient_block";

    public required Vec3<int> Location { get; init; }
    public required IBlock Block { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteVarInt((int)Block.StateId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundAddTransientBlockPacket {
        Location = r.ReadPosition(),
        Block = reg.Blocks.GetByStateId((uint)r.ReadVarInt())
    };
}
