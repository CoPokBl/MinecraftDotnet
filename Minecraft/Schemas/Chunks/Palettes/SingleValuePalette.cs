namespace Minecraft.Schemas.Chunks.Palettes;

public class SingleValuePalette(int d, int maxbpe, int minbpe, uint val) : Palette(d, maxbpe, minbpe) {
    public readonly uint Value = val;

    public override bool HasData => true;  // always has data since it represents a single value

    public override byte[] Serialise() {
        return new DataWriter()
            .WriteUnsignedByte(0x00)
            .WriteVarInt((int)Value)
            .ToArray();
    }
    
    public override uint GetBlock(int x, int y, int z) {
        return Value;
    }

    public override int BlockCount() {
        return Value == 0 ? 0 : d * d * d;
    }

    public override uint[,,] GetData() {
        uint[,,] data = new uint[d, d, d];
        for (int y = 0; y < d; y++) {
            for (int z = 0; z < d; z++) {
                for (int x = 0; x < d; x++) {
                    data[x, y, z] = Value;
                }
            }
        }
        return data;
    }
}
