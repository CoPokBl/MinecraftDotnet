namespace Minecraft.Implementations.Tags;

public interface IMutableTaggability : ITaggable {
    void RemoveTag<T>(Tag<T> tag);
    void SetTag<T>(Tag<T> tag, T value);
}
