namespace Minecraft.NBT.Tags;

public class ListTag<T> : ListTag where T : INbtTag {
    public new T[] Tags => base.Tags.Cast<T>().ToArray();
    
    public ListTag(string? name, T[] tags) : base(name, tags.Cast<INbtTag>().ToArray()) {
        if (typeof(T) == typeof(INbtTag)) {
            throw new ArgumentException("List must only be of one type.", nameof(T));
        }
    }
}

public class ListTag(string? name, INbtTag[] tags) : INbtTag {
    public string? Name { get; set; } = name;
    public INbtTag[] Tags { get; } = tags;

    public ListTag WithName(string name) {
        Name = name;
        return this;
    }

    public byte GetPrefix() {
        return NbtTagPrefix.List;
    }
    
    public string? GetName() {
        return Name;
    }

    public byte[] Serialise(bool noType = false) {
        byte type = Tags.Length == 0 ? NbtTagPrefix.End : Tags[0].GetPrefix();

        NbtBuilder builder = new NbtBuilder().WriteType(NbtTagPrefix.List, noType).WriteName(Name).Write(type).WriteInteger(Tags.Length);
        foreach (INbtTag tag in Tags) {
            builder.Write(tag.Serialise(true));
        }
        return builder.ToArray();
    }
}
