using System.Text.Json;
using ManagedServer.Terrain.Data;
using Minecraft.Schemas;

namespace ManagedServer.Loot;

/// <summary>
/// The registries a loot table can name an element of by id rather than inline: <c>predicate</c>,
/// <c>item_modifier</c>, <c>context_int_provider</c> and <c>context_float_provider</c>.
/// </summary>
/// <remarks>
/// Each element is kept as its JSON and parsed the first time a table names it, so an element of a
/// type with no port fails only the tables that use it. Vanilla's own <c>context_int_provider</c>
/// entries are composter and furnace dispatchers that no block table reaches, which is why parsing
/// everything up front would refuse the vanilla pack.
/// <p/>
/// Not thread safe: <see cref="DatapackBlockLoot"/> resolves every reference while it loads, under its
/// own lock, and nothing reads this afterwards.
/// </remarks>
public sealed class LootReferences {
    public static readonly LootReferences None = new();

    internal readonly Dictionary<Identifier, JsonElement> Predicates = [];
    internal readonly Dictionary<Identifier, JsonElement> ItemModifiers = [];
    internal readonly Dictionary<Identifier, JsonElement> IntProviders = [];
    internal readonly Dictionary<Identifier, JsonElement> FloatProviders = [];

    // Keyed by registry as well as id, since a predicate and a provider may share a name.
    internal readonly Dictionary<(string Registry, Identifier Id), object> Parsed = [];
    internal readonly HashSet<(string Registry, Identifier Id)> Resolving = [];

    private LootReferences() { }

    /// <summary>Every element of the four registries a source carries.</summary>
    public static LootReferences Load(IDatapackSource source) {
        LootReferences references = new();
        Read(source, "predicate", references.Predicates);
        Read(source, "item_modifier", references.ItemModifiers);
        Read(source, "context_int_provider", references.IntProviders);
        Read(source, "context_float_provider", references.FloatProviders);
        return references;
    }

    private static void Read(IDatapackSource source, string registry, Dictionary<Identifier, JsonElement> into) {
        foreach (DatapackEntry entry in source.Entries(registry)) {
            using Stream stream = source.Open(entry.Path);
            using JsonDocument document = JsonDocument.Parse(stream);
            into[entry.Id] = document.RootElement.Clone();
        }
    }
}
