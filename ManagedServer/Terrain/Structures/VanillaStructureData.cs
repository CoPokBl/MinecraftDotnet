using System.Text.Json;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// The vanilla structures and structure sets, read from the pack once per registry.
/// </summary>
/// <remarks>
/// The same bargain as the worldgen, feature and carver data beside it: the files are read rather than
/// transcribed, so a spacing or a biome list that changes upstream comes across with the pack rather
/// than being missed.
/// <p/>
/// A set whose structures are all skipped is dropped, so the placement pass does not roll for a
/// structure it could not build anyway.
/// </remarks>
public sealed class VanillaStructureData {

    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), VanillaStructureData>
        Cache = new();
    private static readonly Lock CacheLock = new();

    private readonly Dictionary<Identifier, Structure> _structures = [];
    private readonly Dictionary<Identifier, StructureSet> _sets = [];
    private readonly List<string> _skipped = [];

    private VanillaStructureData(MinecraftRegistry registry, IDatapackSource source,
        VanillaFeatureData features) {

        StructureParser parser = new(registry, StructureTemplateManager.Load(source, registry),
            TemplatePools.Load(source, ProcessorLists.Load(source, registry), features, registry));

        Dictionary<Identifier, JsonDocument> structureJson = [];
        Dictionary<Identifier, JsonDocument> setJson = [];

        Read(source, "worldgen/structure", structureJson);
        Read(source, "worldgen/structure_set", setJson);

        if (structureJson.Count == 0 || setJson.Count == 0) {
            throw new InvalidOperationException(
                $"\"{source.Describe()}\" carries no structure data: it has no "
                + "data/<namespace>/worldgen/structure or /structure_set.");
        }

        foreach ((Identifier id, JsonDocument document) in structureJson) {
            Structure? structure = parser.Parse(id, document.RootElement);

            if (structure is null) {
                Identifier type = Identifier.Parse(
                    document.RootElement.GetProperty("type").GetString()!);

                _skipped.Add($"{id} ({StructureParser.SkipReason(type)})");

                continue;
            }

            _structures[id] = structure;
        }

        foreach ((Identifier id, JsonDocument document) in setJson) {
            StructureSet set = parser.ParseSet(document.RootElement);

            List<StructureSet.Entry> present = set.Structures
                .Where(entry => _structures.ContainsKey(entry.Structure))
                .ToList();

            if (present.Count == 0) {
                continue;
            }

            _sets[id] = set with { Structures = present };
        }
    }

    private static void Read(IDatapackSource source, string registryPath,
        Dictionary<Identifier, JsonDocument> into) {

        foreach (DatapackEntry entry in source.Entries(registryPath)) {
            using Stream stream = source.Open(entry.Path);
            into[entry.Id] = JsonDocument.Parse(stream);
        }
    }

    public static VanillaStructureData Load(IDatapackSource source, VanillaFeatureData features,
        MinecraftRegistry? registry = null) {

        MinecraftRegistry actual = registry ?? Minecraft.Data.Generated.VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out VanillaStructureData? existing)) {
                return existing;
            }

            VanillaStructureData data = new(actual, source, features);
            Cache[(actual, source)] = data;
            return data;
        }
    }

    /// <summary>Every set that has at least one structure this build can build.</summary>
    public IReadOnlyDictionary<Identifier, StructureSet> Sets => _sets;

    /// <summary>Every structure this build transcribes, by the id vanilla registers it under.</summary>
    public IReadOnlyDictionary<Identifier, Structure> Structures => _structures;

    /// <summary>
    /// What was in the datapack and did not survive the load, with the reason for each.
    /// </summary>
    /// <remarks>
    /// Reported rather than silent, on <c>VanillaFeatureData.Skipped</c>'s reasoning: a world that
    /// generates and has no villages in it looks exactly like a world whose villages are rare.
    /// </remarks>
    public IReadOnlyList<string> Skipped => _skipped;
}
