namespace NBT.Tags;

public class FloatTag(string? name, float value) : INbtTag<FloatTag> {
    public string? Name { get; } = name;
    public float Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Float;
    }
    
    public string? GetName() {
        return Name;
    }
    
    FloatTag INbtTag<FloatTag>.WithName(string? name) {
        return new FloatTag(name, Value);
    }

    public INbtTag WithName(string? name) => ((INbtTag<FloatTag>)this).WithName(name);
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteFloat(Value).ToArray();
    }
}
