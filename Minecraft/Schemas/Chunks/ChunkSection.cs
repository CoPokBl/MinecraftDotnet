// This is the bane of my existence.

using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Chunks;

/// <summary>
/// A 16x16x16 set of blocks.
/// <p/>
/// https://minecraft.wiki/w/Java_Edition_protocol/Chunk_format#Data_structure
/// </summary>
public class ChunkSection : IWritable, IDataReadable<ChunkSection> {
    public const int Size = 16;  // the dimension of the cubic section (16x16x16)
    
    // Params for IndirectPalette (Blocks)
    public const int MaxBpe = 8;  // maximum bits per entry for blocks palette
    public const int MinBpe = 4;  // minimum bits per entry for blocks palette
    
    private Palette? _palette = new SingleValuePalette(Size, MaxBpe, MinBpe, 0);  // initialise with memory-efficient single value palette
    private uint[,,]? _blocks;  // Storing as block states directly, this is memory inefficient but allows for easy modification.
    
    /// <summary>
    /// The blocks in this section.
    /// 3D array of 16x16x16 blocks, each block is a uint representing the block state.
    /// <p/>
    /// Coordinate order is: X, Y, Z.
    /// </summary>
    /// <remarks>
    /// Please use either this property OR <see cref="Palette"/> as accessing one will delete the other
    /// requiring it to be repacked or unpacked.
    /// </remarks>
    public uint[,,] Blocks {
        get {
            if (_blocks != null) {
                return _blocks;
            }
            
            UnpackData();
            return _blocks!;
        }
        set {
            _palette = null;
            _blocks = value;
        }
    }

    /// <summary>
    /// The blocks in this section.
    /// 3D array of 16x16x16 blocks, represented by a <see cref="Minecraft.Schemas.Chunks.Palettes.Palette"/>.
    /// <p/>
    /// Coordinate order is: X, Y, Z.
    /// </summary>
    /// <remarks>
    /// Please use either this property OR <see cref="Blocks"/> as accessing one will delete the other
    /// requiring it to be repacked or unpacked.
    /// </remarks>
    public Palette Palette {
        get {
            if (_palette != null) {
                return _palette;
            }
            
            PackData();
            return _palette!;
        }
        set {
            _blocks = null;
            _palette = value;
        }
    }

    /// <summary>
    /// Pack data into a <see cref="Minecraft.Schemas.Chunks.Palettes.Palette"/>.
    /// This will reduce memory usage at the cost of being unable to modify the blocks
    /// without unpacking the data again.
    /// <p/>
    /// This method is very expensive.
    /// </summary>
    public void PackData() {
        if (_blocks == null) {
            return;  // already packed
        }
        _palette = Palette.CreateOptimisedPalette(Blocks, Size, MaxBpe, MinBpe);
        _blocks = null;  // clear the blocks, we are now using the palette
    }

    public void UnpackData() {
        if (_palette == null) {
            return;  // already unpacked
        }
        _blocks = Palette.GetData();
        _palette = null;  // clear the palette, we are now using the blocks directly
    }
    
    /// <summary>
    /// Highly fast and memory efficient way to fill the section with a single block state.
    /// </summary>
    /// <param name="state">The block state to fill with.</param>
    public void Fill(uint state) {
        _blocks = null;
        _palette = new SingleValuePalette(Size, MaxBpe, MinBpe, state);
    }
    
    /// <summary>
    /// Highly fast and memory efficient way to fill the section with a single block state.
    /// </summary>
    /// <param name="block">The block state to fill with.</param>
    public void Fill(IBlock block) {
        Fill(block.StateId);
    }

    /// <summary>
    /// Fills the section with random block states from the specified registry.
    /// </summary>
    /// <param name="registry">The registry to count block states from (defaults to <see cref="VanillaRegistry"/>)</param>
    public void FillRandom(MinecraftRegistry? registry = null) {
        for (int x = 0; x < Size; x++) {
            for (int y = 0; y < Size; y++) {
                for (int z = 0; z < Size; z++) {
                    Blocks[x, y, z] = (uint)Random.Shared.Next((int)(registry ?? VanillaRegistry.Data).Blocks.Count);
                }
            }
        }
    }

    public void SetBlock(int x, int y, int z, uint state) {
        if (_palette is SingleValuePalette svp && svp.Value == state) {
            // If the palette is already a single value, we can just return
            // this is a memory optimisation for setting an entire section to air.
            return;
        }
        Blocks[x, y, z] = state;
    }

    public void SetBlock(IVec3 pos, uint state) {
        SetBlock(pos.X, pos.Y, pos.Z, state);
    }

    public uint GetBlock(int x, int y, int z) {
        if (_palette != null) {
            return _palette.GetBlock(x, y, z);
        }
        return Blocks[x, y, z];
    }
    
    public uint GetBlock(IVec3 pos) {
        return GetBlock(pos.X, pos.Y, pos.Z);
    }
    
    public IBlock LookupBlock(int x, int y, int z, MinecraftRegistry? registry = null) {
        return (registry ?? VanillaRegistry.Data).Blocks[GetBlock(x, y, z)];
    }
    
    public IBlock LookupBlock(IVec3 pos, MinecraftRegistry? registry = null) {
        return (registry ?? VanillaRegistry.Data).Blocks[GetBlock(pos)];
    }
    
    public void Write(DataWriter w) {
        // BLOCK COUNT
        w.WriteShort((short)Palette.BlockCount());  // Number of non-air blocks in chunk section
        
        // BLOCK STATES
        w.Write(Palette.Serialise());
        
        // BIOMES
        w.WriteUnsignedByte(0x00);  // Bits per entry: Single valued (only one block type for the whole sec)
        w.WriteVarInt(0);  // Our single value
    }

    public ChunkSection Read(DataReader r) {
        short blockCount = r.ReadShort();  // we don't need this
        _palette = Palette.Deserialise(Size, 8, 4, 8, r);
        Palette biomesPalette = Palette.Deserialise(4, 3, 1, 3, r);  // not yet implemented
        
        if (!_palette.HasData) {
            throw new Exception("Empty chunk section");
        }
        return this;
    }
}
