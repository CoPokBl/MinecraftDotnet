using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Triggers a block's animated action, such as a chest opening or a note block playing. The
/// meaning of the two action bytes depends on the block.
/// </summary>
public class ClientBoundBlockActionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_event";

    public required Vec3<int> Location { get; init; }
    public required byte ActionId { get; init; }
    public required byte ActionParameter { get; init; }

    /// <summary>The block the action applies to. Sent as a block id, not a block state id.</summary>
    public required IBlock Block { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePosition(Location)
            .WriteUnsignedByte(ActionId)
            .WriteUnsignedByte(ActionParameter)
            .WriteVarInt(reg.Blocks.GetProtocolId(Block));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundBlockActionPacket {
        Location = r.ReadPosition(),
        ActionId = (byte)r.Read(),
        ActionParameter = (byte)r.Read(),
        Block = reg.Blocks[r.ReadVarInt()]
    };
}
