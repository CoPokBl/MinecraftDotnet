using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetCenterChunkPacket() : ClientBoundPacket {
    public required int X;
    public required int Z;

    public ClientBoundSetCenterChunkPacket(ChunkPosition pos) : this() {
        X = pos.X;
        Z = pos.Z;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(X)
            .WriteVarInt(Z)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSetCenterChunkPacket {
        X = r.ReadVarInt(),
        Z = r.ReadVarInt()
    };
}
