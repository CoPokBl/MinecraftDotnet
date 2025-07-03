namespace Minecraft.NBT.Tags;

public class StringTag(string? name, string value) : INbtTag {
    public string? Name { get; } = name;
    public string Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.String;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(NbtTagPrefix.String, noType).WriteName(Name).WriteString(Value).ToArray();
    }
}
