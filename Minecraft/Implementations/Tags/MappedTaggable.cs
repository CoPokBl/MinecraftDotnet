namespace Minecraft.Implementations.Tags;

public abstract class MappedTaggable : IMutableTaggability {
    private readonly Dictionary<string, object?> _data = new();
    
    public T GetTag<T>(Tag<T> tag) {
        return (T)_data[tag.Id]!;
    }

    public bool HasTag<T>(Tag<T> tag) {
        return _data.ContainsKey(tag.Id);
    }

    public void RemoveTag<T>(Tag<T> tag) {
        _data.Remove(tag.Id);
    }

    public void SetTag<T>(Tag<T> tag, T value) {
        _data[tag.Id] = value;
    }
}
