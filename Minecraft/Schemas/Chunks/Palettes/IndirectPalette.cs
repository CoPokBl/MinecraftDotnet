namespace Minecraft.Schemas.Chunks.Palettes;

public class IndirectPalette : Palette {
    public readonly long[] Blocks;  // array that maps block -> palette index (y then z then x)
    public readonly uint[] PaletteValues;  // the unique values in the palette

    public IndirectPalette(uint[][][] blocks, int d, int maxbpe, int minbpe) : base(d, maxbpe, minbpe) {
        List<uint> palette = [];  // list of unique values

        Blocks = new long[(int)Math.Pow(d, 3)];
        
        int i = 0;
        for (int y = 0; y < d; y++) {
            for (int z = 0; z < d; z++) {
                for (int x = 0; x < d; x++) {
                    uint v = blocks[x][y][z];
                    int paletteIndex;
                    if (!palette.Contains(v)) {
                        paletteIndex = palette.Count;
                        palette.Add(v);
                    }
                    else {
                        paletteIndex = palette.IndexOf(v);
                    }

                    Blocks[i++] = paletteIndex;
                }
            }
        }

        PaletteValues = palette.ToArray();
    }

    public IndirectPalette(uint[] palette, long[] blocks, int d, int maxbpe, int minbpe) : base(d, maxbpe, minbpe) {
        Blocks = blocks;
        PaletteValues = palette;
    }

    public override byte[] Serialise() {
        int bpe = Math.Min(Math.Max(PaletteValues.Length.MinBitsToStore(), MinBitsPerEntry), MaxBitsPerEntry);
        return new DataWriter()
            .WriteUnsignedByte((byte)bpe)
            .WritePrefixedArray(PaletteValues, (u, writer) => writer.WriteVarInt((int)u))
            .WritePacketDataArray(bpe, Blocks)
            .ToArray();
    }

    public override int BlockCount() {
        if (!PaletteValues.Contains((uint)0)) return 0; // palette doesn't have air
        
        for (int i = 0; i < PaletteValues.Length; i++) {
            if (PaletteValues[i] == 0) {
                return Blocks.Count(v => v == i);
            }
        }

        throw new Exception("This cannot happen");
    }

    public override uint[][][] GetData() {
        uint[][][] data = new uint[Dimension][][];
        int i = 0;
        for (int y = 0; y < Dimension; y++) {
            for (int z = 0; z < Dimension; z++) {
                for (int x = 0; x < Dimension; x++) {
                    if (data[x] == null!) data[x] = new uint[Dimension][];
                    if (data[x][y] == null!) data[x][y] =  new uint[Dimension];
                    data[x][y][z] = PaletteValues[Blocks[i++]];
                }
            }
        }
        return data;
    }
}