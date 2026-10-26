using System.Text.Json;
using ManagedServer.Features.Impl;
using ManagedServer.Terrain.Data;
using Minecraft.Data.Blocks;
using Minecraft.Data.Loot;
using Minecraft.Schemas;

namespace ManagedServer.Loot;

/// <summary>
/// Every block loot table a <see cref="IDatapackSource"/> carries, with the <c>predicate</c>,
/// <c>item_modifier</c> and number provider registries of the same source to resolve the ids they name.
/// </summary>
/// <remarks>
/// <b>Read rather than generated, because a loot table is content and not a measured fact.</b> Which
/// item a block drops, at what weight, under what conditions, is somebody's design; restating it as
/// C# would be the same material in another syntax, and nothing Mojang wrote ships here.
/// <p/>
/// Keyed by table rather than by block, because the two are not one to one: every wall sign shares its
/// standing form's table, and a block with no table at all is absent rather than present and empty.
/// <c>BlockInfo.LootTable</c> is the id to look up and is null only for the second kind, so it is
/// never a block's own name that is asked for.
/// <p/>
/// Loading is eager and the whole set is parsed at once, which is about 1100 small files. The parser
/// throws on anything it does not understand, so a pack with a table this build cannot read fails here
/// rather than when somebody breaks that block.
/// </remarks>
public sealed class DatapackBlockLoot : IBlockLootSource {
    private static readonly Dictionary<IDatapackSource, DatapackBlockLoot> Cache = new();
    private static readonly Lock CacheLock = new();

    private readonly Dictionary<Identifier, LootTable> _byId = [];

    private DatapackBlockLoot(IDatapackSource source) {
        LootReferences references = LootReferences.Load(source);

        foreach (DatapackEntry entry in source.Entries("loot_table/blocks")) {
            using Stream stream = source.Open(entry.Path);
            using JsonDocument document = JsonDocument.Parse(stream);

            // The registry id carries the folder, since that is how a block names its table.
            Identifier id = new(entry.Id.Namespace, "blocks/" + entry.Id.Key);
            _byId[id] = LootTableParser.Parse(document.RootElement, id.ToString(), references);
        }

        if (_byId.Count == 0) {
            throw new InvalidOperationException(
                $"\"{source.Describe()}\" carries no block loot tables: it has no "
                + "data/<namespace>/loot_table/blocks.");
        }
    }

    /// <summary>The tables in a source, parsed once and shared.</summary>
    public static DatapackBlockLoot Load(IDatapackSource source) {
        lock (CacheLock) {
            if (Cache.TryGetValue(source, out DatapackBlockLoot? existing)) {
                return existing;
            }

            DatapackBlockLoot loaded = new(source);
            Cache[source] = loaded;
            return loaded;
        }
    }

    /// <summary>Every table, by loot table id.</summary>
    public IReadOnlyDictionary<Identifier, LootTable> ById => _byId;

    public LootTable? TableFor(IBlock block) {
        return block.LootTable is { } id && _byId.TryGetValue(id, out LootTable? table) ? table : null;
    }
}
