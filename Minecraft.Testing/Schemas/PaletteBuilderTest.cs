using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// Which palette shape a section's contents pick, and the boundary between them.
/// </summary>
/// <remarks>
/// The 256 to 257 step is the one that corrupts silently. An <see cref="IndirectPalette"/> can only
/// index eight bits, and a width clamped to fit still fills the right number of bytes, so the client
/// parses the section without complaint and draws whatever the truncated indices point at.
/// </remarks>
public class PaletteBuilderTest {
    private const int Volume = ChunkSection.Size * ChunkSection.Size * ChunkSection.Size;

    private static readonly long StateCount = VanillaRegistry.Data.Blocks.StatesCount;

    [Test]
    public void OneDistinctValueIsSingleValue() {
        uint[] flat = new uint[Volume];
        Array.Fill(flat, Block.Stone.StateId);

        Palette palette = Build(flat);

        Assert.That(palette, Is.InstanceOf<SingleValuePalette>());
        Assert.That(((SingleValuePalette)palette).Value, Is.EqualTo(Block.Stone.StateId));
    }

    [Test]
    public void AFewDistinctValuesAreIndirect() {
        uint[] flat = new uint[Volume];
        Array.Fill(flat, Block.Stone.StateId);
        flat[0] = Block.Dirt.StateId;
        flat[1] = Block.Air.StateId;

        Palette palette = Build(flat);

        Assert.That(palette, Is.InstanceOf<IndirectPalette>());
        Assert.That(((IndirectPalette)palette).PaletteValues, Has.Length.EqualTo(3));
    }

    /// <summary>Exactly as many distinct values as eight bits can index still fits indirectly.</summary>
    [Test]
    public void TwoHundredAndFiftySixDistinctValuesAreIndirect() {
        Palette palette = Build(Distinct(256));

        Assert.That(palette, Is.InstanceOf<IndirectPalette>());
        Assert.That(((IndirectPalette)palette).PaletteValues, Has.Length.EqualTo(256));
    }

    /// <summary>One more than that cannot be indexed, so it has to go direct.</summary>
    [Test]
    public void TwoHundredAndFiftySevenDistinctValuesAreDirect() {
        Palette palette = Build(Distinct(257));

        Assert.That(palette, Is.InstanceOf<DirectPalette>());
    }

    /// <summary>
    /// Every shape has to answer reads the same way, since the section hands them out through one
    /// interface and the lighting engine and the physics both go through it.
    /// </summary>
    [Test]
    public void EveryShapeReadsBackWhatWasWritten() {
        foreach (int distinct in new[] { 1, 3, 256, 257, 1000 }) {
            uint[] flat = Distinct(distinct);
            Palette palette = Build(flat);

            for (int y = 0; y < ChunkSection.Size; y++) {
                for (int z = 0; z < ChunkSection.Size; z++) {
                    for (int x = 0; x < ChunkSection.Size; x++) {
                        Assert.That(palette.GetBlock(x, y, z),
                            Is.EqualTo(flat[x + ChunkSection.Size*z + ChunkSection.Size*ChunkSection.Size*y]),
                            $"{distinct} distinct values, at {x} {y} {z}");
                    }
                }
            }
        }
    }

    /// <summary>
    /// The <c>uint[,,]</c> path has to agree, since chunks read off the wire and out of a region file
    /// arrive that way and go through it.
    /// </summary>
    [Test]
    public void MatchesTheThreeDimensionalPath() {
        uint[] flat = Distinct(40);
        uint[,,] cube = new uint[ChunkSection.Size, ChunkSection.Size, ChunkSection.Size];
        int i = 0;
        for (int y = 0; y < ChunkSection.Size; y++) {
            for (int z = 0; z < ChunkSection.Size; z++) {
                for (int x = 0; x < ChunkSection.Size; x++) {
                    cube[x, y, z] = flat[i++];
                }
            }
        }

        Palette viaCube = Palette.CreateOptimisedPalette(cube, ChunkSection.Size,
            ChunkSection.BlocksMaxBpe, ChunkSection.BlocksMinBpe, StateCount);

        Assert.That(viaCube.Serialise(), Is.EqualTo(Build(flat).Serialise()));
    }

    /// <summary>
    /// Reaching <c>Serialise</c> with an over-wide indirect palette has to throw. Nothing should be
    /// able to build one, and if something does, a section drawn from the wrong indices is worse than
    /// a crash.
    /// </summary>
    [Test]
    public void OverWideIndirectPaletteRefusesToSerialise() {
        uint[] values = new uint[300];
        for (int i = 0; i < values.Length; i++) {
            values[i] = (uint)i + 1;
        }

        IndirectPalette palette = new(values, new ushort[Volume], ChunkSection.Size,
            ChunkSection.BlocksMaxBpe, ChunkSection.BlocksMinBpe);

        Assert.Throws<InvalidOperationException>(() => palette.Serialise());
    }

    private static Palette Build(ReadOnlySpan<uint> flat) {
        return PaletteBuilder.FromFlat(flat, ChunkSection.Size, ChunkSection.BlocksMaxBpe,
            ChunkSection.BlocksMinBpe, StateCount);
    }

    /// <summary>A section holding exactly <paramref name="count"/> distinct state ids.</summary>
    private static uint[] Distinct(int count) {
        uint[] flat = new uint[Volume];
        for (int i = 0; i < Volume; i++) {
            flat[i] = (uint)(i % count) + 1;  // never 0, so "distinct" counts what it says
        }
        return flat;
    }
}
