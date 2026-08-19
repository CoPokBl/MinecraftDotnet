using ManagedServer.Terrain.Noise;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Surface;

/// <summary>What the surface builder needs off the noise chunk, which is one estimate per position.</summary>
public interface INoiseChunkSurfaceView {
    /// <summary>
    /// Where the density function thinks the top of the terrain is, vanilla's
    /// <c>preliminary_surface_level</c> router entry.
    /// </summary>
    int PreliminarySurfaceLevel(int blockX, int blockZ);
}

/// <summary>
/// Turns the stone the density functions produced into ground, vanilla's <c>SurfaceSystem</c>.
/// </summary>
/// <remarks>
/// Runs after the whole chunk of terrain exists, column by column and top down, tracking how deep into
/// stone and how far under water each position is. The rules decide what a block becomes; this decides
/// which blocks they are asked about, which is every block of the default terrain block that is within
/// reach of a cavity above or below.
/// <p/>
/// Two shapes are not rules at all and are applied here: the eroded badlands' spires and the frozen
/// ocean's icebergs. Both need to write blocks the surface rules never see.
/// </remarks>
public sealed class SurfaceSystem {
    private const int ClayBandCount = 192;

    /// <summary>
    /// <c>DimensionType.WAY_BELOW_MIN_Y</c>: a height no world reaches, used as the floor of a stone
    /// run that continues past the bottom of the world.
    /// </summary>
    private const int WayBelowMinY = -32512;

    private static readonly Identifier ErodedBadlands = "minecraft:eroded_badlands";
    private static readonly Identifier FrozenOcean = "minecraft:frozen_ocean";
    private static readonly Identifier DeepFrozenOcean = "minecraft:deep_frozen_ocean";

    private readonly uint _defaultBlock;
    private readonly IPositionalRandomFactory _noiseRandom;

    private readonly uint[] _clayBands;
    private readonly NormalNoise _clayBandsOffsetNoise;
    private readonly NormalNoise _surfaceNoise;
    private readonly NormalNoise _surfaceSecondaryNoise;
    private readonly NormalNoise _badlandsPillarNoise;
    private readonly NormalNoise _badlandsPillarRoofNoise;
    private readonly NormalNoise _badlandsSurfaceNoise;
    private readonly NormalNoise _icebergPillarNoise;
    private readonly NormalNoise _icebergPillarRoofNoise;
    private readonly NormalNoise _icebergSurfaceNoise;

    private readonly uint _water;
    private readonly uint _packedIce;
    private readonly uint _snowBlock;

    public SurfaceSystem(ISurfaceRandomState randomState, uint defaultBlock, int seaLevel,
        IPositionalRandomFactory noiseRandom) {

        _defaultBlock = defaultBlock;
        SeaLevel = seaLevel;
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

        _water = Block.Water.StateId;
        _packedIce = Block.PackedIce.StateId;
        _snowBlock = Block.SnowBlock.StateId;
    }

    public int SeaLevel { get; }

