using ManagedServer.Terrain.Noise;
using Minecraft.Data.Biomes;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Surface;

/// <summary>
/// The per position half of <c>Biome</c>'s climate: <c>getTemperature</c>,
/// <c>getHeightAdjustedTemperature</c> and the two questions the surface builder asks about them.
/// </summary>
/// <remarks>
/// A biome's temperature is not the flat number on it. It falls off above sea level plus seventeen,
/// and a frozen biome's is patchy, which is what puts ice in some parts of a frozen ocean and not
/// others. Surface rules ask <see cref="ColdEnoughToSnow"/>, so a port that reads the flat temperature
/// puts snow on every mountain at once rather than above the snow line.
/// <p/>
/// The three noises are seeded from fixed constants and shared by every biome in the game, which is
/// what makes their patches line up across a biome boundary.
/// </remarks>
public static class BiomeClimate {
    private static readonly PerlinSimplexNoise TemperatureNoise =
        new(new LegacyRandomSource(1234L), [0]);

    private static readonly PerlinSimplexNoise FrozenTemperatureNoise =
        new(new LegacyRandomSource(3456L), [-2, -1, 0]);

    private static readonly PerlinSimplexNoise BiomeInfoNoise =
        new(new LegacyRandomSource(2345L), [0]);

    /// <summary>
    /// <c>Biome.getTemperature</c>. Vanilla caches this per position; this recomputes, since the
    /// surface builder asks once per column rather than repeatedly for the same block.
    /// </summary>
    public static float GetTemperature(IBiome biome, int x, int y, int z, int seaLevel) {
        float baseTemperature = ModifyTemperature(biome, x, z, biome.Temperature);

        int snowLevel = seaLevel + 17;
        if (y <= snowLevel) {
            return baseTemperature;
        }

        // The noise is sampled at eighth scale and the falloff is a fortieth of a twentieth per block,
        // so the line is gradual and ragged rather than flat.
        float variation = (float)(TemperatureNoise.GetValue(x / 8.0f, z / 8.0f, false) * 8.0);
        return baseTemperature - (variation + y - snowLevel) * 0.05f / 40.0f;
    }

    /// <summary><c>Biome.TemperatureModifier.modifyTemperature</c>.</summary>
    private static float ModifyTemperature(IBiome biome, int x, int z, float baseTemperature) {
        if (biome.TemperatureModifier != TemperatureModifier.Frozen) {
            return baseTemperature;
        }

        double largeVariation = FrozenTemperatureNoise.GetValue(x * 0.05, z * 0.05, false) * 7.0;
        double edgeVariation = BiomeInfoNoise.GetValue(x * 0.2, z * 0.2, false);

        if (largeVariation + edgeVariation < 0.3) {
            double smallVariation = BiomeInfoNoise.GetValue(x * 0.09, z * 0.09, false);
            if (smallVariation < 0.8) {
                return 0.2f;
            }
        }

        return baseTemperature;
    }

    /// <summary><c>Biome.warmEnoughToRain</c>.</summary>
    public static bool WarmEnoughToRain(IBiome biome, int x, int y, int z, int seaLevel) {
        return GetTemperature(biome, x, y, z, seaLevel) >= 0.15f;
    }

    /// <summary><c>Biome.coldEnoughToSnow</c>, what the <c>temperature</c> surface condition tests.</summary>
    public static bool ColdEnoughToSnow(IBiome biome, int x, int y, int z, int seaLevel) {
        return !WarmEnoughToRain(biome, x, y, z, seaLevel);
    }

    /// <summary><c>Biome.shouldMeltFrozenOceanIcebergSlightly</c>.</summary>
    public static bool ShouldMeltFrozenOceanIcebergSlightly(IBiome biome, int x, int y, int z, int seaLevel) {
        return GetTemperature(biome, x, y, z, seaLevel) > 0.1f;
    }
}
