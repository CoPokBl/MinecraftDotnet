using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// A value with the version a client running the chat filter is shown instead, vanilla's
/// <c>Filterable</c>. Book titles and pages are the only things that carry one.
/// </summary>
/// <remarks>
/// Vanilla accepts a bare value as well as the object, meaning nothing was filtered, and this reads
/// both. It writes the object form always, which is the unambiguous one and what vanilla's own
/// reader takes either way.
/// </remarks>
public static class Filterable {
    public static INbtTag Write<T>(T raw, T? filtered, Func<T, INbtTag> write) where T : class {
        return new CompoundBuilder()
            .Tag("raw", write(raw))
            .Maybe("filtered", filtered, write)
            .Build();
    }

    public static TResult Read<T, TResult>(INbtTag tag, Identifier component, Func<INbtTag, T> read,
        Func<T, T?, TResult> build) where T : class {

        if (tag is not CompoundTag) {
            return build(read(tag), null);
        }

        NbtNode node = NbtNode.Of(tag, component);
        T raw = read(node.Require("raw"));
        INbtTag? filtered = node.Optional("filtered");
        node.AssertRead();

        return build(raw, filtered is null ? null : read(filtered));
    }
}
