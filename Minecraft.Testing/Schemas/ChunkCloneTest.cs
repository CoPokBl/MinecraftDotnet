using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// Cloning a chunk, which is how a terrain provider hands one out and how a snapshot is taken
/// before serialising.
/// </summary>
/// <remarks>
/// Biomes used to be dropped here, and nothing could see it: a section holds its blocks and its
/// biomes in two independent pairs of fields, so a clone that carried only the block pair still
/// looked like a whole section. The biome half fell back to its field initialiser, which is a
/// single value palette of id zero, and a world loaded through <c>PolarLoader.GetChunk</c> (which
/// returns <c>data.Clone()</c>) came out entirely plains with no error anywhere.
/// </remarks>
public class ChunkCloneTest {
    private const int BiomeDim = ChunkSection.BiomeDimension;

    /// <summary>Two distinct ids so a clone that resets to zero cannot pass by accident.</summary>
    private const uint BiomeA = 3;
    private const uint BiomeB = 7;

    private static ChunkSection SectionWithBiomes() {
        ChunkSection section = new();

        uint[,,] biomes = new uint[BiomeDim, BiomeDim, BiomeDim];
        for (int y = 0; y < BiomeDim; y++) {
            for (int z = 0; z < BiomeDim; z++) {
                for (int x = 0; x < BiomeDim; x++) {
                    biomes[x, y, z] = (x + y + z) % 2 == 0 ? BiomeA : BiomeB;
                }
            }
        }

        section.Biomes = biomes;
        return section;
    }

    private static void AssertBiomesMatch(ChunkSection section) {
        for (int y = 0; y < BiomeDim; y++) {
            for (int z = 0; z < BiomeDim; z++) {
                for (int x = 0; x < BiomeDim; x++) {
                    uint wanted = (x + y + z) % 2 == 0 ? BiomeA : BiomeB;
                    Assert.That(section.Biomes[x, y, z], Is.EqualTo(wanted),
                        $"biome at ({x}, {y}, {z})");
                }
            }
        }
    }

    [Test]
    public void CloneKeepsUnpackedBiomes() {
        ChunkSection original = SectionWithBiomes();

        AssertBiomesMatch(original.Clone());
    }

    /// <summary>
    /// The packed form shares its palette with the clone rather than copying it, so this is also
    /// the test that the sharing is sound.
    /// </summary>
    [Test]
    public void CloneKeepsPackedBiomes() {
        ChunkSection original = SectionWithBiomes();
        original.PackBiomes();

        AssertBiomesMatch(original.Clone());
    }

    /// <summary>
    /// The point of a clone: a later write to the original must not reach it. This is what a chunk
    /// packet relies on once it carries a snapshot instead of the live chunk.
    /// </summary>
    [Test]
    public void CloneIsIndependentOfLaterWrites() {
        ChunkSection original = SectionWithBiomes();
        original.Fill(Block.Stone.StateId);

        ChunkSection clone = original.Clone();

        original.SetBlock(0, 0, 0, Block.Dirt.StateId);
        original.Biomes[0, 0, 0] = BiomeB;

        Assert.Multiple(() => {
            Assert.That(clone.GetBlock(0, 0, 0), Is.EqualTo(Block.Stone.StateId));
            Assert.That(clone.Biomes[0, 0, 0], Is.EqualTo(BiomeA));
        });
    }

    /// <summary>
    /// <c>Snapshot</c> packs before cloning, which settles the representation while the caller still
    /// holds the write lock. Editing the original afterwards unpacks the section it touched and must
    /// leave the snapshot alone.
    /// </summary>
    [Test]
    public void SnapshotIsIndependentOfLaterWrites() {
        ChunkData original = new(ChunkData.VanillaOverworldHeight);
        original.Fill(Block.Stone.StateId);
        original.SetBlock(1, 5, 2, Block.DiamondBlock.StateId);

        ChunkData snapshot = original.Snapshot();

        original.SetBlock(1, 5, 2, Block.Air.StateId);
        original.SetBlock(3, 5, 4, Block.Air.StateId);

        Assert.Multiple(() => {
            Assert.That(snapshot.GetBlock(1, 5, 2), Is.EqualTo(Block.DiamondBlock.StateId));
            Assert.That(snapshot.GetBlock(3, 5, 4), Is.EqualTo(Block.Stone.StateId));
            Assert.That(original.GetBlock(1, 5, 2), Is.EqualTo(Block.Air.StateId));
        });
    }
}
