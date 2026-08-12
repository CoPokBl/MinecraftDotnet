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
        section.PackData();

        int fluid = section.Palette.Count(state =>
            VanillaRegistry.Data.Blocks.StatesByStateId.TryGetValue(state, out var block) && block.Liquid);

        Assert.That(fluid, Is.EqualTo(2));
    }
}
