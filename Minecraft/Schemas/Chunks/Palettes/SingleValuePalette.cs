namespace Minecraft.Schemas.Chunks.Palettes;

public class SingleValuePalette(int d, int maxbpe, int minbpe, uint val) : Palette(d, maxbpe, minbpe) {
    public readonly uint Value = val;

    public override byte[] Serialise() {
        return new DataWriter()
            .WriteUnsignedByte(0x00)
            .WriteVarInt((int)Value)
            .ToArray();
    }

    public override int BlockCount() {
        return Value == 0 ? 0 : d * d * d;
    }

    public override uint[][][] GetData() {
        uint[][][] data = new uint[d][][];
        for (int i = 0; i < d; i++) {
            data[i] = new uint[d][];
            for (int j = 0; j < d; j++) {
                data[i][j] = new uint[d];
                for (int k = 0; k < d; k++) {
                    data[i][j][k] = Value;
                }
            }
        }
        return data;
    }
}