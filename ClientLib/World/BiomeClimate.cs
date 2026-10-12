using Minecraft.Data.Biomes;
using Minecraft.Schemas;

namespace ClientLib.World;

/// <summary>
/// The client level's biome lookups (<c>BiomeManager</c> over <c>ClientLevel</c>) and the per position half
/// of <c>Biome</c>'s climate, which together say whether it rains or snows at a block.
/// </summary>
public static class BiomeClimate {
    public enum Precipitation {
        None,
        Rain,
        Snow
    }

    private static readonly PerlinSimplexNoise TemperatureNoise = new(new LegacyRandomSource(1234L), [0]);
    private static readonly PerlinSimplexNoise FrozenTemperatureNoise = new(new LegacyRandomSource(3456L), [-2, -1, 0]);
    private static readonly PerlinSimplexNoise BiomeInfoNoise = new(new LegacyRandomSource(2345L), [0]);

    /// <summary>
    /// <c>LevelReader.getNoiseBiome</c>: a missing chunk is <c>ClientLevel.getUncachedNoiseBiome</c>, which is
    /// plains, and the quart's y is clamped into the level as <c>ChunkAccess.getNoiseBiome</c> does.
    /// </summary>
    public static IBiome NoiseBiome(ClientLevel level, int quartX, int quartY, int quartZ) {
        if (!level.HasChunk(quartX >> 2, quartZ >> 2)) {
            return level.Registry.Biomes[Minecraft.Data.Generated.Biome.Plains.Identifier];
        }
        int quartMinY = level.MinY >> 2;
        int quartMaxY = quartMinY + (level.Height >> 2) - 1;
        int y = Math.Clamp(quartY, quartMinY, quartMaxY) << 2;
        int id = level.GetBiome(quartX << 2, y, quartZ << 2);
        return level.Registry.Biomes[Math.Min(id, (int)level.Registry.Biomes.Count - 1)];
    }

    /// <summary><c>BiomeManager.getNoiseBiomeAtPosition</c>: the quart cell the point is in, without the zoom.</summary>
    public static IBiome NoiseBiomeAtPosition(ClientLevel level, double x, double y, double z) =>
        NoiseBiome(level, Mth.Floor(x) >> 2, Mth.Floor(y) >> 2, Mth.Floor(z) >> 2);

    /// <summary><c>BiomeManager.getBiome</c>: the nearest of the eight surrounding cell centres, each jittered by the hashed seed.</summary>
    public static IBiome Biome(ClientLevel level, int x, int y, int z) {
        long seed = level.HashedSeed;
        int absX = x - 2;
        int absY = y - 2;
        int absZ = z - 2;
        int parentX = absX >> 2;
        int parentY = absY >> 2;
        int parentZ = absZ >> 2;
        double fractX = (absX & 3) / 4.0;
        double fractY = (absY & 3) / 4.0;
        double fractZ = (absZ & 3) / 4.0;
        int minI = 0;
        double minFiddledDistance = double.PositiveInfinity;
        for (int i = 0; i < 8; i++) {
            bool xEven = (i & 4) == 0;
            bool yEven = (i & 2) == 0;
            bool zEven = (i & 1) == 0;
            int cornerX = xEven ? parentX : parentX + 1;
            int cornerY = yEven ? parentY : parentY + 1;
            int cornerZ = zEven ? parentZ : parentZ + 1;
            double distanceX = xEven ? fractX : fractX - 1.0;
            double distanceY = yEven ? fractY : fractY - 1.0;
            double distanceZ = zEven ? fractZ : fractZ - 1.0;
            double next = FiddledDistance(seed, cornerX, cornerY, cornerZ, distanceX, distanceY, distanceZ);
            if (minFiddledDistance > next) {
                minI = i;
                minFiddledDistance = next;
            }
        }
        return NoiseBiome(level, (minI & 4) == 0 ? parentX : parentX + 1, (minI & 2) == 0 ? parentY : parentY + 1,
            (minI & 1) == 0 ? parentZ : parentZ + 1);
    }

