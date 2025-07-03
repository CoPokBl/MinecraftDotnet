namespace Minecraft.NBT.Tags;

/// <summary>
/// A compound NBT tag.
/// </summary>
/// <param name="name">It's name if used as a child of another compound tag, otherwise it should be null.</param>
/// <param name="children">Child properties, should all have names, null values are ignored.</param>
public class CompoundTag(string? name, params INbtTag?[] children) : INbtTag {
    /// <summary>Child properties, should all have names, null values are ignored.</summary>
    public INbtTag?[] Children { get; } = children;
    public string? Name = name;

    public Dictionary<string, INbtTag> ChildrenMap {
        get {
            return Children.OfType<INbtTag>().ToDictionary(c => c.GetName()!);
        }
    }
    
    public INbtTag? this[string name] => ChildrenMap.GetValueOrDefault(name);

    public string? GetName() {
        return Name;
    }

    public CompoundTag WithName(string? n) {
        Name = n;
        return this;
    }
    
    public byte GetPrefix() {
        return NbtTagPrefix.Compound;
    }

    public byte[] Serialise(bool noType = false) {
        NbtBuilder builder = new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name);  // no write start
        foreach (INbtTag? child in Children) {
            if (child == null) continue;
            builder.Write(child.Serialise());
        }
        return builder.Write(NbtTagPrefix.End).ToArray();
    }
}
