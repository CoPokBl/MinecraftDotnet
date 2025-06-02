using System.Collections;

namespace Minecraft.Schemas.Chunks;

public class LightData {

    public byte[] Serialise() {
        const int worldHeight = 384;  // vanilla overworld height TODO: Make dynamic or a parameter
        const int chunkSections = worldHeight / 16;  // number of sections in a chunk, 24 for vanilla overworld

        BitArray zeros = new(chunkSections + 2);
        BitArray ones = new(chunkSections + 2);
        for (int i = 0; i < chunkSections + 2; i++) {
            zeros.Set(i, false);
            ones.Set(i, true);
        }

        // the bit sets
        BitArray skyLightMask = zeros;
        BitArray blockLightMask = zeros;
        BitArray emptySkyLightMask = ones;
        BitArray emptyBlockLightMask = ones;
        
        DataWriter w = new();
        w.WritePrefixedArray(skyLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WritePrefixedArray(blockLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WritePrefixedArray(emptySkyLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WritePrefixedArray(emptyBlockLightMask.ToLongArray(), (l, writer) => writer.WriteLong(l));
        w.WriteVarInt(0);  // data arr of length 0
        w.WriteVarInt(0);  // data arr of length 0  
        return w.ToArray();
    }
}