namespace Minecraft.Implementations.Tags;

public interface ITaggable {
    T GetTag<T>(Tag<T> tag);
    bool HasTag<T>(Tag<T> tag);
    void SetTag<T>(Tag<T> tag, T value);
}
