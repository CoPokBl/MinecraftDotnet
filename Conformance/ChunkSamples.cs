using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Chunks;

namespace Conformance;

/// <summary>
/// A position in a chunk sample and the state that has to be there, read back out of the decoded
/// section by the harness with vanilla's own <c>getBlockState</c>.
/// </summary>
/// <param name="Section">Index from the bottom of the world, matching <c>ChunkData.Sections</c>.</param>
/// <param name="StateId">The vanilla block state id, which is the number our own writer emitted.</param>
public readonly record struct ChunkProbe(int Section, int X, int Y, int Z, uint StateId);

/// <summary>
/// Chunk packets, which reflection can't fabricate: the sections are a bit packed format whose
/// palettes and bits per entry have to agree with each other, so a default constructed one is
/// either invalid or (worse) trivially empty.
/// </summary>
/// <remarks>
/// Several shapes, because the section encoding branches on how many distinct blocks it holds:
/// one block picks a single value palette, a handful picks an indirect palette sized to fit,
/// and enough of them falls back to writing state ids directly. Only exercising the empty case
/// would leave the interesting branches unchecked.
/// <p/>
/// <b>Each sample carries probe positions, and it needs them.</b> Reading the sections proves the
/// blob is the right length and nothing more, which is not enough for a paletted container: a section
/// written at the wrong bits per entry consumes exactly the right number of bytes and decodes without
/// complaint into different blocks. Clamping an over wide palette changes what the entries mean and
/// not how many there are, so only reading blocks back catches it.
/// </remarks>
public static class ChunkSamples {
    private const int WorldHeight = ChunkData.VanillaOverworldHeight;

    /// <summary>The section count the client will read, which is fixed by the world height.</summary>
    public static int SectionCount => WorldHeight / ChunkSection.Size;

    public static IEnumerable<(string Name, MinecraftPacket Packet, ChunkProbe[] Probes)> Build() {
        yield return Sample("empty", BuildEmpty());
        yield return Sample("single value palette", BuildFilled());
        yield return Sample("indirect palette", BuildIndirect());
        yield return Sample("direct palette", BuildDirect());
    }

    private static (string, MinecraftPacket, ChunkProbe[]) Sample(string label, ChunkData data) {
        // Probed before serialising, so what is asserted is what our own reader says is there, and
        // the harness is the thing that has to agree.
        ChunkProbe[] probes = Probe(data);
        data.PackData();

        MinecraftPacket packet = new ClientBoundChunkDataAndUpdateLightPacket {
            ChunkX = 0,
            ChunkZ = 0,
            Data = data,
            Light = LightData.FullBright
        };

        return ($"ClientBoundChunkDataAndUpdateLightPacket[{label}]", packet, probes);
    }

    /// <summary>
    /// A spread of positions through the chunk: the corners of a section, a few interior cells, and
    /// at least one in every section, so a sample cannot pass by getting one section right.
    /// </summary>
    private static ChunkProbe[] Probe(ChunkData data) {
        (int X, int Y, int Z)[] within = [
            (0, 0, 0), (15, 15, 15), (0, 15, 0), (15, 0, 15),
            (7, 3, 11), (3, 9, 5), (12, 6, 1)
        ];

        List<ChunkProbe> probes = [];
        for (int section = 0; section < SectionCount; section++) {
            foreach ((int x, int y, int z) in within) {
                int protocolY = section * ChunkSection.Size + y;
                probes.Add(new ChunkProbe(section, x, y, z, data.GetBlock(x, protocolY, z)));
            }
        }

        return probes.ToArray();
    }

    private static ChunkData BuildEmpty() {
        return new ChunkData(WorldHeight);
    }

    private static ChunkData BuildFilled() {
        ChunkData data = new(WorldHeight);
        data.Fill(Block.Stone);
        return data;
    }

    /// <summary>A few distinct blocks per section, which is what an indirect palette is for.</summary>
    private static ChunkData BuildIndirect() {
        ChunkData data = new(WorldHeight);
        data.Fill(Block.Stone);

        for (int y = 0; y < WorldHeight; y++) {
            data.SetBlock(y % 16, y, 0, y % 2 == 0 ? Block.Dirt.StateId : Block.Cobblestone.StateId);
        }

        return data;
    }

    /// <summary>
    /// Enough distinct states that the palette stops paying for itself and state ids go out
    /// directly.
    /// </summary>
    /// <remarks>
    /// A fixed stride rather than random fill. A random section cannot be looked at twice after a
    /// failure, and it draws from the whole registry including states the two sides may disagree
    /// about for unrelated reasons; a stride past the 256 an indirect palette can index reaches the
    /// same branch with neither problem.
    /// </remarks>
    private static ChunkData BuildDirect() {
        ChunkData data = new(WorldHeight);

        long states = VanillaRegistry.Data.Blocks.StatesCount;
        for (int y = 0; y < WorldHeight; y++) {
            for (int z = 0; z < ChunkSection.Size; z++) {
                for (int x = 0; x < ChunkSection.Size; x++) {
                    // 400 distinct values per section, which no indirect palette can index, and
                    // spread far enough apart to exercise the wide end of the state id range.
                    long state = (x + z * 16 + y * 256) % 400 * (states / 400);
                    data.SetBlock(x, y, z, (uint)state);
                }
            }
        }

        return data;
    }
}
