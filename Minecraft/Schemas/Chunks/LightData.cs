using System.Collections;

namespace Minecraft.Schemas.Chunks;

public class LightData {
    private const int WorldHeight = 384;  // vanilla overworld height TODO: Make dynamic or a parameter
    private const int ChunkSections = WorldHeight / 16;  // number of sections in a chunk, 24 for vanilla overworld
    
    private static readonly BitArray Zeros = new(ChunkSections + 2);
    private static readonly BitArray Ones = new(ChunkSections + 2);

    public static readonly LightData FullBright;
    public static readonly LightData FullDark;
    
    // Actual params
    public BitArray SkyLightMask = Zeros;
    public BitArray BlockLightMask = Zeros;
    public BitArray EmptySkyLightMask = Zeros;
    public BitArray EmptyBlockLightMask = Zeros;

    public byte[][] SkyLight = [];
    public byte[][] BlockLight = [];

    static LightData() {
        for (int i = 0; i < ChunkSections + 2; i++) {
            Zeros.Set(i, false);
            Ones.Set(i, true);
        }
        
        // Full bright
        byte[][] sky = new byte[ChunkSections + 2][];
        byte[][] block = new byte[ChunkSections + 2][];
        for (int i = 0; i < ChunkSections + 2; i++) {
            sky[i] = new byte[2048];
            block[i] = new byte[2048];
            for (int j = 0; j < 2048; j++) {
                sky[i][j] = byte.MaxValue;
                block[i][j] = byte.MaxValue;
            }
        }
        
        FullBright = new LightData {
            SkyLightMask = Ones,
            BlockLightMask = Ones,
            EmptySkyLightMask = Zeros,
            EmptyBlockLightMask = Zeros,
            
            SkyLight = sky,
            BlockLight = block
        };
        
        FullDark = new LightData {
            SkyLightMask = Zeros,
            BlockLightMask = Zeros,
            EmptySkyLightMask = Ones,
            EmptyBlockLightMask = Ones,
            
            SkyLight = [],
            BlockLight = []
        };
    }

    public byte[] Serialise() {
        DataWriter w = new();
        w.WritePrefixedArray(SkyLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WritePrefixedArray(BlockLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WritePrefixedArray(EmptySkyLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WritePrefixedArray(EmptyBlockLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        
        w.WritePrefixedArray(SkyLight, (i, writer) =>
            writer.WritePrefixedArray(i, (b, dataWriter) => dataWriter.WriteUnsignedByte(b)));
        w.WritePrefixedArray(BlockLight, (i, writer) =>
            writer.WritePrefixedArray(i, (b, dataWriter) => dataWriter.WriteUnsignedByte(b)));
        return w.ToArray();
    }
}