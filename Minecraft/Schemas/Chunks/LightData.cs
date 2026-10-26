using System.Collections;

namespace Minecraft.Schemas.Chunks;

public class LightData : IWritable {
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

    public void Write(DataWriter w) {
        w.WritePrefixedArray((ReadOnlySpan<byte>)SkyLightMask.ToJavaByteArray());
        w.WritePrefixedArray((ReadOnlySpan<byte>)BlockLightMask.ToJavaByteArray());
        w.WritePrefixedArray((ReadOnlySpan<byte>)EmptySkyLightMask.ToJavaByteArray());
        w.WritePrefixedArray((ReadOnlySpan<byte>)EmptyBlockLightMask.ToJavaByteArray());

        // Bulk rather than a nested WritePrefixedArray: a lit chunk carries 48 sections of 2048 bytes,
        // so a delegate per byte is a hundred thousand calls to append a hundred kilobytes.
        WriteSections(w, SkyLight);
        WriteSections(w, BlockLight);
    }

    private static void WriteSections(DataWriter w, byte[][] sections) {
        w.WriteVarInt(sections.Length);
        foreach (byte[] section in sections) {
            w.WritePrefixedArray((ReadOnlySpan<byte>)section);
        }
    }

    public static LightData Read(DataReader r) {
        return new LightData {
            SkyLightMask = ReadMask(r),
            BlockLightMask = ReadMask(r),
            EmptySkyLightMask = ReadMask(r),
            EmptyBlockLightMask = ReadMask(r),
            SkyLight = ReadLightArrays(r),
            BlockLight = ReadLightArrays(r)
        };

        static BitArray ReadMask(DataReader r) {
            return r.Read(r.ReadVarInt()).FromJavaByteArray();
        }

        static byte[][] ReadLightArrays(DataReader r) {
            return r.ReadPrefixedArray(reader => reader.Read(reader.ReadVarInt()));
        }
    }
}