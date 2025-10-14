namespace NBT.Tags;

/// <summary>
/// A compound NBT tag.
/// </summary>
/// <param name="name">It's name if used as a child of another compound tag, otherwise it should be null.</param>
/// <param name="children">Child properties, should all have names, null values are ignored.</param>
public class CompoundTag(string? name, params INbtTag?[] children) : INbtTag<CompoundTag> {
    /// <summary>Child properties, should all have names, null values are ignored.</summary>
    public INbtTag?[] Children { get; } = children;
    public string? Name { get; } = name;

    private Dictionary<string, INbtTag>? _childrenMap;
    public Dictionary<string, INbtTag> ChildrenMap {
        get {
            if (_childrenMap != null) {
                return _childrenMap;
            }
            
            _childrenMap = new Dictionary<string, INbtTag>();
            foreach (INbtTag? child in Children) {
                if (child != null) _childrenMap.Add(child.GetName()!, child);
            }

            return _childrenMap;
        }
    }
    
    public INbtTag? this[string name] => ChildrenMap.GetValueOrDefault(name);
    
    public bool Contains(string name) => ChildrenMap.ContainsKey(name);

    public string? GetName() {
        return Name;
    }
    
    CompoundTag INbtTag<CompoundTag>.WithName(string? name) {
        return new CompoundTag(name, Children);
    }

    public INbtTag WithName(string? name) => ((INbtTag<CompoundTag>)this).WithName(name);
    
    public CompoundTag WithChild(INbtTag child) {
        if (child == null) {
            throw new ArgumentNullException(nameof(child), "Child cannot be null");
        }
        if (child.GetName() == null) {
            throw new ArgumentException("Child tags of a compound tag must have names", nameof(child));
        }
        
        List<INbtTag?> children = Children.ToList();
        children.Add(child);
        return new CompoundTag(Name, children.ToArray());
    }
    
    public byte GetPrefix() {
        return NbtTagPrefix.Compound;
    }

    public byte[] Serialise(bool noType = false) {
        NbtBuilder builder = new NbtBuilder().WriteType(GetPrefix(), noType).WriteName(Name);  // no write start
        foreach (INbtTag? child in Children) {
            if (child == null) continue;
            if (child.GetName() == null) {
                throw new ArgumentException("Child tags of a compound tag must have names", nameof(child));
            }
            builder.Write(child.Serialise());
        }
        return builder.Write(NbtTagPrefix.End).ToArray();
    }
}
