using Minecraft.Schemas;

namespace ManagedServer.Terrain.Biomes;

/// <summary>
/// Which biome a quart is, vanilla's <c>BiomeSource</c>.
/// </summary>
public interface IBiomeSource {
    /// <summary>
    /// <c>possibleBiomes</c>, in the source's own order, which the feature sorter breaks its ties by.
    /// </summary>
    IReadOnlyList<Identifier> PossibleBiomes { get; }

    /// <summary><c>createResolver(sampler).getNoiseBiome</c>, in quart coordinates.</summary>
    Identifier GetBiome(int quartX, int quartY, int quartZ, ClimateSampler sampler);

    /// <summary>
    /// <c>createResolverForChunk</c>: a resolver for one chunk's grid, which may sample the climate as
    /// volumes up front where <see cref="GetBiome"/> samples points.
    /// </summary>
    Func<int, int, int, Identifier> ResolverForChunk(ClimateSampler sampler, int minQuartX, int minQuartY, int minQuartZ,
        int quartSizeX, int quartSizeY, int quartSizeZ);
}
