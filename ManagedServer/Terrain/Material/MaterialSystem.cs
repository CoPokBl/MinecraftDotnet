using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Material;

/// <summary>
/// The column the surface pass is applied to, and the chunk under it.
/// </summary>
/// <remarks>
/// An interface rather than the chunk itself because the surface pass reads back what it has written,
/// and the generation API writes into a staging buffer rather than into the chunk.
/// </remarks>
public interface IMaterialColumn {
    /// <summary>The state at a height in the current column.</summary>
    uint GetBlock(int blockY);

    /// <summary>Writes a state at a height in the current column, ignoring anything outside the world.</summary>
    void SetBlock(int blockY, uint stateId);

    /// <summary>Points the column at a horizontal position, which the block accessors then work in.</summary>
    void SetColumn(int blockX, int blockZ);

    /// <summary>
    /// <c>getHeight(WORLD_SURFACE_WG)</c> of a chunk local column: the highest non air block, from the
    /// heightmap the noise fill kept rather than from the blocks.
    /// </summary>
    int GetGenerationHeight(int localX, int localZ);
}

/// <summary>
/// Turns the terrain the noise fill produced into ground, vanilla's <c>MaterialSystem</c>.
/// </summary>
/// <remarks>
/// Runs after the fill, column by column and top down, tracking how deep into stone and how far under
/// water each position is, and asks the rule about every solid block in the world's range. Unlike the
/// 26.2 surface system it does not first check for the default block, so a rule sees whatever an
/// earlier writer put there.
/// <p/>
/// The eroded badlands spires and the frozen ocean icebergs are not rules and are applied here.
/// </remarks>
public sealed class MaterialSystem {
    private const int ClayBandCount = 192;

    /// <summary><c>DimensionType.WAY_BELOW_MIN_Y</c>.</summary>
    private const int WayBelowMinY = -32512;

    private static readonly Identifier ErodedBadlands = "minecraft:eroded_badlands";
    private static readonly Identifier FrozenOcean = "minecraft:frozen_ocean";
    private static readonly Identifier DeepFrozenOcean = "minecraft:deep_frozen_ocean";

    private readonly MinecraftRegistry _registry;
    private readonly uint _defaultBlock;
    private readonly Identifier _defaultBlockType;
    private readonly IPositionalRandomFactory _noiseRandom;

    private readonly uint[] _clayBands;
    private readonly INoise _clayBandsOffsetNoise;
    private readonly INoise _surfaceNoise;
    private readonly INoise _surfaceSecondaryNoise;
    private readonly INoise _badlandsPillarNoise;
    private readonly INoise _badlandsPillarRoofNoise;
    private readonly INoise _badlandsSurfaceNoise;
    private readonly INoise _icebergPillarNoise;
    private readonly INoise _icebergPillarRoofNoise;
    private readonly INoise _icebergSurfaceNoise;

    public MaterialSystem(MinecraftRegistry registry, IMaterialRandomState randomState, uint defaultBlock, int seaLevel,
        IDensityFunction preliminarySurfaceFunction, IPositionalRandomFactory noiseRandom) {

        _registry = registry;
        _defaultBlock = defaultBlock;
        _defaultBlockType = registry.Blocks.GetByStateId(defaultBlock).Identifier;
        SeaLevel = seaLevel;
        PreliminarySurfaceFunction = preliminarySurfaceFunction;
        _noiseRandom = noiseRandom;

        _clayBandsOffsetNoise = randomState.GetOrCreateNoise("minecraft:clay_bands_offset");
        _clayBands = GenerateBands(noiseRandom.FromHashOf("minecraft:clay_bands"));
        _surfaceNoise = randomState.GetOrCreateNoise("minecraft:surface");
        _surfaceSecondaryNoise = randomState.GetOrCreateNoise("minecraft:surface_secondary");
        _badlandsPillarNoise = randomState.GetOrCreateNoise("minecraft:badlands_pillar");
        _badlandsPillarRoofNoise = randomState.GetOrCreateNoise("minecraft:badlands_pillar_roof");
        _badlandsSurfaceNoise = randomState.GetOrCreateNoise("minecraft:badlands_surface");
        _icebergPillarNoise = randomState.GetOrCreateNoise("minecraft:iceberg_pillar");
        _icebergPillarRoofNoise = randomState.GetOrCreateNoise("minecraft:iceberg_pillar_roof");
        _icebergSurfaceNoise = randomState.GetOrCreateNoise("minecraft:iceberg_surface");
    }

