namespace Minecraft.Schemas.Chunks.Palettes;

public abstract class Palette(int dimension, int maxBitsPerEntry, int minBitsPerEntry) {
    /// <summary>
    /// Length of the cube that this palette represents.
    /// </summary>
    public int Dimension = dimension;
    
    public int MaxBitsPerEntry = maxBitsPerEntry;
    public int MinBitsPerEntry = minBitsPerEntry;

    public abstract byte[] Serialise();
    public abstract int BlockCount();

    public static Palette CreateOptimisedPalette(uint[][][] blocks, int d, int maxbpe, int minbpe) {
        // check if all values are the same
        uint firstValue = blocks[0][0][0];
        if (blocks.Any(x => x.Any(y => y.Any(val => val != firstValue)))) {
            return new IndirectPalette(blocks, d, maxbpe, minbpe);
        }

        return new SingleValuePalette(d, maxbpe, minbpe, firstValue);
    }

    public static Palette Deserialise(int d, int maxbpe, int minbpe, int max, DataReader r) {
        byte bitsPerEntry = r.Read();

        if (bitsPerEntry == 0) {  // single value
            return new SingleValuePalette(d, maxbpe, minbpe, (uint)r.ReadVarInt());
        }

        throw new NotImplementedException();
    }
}