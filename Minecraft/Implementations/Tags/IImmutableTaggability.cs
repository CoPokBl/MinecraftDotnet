namespace Minecraft.Implementations.Tags;

public interface IImmutableTaggability<out TR> : ITaggable where TR : IImmutableTaggability<TR> {
    TR WithoutTag<T>(Tag<T> tag);
    TR WithTag<T>(Tag<T> tag, T value);
}
