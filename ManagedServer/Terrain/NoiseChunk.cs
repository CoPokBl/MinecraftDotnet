using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Material;

namespace ManagedServer.Terrain;

/// <summary>
/// One chunk's sampling state, vanilla's <c>NoiseChunk</c>: the volume, a caching sampler context
/// over a borrowed buffer pool, and the aquifer bound to it.
/// </summary>
/// <remarks>
/// The fill, the surface pass and the carvers' aquifer all sample through <see cref="CachingSamplers"/>,
/// so one chunk's cache cells are shared across the three, as upstream. Dispose returns the pool.
/// </remarks>
public sealed class NoiseChunk : IDisposable {
    private readonly RandomState _randomState;
    private readonly DensityBufferPool _bufferPool;

    /// <param name="beardifier">The structures' terrain adjustment, or null for none.</param>
    public NoiseChunk(RandomState randomState, IDensitySampler? beardifier, NoiseGeneratorSettings settings,
        IFluidPicker globalFluidPicker, DensityVolume volume) {

        _randomState = randomState;
        Volume = volume;
        _bufferPool = randomState.AcquireDensityBufferPool();
        SamplerContext context = SamplerContext.CreateBuilder()
            .With(DensityContextKeys.Beardifier, beardifier)
            .UseBufferArena(_bufferPool)
            .EnableCaches()
            .Build();
        CachingSamplers = randomState.SamplersWithContext(context);
        Aquifer = settings.Aquifers is { } aquifers
            ? aquifers.Create(CachingSamplers, randomState.GetOrCreateRandomFactory("minecraft:aquifer"), volume, globalFluidPicker)
            : new DisabledAquifer(globalFluidPicker);
    }

    public DensityVolume Volume { get; }

    public IAquifer Aquifer { get; }

    public IDensitySamplerSet CachingSamplers { get; }

    public void Dispose() {
        _randomState.ReleaseDensityBufferPool(_bufferPool);
    }
}
