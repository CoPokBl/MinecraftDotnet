namespace NBT.Tags;

public class DoubleTag(string? name, double value) : INbtTag {
    public string? Name { get; } = name;
    public double Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Double;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteDouble(Value).ToArray();
    }
}
