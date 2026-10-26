using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Replaces the biomes of chunks the client already has, without resending the blocks.
/// </summary>
public class ClientBoundChunkBiomesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:chunks_biomes";

    public required ChunkBiomeData[] Chunks { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedArray(Chunks, (chunk, writer) => writer
            // Chunk positions travel as the two ints packed into one long, z in the high half.
            .WriteLong(((long)chunk.ChunkZ << 32) | (uint)chunk.ChunkX)
            .WriteVarInt(chunk.Biomes.Length)
            .Write(chunk.Biomes));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundChunkBiomesPacket {
        Chunks = r.ReadPrefixedArray(reader => {
            long packed = reader.ReadLong();
            return new ChunkBiomeData((int)packed, (int)(packed >> 32), reader.Read(reader.ReadVarInt()));
        })
    };

    /// <param name="ChunkX">Chunk x coordinate.</param>
    /// <param name="ChunkZ">Chunk z coordinate.</param>
    /// <param name="Biomes">
    /// The biome palette of every section in the chunk, back to back, in the same encoding the
    /// palettes use inside <see cref="ClientBoundChunkDataAndUpdateLightPacket"/>.
    /// </param>
    public record ChunkBiomeData(int ChunkX, int ChunkZ, byte[] Biomes);
}
