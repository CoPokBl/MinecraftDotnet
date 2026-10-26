using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// The block and fluid counts a chunk section carries.
/// </summary>
/// <remarks>
/// These ride along with the section but nothing downstream validates them: the client stores
/// both straight off the wire without recounting, so a wrong value is invisible to a decoder
/// and only shows up as a section that renders as air or never ticks its fluid. That makes them
/// unreachable for the conformance harness and a job for tests.
/// </remarks>
public class ChunkSectionCountsTest {
    private const int Blocks = ChunkSection.Size * ChunkSection.Size * ChunkSection.Size;

    [Test]
    public void EmptySectionCountsNothing() {
        ChunkSection section = new();
        section.PackData();

        Assert.That(section.Palette.BlockCount(), Is.Zero);
    }

    [Test]
    public void FilledSectionCountsEveryBlock() {
        ChunkSection section = new();
        section.Fill(Block.Stone.StateId);
        section.PackData();

        Assert.That(section.Palette.BlockCount(), Is.EqualTo(Blocks));
    }

    /// <summary>
    /// The mixed case, which takes the indirect palette path — where the count used to come out
    /// as the number of air blocks instead of the number of real ones.
    /// </summary>
    [Test]
    public void MixedSectionCountsOnlyNonAir() {
        ChunkSection section = new();
        section.Fill(Block.Stone.StateId);
        section.SetBlock(0, 0, 0, Block.Air.StateId);
        section.SetBlock(1, 0, 0, Block.Air.StateId);
        section.PackData();

        Assert.That(section.Palette.BlockCount(), Is.EqualTo(Blocks - 2));
    }

    [Test]
    public void SectionWithoutAirCountsEveryBlock() {
        ChunkSection section = new();
        section.Fill(Block.Stone.StateId);
        section.SetBlock(0, 0, 0, Block.Dirt.StateId);
        section.PackData();

        Assert.That(section.Palette.BlockCount(), Is.EqualTo(Blocks));
    }

    [Test]
    public void FluidCountsOnlyFluidBlocks() {
        ChunkSection section = new();
        section.Fill(Block.Stone.StateId);
        section.SetBlock(0, 0, 0, Block.Water.StateId);
        section.SetBlock(1, 0, 0, Block.Lava.StateId);

        Assert.That(FluidCount(section), Is.EqualTo(2));
    }

    /// <summary>
    /// A waterlogged block holds water without being a fluid itself, which is what vanilla's
    /// <c>getFluidState</c> reports and what the client expects the count to include.
    /// </summary>
    [Test]
    public void FluidCountsWaterloggedBlocks() {
        ChunkSection section = new();
        section.Fill(Block.Stone.StateId);
        section.SetBlock(0, 0, 0, (Block.OakSlab with { Waterlogged = true }).StateId);
        section.SetBlock(1, 0, 0, (Block.OakStairs with { Waterlogged = true }).StateId);
        section.SetBlock(2, 0, 0, Block.Kelp.StateId);
        // The same blocks dry, which the block's own default state cannot tell apart.
        section.SetBlock(3, 0, 0, (Block.OakSlab with { Waterlogged = false }).StateId);
        section.SetBlock(4, 0, 0, (Block.OakStairs with { Waterlogged = false }).StateId);

        Assert.That(FluidCount(section), Is.EqualTo(3));
    }

    /// <summary>The count the section puts on the wire, which is the second short it writes.</summary>
    private static int FluidCount(ChunkSection section) {
        section.PackData();

        DataWriter writer = new();
        section.Write(writer, VanillaRegistry.Data);
        byte[] bytes = writer.ToArray();

        return (bytes[2] << 8) | bytes[3];
    }
}
