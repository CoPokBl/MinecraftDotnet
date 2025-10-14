namespace NBT.Tags;

public class ShortTag(string? name, short value) : INbtTag<ShortTag> {
    public string? Name { get; } = name;
    public short Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Short;
    }
    
    public string? GetName() {
        return Name;
    }
    
    ShortTag INbtTag<ShortTag>.WithName(string? name) {
        return new ShortTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<ShortTag>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteShort(Value).ToArray();
    }
}
