using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBlockUpdatePacket : ClientBoundPacket {
    public required BlockPosition Location;
    public required IBlock Block;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteVarInt((int)Block.StateId)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundBlockUpdatePacket {
        Location = r.ReadPosition(),
        Block = reg.Blocks[(uint)r.ReadVarInt()]
    };
}
