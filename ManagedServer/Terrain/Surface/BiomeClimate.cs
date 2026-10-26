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
    private static readonly SimplexNoise TemperatureNoise = new(new LegacyRandomSource(1234L), true);

    private static readonly NoiseStack FrozenTemperatureNoise = CreateFrozenTemperatureNoise();

    /// <summary><c>Biome.BIOME_INFO_NOISE</c>, which the feature placement noises also read.</summary>
    public static readonly SimplexNoise BiomeInfoNoise = new(new LegacyRandomSource(2345L), true);

    private static NoiseStack CreateFrozenTemperatureNoise() {
        LegacyRandomSource random = new(3456L);
        return NoiseStack.CreateBuilder()
            .Add(new SimplexNoise(random, true), 1.0, 0.14285715F)
            .Add(new SimplexNoise(random, true), 0.5, 0.2857143F)
            .Add(new SimplexNoise(random, true), 0.25, 0.5714286F)
            .Build();
    }

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
        float variation = TemperatureNoise.Get(x / 8.0F, z / 8.0F) * 8.0F;
        return baseTemperature - (variation + y - snowLevel) * 0.05f / 40.0f;
    }

    /// <summary><c>Biome.TemperatureModifier.modifyTemperature</c>.</summary>
    private static float ModifyTemperature(IBiome biome, int x, int z, float baseTemperature) {
        if (biome.TemperatureModifier != TemperatureModifier.Frozen) {
            return baseTemperature;
        }

        double largeVariation = FrozenTemperatureNoise.Get(x * 0.05, z * 0.05) * 7.0F;
        double edgeVariation = BiomeInfoNoise.Get(x * 0.2, z * 0.2);

        if (largeVariation + edgeVariation < 0.3) {
            double smallVariation = BiomeInfoNoise.Get(x * 0.09, z * 0.09);
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
