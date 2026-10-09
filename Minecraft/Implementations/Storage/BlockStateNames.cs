using System.Collections.Concurrent;
using System.Text;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// The two named forms a stored block state takes, in both directions, memoised.
/// <p/>
/// Every disk format spells a state out rather than storing its id, because an id moves on a version
/// bump and a saved world must not. Building that spelling is expensive: a state string is a compound
/// tag, a list, a join and an interpolation, and parsing one back is a split per property and a state
/// lookup. Both are pure functions of the registry, and a world's palettes hold the same few hundred
/// states over and over, so they are computed once each and then read.
/// </summary>
/// <remarks>
/// Caches are per registry and hold entries for the life of it. A server has one registry, so this is
/// a few hundred kilobytes at most and it stops growing as soon as the palettes stop finding new
/// states.
/// </remarks>
public static class BlockStateNames {
    private sealed class Cache {
        public readonly ConcurrentDictionary<uint, string> Strings = new();
        public readonly ConcurrentDictionary<string, uint> Ids = new();
        public readonly ConcurrentDictionary<uint, CompoundTag> Tags = new();
    }

    private static readonly ConcurrentDictionary<MinecraftRegistry, Cache> Caches = new();

    private static Cache For(MinecraftRegistry registry) => Caches.GetOrAdd(registry, _ => new Cache());

    /// <summary>
    /// A state as <c>minecraft:oak_stairs[facing=north,half=bottom]</c>, the form Polar and the
    /// vanilla command syntax both use. Properties keep the registry's order, so the same state always
    /// produces the same string.
    /// </summary>
    public static string ToStateString(uint stateId, MinecraftRegistry registry) {
        Cache cache = For(registry);
        if (cache.Strings.TryGetValue(stateId, out string? existing)) {
            return existing;
        }

        IBlock block = registry.Blocks.GetByStateId(stateId);
        StringBuilder builder = new(block.Identifier.ToString());

        bool first = true;
        foreach ((string key, INbtTag child) in block.ToStateNbt().Children) {
            builder.Append(first ? '[' : ',');
            first = false;
            builder.Append(key).Append('=').Append(child.GetString());
        }

        if (!first) {
            builder.Append(']');
        }

        string result = builder.ToString();
        cache.Strings[stateId] = result;
        cache.Ids[result] = stateId;
        return result;
    }

    public static uint FromStateString(string state, MinecraftRegistry registry) {
        Cache cache = For(registry);
        if (cache.Ids.TryGetValue(state, out uint existing)) {
            return existing;
        }

        int bracket = state.IndexOf('[');
        string name = bracket < 0 ? state : state[..bracket];
        IBlock block = Lookup(name, registry);

        if (bracket >= 0) {
            string[] pairs = state[(bracket + 1)..state.LastIndexOf(']')].Split(',');
            (string, INbtTag)[] properties = new (string, INbtTag)[pairs.Length];
            for (int i = 0; i < pairs.Length; i++) {
                int equals = pairs[i].IndexOf('=');
                properties[i] = (pairs[i][..equals], new StringTag(pairs[i][(equals + 1)..]));
            }

            block = block.WithState(new CompoundTag(properties));
        }

        cache.Ids[state] = block.StateId;
        return block.StateId;
    }

    /// <summary>
    /// A state as Anvil's palette entry: <c>{Name: "minecraft:oak_stairs", Properties: {...}}</c>.
    /// </summary>
    /// <remarks>
    /// The tag is shared rather than copied. Nothing writes to an <see cref="INbtTag"/>, so a palette
    /// built for one chunk is the same object in every other chunk that holds the state.
    /// </remarks>
    public static CompoundTag ToPaletteTag(uint stateId, MinecraftRegistry registry) {
        Cache cache = For(registry);
        if (cache.Tags.TryGetValue(stateId, out CompoundTag? existing)) {
            return existing;
        }

        IBlock block = registry.Blocks.GetByStateId(stateId);
        CompoundTag properties = block.ToStateNbt();

        CompoundTag tag = properties.ChildCount == 0
            ? new CompoundTag(("Name", new StringTag(block.Identifier.ToString())))
            : new CompoundTag(("Name", new StringTag(block.Identifier.ToString())), ("Properties", properties));

        cache.Tags[stateId] = tag;
        return tag;
    }

    public static uint FromPaletteTag(CompoundTag tag, MinecraftRegistry registry) {
        IBlock block = Lookup(tag["Name"].GetString(), registry);
        return tag["Properties"] is CompoundTag properties ? block.WithState(properties).StateId : block.StateId;
    }

    /// <summary>
    /// Resolves a stored block name, following <see cref="RenamedBlocks"/> first so a world saved
    /// before an upstream rename still loads.
    /// </summary>
    private static IBlock Lookup(string name, MinecraftRegistry registry) {
        return registry.Blocks[RenamedBlocks.Map.TryGetValue(name, out Identifier renamed) ? renamed : (Identifier)name];
    }
}
