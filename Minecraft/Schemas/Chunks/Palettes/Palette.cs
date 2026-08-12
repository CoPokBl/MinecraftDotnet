namespace Minecraft.Schemas.Chunks.Palettes;

public abstract class Palette(int dimension, int maxBitsPerEntry, int minBitsPerEntry) {
    /// <summary>
    /// Length of the cube that this palette represents.
    /// </summary>
    public int Dimension { get; } = dimension;

    public int MaxBitsPerEntry { get; } = maxBitsPerEntry;
    public int MinBitsPerEntry { get; } = minBitsPerEntry;

    public abstract bool HasData { get; }
    public abstract byte[] Serialise();
    public abstract uint[,,] GetData();
    public abstract uint GetBlock(int x, int y, int z);

    /// <summary>
    /// How many entries hold a value matching <paramref name="predicate"/>. Only the distinct
    /// palette values are tested, so the predicate can afford to be a registry lookup.
    /// </summary>
    public abstract int Count(Func<uint, bool> predicate);

    /// <summary>Entries that aren't air, which is what the client calls the non empty count.</summary>
    public int BlockCount() => Count(state => state != 0);

    public static Palette CreateOptimisedPalette(uint[,,] blocks, int d, int maxbpe, int minbpe) {
        // check if all values are the same
        uint firstValue = blocks[0, 0, 0];
        foreach (uint val in blocks) {
            if (val != firstValue) {
                return new IndirectPalette(blocks, d, maxbpe, minbpe);
            }
        }

        return new SingleValuePalette(d, maxbpe, minbpe, firstValue);
    }

    public static Palette Deserialise(int d, int maxbpe, int minbpe, int maxIndirectValue, DataReader r) {
        byte bitsPerEntry = r.Read();

        if (bitsPerEntry == 0) {  // single value
            return new SingleValuePalette(d, maxbpe, minbpe, (uint)r.ReadVarInt());
        }

        if (bitsPerEntry <= maxIndirectValue) {  // it's indirect
            uint[] palette = r.ReadPrefixedArray(re => (uint)re.ReadVarInt());
            ushort[] blocks = r.ReadPacketDataArray(bitsPerEntry, d*d*d);
            return new IndirectPalette(palette, blocks, d, maxIndirectValue, minbpe);
        }

        // direct
        throw new NotImplementedException();
    }
}
