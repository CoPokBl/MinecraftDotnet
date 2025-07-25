using Minecraft.Schemas;

namespace Minecraft.Implementations.Tags;

public interface ITaggable {
    T GetTag<T>(Tag<T> tag);
    bool HasTag<T>(Tag<T> tag);
}