    /// <summary>
    /// Builds the surface of one chunk.
    /// </summary>
    /// <param name="registry">Used to tell a fluid or air apart from stone by state id.</param>
    public void BuildSurface(MinecraftRegistry registry, ISurfaceRandomState randomState, ISurfaceColumn column,
        INoiseChunkSurfaceView noiseChunk, ISurfaceRuleSource ruleSource, Func<int, int, int, IBiome> biomeGetter,
        int chunkX, int chunkZ, int minGenY, int genDepth) {

        SurfaceContext context = new(this, randomState, column, noiseChunk, biomeGetter, minGenY, genDepth);
        ISurfaceRule rule = ruleSource.Apply(context);

        int minBlockX = chunkX * 16;
        int minBlockZ = chunkZ * 16;

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                int blockX = minBlockX + x;
                int blockZ = minBlockZ + z;
                column.SetColumn(blockX, blockZ);

                int startingHeight = column.GetGenerationHeight(x, z) + 1;

                // The biome for the two extensions is read at the top of the terrain, not at sea level
                // or at the position being written.
                IBiome surfaceBiome = biomeGetter(blockX, startingHeight, blockZ);

                if (surfaceBiome.Identifier == ErodedBadlands) {
                    ErodedBadlandsExtension(registry, column, blockX, blockZ, startingHeight, minGenY);
                }

                // Re-read rather than reused: the badlands extension writes stone and moves the top.
                int height = column.GetGenerationHeight(x, z) + 1;
                context.UpdateXz(blockX, blockZ);

                int stoneAboveDepth = 0;
                int waterHeight = int.MinValue;
                int nextCeilingStoneY = int.MaxValue;

                for (int y = height; y >= minGenY; y--) {
                    uint old = column.GetBlock(y);
                    IBlock oldBlock = registry.Blocks.GetByStateId(old);

                    if (oldBlock.Air) {
                        stoneAboveDepth = 0;
                        waterHeight = int.MinValue;
                        continue;
                    }

                    if (oldBlock.Fluid != null) {
                        // Only the topmost fluid of a run counts, so a column under a lake measures
                        // from the lake's surface rather than from each block of it.
                        if (waterHeight == int.MinValue) {
                            waterHeight = y + 1;
                        }

                        continue;
                    }

                    if (nextCeilingStoneY >= y) {
                        // How far the stone under this position continues, scanned once per run rather
                        // than per block. The scan reaches one below the world floor, so a column of
                        // stone all the way down leaves this at the sentinel and reads as unbounded.
                        nextCeilingStoneY = WayBelowMinY;

                        for (int lookaheadY = y - 1; lookaheadY >= minGenY - 1; lookaheadY--) {
                            if (!IsStone(registry, column.GetBlock(lookaheadY))) {
                                nextCeilingStoneY = lookaheadY + 1;
                                break;
                            }
                        }
                    }

                    stoneAboveDepth++;
                    int stoneBelowDepth = y - nextCeilingStoneY + 1;
                    context.UpdateY(stoneAboveDepth, stoneBelowDepth, waterHeight, y);

                    // Only the default terrain block is replaced, so a rule cannot overwrite an ore
                    // vein, a deepslate band or anything else already placed.
                    if (old == _defaultBlock) {
                        uint? state = rule.TryApply(blockX, y, blockZ);
                        if (state != null) {
                            column.SetBlock(y, state.Value);
                        }
                    }
                }

                if (surfaceBiome.Identifier == FrozenOcean || surfaceBiome.Identifier == DeepFrozenOcean) {
                    FrozenOceanExtension(registry, context.GetMinSurfaceLevel(), surfaceBiome, column,
                        blockX, blockZ, startingHeight);
                }
            }
        }
    }

    /// <summary>
    /// The surface rules at a single position, vanilla's <c>topMaterial</c>, for the block a carver
    /// exposed.
    /// </summary>
    /// <remarks>
    /// The two stone depths are pinned at one, so the position is asked about as though it were the
    /// only block of terrain there: the rules see a surface whatever depth the block was really at,
    /// which is the whole point of running them again over a cave mouth.
    /// <p/>
    /// The bound rule and the context are the caller's to build and reuse across a chunk. Both are
    /// pure functions of the position they are moved to, so reusing one only changes how often the
    /// binding is paid.
    /// </remarks>
    /// <param name="underFluid">
    /// Whether the carve left a fluid rather than air. It becomes the water height, which is what
    /// decides between a biome's dry top block and its underwater one.
    /// </param>
    /// <returns>The state a rule chose, or null where none matched.</returns>
    public static uint? TopMaterial(ISurfaceRule rule, SurfaceContext context, int blockX, int blockY,
        int blockZ, bool underFluid) {

        context.UpdateXz(blockX, blockZ);
        context.UpdateY(1, 1, underFluid ? blockY + 1 : int.MinValue, blockY);

        return rule.TryApply(blockX, blockY, blockZ);
    }

    /// <summary>How thick the soil layer is here: a noise plus a little jitter, in whole blocks.</summary>
    public int GetSurfaceDepth(int blockX, int blockZ) {
        double noiseValue = _surfaceNoise.GetValue(blockX, 0.0, blockZ);
        return (int)(noiseValue * 2.75 + 3.0 + _noiseRandom.At(blockX, 0, blockZ).NextDouble() * 0.25);
    }

    public double GetSurfaceSecondary(int blockX, int blockZ) {
        return _surfaceSecondaryNoise.GetValue(blockX, 0.0, blockZ);
    }

    private static bool IsStone(MinecraftRegistry registry, uint stateId) {
        IBlock block = registry.Blocks.GetByStateId(stateId);
        return !block.Air && block.Fluid == null;
    }

    /// <summary>
    /// The spires of the eroded badlands: a second terrain shape stacked on the noise one, filled with
    /// the default block and then run through the ordinary rules.
    /// </summary>
    private void ErodedBadlandsExtension(MinecraftRegistry registry, ISurfaceColumn column, int blockX,
        int blockZ, int height, int minGenY) {

        double pillarBuffer = Math.Min(Math.Abs(_badlandsSurfaceNoise.GetValue(blockX, 0.0, blockZ) * 8.25),
            _badlandsPillarNoise.GetValue(blockX * 0.2, 0.0, blockZ * 0.2) * 15.0);

        if (pillarBuffer <= 0.0) {
            return;
        }

        double pillarFloor = Math.Abs(_badlandsPillarRoofNoise.GetValue(blockX * 0.75, 0.0, blockZ * 0.75) * 1.5);
        double extensionTop = 64.0 + Math.Min(pillarBuffer * pillarBuffer * 2.5, Math.Ceiling(pillarFloor * 50.0) + 24.0);
        int startY = Mth.Floor(extensionTop);

        if (height > startY) {
            return;
        }

        // Nothing is built where the column already has terrain or water in the way, which is what
        // stops a spire growing out of a lake or out of the side of a mesa.
        for (int y = startY; y >= minGenY; y--) {
            uint state = column.GetBlock(y);
            if (state == _defaultBlock) {
                break;
            }

            if (state == _water) {
                return;
            }
        }

        for (int y = startY; y >= minGenY && registry.Blocks.GetByStateId(column.GetBlock(y)).Air; y--) {
            column.SetBlock(y, _defaultBlock);
        }
    }

    /// <summary>The icebergs of a frozen ocean: packed ice below, a few blocks of snow on top.</summary>
    private void FrozenOceanExtension(MinecraftRegistry registry, int minSurfaceLevel, IBiome surfaceBiome,
        ISurfaceColumn column, int blockX, int blockZ, int height) {

        double iceberg = Math.Min(Math.Abs(_icebergSurfaceNoise.GetValue(blockX, 0.0, blockZ) * 8.25),
            _icebergPillarNoise.GetValue(blockX * 1.28, 0.0, blockZ * 1.28) * 15.0);

        if (iceberg <= 1.8) {
            return;
        }

        double icebergRoof = Math.Abs(_icebergPillarRoofNoise.GetValue(blockX * 1.17, 0.0, blockZ * 1.17) * 1.5);
        double top = Math.Min(iceberg * iceberg * 1.2, Math.Ceiling(icebergRoof * 40.0) + 14.0);

        if (BiomeClimate.ShouldMeltFrozenOceanIcebergSlightly(surfaceBiome, blockX, SeaLevel, blockZ, SeaLevel)) {
            top -= 2.0;
        }

        double extensionBottom;
        if (top > 2.0) {
            extensionBottom = SeaLevel - top - 7.0;
            top += SeaLevel;
        } else {
            top = 0.0;
            extensionBottom = 0.0;
        }

        double extensionTop = top;
        RandomSource random = _noiseRandom.At(blockX, 0, blockZ);
        int maxSnowDepth = 2 + random.NextInt(4);
        int minSnowHeight = SeaLevel + 18 + random.NextInt(10);
        int snowDepth = 0;

        for (int y = Math.Max(height, (int)top + 1); y >= minSurfaceLevel; y--) {
            uint state = column.GetBlock(y);
            bool inAir = registry.Blocks.GetByStateId(state).Air && y < (int)extensionTop
                && random.NextDouble() > 0.01;
            bool inWater = state == _water && y > (int)extensionBottom && y < SeaLevel
                && extensionBottom != 0.0 && random.NextDouble() > 0.15;

            if (!inAir && !inWater) {
                continue;
            }

            if (snowDepth <= maxSnowDepth && y > minSnowHeight) {
                column.SetBlock(y, _snowBlock);
                snowDepth++;
            } else {
                column.SetBlock(y, _packedIce);
            }
        }
    }

    /// <summary>
    /// The badlands' terracotta stripes, generated once per world from a fixed name so every mesa in
    /// the world has the same band pattern.
    /// </summary>
    private static uint[] GenerateBands(RandomSource random) {
        uint[] clayBands = new uint[ClayBandCount];
        Array.Fill(clayBands, Block.Terracotta.StateId);

        // The loop variable is advanced inside the body as well as by the loop, so the orange bands
        // land at growing gaps rather than at every index.
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

    /// <summary>Which band a height falls in, shifted by a noise so the stripes are not flat.</summary>
    public uint GetBand(int blockX, int blockY, int blockZ) {
        int offset = (int)Mth.JavaRound(_clayBandsOffsetNoise.GetValue(blockX, 0.0, blockZ) * 4.0);
        return _clayBands[(blockY + offset + _clayBands.Length) % _clayBands.Length];
    }
}
