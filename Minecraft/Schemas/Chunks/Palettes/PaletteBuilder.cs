namespace Minecraft.Schemas.Chunks.Palettes;

/// <summary>
/// Builds a <see cref="Palette"/> from a flat buffer of values in y then z then x order, which is the
/// order <see cref="IndirectPalette.Blocks"/> and <see cref="ChunkSection.FillFlatStateIds"/> already
/// use.
/// </summary>
/// <remarks>
/// One pass, with the reverse lookup in a small open addressed probe map. The obvious alternative is
/// quadratic: <c>IndirectPalette</c>'s <c>uint[,,]</c> constructor calls <c>List&lt;uint&gt;.IndexOf</c>
/// once per position, which costs about a million comparisons over a chunk.
/// <p/>
/// The map is deliberately small. A dense table indexed by state id would be a hundred and twenty odd
/// kilobytes per thread and would evict most of L2 for a palette that is almost always under sixteen
/// entries.
/// </remarks>
public static class PaletteBuilder {
    /// <summary>
    /// Slots in the probe map. A power of two so the wrap is a mask, and comfortably more than the
    /// 256 entries an indirect palette can hold so the table never fills.
    /// </summary>
    private const int Slots = 512;
    private const int SlotMask = Slots - 1;

    /// <summary>
    /// The probe map, per thread because chunks are generated on the pool concurrently.
    /// <p/>
    /// Cleared by a stamp rather than by <c>Array.Clear</c>: a slot counts as empty unless its stamp
    /// is the current one, so starting a build is an increment instead of writing two kilobytes.
    /// </summary>
    [ThreadStatic] private static uint[]? _probeKeys;
    [ThreadStatic] private static ushort[]? _probeValues;
    [ThreadStatic] private static int[]? _probeStamps;
    [ThreadStatic] private static int _stamp;

    /// <summary>
    /// The palette for <paramref name="values"/>, which must hold exactly
    /// <paramref name="dimension"/> cubed entries.
    /// </summary>
    /// <param name="globalCount">
    /// How many values the registry behind these ids holds, which is the width a
    /// <see cref="DirectPalette"/> has to be written at. Only read if one is needed.
    /// </param>
    public static Palette FromFlat(ReadOnlySpan<uint> values, int dimension, int maxBitsPerEntry,
        int minBitsPerEntry, long globalCount) {

        int volume = dimension * dimension * dimension;
        if (values.Length != volume) {
            throw new ArgumentException($"Expected {volume} values, got {values.Length}.", nameof(values));
        }

        int maxPaletteSize = 1 << maxBitsPerEntry;
        if (maxPaletteSize > Slots / 2) {
            // The probe loop below relies on never filling the table. Both callers are well under
            // this (256 for blocks, 8 for biomes) and a wider one wants a bigger map, not a silent
            // spin.
            throw new ArgumentOutOfRangeException(nameof(maxBitsPerEntry),
                $"A palette of up to {maxPaletteSize} entries does not fit {Slots} probe slots.");
        }

        uint[] keys = _probeKeys ??= new uint[Slots];
        ushort[] slotValues = _probeValues ??= new ushort[Slots];
        int[] stamps = _probeStamps ??= new int[Slots];

        int stamp = ++_stamp;
        if (stamp == 0) {
            // Wrapped, so a stale slot could pass for a current one. Four billion sections into a
            // thread's life, and the fix is the clear the stamp exists to avoid.
            Array.Clear(stamps);
            stamp = _stamp = 1;
        }

        ushort[] indices = new ushort[volume];
        uint[] palette = new uint[Math.Min(maxPaletteSize, volume)];
        int distinct = 0;

        for (int i = 0; i < volume; i++) {
            uint value = values[i];

            // Fibonacci hash, which spreads the low entropy of sequential state ids across the slots.
            int slot = (int)((value * 2654435761u) >> 23) & SlotMask;
            while (stamps[slot] == stamp && keys[slot] != value) {
                slot = (slot + 1) & SlotMask;
            }

            if (stamps[slot] == stamp) {
                indices[i] = slotValues[slot];
                continue;
            }

            if (distinct == maxPaletteSize) {
                // Too many distinct values to index, and the direct form wants the values themselves
                // rather than indices into them, so nothing gathered so far is worth keeping.
                return new DirectPalette(values.ToArray(), dimension, maxBitsPerEntry, minBitsPerEntry,
                    globalCount);
            }

            keys[slot] = value;
            slotValues[slot] = (ushort)distinct;
            stamps[slot] = stamp;
            palette[distinct] = value;
            indices[i] = (ushort)distinct;
            distinct++;
        }

        if (distinct == 1) {
            return new SingleValuePalette(dimension, maxBitsPerEntry, minBitsPerEntry, palette[0]);
        }

        if (distinct != palette.Length) {
            Array.Resize(ref palette, distinct);
        }

        return new IndirectPalette(palette, indices, dimension, maxBitsPerEntry, minBitsPerEntry);
    }
}
