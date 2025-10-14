namespace NBT.Tags;

public class DoubleTag(string? name, double value) : INbtTag<DoubleTag> {
    public string? Name { get; } = name;
    public double Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Double;
    }
    
    public string? GetName() {
        return Name;
    }
    
    DoubleTag INbtTag<DoubleTag>.WithName(string? name) {
        return new DoubleTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<DoubleTag>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteDouble(Value).ToArray();
    }
}
