// This is the bane of my existence.

using Minecraft.Schemas.Chunks.Palettes;

namespace Minecraft.Schemas.Chunks;

/// <summary>
/// A 16x16x16 set of blocks.
///
/// https://minecraft.wiki/w/Java_Edition_protocol/Chunk_format#Data_structure
/// </summary>
public class ChunkSection : IWritable, IDataReadable<ChunkSection> {
    public const int Size = 16;  // size of a chunk section in blocks (16x16x16)
    
    /// <summary>
    /// The blocks in this section.
    /// 3D array of 16x16x16 blocks, each block is a uint representing the block state.
    /// <p/>
    /// Coordinate order is: X, Y, Z.
    /// </summary>
    public uint[][][] Blocks { get; private set; } = NewBlockSet();

    private static uint[][][] NewBlockSet() {
        uint[][][] blocks = new uint[Size][][];
        for (int x = 0; x < Size; x++) {
            blocks[x] = new uint[Size][];
            for (int y = 0; y < Size; y++) {
                blocks[x][y] = new uint[Size];
            }
        }
        return blocks;
    }
    
    public void Fill(uint state) {
        for (int x = 0; x < Size; x++) {
            for (int y = 0; y < Size; y++) {
                for (int z = 0; z < Size; z++) {
                    Blocks[x][y][z] = state;
                }
            }
        }
    }

    public void SetBlock(int x, int y, int z, uint state) {
        Blocks[x][y][z] = state;
    }

    public void SetBlock(BlockPosition pos, uint state) {
        Blocks[pos.X][pos.Y][pos.Z] = state;
    }

    public uint GetBlock(int x, int y, int z) {
        return Blocks[x][y][z];
    }
    
    public uint GetBlock(BlockPosition pos) {
        return Blocks[pos.X][pos.Y][pos.Z];
    }
    
    public void Write(DataWriter w) {
        Palette palette = Palette.CreateOptimisedPalette(Blocks, Size, 8, 4);

        // BLOCK COUNT
        w.WriteShort((short)palette.BlockCount());  // Number of non-air blocks in chunk section
        
        // BLOCK STATES
        w.Write(palette.Serialise());
        
        // BIOMES
        w.WriteUnsignedByte(0x00);  // Bits per entry: Single valued (only one block type for the whole sec)
        w.WriteVarInt(0);  // Our single value
    }

    public ChunkSection Read(DataReader r) {
        short blockCount = r.ReadShort();  // we don't need this
        Palette blocksPalette = Palette.Deserialise(Size, 8, 4, 8, r);
        Palette biomesPalette = Palette.Deserialise(4, 3, 1, 3, r);  // not yet implemented

        Blocks = blocksPalette.GetData();
        if (Blocks.Length == 0) {
            throw new Exception("Empty chunk section");
        }
        return this;
    }
}