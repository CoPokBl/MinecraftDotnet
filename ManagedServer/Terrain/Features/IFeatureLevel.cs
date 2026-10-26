using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Biomes;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Terrain.Features;

/// <summary>
/// What a feature reads and writes, vanilla's <c>WorldGenLevel</c> narrowed to the parts the feature
/// pass actually uses.
/// </summary>
/// <remarks>
/// Positions are <b>absolute game coordinates</b>, y included, like the rest of the generation API.
/// <p/>
/// <b>A level covers the three by three</b>, as vanilla's <c>WorldGenRegion</c> does. Writes outside the
/// chunk being decorated go through the generation API's forks; reads outside it answer the neighbour's
/// terrain <b>as the carvers left it</b>, which is the status the chunk pyramid guarantees a neighbour
/// has reached when a chunk decorates. What this pass has itself forked into a neighbour reads back on
/// top of that, because a decorator asking whether the block it is about to fill is empty is asking
/// about its own work.
/// <p/>
/// <see cref="IsLoaded"/> is <c>hasChunk</c>: whether the real terrain can be answered here at all. Past
/// the three by three it cannot, and a read there is air.
/// </remarks>
public interface IFeatureLevel {
    MinecraftRegistry Registry { get; }

    /// <summary>The world's lowest block y.</summary>
    int MinY { get; }

    /// <summary>One past the world's highest block y.</summary>
    int MaxY { get; }

    /// <summary>The dimension's sea level, which several features measure against.</summary>
    int SeaLevel { get; }

    /// <summary>The world seed, for a feature that seeds a random of its own from a position.</summary>
    long Seed { get; }

    /// <summary>
    /// <c>WorldGenLevel.getRandom</c>: the level's own random, which a couple of structure pieces draw
    /// from rather than from the random they are handed.
    /// </summary>
    /// <remarks>
    /// Seeded from the world seed and the <b>chunk being generated</b>, as vanilla's
    /// <c>WorldGenRegion</c> seeds it from its centre chunk. So a structure spanning a border genuinely
    /// draws different numbers in each half: a desert pyramid's collapsed roof is patterned per chunk
    /// upstream too, rather than this being a limitation of generating one chunk at a time.
    /// </remarks>
    RandomSource LevelRandom { get; }

    /// <summary>Facts about a state, cached per state id.</summary>
    FeatureBlockData Blocks { get; }

    /// <summary>
    /// The dimension type's <c>has_skylight</c>, which is the whole of what light a feature can see.
    /// </summary>
    /// <remarks>
    /// No light section exists while the pass runs, so <c>getRawBrightness</c> answers the sky layer's
    /// default: 15 at every depth where there is a sky layer, and 0 in a dimension without one, since
    /// the light engine has no sky layer there and the dummy listener answers zero.
    /// </remarks>
    bool HasSkyLight => true;

    /// <summary>
    /// <c>WorldGenerationContext.of(level)</c>: the level's range clamped to the generator's, which is
    /// what an anchor resolves against. The nether is 256 high and generates 128.
    /// </summary>
    GenerationHeightContext WorldGeneration => new(MinY, MaxY - MinY, SeaLevel);

    /// <summary>
    /// <c>ChunkAccess.markPosForPostprocessing</c>: the block here settles against its neighbours'
    /// shapes once the chunk is finished, rather than keeping the state it was written with.
    /// </summary>
    void MarkForPostProcessing(int x, int y, int z) { }

    /// <summary>
    /// <c>WorldGenRegion.hasChunk</c>: whether a read at this column answers the real terrain rather
    /// than the air everything past the region answers.
    /// </summary>
    bool IsLoaded(int x, int z);

    uint GetState(int x, int y, int z);

    /// <summary>
    /// Writes a block, into the chunk or through a fork. Outside the world's y range it does nothing,
    /// which is <c>ProtoChunk.setBlockState</c>'s behaviour and a normal thing for a tall feature near
    /// the build limit to run into.
    /// </summary>
    void SetState(int x, int y, int z, uint stateId);

    /// <summary>
    /// <c>LevelReader.getHeight</c>: one past the highest block matching the heightmap's predicate,
    /// so a feature placed at this y sits on top of the ground.
    /// </summary>
    int GetHeight(HeightmapType type, int x, int z);

    IBiome GetBiome(int x, int y, int z);
}

/// <summary>Convenience over <see cref="IFeatureLevel"/>, in terms of its own members only.</summary>
public static class FeatureLevelExtensions {
    public static bool IsAir(this IFeatureLevel level, int x, int y, int z) {
        return level.Blocks.IsAir(level.GetState(x, y, z));
    }

    public static bool IsEmptyBlock(this IFeatureLevel level, int x, int y, int z) {
        return level.Blocks.IsAir(level.GetState(x, y, z));
    }

    /// <summary>Whether a y is inside the world, <c>LevelHeightAccessor.isInsideBuildHeight</c>.</summary>
    public static bool InWorld(this IFeatureLevel level, int y) {
        return y >= level.MinY && y < level.MaxY;
    }
}
