using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>SnowAndFreezeFeature</c>: the snow layer on cold ground and the ice on cold water.
/// </summary>
/// <remarks>
/// The one feature that covers the whole chunk rather than being scattered: it walks all 256 columns
/// and does not draw from the random at all. That is why it is the last thing in the biome's list.
/// <p/>
/// It is also what makes a mountain white above the snow line while the valley beside it is green,
/// because the temperature it reads falls with height rather than being the biome's flat number.
/// </remarks>
public sealed record SnowAndFreezeFeature : ConfiguredFeature {
    public static readonly SnowAndFreezeFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;

        int originX = context.Origin.X;
        int originZ = context.Origin.Z;

        for (int dx = 0; dx < 16; dx++) {
            for (int dz = 0; dz < 16; dz++) {
                int x = originX + dx;
                int z = originZ + dz;
                int y = level.GetHeight(HeightmapType.MotionBlocking, x, z);

                IBiome biome = level.GetBiome(x, y, z);

                if (BiomeClimate.ShouldFreeze(biome, level, x, y - 1, z)) {
                    level.SetState(x, y - 1, z, Block.Ice.StateId);
                }

                if (!BiomeClimate.ShouldSnow(biome, level, x, y, z)) {
                    continue;
                }

                level.SetState(x, y, z, Block.Snow.StateId);

                // Grass, podzol and mycelium all draw a white top when there is snow on them, and it
                // is a property on the block below rather than something the snow layer implies.
                IBlock below = level.Registry.Blocks.GetByStateId(level.GetState(x, y - 1, z));
                if (below is ISnowy snowy) {
                    level.SetState(x, y - 1, z, snowy.WithSnowy(true).StateId);
                }
            }
        }

        return true;
    }
}

/// <summary>
/// The parts of <c>Biome</c> that decide whether it snows somewhere.
/// </summary>
/// <remarks>
/// <b>Vanilla's <c>getBrightness(BLOCK, pos) &lt; 10</c> is treated as dark, and that is exact rather
/// than an approximation.</b> A chunk reaches <c>INITIALIZE_LIGHT</c> after <c>FEATURES</c>, so no
/// light section exists while the pass runs, and block light has no default the way sky light does:
/// <c>LayerLightSectionStorage.getLightValue</c> answers 0 for a missing layer. So the test holds
/// everywhere a feature can ask, lava and glowstone included.
/// </remarks>
public static class BiomeClimate {
    /// <summary>
    /// <c>Biome.getHeightAdjustedTemperature</c>: the biome's temperature, made colder with height
    /// above seventeen blocks over the sea.
    /// </summary>
    public static float TemperatureAt(IBiome biome, int x, int y, int z, int seaLevel) {
        return Surface.BiomeClimate.GetTemperature(biome, x, y, z, seaLevel);
    }

    /// <summary><c>Biome.warmEnoughToRain</c>.</summary>
    public static bool WarmEnoughToRain(IBiome biome, IFeatureLevel level, int x, int y, int z) {
        return WarmEnoughToRain(biome, x, y, z, level.SeaLevel);
    }

    /// <summary>
    /// The same against a sea level rather than a level, for a caller deciding before there is one.
    /// </summary>
    /// <remarks>
    /// A structure works out what it is while it is being laid out, which is before any chunk exists.
    /// The ruined portal is the one that asks, to decide whether it is a cold one.
    /// </remarks>
    public static bool WarmEnoughToRain(IBiome biome, int x, int y, int z, int seaLevel) {
        return TemperatureAt(biome, x, y, z, seaLevel) >= 0.15f;
    }

    /// <summary><c>Biome.coldEnoughToSnow</c>, which is the other side of the same test.</summary>
    public static bool ColdEnoughToSnow(IBiome biome, int x, int y, int z, int seaLevel) {
        return !WarmEnoughToRain(biome, x, y, z, seaLevel);
    }

    /// <summary>
    /// <c>Biome.shouldFreeze</c> with <c>checkNeighbors</c> false, which is what the feature passes.
    /// </summary>
    /// <remarks>
    /// The neighbour check is what stops the middle of a lake freezing during ordinary play; worldgen
    /// skips it so a whole frozen ocean comes out iced over rather than only its shoreline.
    /// </remarks>
    public static bool ShouldFreeze(IBiome biome, IFeatureLevel level, int x, int y, int z) {
        if (WarmEnoughToRain(biome, level, x, y, z) || !level.InWorld(y)) {
            return false;
        }

        uint state = level.GetState(x, y, z);

        // A water source block rather than anything holding water: a waterlogged fence does not ice
        // over, and vanilla's test is on the block being a LiquidBlock as well as on the fluid.
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        return block.Identifier.Equals(Block.Water.Identifier) && FeatureFluids.IsWater(level, state);
    }

    /// <summary><c>Biome.shouldSnow</c>.</summary>
    public static bool ShouldSnow(IBiome biome, IFeatureLevel level, int x, int y, int z) {
        if (!biome.HasPrecipitation || WarmEnoughToRain(biome, level, x, y, z) || !level.InWorld(y)) {
            return false;
        }

        uint state = level.GetState(x, y, z);
        IBlock here = level.Registry.Blocks.GetByStateId(state);

        if (!here.Air && !here.Identifier.Equals(Block.Snow.Identifier)) {
            return false;
        }

        return FeatureSurvival.CanSurvive(Block.Snow, level, x, y, z);
    }
}
