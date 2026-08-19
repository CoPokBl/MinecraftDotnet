using System.Diagnostics.CodeAnalysis;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Chunks;

public class ChunkData {
    public const int VanillaOverworldHeight = 384;  // vanilla overworld height
    
    private int ChunkSections => WorldHeight / ChunkSection.Size;  // number of sections in a chunk, 24 for vanilla overworld
    
    public ChunkSection[] Sections;  // bottom to top
    
    public Dictionary<Vec3<int>, BlockEntity> BlockEntities = new();  // block entities in this chunk, indexed by position in chunk
    
    // hints for implementations
    public int ChunkX;
    public int ChunkZ;
    public required int WorldHeight { get; init; }

    /// <summary>
    /// The lowest block y this chunk's world holds, the dimension's min y. Zero unless something sets
    /// it, so a chunk dealing only in protocol y can ignore it.
    /// <p/>
    /// Everything else on this type is in protocol y, counting up from the world's floor; this is the
    /// one thing that says what that floor is. A terrain generator works in real y, and takes it from
    /// here rather than open-coding <c>-64</c>.
    /// </summary>
    /// <remarks>
    /// Settable rather than <c>init</c> on purpose. A loader is handed a chunk by reference and may
    /// replace it wholesale (<c>PolarLoader</c> and <c>AnvilLoader</c> both hand back a clone of a
    /// stored chunk), so whatever is driving the load has to be able to stamp this on the object that
    /// actually came back.
    /// </remarks>
    public int MinY { get; set; }

    /// <summary>
    /// What every block position in this chunk is worth, most recently computed.
    /// <p/>
    /// Cached because <see cref="Write"/> runs once per recipient rather than once per chunk: a
    /// packet is serialised by each connection it goes to. Dropped by anything that writes a block,
    /// since a heightmap is a fact about the contents and not about the chunk.
    /// </summary>
    private Heightmaps? _heightmaps;

    [SetsRequiredMembers]
    public ChunkData(int worldHeight, ChunkSection[]? sections = null) {
        WorldHeight = worldHeight;
        Sections = sections ?? GenerateEmptySections();
    }

    public ChunkData Clone() {
        // The heightmaps are deliberately not carried: a clone can be written to independently, and
        // recomputing them is cheaper than reasoning about when the copy stopped being true.
        ChunkData clone = new(WorldHeight) {
            ChunkX = ChunkX,
            ChunkZ = ChunkZ,
            MinY = MinY,
            Sections = new ChunkSection[ChunkSections],
            BlockEntities = new Dictionary<Vec3<int>, BlockEntity>(BlockEntities)
        };
        
        for (int i = 0; i < ChunkSections; i++) {
            clone.Sections[i] = Sections[i].Clone();
        }
        
        return clone;
    }

    /// <summary>
    /// A frozen copy safe to hand to another thread, which is what a chunk packet must carry.
    /// <p/>
    /// <see cref="Write"/> is not a read: it reaches the sections through
    /// <see cref="ChunkSection.Palette"/>, whose getter calls <see cref="ChunkSection.PackData"/> and
    /// swaps the section's representation. So two threads serialising the same live section race with
    /// each other, and either races with a <see cref="SetBlock"/> going the other way through
    /// <see cref="ChunkSection.Blocks"/>. Packing first and then cloning settles the representation
    /// while the caller still holds the write lock, after which the copy is read only in practice and
    /// the original can be edited freely.
    /// <p/>
    /// Cheap for the common case: <see cref="PackData"/> is a no-op for sections nobody has edited,
    /// and a packed section clones by sharing its immutable palette.
    /// </summary>
    public ChunkData Snapshot() {
        PackData();
        return Clone();
    }

    private ChunkSection[] GenerateEmptySections() {
        ChunkSection[] vals = new ChunkSection[ChunkSections];
        for (int i = 0; i < ChunkSections; i++) {
            vals[i] = new ChunkSection();
        }

        return vals;
    }
    
