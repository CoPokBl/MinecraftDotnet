namespace Minecraft.Schemas.Chunks.Palettes;

/// <summary>
/// Every entry as a raw registry id, with no palette table in front of it. Vanilla's
/// <c>GlobalPalette</c>, what a section falls back to once it holds more distinct values than an
/// <see cref="IndirectPalette"/> can index.
/// </summary>
/// <remarks>
/// <b>The bits per entry are not ours to choose.</b> <c>PalettedContainer.read</c> sizes its
/// <c>SimpleBitStorage</c> from <c>Configuration.bitsInMemory()</c> rather than from the bits byte it
/// just read, and for the global palette that is <c>Mth.ceillog2</c> of the registry's size. So the
/// width has to be exactly <see cref="Minecraft.Schemas.Mth.CeilLog2"/> of the number of block states
/// in the game, not the smallest width the values in hand happen to fit in. Send a narrower one and
/// the client unpacks at the wrong stride and misparses the whole section without erroring.
/// <p/>
/// <c>GlobalPalette.write</c> is an empty method, so unlike the other two shapes this writes no
/// palette array: the wire form is the bits byte and then the longs.
/// <p/>
/// Immutable once built, like every <see cref="Palette"/>. See the remarks on
/// <see cref="ChunkSection.Clone"/> for why that matters.
/// </remarks>
public class DirectPalette : Palette {
    /// <summary>The value at every position, flat, in y then z then x order.</summary>
    public readonly uint[] Values;

    /// <summary>
    /// The registry's block state count, which is what <see cref="BitsPerEntry"/> comes from. Carried
    /// rather than looked up so a palette read off the wire keeps the width it was read at.
    /// </summary>
    public readonly long GlobalCount;

    public readonly int BitsPerEntry;

    public override bool HasData => Values.Length > 0;

    public DirectPalette(uint[] values, int d, int maxbpe, int minbpe, long globalCount)
        : base(d, maxbpe, minbpe) {

        if (values.Length != d * d * d) {
            throw new ArgumentException($"Expected {d * d * d} values, got {values.Length}.", nameof(values));
        }

        Values = values;
        GlobalCount = globalCount;
        BitsPerEntry = Mth.CeilLog2((int)globalCount);
    }

    public override uint GetBlock(int x, int y, int z) {
        return Values[x + Dimension*z + Dimension*Dimension*y];
    }

    protected override byte[] BuildSerialised() {
        return new DataWriter()
            .WriteUnsignedByte((byte)BitsPerEntry)
            .WritePacketDataArray(BitsPerEntry, (ReadOnlySpan<uint>)Values)
            .ToArray();
    }

    public override int Count(Func<uint, bool> predicate) {
        // No palette to memo against, so unlike IndirectPalette this really does test every entry.
        // That is the cost of a direct section and is why one is worth avoiding.
        int count = 0;
        foreach (uint value in Values) {
            if (predicate(value)) {
                count++;
            }
        }

        return count;
    }

    public override uint[,,] GetData() {
        uint[,,] data = new uint[Dimension, Dimension, Dimension];
        int i = 0;
        for (int y = 0; y < Dimension; y++) {
            for (int z = 0; z < Dimension; z++) {
                for (int x = 0; x < Dimension; x++) {
                    data[x, y, z] = Values[i++];
                }
            }
        }
        return data;
    }
}
