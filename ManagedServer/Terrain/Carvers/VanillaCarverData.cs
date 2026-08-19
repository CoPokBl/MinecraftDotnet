using System.Text.Json;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// The vanilla configured carvers and the per biome carver lists, embedded and parsed on demand.
/// </summary>
/// <remarks>
/// The same bargain as the worldgen and feature data beside it: the four carver files are copied
/// verbatim rather than transcribed, and the biome files are the ones the feature pass already
/// embeds, trimmed to their <c>features</c> and <c>carvers</c> lists on the way in.
/// <p/>
/// Unlike the feature table there is no global ordering to build. A carver's seed comes from the
/// source chunk and its <b>index in that biome's own list</b>, so two biomes listing the same carver
/// in different positions genuinely give it different seeds, and nothing has to be reconciled between
/// them.
/// <p/>
/// Cached per registry, so a server with several worlds parses this once. Everything under it is
/// immutable and a carver holds no per world state.
/// </remarks>
public sealed class VanillaCarverData {

    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), VanillaCarverData>
        Cache = new();
    private static readonly Lock CacheLock = new();

    private readonly Dictionary<Identifier, JsonDocument> _carverJson = [];
    private readonly Dictionary<Identifier, JsonDocument> _biomeJson = [];

    private readonly Dictionary<Identifier, ConfiguredWorldCarver> _carvers = [];
    private readonly Dictionary<Identifier, IReadOnlyList<ConfiguredWorldCarver>> _perBiome = [];

    private readonly CarverParser _parser;

    private VanillaCarverData(MinecraftRegistry registry, IDatapackSource source) {
        _parser = new CarverParser(new BlockParser(registry));

        Read(source, "worldgen/configured_carver", _carverJson);
        Read(source, "worldgen/biome", _biomeJson);
    }

    private static void Read(IDatapackSource source, string registryPath,
        Dictionary<Identifier, JsonDocument> into) {

        foreach (DatapackEntry entry in source.Entries(registryPath)) {
            using Stream stream = source.Open(entry.Path);
            into[entry.Id] = JsonDocument.Parse(stream);
        }
    }


    public static VanillaCarverData Load(IDatapackSource source, MinecraftRegistry? registry = null) {
        MinecraftRegistry actual = registry ?? Minecraft.Data.Generated.VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out VanillaCarverData? existing)) {
                return existing;
            }

            VanillaCarverData data = new(actual, source);
            Cache[(actual, source)] = data;
            return data;
        }
    }

    /// <summary>
    /// A biome's carvers, in the order it lists them, which is the order their indices come from.
    /// </summary>
    /// <remarks>
    /// A biome with no entry answers nothing rather than throwing: the biome registry is datapack
    /// driven, so a consumer may have added one this data has never heard of.
    /// <p/>
    /// The list is a <c>HolderSet</c>, so a biome with exactly one carver writes it as a bare string
    /// rather than as an array. All five nether biomes do.
    /// </remarks>
    public IReadOnlyList<ConfiguredWorldCarver> For(Identifier biome) {
        lock (CacheLock) {
            if (_perBiome.TryGetValue(biome, out IReadOnlyList<ConfiguredWorldCarver>? existing)) {
                return existing;
            }

            List<ConfiguredWorldCarver> carvers = [];

            if (_biomeJson.TryGetValue(biome, out JsonDocument? document)) {
                JsonElement listed = document.RootElement.GetProperty("carvers");

                if (listed.ValueKind == JsonValueKind.String) {
                    carvers.Add(GetListed(listed));
                } else {
                    foreach (JsonElement entry in listed.EnumerateArray()) {
                        carvers.Add(GetListed(entry));
                    }
                }
            }

            _perBiome[biome] = carvers;
            return carvers;
        }
    }

    /// <summary>
    /// One entry of a biome's carver list. A <c>#tag</c> reference is refused rather than skipped:
    /// vanilla has no carver tags, and a biome silently losing its caves is exactly the failure this
    /// data set is copied verbatim to avoid.
    /// </summary>
    private ConfiguredWorldCarver GetListed(JsonElement entry) {
        string value = entry.GetString()!;

        if (value.StartsWith('#')) {
            throw new FormatException($"A biome's carver list names the tag \"{value}\", which is not "
                + "supported.");
        }

        return Get(Identifier.Parse(value));
    }

    /// <summary>Every configured carver in the data, by the id vanilla registers it under.</summary>
    public IReadOnlyCollection<Identifier> Ids => _carverJson.Keys;

    /// <summary>A configured carver by id, parsed on first use.</summary>
    public ConfiguredWorldCarver Get(Identifier id) {
        if (_carvers.TryGetValue(id, out ConfiguredWorldCarver? existing)) {
            return existing;
        }

        if (!_carverJson.TryGetValue(id, out JsonDocument? document)) {
            throw new InvalidOperationException($"No configured carver registered as \"{id}\".");
        }

        ConfiguredWorldCarver carver = _parser.Parse(document.RootElement);
        _carvers[id] = carver;
        return carver;
    }
}
