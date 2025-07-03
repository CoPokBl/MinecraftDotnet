namespace NBT.Tags;

public class IntegerTag(string? name, int value) : INbtTag {
    public string? Name { get; } = name;
    public int Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Integer;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteInteger(Value).ToArray();
    }
}
