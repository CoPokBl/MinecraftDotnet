namespace Minecraft.Schemas.Chunks.Palettes;

public class SingleValuePalette(int d, int maxbpe, int minbpe, uint val) : Palette(d, maxbpe, minbpe) {
    public readonly uint Value = val;
    private readonly int _dimension = d;

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
        return Value == 0 ? 0 : _dimension * _dimension * _dimension;
    }

    public override uint[,,] GetData() {
        uint[,,] data = new uint[_dimension, _dimension, _dimension];
        for (int y = 0; y < _dimension; y++) {
            for (int z = 0; z < _dimension; z++) {
                for (int x = 0; x < _dimension; x++) {
                    data[x, y, z] = Value;
                }
            }
        }
        return data;
    }
}
