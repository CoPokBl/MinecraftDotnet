using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Material;

namespace ManagedServer.Terrain;

/// <summary>
/// The eight density functions a dimension's terrain is described by, vanilla's <c>NoiseRouter</c>.
/// </summary>
/// <remarks>
/// <see cref="FinalDensity"/> decides whether a position is solid, including the beardifier term,
/// which is in the data rather than added by code; the six climate entries decide the biome; and
/// <see cref="ChunkSurfaceLevel"/> is where the surface pass stops looking for ground. The aquifer's
/// functions are in <see cref="AquiferConfig"/> and the ore veins' in their material rules.
/// </remarks>
public sealed record NoiseRouter(
    IDensityFunction Temperature,
    IDensityFunction Vegetation,
    IDensityFunction Continents,
    IDensityFunction Erosion,
    IDensityFunction Depth,
    IDensityFunction Ridges,
    IDensityFunction ChunkSurfaceLevel,
    IDensityFunction FinalDensity) {

    public ClimateSampler CreateClimateSampler(IDensitySamplerSet samplers) {
        return new ClimateSampler(samplers.Get(Temperature), samplers.Get(Vegetation), samplers.Get(Continents),
            samplers.Get(Erosion), samplers.Get(Depth), samplers.Get(Ridges));
    }
}
