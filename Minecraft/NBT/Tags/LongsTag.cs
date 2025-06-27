namespace Minecraft.NBT.Tags;

public class LongsTag(string? name, long[] values) : ITag {
    public string? Name { get; private set; } = name;
    public long[] Values { get; } = values;

    public byte GetPrefix() {
        return NbtTagPrefix.Longs;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public LongsTag WithName(string name) {
        Name = name;
        return this;
    }
    
    public byte[] Serialise(bool noType = false) {
        NbtBuilder b = new NbtBuilder()
            .WriteType(GetPrefix(), noType)
            .WriteName(Name)
            .WriteInteger(Values.Length);
        foreach (int v in Values) {
            b.WriteLong(v);
        }
        return b.ToArray();
    }
}
