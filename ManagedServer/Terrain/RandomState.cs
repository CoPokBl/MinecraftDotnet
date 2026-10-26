using System.Collections.Concurrent;
using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Material;
using ManagedServer.Terrain.Noise;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain;

/// <summary>
/// One world's seeded worldgen state, vanilla's <c>RandomState</c>: the noises, the random factories,
/// the material system and the compiler every density function goes through.
/// </summary>
/// <remarks>
/// Every noise is seeded from a hash of its own name under a factory derived from the world seed, so a
/// chunk generates the same whatever order chunks are asked for. Shared by every chunk of a world and
/// touched from the pool, so its lazy maps are concurrent and the buffer pools are handed out under a
/// lock.
/// </remarks>
public sealed class RandomState : IMaterialRandomState {
    private const int MaxBufferPools = 16;
    private const int MaxBufferAgeTicks = 20;

    private static readonly Identifier NetherTemperature = "minecraft:nether/temperature";
    private static readonly Identifier NetherVegetation = "minecraft:nether/vegetation";

    private readonly IPositionalRandomFactory _random;
    private readonly Func<Identifier, NormalNoise?> _noises;
    private readonly ConcurrentDictionary<Identifier, INoise> _noiseInstances = new();
    private readonly ConcurrentDictionary<Identifier, IPositionalRandomFactory> _positionalRandoms = new();
    private readonly DensityFunctionCompiler _compiler;
    private readonly Lock _poolLock = new();
    private readonly List<DensityBufferPool> _pools = new(MaxBufferPools);

    public RandomState(MinecraftRegistry registry, NoiseGeneratorSettings settings, Func<Identifier, NormalNoise?> noises, long seed) {
        Seed = seed;
        Router = settings.NoiseRouter;
        _noises = noises;
        RandomSource root = settings.UseLegacyRandomSource ? new LegacyRandomSource(seed) : new XoroshiroRandomSource(seed);
        _random = root.ForkPositional();
        _compiler = new DensityFunctionCompiler(new CompileContext(this, seed, settings.UseLegacyRandomSource));
        MaterialSystem = new MaterialSystem(registry, this, settings.DefaultBlock, settings.SeaLevel, Router.ChunkSurfaceLevel, _random);
    }

    public long Seed { get; }

    public NoiseRouter Router { get; }

    public MaterialSystem MaterialSystem { get; }

    public IDensitySampler GetSampler(IDensityFunction function) => _compiler.GetSampler(function);

    public IDensitySamplerSet SamplersWithContext(SamplerContext context) => new SamplerSet(this, context);

    public ClimateSampler CreateClimateSampler(SamplerContext context) => Router.CreateClimateSampler(SamplersWithContext(context));

    /// <summary><c>createUncachedResolver</c>'s sampler: point samples, no cache.</summary>
    public ClimateSampler UncachedClimateSampler() => CreateClimateSampler(SamplerContext.EmptyUncached);

    public INoise GetOrCreateNoise(Identifier id) {
        return _noiseInstances.GetOrAdd(id, key => {
            NormalNoise noise = _noises(key) ?? throw new InvalidOperationException($"No noise registered as \"{key}\".");
            return noise.Create(_random.FromHashOf(key.ToString()));
        });
    }

    public IPositionalRandomFactory GetOrCreateRandomFactory(Identifier name) {
        return _positionalRandoms.GetOrAdd(name, key => _random.FromHashOf(key.ToString()).ForkPositional());
    }

    public DensityBufferPool AcquireDensityBufferPool() {
        lock (_poolLock) {
            if (_pools.Count > 0) {
                DensityBufferPool pool = _pools[^1];
                _pools.RemoveAt(_pools.Count - 1);
                return pool;
            }
        }

        return new DensityBufferPool(MaxBufferAgeTicks);
    }

    public void ReleaseDensityBufferPool(DensityBufferPool pool) {
        lock (_poolLock) {
            if (_pools.Count < MaxBufferPools) {
                _pools.Add(pool);
            }
        }
    }

    private sealed class SamplerSet(RandomState state, SamplerContext context) : IDensitySamplerSet {
        public BoundSampler Get(IDensityFunction function) => new(state.GetSampler(function), context);

        public float SampleValue(IDensityFunction function, int blockX, int blockY, int blockZ) {
            return state.GetSampler(function).SampleValue(context, blockX, blockY, blockZ);
        }
    }

    /// <summary>
    /// The nether's two biome noises keep the sequential legacy octaves, seeded from the world seed
    /// directly; every other noise is the named instance.
    /// </summary>
    private sealed class CompileContext(RandomState state, long seed, bool useLegacyRandom) : ICompileContext {
        public INoise CreateNoiseSampler(NoiseHolder noise) {
            if (noise.Key == NetherTemperature) {
                return noise.Value.CreateForLegacyNetherBiome(new LegacyRandomSource(seed));
            }

            if (noise.Key == NetherVegetation) {
                return noise.Value.CreateForLegacyNetherBiome(new LegacyRandomSource(seed + 1L));
            }

            if (noise.Key is not { } key) {
                throw new InvalidOperationException("A noise written inline cannot be instantiated: it has no name to seed from.");
            }

            return state.GetOrCreateNoise(key);
        }

        public RandomSource CreateRandom(Identifier seedName) {
            return useLegacyRandom && seedName == BlendedNoise.NoiseSeed ? new LegacyRandomSource(seed) : state._random.FromHashOf(seedName.ToString());
        }

        public RandomSource CreateEndIslandRandom() => new LegacyRandomSource(seed);
    }
}
