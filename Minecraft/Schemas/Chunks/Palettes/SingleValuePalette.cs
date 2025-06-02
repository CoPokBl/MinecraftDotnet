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
}