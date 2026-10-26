using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Biomes;

/// <summary>
/// The end's biomes, vanilla's <c>TheEndBiomeSource</c>: the central island inside 64 chunks of the
/// origin, and past it a band of the noise router's <c>erosion</c> entry, which in the end is the island
/// height function rather than a climate.
/// </summary>
/// <remarks>
/// It inherits <c>createResolverForChunk</c>, so a chunk's grid is point samples through the chunk's
/// caching context, not the volumes the multi noise source takes.
/// </remarks>
public sealed class TheEndBiomeSource : IBiomeSource {
    public IReadOnlyList<Identifier> PossibleBiomes { get; } = [
        Biome.TheEnd.Identifier, Biome.EndHighlands.Identifier, Biome.EndMidlands.Identifier,
        Biome.SmallEndIslands.Identifier, Biome.EndBarrens.Identifier
    ];

    public Identifier GetBiome(int quartX, int quartY, int quartZ, ClimateSampler sampler) {
        int blockX = quartX << 2;
        int blockY = quartY << 2;
        int blockZ = quartZ << 2;
        int chunkX = blockX >> 4;
        int chunkZ = blockZ >> 4;
        if ((long)chunkX * chunkX + (long)chunkZ * chunkZ <= 4096L) {
            return Biome.TheEnd.Identifier;
        }

        // The centre of the sixteen by sixteen, whatever quart of it was asked about.
        int weirdBlockX = ((blockX >> 4) * 2 + 1) * 8;
        int weirdBlockZ = ((blockZ >> 4) * 2 + 1) * 8;
        double heightValue = sampler.Erosion.SampleValue(weirdBlockX, blockY, weirdBlockZ);
        if (heightValue > 0.25) {
            return Biome.EndHighlands.Identifier;
        }

        if (heightValue >= -0.0625) {
            return Biome.EndMidlands.Identifier;
        }

        return heightValue < -0.21875 ? Biome.SmallEndIslands.Identifier : Biome.EndBarrens.Identifier;
    }

    public Func<int, int, int, Identifier> ResolverForChunk(ClimateSampler sampler, int minQuartX, int minQuartY,
        int minQuartZ, int quartSizeX, int quartSizeY, int quartSizeZ) {

        return (quartX, quartY, quartZ) => GetBiome(quartX, quartY, quartZ, sampler);
    }
}
