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

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(X)
            .WriteVarInt(Z);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetCenterChunkPacket {
        X = r.ReadVarInt(),
        Z = r.ReadVarInt()
    };
}
