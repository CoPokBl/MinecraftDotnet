using System.Collections.Concurrent;
using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Noise;
using ManagedServer.Terrain.Surface;
using Minecraft.Schemas;

namespace ManagedServer.Terrain;

/// <summary>What a chunk being generated needs off the world's seeded state.</summary>
public interface IRandomState : ISurfaceRandomState {
    /// <summary>The router with every noise bound to this world's seed.</summary>
    NoiseRouter Router { get; }

    IPositionalRandomFactory AquiferRandom { get; }

    IPositionalRandomFactory OreRandom { get; }
}

/// <summary>
/// One world's seeded worldgen state, vanilla's <c>RandomState</c>: the noises, the random factories
/// and the router bound to them.
/// </summary>
/// <remarks>
/// Nothing here draws from a running sequence. Every noise is seeded from a hash of <b>its own name</b>
/// under a factory derived from the world seed, and every positional random from a hash of its
/// purpose. That is what makes a chunk generate identically whatever order chunks are asked for and
/// however many threads are asking.
/// <p/>
/// Shared by every chunk of a world and touched from the pool, so the two lazy maps are concurrent.
/// </remarks>
public sealed class RandomState : IRandomState {
    private readonly IPositionalRandomFactory _random;
    private readonly IReadOnlyDictionary<Identifier, NoiseParameters> _noiseParameters;

    private readonly ConcurrentDictionary<Identifier, NormalNoise> _noiseInstances = new();
    private readonly ConcurrentDictionary<Identifier, IPositionalRandomFactory> _positionalRandoms = new();

    public RandomState(NoiseGeneratorSettings settings, IReadOnlyDictionary<Identifier, NoiseParameters> noiseParameters,
        long seed) {

        _noiseParameters = noiseParameters;

        RandomSource root = settings.UseLegacyRandomSource
            ? new LegacyRandomSource(seed)
            : new XoroshiroRandomSource(seed);

        _random = root.ForkPositional();

        AquiferRandom = _random.FromHashOf("minecraft:aquifer").ForkPositional();
        OreRandom = _random.FromHashOf("minecraft:ore").ForkPositional();

        SurfaceSystem = new SurfaceSystem(this, settings.DefaultBlock, settings.SeaLevel, _random);

        Router = settings.NoiseRouter.MapAll(new NoiseWiringVisitor(this, seed, settings.UseLegacyRandomSource));

        // A second router with every marker stripped, for sampling climate away from a chunk. The
        // caches a marker becomes are per chunk, so a bare tree is the only thing that can be sampled
        // at an arbitrary position.
        Sampler = new ClimateSampler(
            Router.Temperature.MapAll(NoiseFlattener.Instance),
            Router.Vegetation.MapAll(NoiseFlattener.Instance),
            Router.Continents.MapAll(NoiseFlattener.Instance),
            Router.Erosion.MapAll(NoiseFlattener.Instance),
            Router.Depth.MapAll(NoiseFlattener.Instance),
            Router.Ridges.MapAll(NoiseFlattener.Instance));
    }

    public NoiseRouter Router { get; }

    /// <summary>The uncached climate sampler, for a position outside any chunk being generated.</summary>
    public ClimateSampler Sampler { get; }

    public SurfaceSystem SurfaceSystem { get; }

    public IPositionalRandomFactory AquiferRandom { get; }

    public IPositionalRandomFactory OreRandom { get; }

    public NormalNoise GetOrCreateNoise(Identifier id) {
        return _noiseInstances.GetOrAdd(id, key => {
            if (!_noiseParameters.TryGetValue(key, out NoiseParameters? parameters)) {
                throw new InvalidOperationException($"No noise parameters registered for \"{key}\".");
            }

            return NormalNoise.Create(_random.FromHashOf(key.ToString()), parameters);
        });
    }

    public IPositionalRandomFactory GetOrCreateRandomFactory(Identifier name) {
        return _positionalRandoms.GetOrAdd(name, key => _random.FromHashOf(key.ToString()).ForkPositional());
    }

    /// <summary>
    /// Binds a parsed tree to this world: each named noise gets a real noise, and the old terrain noise
    /// gets a seeded generator.
    /// </summary>
    /// <remarks>
    /// The nether's temperature and vegetation noises are deliberately not handled: they need vanilla's
    /// <c>createLegacyNetherBiome</c>, which draws its octaves sequentially rather than from their
    /// names, and only the nether's biome source reads them. Overworld terrain never reaches that
    /// branch.
    /// </remarks>
    private sealed class NoiseWiringVisitor(RandomState state, long seed, bool useLegacyInit)
        : IDensityFunctionVisitor {

        private readonly Dictionary<IDensityFunction, IDensityFunction> _wrapped = [];

        public IDensityFunction Apply(IDensityFunction input) {
            if (_wrapped.TryGetValue(input, out IDensityFunction? existing)) {
                return existing;
            }

            IDensityFunction wrapped = WrapNew(input);
            _wrapped[input] = wrapped;
            return wrapped;
        }

        public NoiseHolder VisitNoise(NoiseHolder noise) {
            return noise with { Noise = state.GetOrCreateNoise(noise.NoiseId) };
        }

        private IDensityFunction WrapNew(IDensityFunction function) {
            return function switch {
                BlendedNoise blended => blended.WithNewRandom(useLegacyInit
                    ? new LegacyRandomSource(seed)
                    : state._random.FromHashOf("minecraft:terrain")),
                DensityFunctions.EndIslands => new DensityFunctions.EndIslands(seed),
                _ => function
            };
        }
    }

    /// <summary>
    /// Strips markers, since a cache or an interpolator only means something inside a chunk's walk.
    /// </summary>
    private sealed class NoiseFlattener : IDensityFunctionVisitor {
        public static readonly NoiseFlattener Instance = new();

        public IDensityFunction Apply(IDensityFunction input) {
            return input is DensityFunctions.Marker marker ? marker.Wrapped : input;
        }
    }
}
