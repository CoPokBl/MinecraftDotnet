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
/// <remarks>
/// Not thread-safe, and the failure mode is silent. Blocks live either in a packed
/// <see cref="Palettes.Palette"/> or an unpacked array, and touching one form converts from the
/// other in place; two threads converting at once each build their own copy and the loser's
/// writes vanish with it. A threaded terrain provider must therefore give each thread whole
/// sections — never a slice of one.
/// </remarks>
public class ChunkSection : IWritable, IDataReadable<ChunkSection> {
    public const int Size = 16;  // the dimension of the cubic section (16x16x16)
    public const int BiomeDimension = 4;  // the dimension of the biomes (4x4x4)
    
    // Params for IndirectPalette (Blocks)
    public const int BlocksMaxBpe = 8;  // maximum bits per entry for blocks palette
    public const int BlocksMinBpe = 4;  // minimum bits per entry for blocks palette
    
    // Params for IndirectPalette (Biomes)
    public const int BiomesMaxBpe = 3;  // maximum bits per entry
    public const int BiomesMinBpe = 1;  // minimum bits per entry
    
    private Palette? _palette = new SingleValuePalette(Size, BlocksMaxBpe, BlocksMinBpe, 0);  // initialise with memory-efficient single value palette
    private uint[,,]? _blocks;  // Storing as block states directly, this is memory inefficient but allows for easy modification.

    // in this situation '0' is the first entry in the biomes registry
    private Palette? _biomesPalette = new SingleValuePalette(BiomeDimension, BiomesMaxBpe, BiomesMinBpe, 0);
    private uint[,,]? _biomes;  // Storing as biome states directly, this is memory inefficient but allows for easy modification.
    
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
    /// The one state every position in this section holds, or null when it holds more than one.
    /// </summary>
    /// <remarks>
    /// Deliberately does not go through <see cref="Palette"/>: that getter packs, and packing is a
    /// mutation, so a reader asking a cheap question would convert the section under whoever is
    /// writing it. A section that is currently unpacked answers null even if its contents happen to
    /// be uniform, which costs the caller its fast path and never costs it a wrong answer.
    /// </remarks>
    public uint? UniformState => _palette is SingleValuePalette svp ? svp.Value : null;

    public uint[,,] Biomes {
        get {
            if (_biomes != null) {
                return _biomes;
            }
            
            UnpackBiomes();
            return _biomes!;
        }
        set {
            _biomesPalette = null;
            _biomes = value;
        }
    }
    
    public Palette BiomesPalette {
        get {
            if (_biomesPalette != null) {
                return _biomesPalette;
            }
            
            PackBiomes();
            return _biomesPalette!;
        }
        set {
            _biomes = null;
            _biomesPalette = value;
        }
    }
    
    /// <summary>
    /// A copy that later writes to this section cannot reach. Both halves are carried: a section
    /// that only ever held biomes still has to survive a clone, and dropping them silently resets
    /// the section to biome zero rather than failing.
    /// <p/>
    /// The unpacked arrays are copied and the palettes are shared, which is safe because a
    /// <see cref="Minecraft.Schemas.Chunks.Palettes.Palette"/> is never mutated in place once built:
    /// <see cref="Palettes.Palette.CreateOptimisedPalette"/> fills it in its constructor and
    /// <see cref="UnpackData"/> allocates a fresh array rather than writing through it. So a packed
    /// section clones in constant time, which is what makes snapshotting a chunk per send affordable.
    /// </summary>
    public ChunkSection Clone() {
        ChunkSection clone = new() {
            _blocks = _blocks?.Clone() as uint[,,],
            _palette = _palette,
            _biomes = _biomes?.Clone() as uint[,,],
            _biomesPalette = _biomesPalette
        };
        return clone;
    }

