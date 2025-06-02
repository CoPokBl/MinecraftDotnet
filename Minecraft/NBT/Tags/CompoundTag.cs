namespace Minecraft.NBT.Tags;

/// <summary>
/// A compound NBT tag.
/// </summary>
/// <param name="name">It's name if used as a child of another compound tag, otherwise it should be null.</param>
/// <param name="children">Child properties, should all have names, null values are ignored.</param>
public class CompoundTag(string? name, params ITag?[] children) : ITag {
    private string? _name = name;

    public CompoundTag WithName(string? n) {
        _name = n;
        return this;
    }
    
    public byte GetPrefix() {
        return NbtTagPrefix.Compound;
    }

    public byte[] Serialise(bool noType = false) {
        NbtBuilder builder = new NbtBuilder().WriteType(NbtTagPrefix.Compound, noType).WriteName(_name);  // no write start
        foreach (ITag? child in children) {
            if (child == null) continue;
            builder.Write(child.Serialise());
        }
        return builder.Write(NbtTagPrefix.End).ToArray();
    }
}