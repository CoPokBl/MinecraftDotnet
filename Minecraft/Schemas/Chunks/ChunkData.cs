namespace Minecraft.Schemas.Chunks;

public class ChunkData : IWritable, IDataReadable<ChunkData> {
    private const int WorldHeight = 384;  // vanilla overworld height TODO: Make dynamic or a parameter
    private const int ChunkSections = WorldHeight / 16;  // number of sections in a chunk, 24 for vanilla overworld
    
    public ChunkSection[] Sections = GenerateEmptySections();  // bottom to top
    
    // hints for implementations
    public int ChunkX;
    public int ChunkZ;

    private static ChunkSection[] GenerateEmptySections() {
        ChunkSection[] vals = new ChunkSection[ChunkSections];
        for (int i = 0; i < ChunkSections; i++) {
            vals[i] = new ChunkSection();
        }

        return vals;
    }

    public void SetBlock(int x, int y, int z, uint state) {
        int chunkSection = y / 16;  // sections from the bottom
        int chunkY = y % 16;
        Sections[chunkSection].SetBlock(x, chunkY, z, state);
    }

    public uint GetBlock(int x, int y, int z) {
        int chunkSection = y / 16;  // sections from the bottom
        int chunkY = y % 16;
        return Sections[chunkSection].GetBlock(x, chunkY, z);
    }
    
    public void Write(DataWriter w) {
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
        
        byte[] chunkData = chunks.ToArray();
        w.WriteVarInt(chunkData.Length);  // length of chunk data
        w.Write(chunkData);  // write the chunk data
        
        // prefixed array of block entities, ignore for now
        w.WriteVarInt(0);  // len of 0
    }

    public ChunkData Read(DataReader r) {
        // TODO: Heightmaps
        int heightMaps = r.ReadVarInt();
        for (int i = 0; i < heightMaps; i++) {
            r.ReadVarInt();  // type
            r.ReadPrefixedArray(re => re.ReadLong());  // packed data
        }
        
        // NON PREFIXED CHUNK SECTION ARRAY (dependant on world height)
        r.ReadVarInt();  // bytes used in the following chunk sections, unneeded by us
        for (int i = 0; i < ChunkSections; i++) {
            Sections[i] = new ChunkSection().Read(r);
        }
        
        // TODO: Block entities
        r.ReadPrefixedArray(re => {
            re.Read();
            re.ReadShort();
            re.ReadVarInt();
            re.ReadNbt();
            return false;
        });

        return this;
    }
}