    /// <summary>
    /// Pack data into a <see cref="Minecraft.Schemas.Chunks.Palettes.Palette"/>.
    /// This will reduce memory usage at the cost of being unable to modify the blocks
    /// without unpacking the data again.
    /// <p/>
    /// This method is very expensive.
    /// </summary>
    public void PackData(MinecraftRegistry? registry = null) {
        if (_blocks == null) {
            return;  // already packed
        }
        _palette = Palette.CreateOptimisedPalette(Blocks, Size, BlocksMaxBpe, BlocksMinBpe,
            (registry ?? VanillaRegistry.Data).Blocks.StatesCount);
        _blocks = null;  // clear the blocks, we are now using the palette
    }

    public void UnpackData() {
        if (_palette == null) {
            return;  // already unpacked
        }
        _blocks = Palette.GetData();
        _palette = null;  // clear the palette, we are now using the blocks directly
    }
    
    public void PackBiomes(MinecraftRegistry? registry = null) {
        if (_biomes == null) {
            return;  // already packed
        }
        _biomesPalette = Palette.CreateOptimisedPalette(Biomes, BiomeDimension, BiomesMaxBpe, BiomesMinBpe,
            (registry ?? VanillaRegistry.Data).Biomes.Count);
        _biomes = null;  // clear the biomes, we are now using the palette
    }
    
    public void UnpackBiomes() {
        if (_biomesPalette == null) {
            return;  // already unpacked
        }
        _biomes = _biomesPalette.GetData();
        _biomesPalette = null;  // clear the palette, we are now using the biomes directly
    }
    
    /// <summary>
    /// Highly fast and memory efficient way to fill the section with a single block state.
    /// </summary>
    /// <param name="state">The block state to fill with.</param>
    public void Fill(uint state) {
        _blocks = null;
        _palette = new SingleValuePalette(Size, BlocksMaxBpe, BlocksMinBpe, state);
    }
    
    /// <summary>
    /// Highly fast and memory efficient way to fill the section with a single block state.
    /// </summary>
    /// <param name="block">The block state to fill with.</param>
    public void Fill(IBlock block) {
        Fill(block.StateId);
    }
    
    public void FillBiomes(uint state) {
        _biomes = null;
        _biomesPalette = new SingleValuePalette(BiomeDimension, BiomesMaxBpe, BiomesMinBpe, state);
    }