    private static double FiddledDistance(long seed, int xRandom, int yRandom, int zRandom, double distanceX, double distanceY, double distanceZ) {
        long rval = Lcg(seed, xRandom);
        rval = Lcg(rval, yRandom);
        rval = Lcg(rval, zRandom);
        rval = Lcg(rval, xRandom);
        rval = Lcg(rval, yRandom);
        rval = Lcg(rval, zRandom);
        double fiddleX = Fiddle(rval);
        rval = Lcg(rval, seed);
        double fiddleY = Fiddle(rval);
        rval = Lcg(rval, seed);
        double fiddleZ = Fiddle(rval);
        return Square(distanceZ + fiddleZ) + Square(distanceY + fiddleY) + Square(distanceX + fiddleX);
    }

    /// <summary><c>LinearCongruentialGenerator.next</c>, which squares: <c>rval * (rval * m + i) + c</c>.</summary>
    private static long Lcg(long rval, long c) {
        rval *= rval * 6364136223846793005L + 1442695040888963407L;
        return rval + c;
    }

    private static double Fiddle(long rval) => (((rval >> 24) % 1024L + 1024L) % 1024L / 1024.0 - 0.5) * 0.9;

    private static double Square(double value) => value * value;

    /// <summary><c>Biome.getPrecipitationAt</c>: snow where <c>coldEnoughToSnow</c>.</summary>
    public static Precipitation PrecipitationAt(IBiome biome, int x, int y, int z, int seaLevel) {
        if (!biome.HasPrecipitation) {
            return Precipitation.None;
        }
        return Temperature(biome, x, y, z, seaLevel) >= 0.15F ? Precipitation.Rain : Precipitation.Snow;
    }

    /// <summary><c>Biome.getHeightAdjustedTemperature</c>, which <c>getTemperature</c> caches.</summary>
    public static float Temperature(IBiome biome, int x, int y, int z, int seaLevel) {
        float adjustedTemperature = ModifyTemperature(biome, x, z, biome.Temperature);
        int snowLevel = seaLevel + 17;
        if (y > snowLevel) {
            float v = (float)(TemperatureNoise.GetValue(x / 8.0F, z / 8.0F) * 8.0);
            return adjustedTemperature - (v + y - snowLevel) * 0.05F / 40.0F;
        }
        return adjustedTemperature;
    }

    /// <summary><c>Biome.TemperatureModifier.modifyTemperature</c>.</summary>
    private static float ModifyTemperature(IBiome biome, int x, int z, float baseTemperature) {
        if (biome.TemperatureModifier != TemperatureModifier.Frozen) {
            return baseTemperature;
        }
        double groundValueLargeVariation = FrozenTemperatureNoise.GetValue(x * 0.05, z * 0.05) * 7.0;
        double groundValueEdgeVariation = BiomeInfoNoise.GetValue(x * 0.2, z * 0.2);
        if (groundValueLargeVariation + groundValueEdgeVariation < 0.3) {
            double groundValueSmallVariation = BiomeInfoNoise.GetValue(x * 0.09, z * 0.09);
            if (groundValueSmallVariation < 0.8) {
                return 0.2F;
            }
        }
        return baseTemperature;
    }

    /// <summary>
    /// <c>PerlinSimplexNoise</c>, for the octave sets the climate builds, none of them positive. Octaves run
    /// highest frequency first and the value factor grows.
    /// </summary>
    private sealed class PerlinSimplexNoise {
        private readonly SimplexNoise?[] _noiseLevels;
        private readonly double _highestFreqValueFactor;
        private readonly double _highestFreqInputFactor;

