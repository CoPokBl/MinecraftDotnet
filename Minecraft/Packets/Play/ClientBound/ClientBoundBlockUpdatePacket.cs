using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBlockUpdatePacket : ClientBoundPacket {
    public required BlockPosition Location;
    public required int BlockId;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteVarInt(BlockId)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundBlockUpdatePacket {
        Location = r.ReadPosition(),
        BlockId = r.ReadVarInt()
    };
}