    public void Fill(uint state) {
        _heightmaps = null;
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].Fill(state);
        }
    }

    public void Fill(IBlock block) {
        Fill(block.StateId);
    }

    public void FillRandom() {
        _heightmaps = null;
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].FillRandom();
        }
    }

    /// <summary>
    /// Marks the cached heightmaps stale. Only needed by something that reaches past
    /// <see cref="SetBlock(int,int,int,uint)"/> into <see cref="Sections"/> directly, which the
    /// terrain generation path does because it commits whole sections at once.
    /// </summary>
    public void InvalidateHeightmaps() {
        _heightmaps = null;
    }

    public void PackData(MinecraftRegistry? registry = null) {
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].PackData(registry);
        }
    }

    public int GetYSection(int y, out int chunkY)
    {
        chunkY = y % ChunkSection.Size;
        return y / ChunkSection.Size;  // sections from the bottom
    }

    public void SetBlock(int x, int y, int z, uint state)
    {
        _heightmaps = null;
        int chunkSection = GetYSection(y, out int chunkY);
        Sections[chunkSection].SetBlock(x, chunkY, z, state);
    }

    public void SetBlock(int x, int y, int z, IBlock block) {
        SetBlock(x, y, z, block.StateId);
    }
    
    public void SetBlock(Vec3<int> pos, IBlock block) {
        SetBlock(pos.X, pos.Y, pos.Z, block);
    }

    public uint GetBlock(int x, int y, int z)
    {
        int chunkSection = GetYSection(y, out int chunkY);
        return Sections[chunkSection].GetBlock(x, chunkY, z);
    }

    #region biomes

    /*
     * Biomes are stored one per 4x4x4 cell rather than per block, so these take block coordinates and
     * round down to the cell holding them. The stored value is the biome's index in the registry,
     * which for a SequentialRegistry is its protocol id, and not a state id like a block's.
     *
     * Everything below is a passthrough to the section, which has had the storage all along. Without
     * them there was no route to it from a chunk at all, so every chunk in every world shipped as
     * whatever sits at index 0.
     */

    public void SetBiome(int x, int y, int z, uint biomeId) {
        int chunkSection = GetYSection(y, out int chunkY);
        Sections[chunkSection].SetBiome(x / ChunkSection.BiomeDimension, chunkY / ChunkSection.BiomeDimension,
            z / ChunkSection.BiomeDimension, biomeId);
    }

    public void SetBiome(Vec3<int> pos, uint biomeId) {
        SetBiome(pos.X, pos.Y, pos.Z, biomeId);
    }

    public void SetBiome(int x, int y, int z, IBiome biome, MinecraftRegistry? registry = null) {
        SetBiome(x, y, z, BiomeId(biome, registry));
    }

    public void SetBiome(Vec3<int> pos, IBiome biome, MinecraftRegistry? registry = null) {
        SetBiome(pos.X, pos.Y, pos.Z, BiomeId(biome, registry));
    }

    public uint GetBiome(int x, int y, int z) {
        int chunkSection = GetYSection(y, out int chunkY);
        return Sections[chunkSection].GetBiome(x / ChunkSection.BiomeDimension,
            chunkY / ChunkSection.BiomeDimension, z / ChunkSection.BiomeDimension);
    }

    /// <summary>The whole chunk, in constant time per section.</summary>
    public void FillBiomes(uint biomeId) {
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].FillBiomes(biomeId);
        }
    }

    public void FillBiomes(IBiome biome, MinecraftRegistry? registry = null) {
        FillBiomes(BiomeId(biome, registry));
    }

    /// <summary>
    /// A biome's registry index. A <c>SequentialRegistry</c> hands out its entries' positions as their
    /// protocol ids, and the palette stores exactly that.
    /// </summary>
    public static uint BiomeId(IBiome biome, MinecraftRegistry? registry = null) {
        return (uint)(registry ?? VanillaRegistry.Data).Biomes.GetProtocolId(biome);
    }

    #endregion
    
    public IBlock LookupBlock(int x, int y, int z, MinecraftRegistry? registry = null)
    {
        int chunkSection = GetYSection(y, out int chunkY);
        return Sections[chunkSection].LookupBlock(x, chunkY, z, registry);
    }
    
    public IBlock LookupBlock(Vec3<int> pos, MinecraftRegistry? registry = null) {
        return LookupBlock(pos.X, pos.Y, pos.Z, registry);
    }
    
    public void Write(DataWriter w, MinecraftRegistry reg) {
        // https://minecraft.wiki/w/Java_Edition_protocol/Chunk_format#Heightmap_structure
        (_heightmaps ??= Heightmaps.Compute(this, reg)).Write(w, WorldHeight);

        // Chunk data, gathered separately because it goes out length prefixed and the length is only
        // known once every section has been written.
        DataWriter chunks = new(Sections.Length * 2048);
        foreach (ChunkSection chunkSection in Sections) {
            chunkSection.Write(chunks, reg);
        }

        w.WritePrefixedArray(chunks.AsSpan());
        
        // prefixed array of block entities
        w.WritePrefixedArray(BlockEntities.Values.ToArray(), reg);
    }

    public static ChunkData Read(DataReader r, MinecraftRegistry reg) {
        // The world height is not known until the sections have been counted, and the heightmaps come
        // first, so they are read against the only height a chunk on the wire can have. A chunk from
        // a shorter world decodes its sections fine and loses its heightmaps, which are recomputed on
        // the next write anyway.
        Heightmaps? heightmaps = Heightmaps.Read(r, VanillaOverworldHeight);

        // NON PREFIXED CHUNK SECTION ARRAY (dependant on world height)
        int sectionBytes = r.ReadVarInt();  // bytes used in the following chunk sections
        long startPos = r.Position;  // start position of the chunk sections

        List<ChunkSection> sections = [];
        while (true) {
            sections.Add(new ChunkSection().Read(r, reg));
            if (r.Position - startPos >= sectionBytes) {
                break;  // we have read all sections
            }
        }
        
        int worldHeight = sections.Count * 16;  // calculate world height from sections
        
        Dictionary<Vec3<int>, BlockEntity> blockEntities = r
            .ReadPrefixedArray<BlockEntity>(reg)
            .ToDictionary(a => new Vec3<int>(a.X, a.Y, a.Z));

        return new ChunkData(worldHeight) {
            Sections = sections.ToArray(),
            BlockEntities = blockEntities,
            _heightmaps = worldHeight == VanillaOverworldHeight ? heightmaps : null
        };
    }
}