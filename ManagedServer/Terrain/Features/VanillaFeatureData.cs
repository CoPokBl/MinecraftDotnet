using System.Text.Json;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Structures.Templates;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Features;

/// <summary>
/// The vanilla configured features, placed features and per biome feature lists, embedded and parsed
/// on demand.
/// </summary>
/// <remarks>
/// Same bargain as <see cref="ManagedServer.Terrain.VanillaWorldgenData"/>: the datapack is copied
/// verbatim rather than transcribed, because 226 configured features and 262 placed ones is a few
/// thousand chances to be quietly wrong about a number.
/// <p/>
/// The biome files are trimmed to their <c>features</c> and <c>carvers</c> lists on the way in. The
/// rest of a biome is climate, colours and mob spawns, which the biome registry already carries from
/// the network form.
/// <p/>
/// Cached per registry, so a server with four worlds parses this once and shares the parsed features.
/// That is safe because everything under it is immutable and holds no per world state: a feature's
/// randomness comes from the random it is handed, never from a field.
/// </remarks>
public sealed class VanillaFeatureData {

    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), VanillaFeatureData>
        Cache = new();
    private static readonly Lock CacheLock = new();

    private readonly Dictionary<Identifier, JsonDocument> _configuredJson = [];
    private readonly Dictionary<Identifier, JsonDocument> _placedJson = [];
    private readonly Dictionary<Identifier, JsonDocument> _biomeJson = [];

    private readonly Dictionary<Identifier, ConfiguredFeature?> _configured = [];
    private readonly Dictionary<Identifier, PlacedFeature?> _placed = [];
    /// <summary>
    /// One per registry, not one shared. The two registries have overlapping names on purpose:
    /// <c>amethyst_geode</c> is a placed feature whose configured feature is also called
    /// <c>amethyst_geode</c>, so a single set reads that as a cycle.
    /// </summary>
    private readonly HashSet<Identifier> _resolvingPlaced = [];
    private readonly HashSet<Identifier> _resolvingConfigured = [];

    private readonly Dictionary<string, List<Identifier>> _skipped = [];

    private readonly FeatureParser _parser;
    private readonly PlacementParser _placement;

    private readonly Dictionary<string, BiomeFeatureTable> _tables = [];

    private VanillaFeatureData(MinecraftRegistry registry, IDatapackSource source) {
        BlockParser blocks = new(registry);
        _placement = new PlacementParser(blocks);
        _parser = new FeatureParser(blocks, _placement, ResolvePlaced, ResolveConfigured,
            StructureTemplateManager.Load(source, registry), ProcessorLists.Load(source, registry));

        Read(source, "worldgen/configured_feature", _configuredJson);
        Read(source, "worldgen/placed_feature", _placedJson);
        Read(source, "worldgen/biome", _biomeJson);
    }

    private static void Read(IDatapackSource source, string registryPath,
        Dictionary<Identifier, JsonDocument> into) {

        foreach (DatapackEntry entry in source.Entries(registryPath)) {
            using Stream stream = source.Open(entry.Path);
            into[entry.Id] = JsonDocument.Parse(stream);
        }
    }


    public static VanillaFeatureData Load(IDatapackSource source, MinecraftRegistry? registry = null) {
        MinecraftRegistry actual = registry ?? Minecraft.Data.Generated.VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out VanillaFeatureData? existing)) {
                return existing;
            }

            VanillaFeatureData data = new(actual, source);
            Cache[(actual, source)] = data;
            return data;
        }
    }

    /// <summary>
    /// Which placed features were dropped and why, keyed by the feature type that is not transcribed.
    /// </summary>
    /// <remarks>
    /// Only filled once <see cref="TableFor"/> has been built, since resolution is lazy. It is the honest
    /// answer to "what is missing from this world", and the reason a skipped feature is recorded
    /// rather than merely returning null.
    /// </remarks>
    public IReadOnlyDictionary<string, List<Identifier>> Skipped => _skipped;

    /// <summary>
    /// Every biome the pack describes, whichever dimension it belongs to, sorted.
    /// </summary>
    /// <remarks>
    /// Not what a table is built from: a dimension's table covers what its own biome source can
    /// produce. This is for a caller that wants the whole pack resolved rather than one world's worth
    /// of it.
    /// </remarks>
    public IReadOnlyList<Identifier> Biomes =>
        _biomeJson.Keys.OrderBy(id => id.ToString(), StringComparer.Ordinal).ToList();

    /// <summary>
    /// The per biome, per step feature lists in vanilla's own global order, for a dimension whose
    /// biome source can produce <paramref name="biomes"/>.
    /// </summary>
    /// <remarks>
    /// <b>The list and its order are both load bearing.</b> Vanilla sorts
    /// <c>biomeSource.possibleBiomes()</c>, so the overworld's table is built from the 55 biomes the
    /// overworld can produce and in the order the climate parameter list first mentions them. A
    /// feature's index in the result is what seeds it, so feeding in every biome in the registry, or
    /// the same biomes in another order, moves the index of everything the extra entries order against
    /// and puts every tree, patch and ore blob of the affected steps somewhere else.
    /// </remarks>
    public BiomeFeatureTable TableFor(IReadOnlyList<Identifier> biomes) {
        string key = string.Join('\n', biomes.Select(id => id.ToString()));

        lock (CacheLock) {
            if (_tables.TryGetValue(key, out BiomeFeatureTable? existing)) {
                return existing;
            }

            BiomeFeatureTable table = BuildTable(biomes);
            _tables[key] = table;
            return table;
        }
    }

    /// <summary>
    /// One placed feature by id, for a caller that reaches a feature through something other than a
    /// biome's list.
    /// </summary>
    /// <remarks>
    /// A jigsaw pool's feature element is the only one: it names a placed feature that no biome need
    /// mention, so it cannot come off <see cref="TableFor"/>. Resolution memoises into shared state, so
    /// this takes the same lock the table build does.
    /// </remarks>
    public PlacedFeature? Placed(Identifier id) {
        lock (CacheLock) {
            return ResolvePlaced(id);
        }
    }

    /// <summary>
    /// A placed feature by id, or null when the feature behind it is not transcribed.
    /// </summary>
    /// <remarks>
    /// Memoised including the null, so a feature referenced from twenty biomes is parsed once and a
    /// skipped one is recorded once.
    /// <p/>
    /// Private because none of this is thread safe and it does not need to be: everything resolves
    /// while <see cref="TableFor"/> is being built, which happens once under the cache lock.
    /// </remarks>
    private PlacedFeature? ResolvePlaced(Identifier id) {
        if (_placed.TryGetValue(id, out PlacedFeature? existing)) {
            return existing;
        }

        if (!_placedJson.TryGetValue(id, out JsonDocument? document)) {
            throw new InvalidOperationException($"No placed feature registered as \"{id}\".");
        }

        if (!_resolvingPlaced.Add(id)) {
            throw new InvalidOperationException($"Placed feature \"{id}\" refers to itself.");
        }

        try {
            JsonElement root = document.RootElement;
            ConfiguredFeature? feature = ResolveConfigured(
                Identifier.Parse(root.GetProperty("feature").GetString()!));

            PlacedFeature? placed = feature is null
                ? null
                : new PlacedFeature(feature, _placement.ParseAll(root.GetProperty("placement")), id);

            _placed[id] = placed;
            return placed;
        } finally {
            _resolvingPlaced.Remove(id);
        }
    }

    /// <inheritdoc cref="ResolvePlaced"/>
    private ConfiguredFeature? ResolveConfigured(Identifier id) {
        if (_configured.TryGetValue(id, out ConfiguredFeature? existing)) {
            return existing;
        }

        if (!_configuredJson.TryGetValue(id, out JsonDocument? document)) {
            throw new InvalidOperationException($"No configured feature registered as \"{id}\".");
        }

        if (!_resolvingConfigured.Add(id)) {
            throw new InvalidOperationException($"Configured feature \"{id}\" refers to itself.");
        }

        try {
            ConfiguredFeature? feature;

            try {
                feature = _parser.Parse(document.RootElement);
            } catch (FeatureNotPortedException notPorted) {
                RecordSkipped(notPorted.FeatureType, id);
                feature = null;
            }

            // A nested entry this feature dropped is charged to it, since the parser has no idea whose
            // list it was in.
            foreach (string dropped in _parser.DroppedNested) {
                RecordSkipped(dropped, id);
            }

            _parser.DroppedNested.Clear();

            _configured[id] = feature;
            return feature;
        } finally {
            _resolvingConfigured.Remove(id);
        }
    }

    private void RecordSkipped(string type, Identifier id) {
        if (!_skipped.TryGetValue(type, out List<Identifier>? ids)) {
            _skipped[type] = ids = [];
        }

        if (!ids.Contains(id)) {
            ids.Add(id);
        }
    }

    /// <summary>
    /// Builds the global feature order, vanilla's <c>FeatureSorter.buildFeaturesPerStep</c>.
    /// </summary>
    /// <remarks>
    /// This is not a formality. A feature's <b>index in the global list</b> is what seeds it, so two
    /// biomes sharing a feature give it the same seed and the same feature keeps its seed however many
    /// biomes a chunk touches. Ordering per biome instead would make a chunk's trees depend on which
    /// biome happened to be looked at first.
    /// <p/>
    /// The sort is a topological one over "this feature comes before that one in some biome's list",
    /// which is what makes the order consistent with every biome at once.
    /// </remarks>
    /// <remarks>
    /// The sort runs over what the biomes <b>name</b> rather than over what this build can construct,
    /// which is why it is keyed on the identifier. A feature that is not transcribed is still a vertex
    /// with a discovery index and an edge either side of it, exactly as it is upstream, and is dropped
    /// only from the finished lists. Leaving it out of the graph instead renumbers everything after it
    /// and short circuits the chain it sat in, which moves features that are transcribed.
    /// </remarks>
    private BiomeFeatureTable BuildTable(IReadOnlyList<Identifier> biomes) {
        Dictionary<Identifier, List<List<Identifier>>> named = [];
        Dictionary<Identifier, int> discoveryIndex = [];
        int nextIndex = 0;
        int maxStep = 0;

        // In the order given, which is the biome source's own and is what breaks ties in the
        // topological sort.
        foreach (Identifier biome in biomes) {
            if (!_biomeJson.ContainsKey(biome) || named.ContainsKey(biome)) {
                continue;
            }

            List<List<Identifier>> steps = [];

            foreach (JsonElement step in _biomeJson[biome].RootElement.GetProperty("features").EnumerateArray()) {
                List<Identifier> features = [];

                foreach (JsonElement entry in step.EnumerateArray()) {
                    Identifier id = Identifier.Parse(entry.GetString()!);

                    // For the report rather than for the sort: a feature that cannot be built is still
                    // ordered, and this is what records that it is missing.
                    _ = ResolvePlaced(id);

                    if (!discoveryIndex.ContainsKey(id)) {
                        discoveryIndex[id] = nextIndex++;
                    }

                    features.Add(id);
                }

                steps.Add(features);
            }

            maxStep = Math.Max(maxStep, steps.Count);
            named[biome] = steps;
        }

        List<List<Identifier>> globalOrder = TopologicalOrder(named, discoveryIndex, maxStep);

        // The global list keeps its untranscribed slots, because an index in it is what seeds a
        // feature; a biome's own list drops them, because nothing runs them.
        return new BiomeFeatureTable(Resolve(named),
            globalOrder.Select(step => step.Select(ResolvePlaced).ToList()).ToList());
    }

    /// <summary>The named features that this build can construct, in the order they were named.</summary>
    private Dictionary<Identifier, List<List<PlacedFeature>>> Resolve(
        Dictionary<Identifier, List<List<Identifier>>> named) {

        Dictionary<Identifier, List<List<PlacedFeature>>> resolved = [];

        foreach ((Identifier biome, List<List<Identifier>> steps) in named) {
            resolved[biome] = steps.Select(Resolve).ToList();
        }

        return resolved;
    }

    private List<PlacedFeature> Resolve(List<Identifier> ids) {
        List<PlacedFeature> features = [];

        foreach (Identifier id in ids) {
            if (ResolvePlaced(id) is { } placed) {
                features.Add(placed);
            }
        }

        return features;
    }

    /// <summary>
    /// The topological sort itself: an edge from each feature to the one after it in the same biome's
    /// list, then a depth first walk whose output is reversed.
    /// </summary>
    /// <remarks>
    /// Vanilla orders both the vertex set and each vertex's edges by (step, discovery index), and that
    /// ordering is what makes the result deterministic rather than merely valid. A cycle is a datapack
    /// error and throws, as it does upstream.
    /// </remarks>
    private static List<List<Identifier>> TopologicalOrder(
        Dictionary<Identifier, List<List<Identifier>>> named,
        Dictionary<Identifier, int> discoveryIndex, int maxStep) {

        Comparison<(int Step, int Index, Identifier Feature)> compare =
            (a, b) => a.Step != b.Step ? a.Step.CompareTo(b.Step) : a.Index.CompareTo(b.Index);

        SortedDictionary<(int Step, int Index), (int Step, int Index, Identifier Feature)> vertices =
            new(Comparer<(int Step, int Index)>.Create((a, b) =>
                a.Step != b.Step ? a.Step.CompareTo(b.Step) : a.Index.CompareTo(b.Index)));

        Dictionary<(int, int), SortedSet<(int Step, int Index, Identifier Feature)>> edges = [];

        foreach (List<List<Identifier>> steps in named.Values) {
            List<(int Step, int Index, Identifier Feature)> flattened = [];

            for (int step = 0; step < steps.Count; step++) {
                foreach (Identifier feature in steps[step]) {
                    flattened.Add((step, discoveryIndex[feature], feature));
                }
            }

            for (int i = 0; i < flattened.Count; i++) {
                (int Step, int Index, Identifier Feature) vertex = flattened[i];
                vertices[(vertex.Step, vertex.Index)] = vertex;

                if (!edges.TryGetValue((vertex.Step, vertex.Index), out SortedSet<(int, int, Identifier)>? set)) {
                    edges[(vertex.Step, vertex.Index)] = set =
                        new SortedSet<(int Step, int Index, Identifier Feature)>(
                            Comparer<(int Step, int Index, Identifier Feature)>.Create(compare));
                }

                if (i < flattened.Count - 1) {
                    set.Add(flattened[i + 1]);
                }
            }
        }

        HashSet<(int, int)> discovered = [];
        HashSet<(int, int)> visiting = [];
        List<(int Step, int Index, Identifier Feature)> sorted = [];

        foreach ((int Step, int Index, Identifier Feature) vertex in vertices.Values) {
            Visit(vertex, edges, discovered, visiting, sorted);
        }

        sorted.Reverse();

        List<List<Identifier>> byStep = [];
        for (int step = 0; step < maxStep; step++) {
            List<Identifier> features = [];
            foreach ((int Step, int Index, Identifier Feature) vertex in sorted) {
                if (vertex.Step == step) {
                    features.Add(vertex.Feature);
                }
            }

            byStep.Add(features);
        }

        return byStep;
    }

    private static void Visit((int Step, int Index, Identifier Feature) vertex,
        Dictionary<(int, int), SortedSet<(int Step, int Index, Identifier Feature)>> edges,
        HashSet<(int, int)> discovered, HashSet<(int, int)> visiting,
        List<(int Step, int Index, Identifier Feature)> sorted) {

        (int, int) key = (vertex.Step, vertex.Index);

        if (discovered.Contains(key)) {
            return;
        }

        if (!visiting.Add(key)) {
            throw new InvalidOperationException(
                "The biome feature lists contain a cycle, so no order satisfies all of them.");
        }

        if (edges.TryGetValue(key, out SortedSet<(int Step, int Index, Identifier Feature)>? next)) {
            foreach ((int Step, int Index, Identifier Feature) child in next) {
                Visit(child, edges, discovered, visiting, sorted);
            }
        }

        visiting.Remove(key);
        discovered.Add(key);
        sorted.Add(vertex);
    }
}

