namespace Minecraft.NBT.Tags;

public class BytesTag(string? name, int[] values) : ITag {
    public string? Name { get; private set; } = name;
    public int[] Values { get; } = values;

    public byte GetPrefix() {
        return NbtTagPrefix.Bytes;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public BytesTag WithName(string name) {
        Name = name;
        return this;
    }
    
    public byte[] Serialise(bool noType = false) {
        NbtBuilder b = new NbtBuilder()
            .WriteType(GetPrefix(), noType)
            .WriteName(Name)
            .WriteInteger(Values.Length);
        foreach (int v in Values) {
            if (v is < -128 or > 127) {
                throw new ArgumentOutOfRangeException(nameof(v), "Value must be between -128 and 127.");
            }
            if (v >= 0) b.Write((byte)v);  // For positive values, write directly as byte
            else {
                // Convert to two's complement for negative values
                b.Write((byte)(256 + v)); // 256 - 128 = 128, so -128 becomes 128
            }
        }
        return b.ToArray();
    }
}