    public int SeaLevel { get; }

    /// <summary>The router's <c>chunk_surface_level</c>, which the surface reads its depth limit from.</summary>
    public IDensityFunction PreliminarySurfaceFunction { get; }

    /// <summary>
    /// <c>buildSurface</c> for one chunk.
    /// </summary>
    /// <param name="fullVolume">The noise chunk's volume; the ore veins prefill over it, trimmed to the highest filled section.</param>
    /// <param name="highestFilledBlockY">The top of the highest section holding anything.</param>
    /// <param name="biomeGetter">The chunk's stored biomes through the zoom, <c>BiomeManager.getBiome</c>.</param>
    public void BuildSurface(IMaterialRandomState randomState, IMaterialColumn column, IDensitySamplerSet densitySamplers,
        DensityVolume fullVolume, int highestFilledBlockY, IMaterialRule ruleSource, Func<int, int, int, IBiome> biomeGetter,
        IReadOnlySet<Identifier>? possibleBiomes, GenerationHeightContext heightContext, int chunkX, int chunkZ, int minY, int maxY) {

        DensityVolume narrowedVolume = new(fullVolume.SizeX, Math.Max(highestFilledBlockY - fullVolume.MinBlockY + 1, 1), fullVolume.SizeZ,
            fullVolume.MinBlockX, fullVolume.MinBlockY, fullVolume.MinBlockZ);
        MaterialRuleContext context = new(this, randomState, narrowedVolume, densitySamplers, biomeGetter, heightContext, possibleBiomes);
        IRuleEvaluator rule = ruleSource.Compile(context);

        int minBlockX = chunkX * 16;
        int minBlockZ = chunkZ * 16;

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                int blockX = minBlockX + x;
                int blockZ = minBlockZ + z;
                int startingHeight = column.GetGenerationHeight(x, z) + 1;
                column.SetColumn(blockX, blockZ);
                IBiome surfaceBiome = biomeGetter(blockX, startingHeight, blockZ);
                if (surfaceBiome.Identifier == ErodedBadlands) {
                    ErodedBadlandsExtension(column, blockX, blockZ, startingHeight, minY);
                }

                int height = column.GetGenerationHeight(x, z) + 1;
                context.UpdateXz(blockX, blockZ, SurfaceGradientX(column, x, z), SurfaceGradientZ(column, x, z));
                int stoneAboveDepth = 0;
                int waterHeight = int.MinValue;
                int nextCeilingStoneY = int.MaxValue;
                int endY = minY;

                for (int y = height; y >= endY; y--) {
                    IBlock old = _registry.Blocks.GetByStateId(column.GetBlock(y));
                    if (old.Air) {
                        stoneAboveDepth = 0;
                        waterHeight = int.MinValue;
                    } else if (old.Fluid != null) {
                        if (waterHeight == int.MinValue) {
                            waterHeight = y + 1;
                        }
                    } else {
                        if (nextCeilingStoneY >= y) {
                            nextCeilingStoneY = WayBelowMinY;
                            for (int lookaheadY = y - 1; lookaheadY >= endY - 1; lookaheadY--) {
                                if (!IsStone(column.GetBlock(lookaheadY))) {
                                    nextCeilingStoneY = lookaheadY + 1;
                                    break;
                                }
                            }
                        }

                        stoneAboveDepth++;
                        int stoneBelowDepth = y - nextCeilingStoneY + 1;
                        context.UpdateY(stoneAboveDepth, stoneBelowDepth, waterHeight, y);
                        if (y >= minY && y <= maxY && rule.TryApply(blockX, y, blockZ) is { } state) {
                            column.SetBlock(y, state);
                        }
                    }
                }

                if (surfaceBiome.Identifier == FrozenOcean || surfaceBiome.Identifier == DeepFrozenOcean) {
                    FrozenOceanExtension(context.GetMinSurfaceLevel(), surfaceBiome, column, blockX, blockZ, startingHeight);
                }
            }
        }
    }

    private static int SurfaceGradientX(IMaterialColumn column, int x, int z) {
        return column.GetGenerationHeight(Math.Min(x + 1, 15), z) - column.GetGenerationHeight(Math.Max(x - 1, 0), z);
    }

    private static int SurfaceGradientZ(IMaterialColumn column, int x, int z) {
        return column.GetGenerationHeight(x, Math.Min(z + 1, 15)) - column.GetGenerationHeight(x, Math.Max(z - 1, 0));
    }

    /// <summary>
    /// <c>topMaterial</c>: the rule at one position, for the dirt a carver exposed under grass. The
    /// rule is compiled for a one block volume each time, and both stone depths are pinned at one.
    /// </summary>
    /// <param name="underFluid">Whether the carve left a fluid, which becomes the water height.</param>
    public uint? TopMaterial(IMaterialRule ruleSource, IMaterialRandomState randomState, GenerationHeightContext heightContext,
        Func<int, int, int, IBiome> biomeGetter, IMaterialColumn column, IDensitySamplerSet densitySamplers,
        int blockX, int blockY, int blockZ, bool underFluid) {

        DensityVolume volume = new(1, 1, 1, blockX, blockY, blockZ);
        MaterialRuleContext context = new(this, randomState, volume, densitySamplers, biomeGetter, heightContext, null);
        IRuleEvaluator rule = ruleSource.Compile(context);
        int localX = blockX & 15;
        int localZ = blockZ & 15;
        context.UpdateXz(blockX, blockZ, SurfaceGradientX(column, localX, localZ), SurfaceGradientZ(column, localX, localZ));
        context.UpdateY(1, 1, underFluid ? blockY + 1 : int.MinValue, blockY);
        return rule.TryApply(blockX, blockY, blockZ);
    }

    internal int GetSurfaceDepth(int blockX, int blockZ) {
        double noiseValue = _surfaceNoise.Get(blockX, 0.0, blockZ);
        return (int)(noiseValue * 2.75 + 3.0 + _noiseRandom.At(blockX, 0, blockZ).NextDouble() * 0.25);
    }

    internal double GetSurfaceSecondary(int blockX, int blockZ) => _surfaceSecondaryNoise.Get(blockX, 0.0, blockZ);

    private bool IsStone(uint stateId) {
        IBlock block = _registry.Blocks.GetByStateId(stateId);
        return !block.Air && block.Fluid == null;
    }

    private bool IsBlock(uint stateId, Identifier block) => _registry.Blocks.GetByStateId(stateId).Identifier == block;

    private void ErodedBadlandsExtension(IMaterialColumn column, int blockX, int blockZ, int height, int minY) {
        double pillarBuffer = Math.Min(Math.Abs(_badlandsSurfaceNoise.Get(blockX, 0.0, blockZ) * 8.25),
            (double)(_badlandsPillarNoise.Get(blockX * 0.2, 0.0, blockZ * 0.2) * 15.0F));
        if (pillarBuffer <= 0.0) {
            return;
        }

        double pillarFloor = Math.Abs(_badlandsPillarRoofNoise.Get(blockX * 0.75, 0.0, blockZ * 0.75) * 1.5);
        double extensionTop = 64.0 + Math.Min(pillarBuffer * pillarBuffer * 2.5, Math.Ceiling(pillarFloor * 50.0) + 24.0);
        int startY = Mth.Floor(extensionTop);
        if (height > startY) {
            return;
        }

        for (int y = startY; y >= minY; y--) {
            uint state = column.GetBlock(y);
            if (IsBlock(state, _defaultBlockType)) {
                break;
            }

            if (IsBlock(state, Block.Water.Identifier)) {
                return;
            }
        }

        for (int y = startY; y >= minY && _registry.Blocks.GetByStateId(column.GetBlock(y)).Air; y--) {
            column.SetBlock(y, _defaultBlock);
        }
    }

    /// <summary>
    /// The icebergs of a frozen ocean. A column whose iceberg top is two or less is left alone, draws
    /// included.
    /// </summary>
    private void FrozenOceanExtension(int minSurfaceLevel, IBiome surfaceBiome, IMaterialColumn column, int blockX, int blockZ, int height) {
        double iceberg = Math.Min(Math.Abs(_icebergSurfaceNoise.Get(blockX, 0.0, blockZ) * 8.25),
            (double)(_icebergPillarNoise.Get(blockX * 1.28, 0.0, blockZ * 1.28) * 15.0F));
        if (iceberg <= 1.8) {
            return;
        }

        double icebergRoof = Math.Abs(_icebergPillarRoofNoise.Get(blockX * 1.17, 0.0, blockZ * 1.17) * 1.5);
        double top = Math.Min(iceberg * iceberg * 1.2, Math.Ceiling(icebergRoof * 40.0) + 14.0);
        if (Surface.BiomeClimate.ShouldMeltFrozenOceanIcebergSlightly(surfaceBiome, blockX, SeaLevel, blockZ, SeaLevel)) {
            top -= 2.0;
        }

        if (top <= 2.0) {
            return;
        }

        double extensionBottom = SeaLevel - top - 7.0;
        top += SeaLevel;
        double extensionTop = top;
        RandomSource random = _noiseRandom.At(blockX, 0, blockZ);
        int maxSnowDepth = 2 + random.NextInt(4);
        int minSnowHeight = SeaLevel + 18 + random.NextInt(10);
        int snowDepth = 0;

        for (int y = Math.Max(height, (int)top + 1); y >= minSurfaceLevel; y--) {
            if ((_registry.Blocks.GetByStateId(column.GetBlock(y)).Air && y < (int)extensionTop && random.NextDouble() > 0.01)
                || (IsBlock(column.GetBlock(y), Block.Water.Identifier) && y > (int)extensionBottom && y < SeaLevel
                    && random.NextDouble() > 0.15)) {
                if (snowDepth <= maxSnowDepth && y > minSnowHeight) {
                    column.SetBlock(y, Block.SnowBlock.StateId);
                    snowDepth++;
                } else {
                    column.SetBlock(y, Block.PackedIce.StateId);
                }
            }
        }
    }

    /// <summary>The badlands stripes, generated once per world from a fixed name.</summary>
    private static uint[] GenerateBands(RandomSource random) {
        uint[] clayBands = new uint[ClayBandCount];
        Array.Fill(clayBands, Block.Terracotta.StateId);

        // The loop variable is advanced inside the body as well, so the orange bands land at growing gaps.
        for (int i = 0; i < clayBands.Length; i++) {
            i += random.NextInt(5) + 1;
            if (i < clayBands.Length) {
                clayBands[i] = Block.OrangeTerracotta.StateId;
            }
        }

        MakeBands(random, clayBands, 1, Block.YellowTerracotta.StateId);
        MakeBands(random, clayBands, 2, Block.BrownTerracotta.StateId);
        MakeBands(random, clayBands, 1, Block.RedTerracotta.StateId);

        int whiteBandCount = random.NextIntBetweenInclusive(9, 15);
        int written = 0;
        for (int start = 0; written < whiteBandCount && start < clayBands.Length; start += random.NextInt(16) + 4) {
            clayBands[start] = Block.WhiteTerracotta.StateId;
            if (start - 1 > 0 && random.NextBoolean()) {
                clayBands[start - 1] = Block.LightGrayTerracotta.StateId;
            }

            if (start + 1 < clayBands.Length && random.NextBoolean()) {
                clayBands[start + 1] = Block.LightGrayTerracotta.StateId;
            }

            written++;
        }

        return clayBands;
    }

    private static void MakeBands(RandomSource random, uint[] clayBands, int baseWidth, uint state) {
        int bandCount = random.NextIntBetweenInclusive(6, 15);
        for (int i = 0; i < bandCount; i++) {
            int width = baseWidth + random.NextInt(3);
            int start = random.NextInt(clayBands.Length);
            for (int p = 0; start + p < clayBands.Length && p < width; p++) {
                clayBands[start + p] = state;
            }
        }
    }

    /// <summary>Which band a height falls in, shifted by a noise. The round is <c>Math.round(float)</c>.</summary>
    internal uint GetBand(int blockX, int blockY, int blockZ) {
        int offset = Mth.JavaRound(_clayBandsOffsetNoise.Get(blockX, 0.0, blockZ) * 4.0F);
        return _clayBands[(blockY + offset + _clayBands.Length) % _clayBands.Length];
    }
}
