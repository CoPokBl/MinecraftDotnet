// This is the bane of my existence.

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

        // BLOCK COUNT
        w.WriteShort((short)palette.BlockCount());  // Number of non-air blocks in chunk section
        
        // BLOCK STATES
        w.Write(palette.Serialise());
        
        // BIOMES
        w.WriteUnsignedByte(0x00);  // Bits per entry: Single valued (only one block type for the whole sec)
        w.WriteVarInt(0);  // Our single value
        
        return w.ToArray();
    }
}