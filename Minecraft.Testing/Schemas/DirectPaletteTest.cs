using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// The wire form of a section holding more distinct states than an indirect palette can index.
/// </summary>
/// <remarks>
/// The width is the part worth pinning. <c>PalettedContainer.read</c> sizes its <c>BitStorage</c> from
/// <c>Configuration.bitsInMemory()</c>, which for the global palette is <c>Mth.ceillog2</c> of the
/// registry's size, and <b>not</b> from the bits byte it just read. So a palette written at the width
/// its own values happen to need is unpacked by the client at a different stride, and every entry
/// after the first comes out as a different block with nothing thrown anywhere.
/// </remarks>
public class DirectPaletteTest {
    private const int Volume = ChunkSection.Size * ChunkSection.Size * ChunkSection.Size;

    private static readonly long StateCount = VanillaRegistry.Data.Blocks.StatesCount;

    [Test]
    public void WidthIsTheRegistrySizeNotTheValuesInHand() {
        // Only three distinct values, but a direct palette is still read at the global width.
        uint[] values = new uint[Volume];
        for (int i = 0; i < Volume; i++) {
            values[i] = (uint)(i % 3);
        }

        DirectPalette palette = new(values, ChunkSection.Size, ChunkSection.BlocksMaxBpe,
            ChunkSection.BlocksMinBpe, StateCount);

        Assert.That(palette.Serialise()[0], Is.EqualTo((byte)Mth.CeilLog2((int)StateCount)));
    }

    /// <summary>
    /// The two "how many bits" helpers disagree on exact powers of two, and only one of them is the
    /// one vanilla reads a direct palette at. This is the case that would go wrong silently the day
    /// the block state count landed on one.
    /// </summary>
    [Test]
    public void CeilLog2IsNotMinBitsToStore() {
        Assert.Multiple(() => {
            Assert.That(Mth.CeilLog2(32768), Is.EqualTo(15));
            Assert.That(32768.MinBitsToStore(), Is.EqualTo(16));

            // Agreeing everywhere else is what makes the difference easy to miss.
            Assert.That(Mth.CeilLog2(32769), Is.EqualTo(16));
            Assert.That(32769.MinBitsToStore(), Is.EqualTo(16));
            Assert.That(Mth.CeilLog2(300), Is.EqualTo(9));
            Assert.That(300.MinBitsToStore(), Is.EqualTo(9));
        });

        // And vanilla's own edges.
        Assert.Multiple(() => {
            Assert.That(Mth.CeilLog2(0), Is.Zero);
            Assert.That(Mth.CeilLog2(1), Is.Zero);
            Assert.That(Mth.CeilLog2(2), Is.EqualTo(1));
            Assert.That(Mth.CeilLog2(3), Is.EqualTo(2));
            Assert.That(Mth.CeilLog2(4), Is.EqualTo(2));
        });
    }

    /// <summary>A direct palette writes no palette array, since vanilla's is an empty method.</summary>
    [Test]
    public void CarriesNoPaletteArray() {
        DirectPalette palette = new(Ascending(300), ChunkSection.Size, ChunkSection.BlocksMaxBpe,
            ChunkSection.BlocksMinBpe, StateCount);

        int bits = Mth.CeilLog2((int)StateCount);
        int entriesPerLong = 64 / bits;
        int longCount = (Volume + entriesPerLong - 1) / entriesPerLong;

        // One bits byte and then nothing but the longs.
        Assert.That(palette.Serialise(), Has.Length.EqualTo(1 + longCount * sizeof(long)));
    }

    [Test]
    public void RoundTrips() {
        foreach (int distinct in new[] { 300, 4096 }) {
            uint[] values = Ascending(distinct);
            DirectPalette written = new(values, ChunkSection.Size, ChunkSection.BlocksMaxBpe,
                ChunkSection.BlocksMinBpe, StateCount);

            Palette read = Palette.Deserialise(ChunkSection.Size, ChunkSection.BlocksMaxBpe,
                ChunkSection.BlocksMinBpe, ChunkSection.BlocksMaxBpe,
                new DataReader(written.Serialise()), StateCount);

            Assert.That(read, Is.InstanceOf<DirectPalette>(), $"{distinct} distinct values");
            for (int i = 0; i < Volume; i++) {
                int x = i % ChunkSection.Size;
                int z = i / ChunkSection.Size % ChunkSection.Size;
                int y = i / (ChunkSection.Size * ChunkSection.Size);
                Assert.That(read.GetBlock(x, y, z), Is.EqualTo(values[i]),
                    $"{distinct} distinct values, at {x} {y} {z}");
            }
        }
    }

    /// <summary>
    /// The largest state id in the game has to survive the trip, which is the case an entry width
    /// taken from anything narrower than the registry would truncate.
    /// </summary>
    [Test]
    public void RoundTripsTheHighestStateId() {
        uint highest = (uint)(StateCount - 1);
        uint[] values = Ascending(300);
        values[0] = highest;
        values[^1] = highest;

        DirectPalette written = new(values, ChunkSection.Size, ChunkSection.BlocksMaxBpe,
            ChunkSection.BlocksMinBpe, StateCount);
        Palette read = Palette.Deserialise(ChunkSection.Size, ChunkSection.BlocksMaxBpe,
            ChunkSection.BlocksMinBpe, ChunkSection.BlocksMaxBpe,
            new DataReader(written.Serialise()), StateCount);

        Assert.Multiple(() => {
            Assert.That(read.GetBlock(0, 0, 0), Is.EqualTo(highest));
            Assert.That(read.GetBlock(15, 15, 15), Is.EqualTo(highest));
        });
    }

    /// <summary>A section that needs a direct palette still serialises and reads back as one.</summary>
    [Test]
    public void SectionWithTooManyStatesSurvivesAWrite() {
        ChunkSection section = new();
        for (int i = 0; i < Volume; i++) {
            int x = i % ChunkSection.Size;
            int z = i / ChunkSection.Size % ChunkSection.Size;
            int y = i / (ChunkSection.Size * ChunkSection.Size);
            section.SetBlock(x, y, z, (uint)(i % 400) + 1);
        }
        section.PackData();

        Assert.That(section.Palette, Is.InstanceOf<DirectPalette>());

        DataWriter writer = new();
        section.Write(writer, VanillaRegistry.Data);

        ChunkSection read = new ChunkSection().Read(new DataReader(writer.ToArray()), VanillaRegistry.Data);

        Assert.That(read.GetBlock(3, 4, 5), Is.EqualTo(section.GetBlock(3, 4, 5)));
        Assert.That(read.GetBlock(15, 15, 15), Is.EqualTo(section.GetBlock(15, 15, 15)));
    }

    /// <summary>A section using every one of <paramref name="distinct"/> ids, cycling.</summary>
    private static uint[] Ascending(int distinct) {
        uint[] values = new uint[Volume];
        for (int i = 0; i < Volume; i++) {
            values[i] = (uint)(i % distinct) + 1;
        }
        return values;
    }
}
