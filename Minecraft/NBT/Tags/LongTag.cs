namespace Minecraft.NBT.Tags;

public class LongTag(string? name, long value) : INbtTag {
    public string? Name { get; } = name;
    public long Value { get; } = value;

    public byte GetPrefix() {
        return NbtTagPrefix.Long;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name).WriteLong(Value).ToArray();
    }
}
