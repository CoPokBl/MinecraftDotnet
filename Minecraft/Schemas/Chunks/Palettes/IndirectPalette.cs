namespace Minecraft.Schemas.Chunks.Palettes;

public class IndirectPalette : Palette {
    public readonly ushort[] Blocks;  // array that maps block -> palette index (y then z then x)
    public readonly uint[] PaletteValues;  // the unique values in the palette

    public override bool HasData => Blocks.Length > 0 && PaletteValues.Length > 0;

    public IndirectPalette(uint[,,] blocks, int d, int maxbpe, int minbpe) : base(d, maxbpe, minbpe) {
        List<uint> palette = [];  // list of unique values

        Blocks = new ushort[(int)Math.Pow(d, 3)];
        
        int i = 0;
        for (int y = 0; y < d; y++) {
            for (int z = 0; z < d; z++) {
                for (int x = 0; x < d; x++) {
                    uint v = blocks[x, y, z];
                    int paletteIndex = palette.IndexOf(v);
                    if (paletteIndex == -1) {
                        paletteIndex = (ushort)palette.Count;
                        palette.Add(v);
                    }

                    Blocks[i++] = (ushort)paletteIndex;
                }
            }
        }

        PaletteValues = palette.ToArray();
    }

    public IndirectPalette(uint[] palette, ushort[] blocks, int d, int maxbpe, int minbpe) : base(d, maxbpe, minbpe) {
        Blocks = blocks;
        PaletteValues = palette;
    }
    
    public override uint GetBlock(int x, int y, int z) {
        // get the index in the blocks array
        // keeping in mind that the blocks are stored in y then z then x order
        // where x is the fastest changing dimension
        return PaletteValues[Blocks[x + Dimension*z + Dimension*Dimension*y]];
    }

    public override byte[] Serialise() {
        int bpe = Math.Min(Math.Max(PaletteValues.Length.MinBitsToStore(), MinBitsPerEntry), MaxBitsPerEntry);
        return new DataWriter()
            .WriteUnsignedByte((byte)bpe)
            .WritePrefixedArray(PaletteValues, (u, writer) => writer.WriteVarInt((int)u))
            .WritePacketDataArray(bpe, Blocks)
            .ToArray();
    }

    public override int Count(Func<uint, bool> predicate) {
        // Test each distinct value once, then tally the entries pointing at the ones that matched
        bool[] matches = new bool[PaletteValues.Length];
        bool any = false;
        for (int i = 0; i < PaletteValues.Length; i++) {
            matches[i] = predicate(PaletteValues[i]);
            any |= matches[i];
        }

        if (!any) {
            return 0;
        }

        int count = 0;
        foreach (ushort index in Blocks) {
            if (matches[index]) {
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
                    data[x, y, z] = PaletteValues[Blocks[i++]];
                }
            }
        }
        return data;
    }
}