        public PerlinSimplexNoise(RandomSource random, int[] octaveSet) {
            int lowFreqOctaves = -octaveSet.Min();
            int highFreqOctaves = octaveSet.Max();
            int octaves = lowFreqOctaves + highFreqOctaves + 1;
            SimplexNoise zeroOctave = new(random);
            _noiseLevels = new SimplexNoise?[octaves];
            if (highFreqOctaves >= 0 && highFreqOctaves < octaves && octaveSet.Contains(0)) {
                _noiseLevels[highFreqOctaves] = zeroOctave;
            }
            for (int i = highFreqOctaves + 1; i < octaves; i++) {
                if (octaveSet.Contains(highFreqOctaves - i)) {
                    _noiseLevels[i] = new SimplexNoise(random);
                }
                else {
                    random.ConsumeCount(262);
                }
            }
            _highestFreqInputFactor = Math.Pow(2.0, highFreqOctaves);
            _highestFreqValueFactor = 1.0 / (Math.Pow(2.0, octaves) - 1.0);
        }

        public double GetValue(double x, double y) {
            double value = 0.0;
            double factor = _highestFreqInputFactor;
            double valueFactor = _highestFreqValueFactor;
            foreach (SimplexNoise? level in _noiseLevels) {
                if (level != null) {
                    value += level.GetValue(x * factor, y * factor) * valueFactor;
                }
                factor /= 2.0;
                valueFactor *= 2.0;
            }
            return value;
        }
    }

    /// <summary><c>SimplexNoise</c>, two dimensional only.</summary>
    private sealed class SimplexNoise {
        private static readonly int[][] Gradient = [
            [1, 1, 0], [-1, 1, 0], [1, -1, 0], [-1, -1, 0],
            [1, 0, 1], [-1, 0, 1], [1, 0, -1], [-1, 0, -1],
            [0, 1, 1], [0, -1, 1], [0, 1, -1], [0, -1, -1],
            [1, 1, 0], [0, -1, 1], [-1, 1, 0], [0, -1, -1]
        ];

        private static readonly double Sqrt3 = Math.Sqrt(3.0);
        private static readonly double F2 = 0.5 * (Sqrt3 - 1.0);
        private static readonly double G2 = (3.0 - Sqrt3) / 6.0;

        private readonly int[] _p = new int[512];

        public SimplexNoise(RandomSource random) {
            // xo, yo and zo: drawn for the stream's sake, unused by the plane sampler without noise start.
            random.NextDouble();
            random.NextDouble();
            random.NextDouble();
            for (int i = 0; i < 256; i++) {
                _p[i] = i;
            }
            for (int i = 0; i < 256; i++) {
                int offset = random.NextInt(256 - i);
                (_p[i], _p[i + offset]) = (_p[i + offset], _p[i]);
            }
        }

        private int P(int x) => _p[x & 0xFF];

        private static double CornerNoise(int index, double x, double y, double basis) {
            double t = basis - x * x - y * y;
            if (t < 0.0) {
                return 0.0;
            }
            t *= t;
            int[] g = Gradient[index];
            return t * t * (g[0] * x + g[1] * y);
        }

        public double GetValue(double xin, double yin) {
            double s = (xin + yin) * F2;
            int i = Mth.Floor(xin + s);
            int j = Mth.Floor(yin + s);
            double t = (i + j) * G2;
            double x0 = xin - (i - t);
            double y0 = yin - (j - t);
            int i1 = x0 > y0 ? 1 : 0;
            int j1 = x0 > y0 ? 0 : 1;
            double x1 = x0 - i1 + G2;
            double y1 = y0 - j1 + G2;
            double x2 = x0 - 1.0 + 2.0 * G2;
            double y2 = y0 - 1.0 + 2.0 * G2;
            int ii = i & 0xFF;
            int jj = j & 0xFF;
            int gi0 = P(ii + P(jj)) % 12;
            int gi1 = P(ii + i1 + P(jj + j1)) % 12;
            int gi2 = P(ii + 1 + P(jj + 1)) % 12;
            return 70.0 * (CornerNoise(gi0, x0, y0, 0.5) + CornerNoise(gi1, x1, y1, 0.5) + CornerNoise(gi2, x2, y2, 0.5));
        }
    }
}
