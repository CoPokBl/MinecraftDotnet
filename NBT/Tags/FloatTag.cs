namespace NBT.Tags;

public class FloatTag(string? name, float value) : INbtTag {
    public string? Name { get; } = name;
    public float Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Float;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteFloat(Value).ToArray();
    }
}