/// <summary>
/// Which features a biome has, and where each sits in the global order.
/// </summary>
/// <remarks>
/// The index is what seeds a feature, so it has to come from the global list rather than from the
/// biome's own. <see cref="Contains"/> is what the biome placement filter asks per position.
/// </remarks>
/// <summary>
/// A dimension's feature lists: what each biome asks for, and the one global order per decoration step
/// that decides the seeds.
/// </summary>
/// <remarks>
/// <b>The global list holds every feature the biomes name, transcribed or not.</b> A feature is seeded
/// from its index in that list, and vanilla numbers it over what the datapack says rather than over
/// what this build can construct, so leaving the untranscribed ones out would renumber everything after
/// them and place it somewhere else. They come back as a null slot, which the pass steps over.
/// </remarks>
public sealed class BiomeFeatureTable {
    private readonly Dictionary<Identifier, List<List<PlacedFeature>>> _perBiome;
    private readonly List<List<PlacedFeature?>> _globalOrder;
    private readonly Dictionary<PlacedFeature, int>[] _indexInStep;
    private readonly Dictionary<Identifier, HashSet<PlacedFeature>> _membership;

    internal BiomeFeatureTable(Dictionary<Identifier, List<List<PlacedFeature>>> perBiome,
        List<List<PlacedFeature?>> globalOrder) {

        _perBiome = perBiome;
        _globalOrder = globalOrder;

        _indexInStep = new Dictionary<PlacedFeature, int>[globalOrder.Count];
        for (int step = 0; step < globalOrder.Count; step++) {
            Dictionary<PlacedFeature, int> lookup = [];
            for (int i = 0; i < globalOrder[step].Count; i++) {
                if (globalOrder[step][i] is { } feature) {
                    lookup[feature] = i;
                }
            }

            _indexInStep[step] = lookup;
        }

        _membership = [];
        foreach ((Identifier biome, List<List<PlacedFeature>> steps) in perBiome) {
            HashSet<PlacedFeature> all = [];
            foreach (List<PlacedFeature> step in steps) {
                all.UnionWith(step);
            }

            _membership[biome] = all;
        }
    }

    public int StepCount => _globalOrder.Count;

    /// <summary>
    /// The step's features in the order that seeds them, with a null where one is not transcribed.
    /// </summary>
    public IReadOnlyList<PlacedFeature?> GlobalStep(int step) => _globalOrder[step];

    public int IndexOf(int step, PlacedFeature feature) => _indexInStep[step][feature];

    /// <summary>The features a biome asks for at a step, or nothing when it has none.</summary>
    public IReadOnlyList<PlacedFeature> For(Identifier biome, int step) {
        if (!_perBiome.TryGetValue(biome, out List<List<PlacedFeature>>? steps) || step >= steps.Count) {
            return [];
        }

        return steps[step];
    }

    public bool Contains(Identifier biome, PlacedFeature feature) {
        return _membership.TryGetValue(biome, out HashSet<PlacedFeature>? all) && all.Contains(feature);
    }
}
