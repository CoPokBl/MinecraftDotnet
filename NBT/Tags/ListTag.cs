namespace NBT.Tags;

public class ListTag<T> : ListTag where T : INbtTag {
    public new T[] Tags => base.Tags.Cast<T>().ToArray();
    
    public ListTag(string? name, T[] tags) : base(name, tags.Cast<INbtTag>().ToArray()) {
        if (typeof(T) == typeof(INbtTag)) {
            throw new ArgumentException("List must only be of one type.", nameof(T));
        }
    }
    
    public new ListTag<T> WithName(string name) {
        return new ListTag<T>(Name, Tags);
    }
}

public class ListTag(string? name, INbtTag[] tags) : INbtTag<ListTag> {
    public string? Name { get; } = name;
    public INbtTag[] Tags { get; } = tags;

    public byte GetPrefix() {
        return NbtTagPrefix.List;
    }
    
    public string? GetName() {
        return Name;
    }
    
    ListTag INbtTag<ListTag>.WithName(string? name) {
        return new ListTag(name, Tags);
    }

    public INbtTag WithName(string? name) => ((INbtTag<ListTag>)this).WithName(name);

    public byte[] Serialise(bool noType = false) {
        byte type = Tags.Length == 0 ? NbtTagPrefix.End : Tags[0].GetPrefix();

        NbtBuilder builder = new NbtBuilder().WriteType(NbtTagPrefix.List, noType).WriteName(Name).Write(type).WriteInteger(Tags.Length);
        foreach (INbtTag tag in Tags) {
            builder.Write(tag.Serialise(true));
        }
        return builder.ToArray();
    }
}
