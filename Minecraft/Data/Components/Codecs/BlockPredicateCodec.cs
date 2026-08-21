using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// The predicate an item's <c>can_break</c> and <c>can_place_on</c> are a list of.
/// </summary>
/// <remarks>
/// <b>Three fields, where the wire form carries five.</b> Vanilla's persistent codec has only
/// <c>blocks</c>, <c>state</c> and <c>nbt</c>; the component matchers exist on the network side and
/// nowhere a datapack or a saved stack can put them. A predicate carrying one is refused rather than
/// written without it, since a predicate that lost a clause matches more than it should.
/// <p/>
/// A property is either an exact value or a range, both written as strings, because a block property
/// is named by its string form wherever it is written.
/// </remarks>
public static class BlockPredicateCodec {
    public static NbtCodec<BlockPredicate[]> Of(Identifier component) {
        return new NbtCodec<BlockPredicate[]>(
            (val, registry) => new ListTag(val
                .Select(predicate => Write(predicate, registry, component))
                .ToArray()),
            (tag, registry) => tag.GetList().Tags.ToArray()
                .Select(predicate => Read(predicate, registry, component))
                .ToArray());
    }

    private static INbtTag Write(BlockPredicate predicate, MinecraftRegistry registry,
        Identifier component) {

        if (predicate.Components is { Length: > 0 } || predicate.PartialComponents is { Length: > 0 }) {
            throw new UnportedComponentException(component,
                "a block predicate matching data components, which has no persistent form upstream.");
        }

        return new CompoundBuilder()
            .IdSet("blocks", predicate.Blocks, registry.Blocks)
            .TagWhen("state", State(predicate.Properties ?? []), predicate.Properties is { Length: > 0 })
            .Maybe("nbt", predicate.Nbt, nbt => nbt)
            .Build();
    }

    private static BlockPredicate Read(INbtTag tag, MinecraftRegistry registry, Identifier component) {
        NbtNode node = NbtNode.Of(tag, component);

        BlockPredicate predicate = new(
            node.IdSetOrNull("blocks", registry.Blocks),
            node.Has("state") ? Properties(node.Require("state"), component) : null,
            node.Optional("nbt"));

        node.AssertRead();
        return predicate;
    }

    private static CompoundTag State(BlockPropertyFilter[] properties) {
        return new CompoundTag(properties
            .Select(property => (property.Name, property.ExactMatch
                ? (INbtTag)new StringTag(property.ExactValue!)
                : new CompoundBuilder()
                    .String("min", property.MinValue, null)
                    .String("max", property.MaxValue, null)
                    .Build()))
            .ToArray());
    }

    private static BlockPropertyFilter[] Properties(INbtTag tag, Identifier component) {
        return tag.GetCompound().Children
            .Select(property => {
                if (property.child is not CompoundTag) {
                    return new BlockPropertyFilter(property.key, true, property.child.GetString());
                }

                NbtNode range = NbtNode.Of(property.child, component);
                BlockPropertyFilter filter = new(property.key, false, null,
                    range.StringOrNull("min"), range.StringOrNull("max"));
                range.AssertRead();
                return filter;
            })
            .ToArray();
    }

}
