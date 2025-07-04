using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBlockUpdatePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_update";
    
    public required BlockPosition Location;
    public required IBlock Block;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteVarInt((int)Block.StateId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundBlockUpdatePacket {
        Location = r.ReadPosition(),
        Block = reg.Blocks[(uint)r.ReadVarInt()]
    };
}
