namespace Minecraft.Schemas.Chunks;

public class ChunkData {
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
    
    public byte[] Serialise() {
        DataWriter w = new();
        
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
            chunks.Write(chunkSection.Serialise());
        }
        
        byte[] chunkData = chunks.ToArray();
        // foreach (byte b in chunkData) {
        //     Console.Write(b);
        //     Console.Write(",");
        // }
        w.WriteVarInt(chunkData.Length);  // length of chunk data
        w.Write(chunkData);  // write the chunk data
        
        // prefixed array of block entities, ignore for now
        w.WriteVarInt(0);  // len of 0
        
        return w.ToArray();
    }
}