using System.Diagnostics.CodeAnalysis;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Chunks;

public class ChunkData {
    public const int VanillaOverworldHeight = 384;  // vanilla overworld height
    
    private int ChunkSections => WorldHeight / 16;  // number of sections in a chunk, 24 for vanilla overworld
    
    public ChunkSection[] Sections;  // bottom to top
    
    public Dictionary<IVec3, BlockEntity> BlockEntities = new();  // block entities in this chunk, indexed by position in chunk
    
    // hints for implementations
    public int ChunkX;
    public int ChunkZ;
    public required int WorldHeight { get; init; }

    [SetsRequiredMembers]
    public ChunkData(int worldHeight, ChunkSection[]? sections = null) {
        WorldHeight = worldHeight;
        Sections = sections ?? GenerateEmptySections();
    }

    private ChunkSection[] GenerateEmptySections() {
        ChunkSection[] vals = new ChunkSection[ChunkSections];
        for (int i = 0; i < ChunkSections; i++) {
            vals[i] = new ChunkSection();
        }

        return vals;
    }
    
    public void Fill(uint state) {
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].Fill(state);
        }
    }
    
    public void Fill(IBlock block) {
        Fill(block.StateId);
    }
    
    public void FillRandom() {
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].FillRandom();
        }
    }

    public void PackData() {
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i].PackData();
        }
    }

    public void SetBlock(int x, int y, int z, uint state) {
        int chunkSection = y / 16;  // sections from the bottom
        int chunkY = y % 16;
        Sections[chunkSection].SetBlock(x, chunkY, z, state);
    }
    
    public void SetBlock(int x, int y, int z, IBlock block) {
        SetBlock(x, y, z, block.StateId);
    }
    
    public void SetBlock(IVec3 pos, IBlock block) {
        SetBlock(pos.X, pos.Y, pos.Z, block);
    }

    public uint GetBlock(int x, int y, int z) {
        int chunkSection = y / 16;  // sections from the bottom
        int chunkY = y % 16;
        return Sections[chunkSection].GetBlock(x, chunkY, z);
    }
    
    public IBlock LookupBlock(int x, int y, int z, MinecraftRegistry? registry = null) {
        int chunkSection = y / 16;  // sections from the bottom
        int chunkY = y % 16;
        return Sections[chunkSection].LookupBlock(x, chunkY, z, registry);
    }
    
    public IBlock LookupBlock(IVec3 pos, MinecraftRegistry? registry = null) {
        return LookupBlock(pos.X, pos.Y, pos.Z, registry);
    }
    
    public void Write(DataWriter w, MinecraftRegistry reg) {
        // https://minecraft.wiki/w/Java_Edition_protocol/Chunk_format#Heightmap_structure
        // Height map, not quite sure how this works
        w.WriteVarInt(0);  // no hightmaps pls
        // w.WriteVarInt(5);  // hightmap count
        // for (int i = 0; i < 5; i++) {
        //     w.WriteVarInt(i);  // type
        //     int heightMapBitsPerEntry = (int)Math.Ceiling(Math.Log2(worldHeight + 1));
        //     long[] heightmap = new long[16 * 16];
        //     for (int i2 = 0; i2 < heightmap.Length; i2++) {
        //         heightmap[i2] = worldHeight-1;
        //     }
        //     w.WritePacketDataArray(heightMapBitsPerEntry, heightmap, true);
        // }
        

        // Chunk data
        DataWriter chunks = new();
        foreach (ChunkSection chunkSection in Sections) {
            chunks.Write(chunkSection);
        }
        
        List<byte> chunkData = chunks.GetRaw()!;
        w.WriteVarInt(chunkData.Count);  // length of chunk data
        w.Write(chunkData);  // write the chunk data
        
        // prefixed array of block entities
        w.WritePrefixedArray(BlockEntities.Values.ToArray(), (entity, wr) => entity.WriteData(entity, wr, reg));
    }

    public static ChunkData Read(DataReader r, MinecraftRegistry reg) {
        // TODO: Heightmaps
        int heightMaps = r.ReadVarInt();
        for (int i = 0; i < heightMaps; i++) {
            r.ReadVarInt();  // type
            r.ReadPrefixedArray(re => re.ReadLong());  // packed data
        }
        
        // NON PREFIXED CHUNK SECTION ARRAY (dependant on world height)
        int sectionBytes = r.ReadVarInt();  // bytes used in the following chunk sections
        long startPos = r.Position;  // start position of the chunk sections

        List<ChunkSection> sections = [];
        while (true) {
            sections.Add(new ChunkSection().Read(r));
            if (r.Position - startPos >= sectionBytes) {
                break;  // we have read all sections
            }
        }
        
        int worldHeight = sections.Count * 16;  // calculate world height from sections
        
        Dictionary<IVec3, BlockEntity> blockEntities = r
            .ReadPrefixedArray(re => BlockEntity.ReadData(re, reg))
            .ToDictionary(a => new IVec3(a.X, a.Y, a.Z));

        return new ChunkData(worldHeight) {
            Sections = sections.ToArray(),
            BlockEntities = blockEntities
        };
    }
}