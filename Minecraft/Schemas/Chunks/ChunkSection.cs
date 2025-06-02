using Minecraft.Schemas.Chunks.Palettes;

namespace Minecraft.Schemas.Chunks;

/// <summary>
/// A 16x16x16 set of blocks.
///
/// https://minecraft.wiki/w/Java_Edition_protocol/Chunk_format#Data_structure
/// </summary>
public class ChunkSection {
    /// <summary>
    /// The blocks in this section.
    /// 3D array of 16x16x16 blocks, each block is a uint representing the block state.
    /// <p/>
    /// Coordinate order is: X, Y, Z.
    /// </summary>
    public uint[][][] Blocks { get; } = NewBlockSet();

    private static uint[][][] NewBlockSet() {
        uint[][][] blocks = new uint[16][][];
        for (int x = 0; x < 16; x++) {
            blocks[x] = new uint[16][];
            for (int y = 0; y < 16; y++) {
                blocks[x][y] = new uint[16];
            }
        }
        return blocks;
    }

    public void SetBlock(int x, int y, int z, uint state) {
        Blocks[x][y][z] = state;
    }

    public void SetBlock(BlockPosition pos, uint state) {
        Blocks[pos.X][pos.Y][pos.Z] = state;
    }
    
    public byte[] Serialise() {
        DataWriter w = new();
        
        Palette palette = Palette.CreateOptimisedPalette(Blocks, 16, 8, 4);

        w.WriteShort((short)palette.BlockCount());  // Number of non-air blocks in chunk section
        // w.WriteShort((short)(dirt ? 1 : 0));  // Number of non-air blocks in chunk section
        
        // BLOCK STATES
        w.Write(palette.Serialise());
        
        // DIRECT
        // w.WriteUnsignedByte(15);  // Bits per entry: 15 bits per block state
        // long[] blocks = new long[16*16*16];  // 16x16x16 blocks, all air
        // for (int i = 0; i < blocks.Length; i++) {
        //     blocks[i] = 11;
        // }
        // // blocks[0] = 11;
        // w.WritePacketDataArray(15, blocks, false);  // 16x16x16 blocks, all air
            
        // INDIRECT
        // w.WriteUnsignedByte(4);  // Bits per entry: indirect
        // w.WritePrefixedArray([3, 11, 0], (i, writer) => writer.WriteVarInt(i));  // palette length + palette
        // long[] blocks = new long[16 * 16 * 16];  // 16x16x16 blocks, all dirt
        // for (int i = 0; i < blocks.Length; i++) {
        //     blocks[i] = i % 2 == 0 ? 2 : 1;
        // }
        // w.WritePacketDataArray(4, blocks);  // 16x16x16 blocks, all air
            
        // SINGLE
        // w.WriteUnsignedByte(0x00);  // Bits per entry: Single valued (only one block type for the whole sec)
        // w.WriteVarInt(11);  // Our single value (air), obby is 20477
        
        // BIOMES
        // w.WriteUnsignedByte(0x01);  // Bits per entry: Indirect
        // w.WriteVarInt(1); // Length of palette
        // foreach (int biome in new[] {0x00}) {  // Biomes in the palette
        //     w.WriteVarInt(biome);
        // }
        // // data array for biomes
        // w.WritePrefixedArray([0xCCFFCCFFCCFFCCFFL], (l, writer) => writer.WriteLong((long)l));
        
        // w.WriteUnsignedByte(6);
        // w.WritePacketDataArray(6, new long[64], false);
        
        w.WriteUnsignedByte(0x00);  // Bits per entry: Single valued (only one block type for the whole sec)
        w.WriteVarInt(0);  // Our single value
        
        // w.WriteUnsignedByte(4);  // Bits per entry: indirect
        // w.WritePrefixedArray([3, 11, 0], (i, writer) => writer.WriteVarInt(i));  // palette length + palette
        // long[] biomes = new long[16 * 16 * 16];  // 16x16x16 blocks, all dirt
        // for (int i = 0; i < biomes.Length; i++) {
        //     biomes[i] = 2;
        // }
        // w.WritePacketDataArray(4, biomes);  // 16x16x16 blocks, all air
        
        return w.ToArray();
    }
}