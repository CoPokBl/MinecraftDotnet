using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// Octaves of <see cref="SimplexNoise"/>, vanilla's <c>PerlinSimplexNoise</c>. The one thing left
/// using it is <see cref="BiomeClimate"/>, which is why a biome's temperature varies across a chunk.
/// </summary>
/// <remarks>
/// Octaves run <b>highest frequency first</b> here, the opposite of <see cref="PerlinNoise"/>, and the
/// value factor grows rather than shrinks. Reading it as the Perlin one is a plausible looking noise
/// with the wrong shape.
/// <p/>
/// Only the non positive octave sets vanilla actually constructs are supported; the branch upstream
/// that reseeds from the zero octave's own value for positive octaves is not reachable from any of
/// them.
/// </remarks>
public sealed class PerlinSimplexNoise {
    private readonly SimplexNoise?[] _noiseLevels;
    private readonly double _highestFreqValueFactor;
    private readonly double _highestFreqInputFactor;

    public PerlinSimplexNoise(RandomSource random, IReadOnlyCollection<int> octaveSet) {
        if (octaveSet.Count == 0) {
            throw new ArgumentException("Need some octaves", nameof(octaveSet));
        }

        int lowFreqOctaves = -octaveSet.Min();
        int highFreqOctaves = octaveSet.Max();
        int octaves = lowFreqOctaves + highFreqOctaves + 1;

        if (highFreqOctaves > 0) {
            throw new ArgumentException(
                "Positive octaves need a second generator seeded from the zero octave's own value, " +
                "which nothing in vanilla constructs.", nameof(octaveSet));
        }

        SimplexNoise zeroOctave = new(random);
        _noiseLevels = new SimplexNoise[octaves];

        if (highFreqOctaves >= 0 && highFreqOctaves < octaves && octaveSet.Contains(0)) {
            _noiseLevels[highFreqOctaves] = zeroOctave;
        }

        for (int i = highFreqOctaves + 1; i < octaves; i++) {
            if (octaveSet.Contains(highFreqOctaves - i)) {
                _noiseLevels[i] = new SimplexNoise(random);
            } else {
                random.ConsumeCount(262);
            }
        }

        _highestFreqInputFactor = Math.Pow(2.0, highFreqOctaves);
        _highestFreqValueFactor = 1.0 / (Math.Pow(2.0, octaves) - 1.0);
    }

    public double GetValue(double x, double y, bool useNoiseStart) {
        double value = 0.0;
        double factor = _highestFreqInputFactor;
        double valueFactor = _highestFreqValueFactor;

        foreach (SimplexNoise? level in _noiseLevels) {
            if (level != null) {
                value += level.GetValue(x * factor + (useNoiseStart ? level.Xo : 0.0),
                    y * factor + (useNoiseStart ? level.Yo : 0.0)) * valueFactor;
            }

            factor /= 2.0;
            valueFactor *= 2.0;
        }

        return value;
    }
}
