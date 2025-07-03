using System.Diagnostics.CodeAnalysis;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetCenterChunkPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_chunk_cache_center";
    
    public required int X;
    public required int Z;

    [SetsRequiredMembers]
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
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetCenterChunkPacket {
        X = r.ReadVarInt(),
        Z = r.ReadVarInt()
    };
}
