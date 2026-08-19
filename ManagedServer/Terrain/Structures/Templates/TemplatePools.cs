using System.Text.Json;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// The <c>worldgen/template_pool</c> registry, read from the pack.
/// </summary>
/// <remarks>
/// Read eagerly and whole, because a pool's fallback and every jigsaw block's target pool are looked
/// up while a structure is being laid out on the thread pool. Resolving one lazily there would need a
/// lock on the hot path of the placer.
/// <p/>
/// <b>A pool naming a missing one is not fatal.</b> Vanilla logs and treats the connection as
/// unfillable, and a datapack that removes a pool relies on that. What is fatal is a pool file this
/// build cannot read, which is the parser's own bargain.
/// <p/>
/// The one exception is an element whose feature is not transcribed: it is <b>dropped from its pool</b>
/// and reported through <see cref="Dropped"/>, on <c>FeatureParser.DroppedNested</c>'s reasoning.
/// Failing the load would take out every structure using that pool, and keeping the element would
/// consume a connection and put nothing there.
/// </remarks>
public sealed class TemplatePools {
    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), TemplatePools> Cache =
        new();

    private static readonly Lock CacheLock = new();

    /// <summary>The pool every fallback chain ends at, and the one an unfillable target answers.</summary>
    public static readonly Identifier Empty = "minecraft:empty";

    private readonly Dictionary<Identifier, StructureTemplatePool> _pools = [];
    private readonly List<string> _dropped = [];

    private TemplatePools(MinecraftRegistry registry, IDatapackSource source,
        ProcessorLists processors, VanillaFeatureData features) {

        PoolParser parser = new(processors, features);

        foreach (DatapackEntry entry in source.Entries("worldgen/template_pool")) {
            using Stream stream = source.Open(entry.Path);
            using JsonDocument document = JsonDocument.Parse(stream);

            try {
                _pools[entry.Id] = parser.Parse(document.RootElement);

                foreach (string dropped in parser.Dropped) {
                    _dropped.Add($"{entry.Id} ({dropped})");
                }

                parser.Dropped.Clear();
            } catch (Exception error) {
                throw new FormatException(
                    $"The template pool \"{entry.Id}\" did not read: {error.Message}", error);
            }
        }
    }

    public static TemplatePools Load(IDatapackSource source, ProcessorLists processors,
        VanillaFeatureData features, MinecraftRegistry? registry = null) {

        MinecraftRegistry actual = registry ?? VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out TemplatePools? existing)) {
                return existing;
            }

            TemplatePools pools = new(actual, source, processors, features);
            Cache[(actual, source)] = pools;
            return pools;
        }
    }

    /// <summary>
    /// The pool entries dropped because their feature is not transcribed, with the reason for each.
    /// </summary>
    public IReadOnlyList<string> Dropped => _dropped;

    /// <summary>The named pool, or null where the pack has none.</summary>
    public StructureTemplatePool? Get(Identifier id) => _pools.GetValueOrDefault(id);

    public int Count => _pools.Count;
}

/// <summary>Reads one <c>template_pool</c> file.</summary>
/// <remarks>
/// The projection is written onto each element after it is built rather than passed in, because a
/// list element has to push it down to the elements inside it and only knows them once they exist.
/// </remarks>
public sealed class PoolParser(ProcessorLists processors, VanillaFeatureData features) {
    /// <summary>What this parser dropped since the list was last cleared, with the reason.</summary>
    public List<string> Dropped { get; } = [];

    public StructureTemplatePool Parse(JsonElement root) {
        Identifier fallback = Identifier.Parse(root.GetProperty("fallback").GetString()!);

        List<(IStructurePoolElement Element, int Weight)> entries = [];

        foreach (JsonElement entry in root.GetProperty("elements").EnumerateArray()) {
            if (ParseElement(entry.GetProperty("element")) is { } parsed) {
                entries.Add((parsed, entry.GetProperty("weight").GetInt32()));
            }
        }

        return new StructureTemplatePool(fallback, entries);
    }

    /// <summary>One element, or null where its feature is not transcribed.</summary>
    public IStructurePoolElement? ParseElement(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("element_type").GetString()!).Key;

        PoolProjection projection = element.TryGetProperty("projection", out JsonElement written)
            ? ParseProjection(written.GetString()!)
            : PoolProjection.Rigid;

        switch (type) {
            case "empty_pool_element":
                return EmptyPoolElement.Instance;

            case "single_pool_element":
                return new SinglePoolElement(TemplateOf(element), ProcessorsOf(element), projection,
                    LiquidsOf(element));

            case "legacy_single_pool_element":
                return new LegacySinglePoolElement(TemplateOf(element), ProcessorsOf(element),
                    projection, LiquidsOf(element));

            case "list_pool_element": {
                List<IStructurePoolElement> inner = [];

                foreach (JsonElement nested in element.GetProperty("elements").EnumerateArray()) {
                    if (ParseElement(nested) is { } parsed) {
                        inner.Add(parsed);
                    }
                }

                // A list that lost every element has nothing to place and no connections, so it is
                // dropped whole rather than becoming an element that answers nothing.
                return inner.Count == 0 ? null : new ListPoolElement(inner, projection);
            }

            case "feature_pool_element": {
                Identifier id = Identifier.Parse(element.GetProperty("feature").GetString()!);

                if (features.Placed(id) is not { } placed) {
                    Dropped.Add($"the placed feature {id} is not transcribed");
                    return null;
                }

                return new FeaturePoolElement(id, placed, projection);
            }

            default:
                throw new FormatException($"Unknown structure pool element type \"{type}\".");
        }
    }

    /// <summary>
    /// A single element's template, which is always a location rather than an inline template.
    /// </summary>
    /// <remarks>
    /// The format allows an inline <c>StructureTemplate</c> in place of an id, which is how the
    /// structure block writes one out. No pack ships one, and reading it would mean a second parse of
    /// the template format against JSON rather than NBT.
    /// </remarks>
    private static Identifier TemplateOf(JsonElement element) {
        JsonElement location = element.GetProperty("location");

        return location.ValueKind == JsonValueKind.String
            ? Identifier.Parse(location.GetString()!)
            : throw new FormatException(
                "A pool element carries an inline structure template, which this build does not read.");
    }

    /// <summary>
    /// The element's processors, written either as a list id or as an inline list.
    /// </summary>
    private IReadOnlyList<IStructureProcessor> ProcessorsOf(JsonElement element) {
        if (!element.TryGetProperty("processors", out JsonElement written)) {
            return [];
        }

        if (written.ValueKind == JsonValueKind.String) {
            return processors.Get(Identifier.Parse(written.GetString()!));
        }

        return new ProcessorParser(VanillaRegistry.Data).ParseList(written);
    }

    /// <summary>
    /// The element's liquid override, or null to take the structure's own setting.
    /// </summary>
    private static bool? LiquidsOf(JsonElement element) {
        return element.TryGetProperty("override_liquid_settings", out JsonElement written)
            ? ParseLiquidSettings(written.GetString()!)
            : null;
    }

    public static bool ParseLiquidSettings(string value) {
        return value switch {
            "apply_waterlogging" => true,
            "ignore_waterlogging" => false,
            _ => throw new FormatException($"Unknown liquid settings \"{value}\".")
        };
    }

    private static PoolProjection ParseProjection(string value) {
        return value switch {
            "terrain_matching" => PoolProjection.TerrainMatching,
            "rigid" => PoolProjection.Rigid,
            _ => throw new FormatException($"Unknown pool projection \"{value}\".")
        };
    }
}
