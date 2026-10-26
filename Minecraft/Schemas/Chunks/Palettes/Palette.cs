namespace Minecraft.Schemas.Chunks.Palettes;

/// <summary>
/// The values of a cubic section, in whichever of the three wire shapes suits how many distinct ones
/// there are.
/// </summary>
/// <remarks>
/// <b>Immutable once built</b>, which is what lets <see cref="ChunkSection.Clone"/> share one and
/// makes snapshotting a chunk per send cost nothing. <c>PaletteImmutabilityTest</c> pins it, and it
/// is also what makes the memos here safe: a wire form and a count decided once stay right for the
/// life of the object.
/// </remarks>
public abstract class Palette(int dimension, int maxBitsPerEntry, int minBitsPerEntry) {
    /// <summary>
    /// Length of the cube that this palette represents.
    /// </summary>
    public int Dimension { get; } = dimension;

    public int MaxBitsPerEntry { get; } = maxBitsPerEntry;
    public int MinBitsPerEntry { get; } = minBitsPerEntry;

    private byte[]? _serialised;
    private int _blockCount = -1;
    private CountMemo? _countMemo;

    public abstract bool HasData { get; }
    public abstract uint[,,] GetData();
    public abstract uint GetBlock(int x, int y, int z);

    /// <summary>
    /// The wire form of this palette: the bits per entry byte, the palette array where the shape has
    /// one, and the packed data.
    /// </summary>
    /// <remarks>
    /// Built once and handed out by reference, since a chunk is serialised again for every recipient
    /// and every resend. <b>The caller must not write to it.</b>
    /// </remarks>
    public byte[] Serialise() => _serialised ??= BuildSerialised();

    protected abstract byte[] BuildSerialised();

    /// <summary>
    /// How many entries hold a value matching <paramref name="predicate"/>. Only the distinct
    /// palette values are tested, so the predicate can afford to be a registry lookup.
    /// </summary>
    public abstract int Count(Func<uint, bool> predicate);

    /// <summary>
    /// <see cref="Count(Func{uint,bool})"/> memoised against whatever decides the predicate's answers,
    /// usually the registry it reads.
    /// </summary>
    /// <remarks>
    /// One slot, because the caller asking per send asks the same question every time. A key that
    /// does not match simply recounts, so passing the wrong one is slow rather than wrong.
    /// <p/>
    /// The key is compared by reference, so it has to be something that is replaced rather than
    /// edited when the answers change. A registry qualifies in practice, since one is built by the
    /// generator and then read.
    /// </remarks>
    public int Count(object key, Func<uint, bool> predicate) {
        CountMemo? memo = _countMemo;
        if (memo != null && ReferenceEquals(memo.Key, key)) {
            return memo.Value;
        }

        int count = Count(predicate);

        // One field rather than a key and a value, so a concurrent reader sees both halves or neither.
        _countMemo = new CountMemo(key, count);
        return count;
    }

    /// <summary>Entries that aren't air, which is what the client calls the non empty count.</summary>
    public int BlockCount() {
        if (_blockCount < 0) {
            _blockCount = Count(state => state != 0);
        }

        return _blockCount;
    }

    private sealed record CountMemo(object Key, int Value);

    /// <param name="globalCount">
    /// How many values the registry behind these ids holds. Only used if the data needs a
    /// <see cref="DirectPalette"/>, whose width is fixed by it rather than by the values in hand.
    /// </param>
    public static Palette CreateOptimisedPalette(uint[,,] blocks, int d, int maxbpe, int minbpe,
        long globalCount) {

        // Flattened into the y then z then x order every palette shape stores, which is also the one
        // PaletteBuilder wants. The copy is what the caller pays for holding a uint[,,]; a caller with
        // a flat buffer already should call PaletteBuilder.FromFlat and skip this.
        uint[] flat = new uint[d * d * d];
        int i = 0;
        for (int y = 0; y < d; y++) {
            for (int z = 0; z < d; z++) {
                for (int x = 0; x < d; x++) {
                    flat[i++] = blocks[x, y, z];
                }
            }
        }

        return PaletteBuilder.FromFlat(flat, d, maxbpe, minbpe, globalCount);
    }

    /// <param name="globalCount">
    /// The registry size behind these ids, which is the width a direct palette is read at. Vanilla
    /// takes it off the registry rather than off the wire, so the bits byte a direct palette carries
    /// is informational and this is what actually decides the stride.
    /// </param>
    public static Palette Deserialise(int d, int maxbpe, int minbpe, int maxIndirectValue, DataReader r,
        long globalCount) {

        byte bitsPerEntry = r.Read();

        if (bitsPerEntry == 0) {  // single value
            return new SingleValuePalette(d, maxbpe, minbpe, (uint)r.ReadVarInt());
        }

        if (bitsPerEntry <= maxIndirectValue) {  // it's indirect
            uint[] palette = r.ReadPrefixedArray(re => (uint)re.ReadVarInt());
            ushort[] blocks = r.ReadPacketDataArray(bitsPerEntry, d*d*d);
            return new IndirectPalette(palette, blocks, d, maxIndirectValue, minbpe);
        }

        // Direct: no palette array at all, since vanilla's GlobalPalette.write is empty. The width is
        // the registry's, not the byte just read, because that is what the client's own reader uses.
        return new DirectPalette(r.ReadPacketDataArray32(Mth.CeilLog2((int)globalCount), d*d*d), d,
            maxbpe, minbpe, globalCount);
    }
}
