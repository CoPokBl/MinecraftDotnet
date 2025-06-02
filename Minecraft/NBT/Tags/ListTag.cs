namespace Minecraft.NBT.Tags;

public class ListTag<T> : ITag where T : ITag {
    private readonly T[] _tags;
    private readonly string? _name;
    
    public ListTag(string? name, T[] tags) {
        if (typeof(T) == typeof(ITag)) {
            throw new ArgumentException("List must only be of one type.", nameof(T));
        }

        _tags = tags;
        _name = name;
    }
    
    public byte GetPrefix() {
        return NbtTagPrefix.List;
    }

    public byte[] Serialise(bool noType = false) {
        byte type = _tags.Length == 0 ? NbtTagPrefix.End : _tags[0].GetPrefix();

        NbtBuilder builder = new NbtBuilder().WriteType(NbtTagPrefix.List, noType).WriteName(_name).Write(type).WriteInteger(_tags.Length);
        foreach (T tag in _tags) {
            builder.Write(tag.Serialise(true));
        }
        return builder.ToArray();
    }
}