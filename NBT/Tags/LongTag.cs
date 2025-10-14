namespace NBT.Tags;

public class LongTag(string? name, long value) : INbtTag<LongTag> {
    public string? Name { get; } = name;
    public long Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Long;
    }
    
    public string? GetName() {
        return Name;
    }
    
    LongTag INbtTag<LongTag>.WithName(string? name) {
        return new LongTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<LongTag>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteLong(Value).ToArray();
    }
}