    /// <summary>
    /// Fills the section with random block states from the specified registry.
    /// </summary>
    /// <param name="registry">The registry to count block states from (defaults to <see cref="VanillaRegistry"/>)</param>
    public void FillRandom(MinecraftRegistry? registry = null) {
        for (int x = 0; x < Size; x++) {
            for (int y = 0; y < Size; y++) {
                for (int z = 0; z < Size; z++) {
                    Blocks[x, y, z] = (uint)Random.Shared.Next((int)(registry ?? VanillaRegistry.Data).Blocks.StatesCount);
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

    public void SetBlock(Vec3<int> pos, uint state) {
        SetBlock(pos.X, pos.Y, pos.Z, state);
    }

    public uint GetBlock(int x, int y, int z) {
        if (_palette != null) {
            return _palette.GetBlock(x, y, z);
        }
        return Blocks[x, y, z];
    }
    
    public uint GetBlock(Vec3<int> pos) {
        return GetBlock(pos.X, pos.Y, pos.Z);
    }
    
    public IBlock LookupBlock(int x, int y, int z, MinecraftRegistry? registry = null) {
        return (registry ?? VanillaRegistry.Data).Blocks.GetByStateId(GetBlock(x, y, z));
    }
    
    public IBlock LookupBlock(Vec3<int> pos, MinecraftRegistry? registry = null) {
        return (registry ?? VanillaRegistry.Data).Blocks.GetByStateId(GetBlock(pos));
    }
    
    /// <summary>
    /// Fills <paramref name="target"/> with the block state ID at every position in YZX order
    /// (Y outermost, X fastest — the same layout used by <see cref="IndirectPalette.Blocks"/>).
    /// <paramref name="target"/> must have at least 4096 elements.
    /// <p/>
    /// This avoids repeated palette decode and registry lookups in hot paths such as lighting.
    /// </summary>
    public void FillFlatStateIds(Span<uint> target) {
        // Fast path: SingleValuePalette — every position has the same state ID
        if (_palette is SingleValuePalette svp) {
            target[..4096].Fill(svp.Value);
            return;
        }

        // Fast path: IndirectPalette — blocks are already stored in YZX/flat order
        if (_palette is IndirectPalette ip) {
            ReadOnlySpan<ushort> blocks = ip.Blocks;
            ReadOnlySpan<uint> palette = ip.PaletteValues;
            for (int i = 0; i < 4096; i++) {
                target[i] = palette[blocks[i]];
            }
            return;
        }

        // Fallback: section is in unpacked _blocks form (or an unrecognised palette type)
        for (int y = 0; y < Size; y++) {
            for (int z = 0; z < Size; z++) {
                for (int x = 0; x < Size; x++) {
                    target[y * 256 + z * 16 + x] = GetBlock(x, y, z);
                }
            }
        }
    }

    public void SetBiome(int x, int y, int z, uint state) {
        if (_biomesPalette is SingleValuePalette svp && svp.Value == state) {
            // If the palette is already a single value, we can just return
            // this is a memory optimisation for setting an entire section to the same biome.
            return;
        }
        Biomes[x, y, z] = state;
    }
    
    public void SetBiome(Vec3<int> pos, uint state) {
        SetBiome(pos.X, pos.Y, pos.Z, state);
    }
    
    public uint GetBiome(int x, int y, int z) {
        if (_biomesPalette != null) {
            return _biomesPalette.GetBlock(x, y, z);
        }
        return Biomes[x, y, z];
    }
    
    public void Write(DataWriter w) {
        Write(w, VanillaRegistry.Data);
    }

    /// <param name="reg">Used to tell which block states hold a fluid.</param>
    public void Write(DataWriter w, MinecraftRegistry reg) {
        // BLOCK COUNT
        w.WriteShort((short)Palette.BlockCount());  // Number of non-air blocks in chunk section

        // FLUID COUNT
        // The client takes this straight off the wire rather than recounting, and uses it to
        // decide whether the section has fluid in it at all. Keyed on the registry, which is what
        // decides the answer, so a chunk sent to a second player counts nothing again.
        w.WriteShort((short)Palette.Count(reg, state => IsFluid(reg, state)));

        // BLOCK STATES
        w.Write(Palette.Serialise());

        // BIOMES
        w.Write(BiomesPalette.Serialise());
    }

    /// <summary>
    /// Whether a block state carries a fluid, either by being one or by being waterlogged. This is
    /// vanilla's <c>!state.getFluidState().isEmpty()</c>, which is what its own count comes from.
    /// </summary>
    private static bool IsFluid(MinecraftRegistry reg, uint state) {
        // Chunks can carry state ids we don't know, and a section that won't serialise is worse
        // than one whose fluid count is a little off
        if (!reg.Blocks.StatesByStateId.ContainsKey(state)) {
            return false;
        }

        // Fluid is a per state answer, and waterlogging is a property, so this has to be the block
        // at this state rather than the block's default.
        return reg.Blocks.GetByStateId(state).Fluid is not null;
    }

    public ChunkSection Read(DataReader r) {
        return Read(r, VanillaRegistry.Data);
    }

    /// <param name="reg">
    /// Needed for the same reason vanilla's reader takes a registry: a direct palette's stride is
    /// <c>Mth.ceillog2</c> of the registry's size rather than anything on the wire.
    /// </param>
    public ChunkSection Read(DataReader r, MinecraftRegistry reg) {
        r.ReadShort();  // This is the number of non-air blocks in the chunk section, we don't need it
        r.ReadShort();  // Fluid count, likewise
        _palette = Palette.Deserialise(Size, BlocksMaxBpe, BlocksMinBpe, BlocksMaxBpe, r,
            reg.Blocks.StatesCount);
        _biomesPalette = Palette.Deserialise(BiomeDimension, BiomesMaxBpe, BiomesMinBpe, BiomesMaxBpe, r,
            reg.Biomes.Count);

        if (!_palette.HasData) {
            throw new Exception("Empty chunk section");
        }
        return this;
    }
}
