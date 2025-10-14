namespace NBT.Tags;

public class IntegerTag(string? name, int value) : INbtTag<IntegerTag> {
    public string? Name { get; } = name;
    public int Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Integer;
    }
    
    public string? GetName() {
        return Name;
    }
    
    IntegerTag INbtTag<IntegerTag>.WithName(string? name) {
        return new IntegerTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<IntegerTag>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteInteger(Value).ToArray();
    }
}
