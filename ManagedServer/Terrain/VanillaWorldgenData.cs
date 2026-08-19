using System.Text.Json;
using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Noise;
using ManagedServer.Terrain.Surface;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain;

/// <summary>
/// The worldgen data a <see cref="IDatapackSource"/> carries, parsed on demand.
/// </summary>
/// <remarks>
/// These are the files vanilla's own codecs read, and they are read rather than transcribed on
/// purpose: the density function tree is 460KB of nested expressions and every constant in it decides
/// the shape of the world, so a hand written version would be a few thousand chances to be quietly
/// wrong about a mountain.
/// <p/>
/// <b>They are the consumer's files, not ours.</b> Nothing Mojang wrote ships here, so a world gets
/// vanilla terrain because it was handed a source holding the vanilla data, which
/// <see cref="VanillaDatapack.Download"/> will fetch. That is also what makes worldgen configurable:
/// a consumer layers their own pack over it and overrides one function.
/// <p/>
/// <see cref="Load"/> is cached per registry and source, so a server with several worlds off one pack
/// parses this once. Resolving is lazy and memoised, and cycles are reported rather than being
/// followed forever.
/// </remarks>
public sealed class VanillaWorldgenData : IDensityFunctionSource {
    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), VanillaWorldgenData>
        Cache = new();

    private static readonly Lock CacheLock = new();

    private readonly MinecraftRegistry _registry;
    private readonly IDatapackSource _source;
    private readonly Dictionary<Identifier, NoiseParameters> _noiseParameters = [];
    private readonly Dictionary<Identifier, JsonDocument> _densityFunctionJson = [];
    private readonly Dictionary<Identifier, JsonDocument> _noiseSettingsJson = [];

    private readonly Dictionary<Identifier, IDensityFunction> _densityFunctions = [];
    private readonly HashSet<Identifier> _resolving = [];

    private readonly Dictionary<Identifier, NoiseGeneratorSettings> _noiseSettings = [];
    private readonly Dictionary<Identifier, ClimateParameterList<Identifier>> _biomeParameterLists = [];

    private readonly DensityFunctionParser _densityParser;
    private readonly SurfaceRuleParser _surfaceParser;

    private VanillaWorldgenData(MinecraftRegistry registry, IDatapackSource source) {
        _registry = registry;
        _source = source;
        _densityParser = new DensityFunctionParser(this);
        _surfaceParser = new SurfaceRuleParser(registry);

        foreach (DatapackEntry entry in source.Entries("worldgen/noise")) {
            using Stream stream = source.Open(entry.Path);
            using JsonDocument document = JsonDocument.Parse(stream);
            _noiseParameters[entry.Id] = ParseNoiseParameters(document.RootElement);
        }

        // The two kept as documents are resolved lazily, since a density function references others
        // and a noise setting names a router that is most of the tree.
        foreach (DatapackEntry entry in source.Entries("worldgen/density_function")) {
            using Stream stream = source.Open(entry.Path);
            _densityFunctionJson[entry.Id] = JsonDocument.Parse(stream);
        }

        foreach (DatapackEntry entry in source.Entries("worldgen/noise_settings")) {
            using Stream stream = source.Open(entry.Path);
            _noiseSettingsJson[entry.Id] = JsonDocument.Parse(stream);
        }

        if (_noiseParameters.Count == 0 || _densityFunctionJson.Count == 0) {
            throw new InvalidOperationException(
                $"\"{source.Describe()}\" carries no worldgen data: it has no "
                + "data/<namespace>/worldgen/noise or /density_function. A vanilla server jar is a "
                + "datapack and can be used directly; VanillaDatapack.Download fetches one.");
        }
    }

    /// <summary>The data for a registry and a source, parsed once and shared.</summary>
    /// <remarks>
    /// Keyed on both, because two sources are two different worlds and the registry decides which
    /// biomes a climate table may name.
    /// </remarks>
    public static VanillaWorldgenData Load(IDatapackSource source, MinecraftRegistry? registry = null) {
        MinecraftRegistry actual = registry ?? Minecraft.Data.Generated.VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out VanillaWorldgenData? existing)) {
                return existing;
            }

            VanillaWorldgenData data = new(actual, source);
            Cache[(actual, source)] = data;
            return data;
        }
    }

    public IReadOnlyDictionary<Identifier, NoiseParameters> NoiseParameters => _noiseParameters;

    public bool HasNoise(Identifier id) => _noiseParameters.ContainsKey(id);

    /// <summary>
    /// A density function by its registry id, built on first use.
    /// </summary>
    /// <remarks>
    /// Resolution is recursive because the files reference each other, and the guard is what turns a
    /// cycle into a message rather than a stack overflow. The vanilla data has none; a consumer's
    /// override could.
    /// </remarks>
    public IDensityFunction Resolve(Identifier id) {
        if (_densityFunctions.TryGetValue(id, out IDensityFunction? existing)) {
            return existing;
        }

        if (!_densityFunctionJson.TryGetValue(id, out JsonDocument? document)) {
            throw new InvalidOperationException($"No density function registered as \"{id}\".");
        }

        if (!_resolving.Add(id)) {
            throw new InvalidOperationException($"Density function \"{id}\" refers to itself.");
        }

        try {
            IDensityFunction function = _densityParser.Parse(document.RootElement);
            _densityFunctions[id] = function;
            return function;
        } finally {
            _resolving.Remove(id);
        }
    }

    /// <summary>A dimension's noise settings, parsed on first use.</summary>
    public NoiseGeneratorSettings GetNoiseSettings(Identifier id) {
        if (_noiseSettings.TryGetValue(id, out NoiseGeneratorSettings? existing)) {
            return existing;
        }

        if (!_noiseSettingsJson.TryGetValue(id, out JsonDocument? document)) {
            throw new InvalidOperationException($"No noise settings registered as \"{id}\".");
        }

        JsonElement root = document.RootElement;
        JsonElement noise = root.GetProperty("noise");

        NoiseGeneratorSettings settings = new(
            new NoiseSettings(noise.GetProperty("min_y").GetInt32(), noise.GetProperty("height").GetInt32(),
                noise.GetProperty("size_horizontal").GetInt32(), noise.GetProperty("size_vertical").GetInt32()),
            _surfaceParser.ParseBlockState(root.GetProperty("default_block")),
            _surfaceParser.ParseBlockState(root.GetProperty("default_fluid")),
            ParseRouter(root.GetProperty("noise_router")),
            _surfaceParser.ParseRule(root.GetProperty("surface_rule")),
            root.GetProperty("sea_level").GetInt32(),
            root.GetProperty("aquifers_enabled").GetBoolean(),
            root.GetProperty("ore_veins_enabled").GetBoolean(),
            root.GetProperty("legacy_random_source").GetBoolean());

        _noiseSettings[id] = settings;
        return settings;
    }

    private NoiseRouter ParseRouter(JsonElement element) {
        return new NoiseRouter(
            _densityParser.Parse(element.GetProperty("barrier")),
            _densityParser.Parse(element.GetProperty("fluid_level_floodedness")),
            _densityParser.Parse(element.GetProperty("fluid_level_spread")),
            _densityParser.Parse(element.GetProperty("lava")),
            _densityParser.Parse(element.GetProperty("temperature")),
            _densityParser.Parse(element.GetProperty("vegetation")),
            _densityParser.Parse(element.GetProperty("continents")),
            _densityParser.Parse(element.GetProperty("erosion")),
            _densityParser.Parse(element.GetProperty("depth")),
            _densityParser.Parse(element.GetProperty("ridges")),
            _densityParser.Parse(element.GetProperty("preliminary_surface_level")),
            _densityParser.Parse(element.GetProperty("final_density")),
            _densityParser.Parse(element.GetProperty("vein_toggle")),
            _densityParser.Parse(element.GetProperty("vein_ridged")),
            _densityParser.Parse(element.GetProperty("vein_gap")));
    }

    /// <summary>
    /// A multi noise biome preset's climate to biome table, built on first use.
    /// </summary>
    /// <remarks>
    /// This table is not in the datapack: <c>multi_noise_biome_source_parameter_list</c> is one field
    /// naming a preset, and the preset is code in the jar. So it is transcribed rather than read, in
    /// <see cref="OverworldBiomeBuilder"/>. Building the R-tree over 7599 regions takes long enough to
    /// be worth doing lazily.
    /// <p/>
    /// A biome the registry does not have is dropped rather than failing the load, since the biome
    /// registry is datapack driven and a consumer may have removed one.
    /// </remarks>
    public ClimateParameterList<Identifier> GetBiomeParameters(Identifier preset) {
        if (_biomeParameterLists.TryGetValue(preset, out ClimateParameterList<Identifier>? existing)) {
            return existing;
        }

        // The two vanilla presets. An unknown one throws rather than reading as empty, which would be
        // a world where every position resolves to whatever the search does with no regions at all.
        List<(ClimateParameterPoint Point, Identifier Biome)> built = preset.ToString() switch {
            "minecraft:overworld" => OverworldBiomeBuilder.Build(),
            "minecraft:nether" => NetherBiomePreset.Build(),
            _ => throw new InvalidOperationException(
                $"No biome parameter preset named \"{preset}\". Vanilla has minecraft:overworld and "
                + "minecraft:nether, and both are built in code rather than carried by the datapack.")
        };

        List<(ClimateParameterPoint, Identifier)> values = built
            .Where(entry => _registry.Biomes.Contains(entry.Biome))
            .Select(entry => (entry.Point, entry.Biome))
            .ToList();

        ClimateParameterList<Identifier> list = new(values);
        _biomeParameterLists[preset] = list;
        return list;
    }

    private static NoiseParameters ParseNoiseParameters(JsonElement element) {
        List<double> amplitudes = [];
        foreach (JsonElement amplitude in element.GetProperty("amplitudes").EnumerateArray()) {
            amplitudes.Add(amplitude.GetDouble());
        }

        return new NoiseParameters(element.GetProperty("firstOctave").GetInt32(), amplitudes);
    }

}
