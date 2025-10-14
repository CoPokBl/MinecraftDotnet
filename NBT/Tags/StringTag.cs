namespace NBT.Tags;

public class StringTag(string? name, string value) : INbtTag<StringTag> {
    public string? Name { get; } = name;
    public string Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.String;
    }
    
    public string? GetName() {
        return Name;
    }
    
    StringTag INbtTag<StringTag>.WithName(string? name) {
        return new StringTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<StringTag>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(NbtTagPrefix.String, noType).WriteName(Name).WriteString(Value).ToArray();
    }
}
