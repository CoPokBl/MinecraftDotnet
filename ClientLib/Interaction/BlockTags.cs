using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace ClientLib.Interaction;

/// <summary>Block tag membership as the server synchronised the tags, which is what <c>state.is(tag)</c> asks.</summary>
public sealed class BlockTags(MinecraftClient client) {
    private static readonly Identifier BlockRegistry = "minecraft:block";
    private readonly Dictionary<Identifier, HashSet<int>> _cache = new();
    private Dictionary<Identifier, Dictionary<Identifier, int[]>>? _source;

    public bool Contains(IdSet set, IBlock block) {
        int id = client.Registry.Blocks.GetProtocolId(block);
        return set switch {
            IdSet.Ids ids => Array.IndexOf(ids.Values, id) >= 0,
            IdSet.Tag tag => Members(tag.TagName).Contains(id),
            _ => false
        };
    }

    public bool Contains(Identifier tag, IBlock block) {
        return Members(tag).Contains(client.Registry.Blocks.GetProtocolId(block));
    }

    private HashSet<int> Members(Identifier tag) {
        if (!ReferenceEquals(_source, client.Tags)) {
            _source = client.Tags;
            _cache.Clear();
        }
        if (_cache.TryGetValue(tag, out HashSet<int>? members)) {
            return members;
        }
        members = client.Tags.TryGetValue(BlockRegistry, out Dictionary<Identifier, int[]>? tags) && tags.TryGetValue(tag, out int[]? ids)
            ? [..ids]
            : [];
        _cache[tag] = members;
        return members;
    }
}
