namespace Minecraft.NBT.Tags;

public class IntegersTag(string? name, int[] values) : ITag {
    public string? Name { get; private set; } = name;
    public int[] Values { get; } = values;

    public byte GetPrefix() {
        return NbtTagPrefix.Integers;
    }
    
    public string? GetName() {
        return Name;
    }
    
    public IntegersTag WithName(string name) {
        Name = name;
        return this;
    }
    
    public byte[] Serialise(bool noType = false) {
        NbtBuilder b = new NbtBuilder()
            .WriteType(GetPrefix(), noType)
            .WriteName(Name)
            .WriteInteger(Values.Length);
        foreach (int v in Values) {
            b.WriteInteger(v);
        }
        return b.ToArray();
    }
}
