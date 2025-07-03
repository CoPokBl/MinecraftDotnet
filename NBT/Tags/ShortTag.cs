namespace NBT.Tags;

public class ShortTag(string? name, short value) : INbtTag {
    public string? Name { get; } = name;
    public short Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Short;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteShort(Value).ToArray();
    }
}
