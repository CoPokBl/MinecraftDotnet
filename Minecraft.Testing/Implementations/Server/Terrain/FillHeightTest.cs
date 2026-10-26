using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;

namespace Minecraft.Testing.Implementations.Server.Terrain;

/// <summary>
/// <c>FillHeight</c> at every alignment against the section grid.
/// </summary>
/// <remarks>
/// Two things are measured, and the second is the one nothing else catches. The blocks have to be
/// right, and the sections wholly inside the range have to come out as a <b>single value palette</b>:
/// that is the constant time path, and a fill quietly degrading to a per position loop passes on
/// contents alone while costing a flat world 98,304 writes a chunk.
/// <p/>
/// The range is half open, <c>minY</c> inclusive and <c>maxY</c> exclusive, like every other range
/// here.
/// </remarks>
public class FillHeightTest {
    private const int MinY = -64;

    private static ChunkData Fill(int from, int to) {
        return GenerationUnitTest.Generate(new GenerationUnitTest.Lambda(
            unit => unit.Modifier.FillHeight(from, to, Block.Stone)));
    }

    /// <summary>The section holding a game y.</summary>
    private static int SectionOf(int gameY) => (gameY - MinY) / ChunkSection.Size;

    [TestCase(-64, -48, TestName = "aligned to both boundaries, one section")]
    [TestCase(-64, -16, TestName = "aligned to both boundaries, three sections")]
    [TestCase(-60, -52, TestName = "wholly inside one section")]
    [TestCase(-60, -40, TestName = "spanning two sections, both partial")]
    [TestCase(-64, -52, TestName = "aligned at the bottom only")]
    [TestCase(-60, -48, TestName = "aligned at the top only")]
    [TestCase(-64, 0, TestName = "the usual case, floor to game y zero")]
    public void FillsExactlyTheRange(int from, int to) {
        ChunkData chunk = Fill(from, to);

        for (int y = MinY; y < MinY + ChunkData.VanillaOverworldHeight; y++) {
            uint expected = y >= from && y < to ? Block.Stone.StateId : 0;
            Assert.That(chunk.GetBlock(0, y - MinY, 0), Is.EqualTo(expected), $"game y {y}");
            Assert.That(chunk.GetBlock(15, y - MinY, 15), Is.EqualTo(expected), $"corner, game y {y}");
        }
    }

    /// <summary>
    /// Sections the range covers completely take the constant time path; the partial ones at each end
    /// do not, and the ones outside are not touched at all.
    /// </summary>
    [TestCase(-64, -16, 0, 2, TestName = "three whole sections")]
    [TestCase(-60, -16, 1, 2, TestName = "partial bottom, whole middle and top")]
    [TestCase(-64, -20, 0, 1, TestName = "whole bottom and middle, partial top")]
    public void WholeSectionsTakeTheConstantTimePath(int from, int to, int firstWhole, int lastWhole) {
        ChunkData chunk = Fill(from, to);

        for (int s = firstWhole; s <= lastWhole; s++) {
            Assert.That(chunk.Sections[s].UniformState, Is.EqualTo(Block.Stone.StateId),
                $"section {s} should have collapsed to a single value");
        }

        // The partial ones genuinely hold a mixture, so they cannot have.
        int bottomSection = SectionOf(from);
        if (bottomSection < firstWhole) {
            Assert.That(chunk.Sections[bottomSection].Palette, Is.InstanceOf<IndirectPalette>(),
                "the partial section at the bottom");
        }

        int topSection = SectionOf(to - 1);
        if (topSection > lastWhole) {
            Assert.That(chunk.Sections[topSection].Palette, Is.InstanceOf<IndirectPalette>(),
                "the partial section at the top");
        }

        // And nothing above the range was written.
        Assert.That(chunk.Sections[SectionOf(to - 1) + 1].UniformState, Is.EqualTo(0u));
    }

    /// <summary>A range outside the world, or an inverted one, writes nothing rather than throwing.</summary>
    [TestCase(-200, -100, TestName = "entirely below the world")]
    [TestCase(1000, 2000, TestName = "entirely above it")]
    [TestCase(0, 0, TestName = "empty")]
    [TestCase(10, -10, TestName = "inverted")]
    public void RangesOutsideTheWorldDoNothing(int from, int to) {
        ChunkData chunk = Fill(from, to);

        foreach (ChunkSection section in chunk.Sections) {
            Assert.That(section.UniformState, Is.EqualTo(0u));
        }
    }

    /// <summary>A range running off the bottom or top is clipped, not rejected.</summary>
    [Test]
    public void RangesAreClippedToTheWorld() {
        ChunkData chunk = Fill(-500, -60);

        Assert.Multiple(() => {
            Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.Stone.StateId), "the world floor");
            Assert.That(chunk.GetBlock(0, 3, 0), Is.EqualTo(Block.Stone.StateId), "game y -61");
            Assert.That(chunk.GetBlock(0, 4, 0), Is.EqualTo(0u), "game y -60, one past the range");
        });
    }
}
