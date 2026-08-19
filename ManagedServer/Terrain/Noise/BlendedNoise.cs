using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// The old terrain noise, vanilla's <c>BlendedNoise</c>: two limit stacks interpolated by a third
/// selector stack. It is what puts the roughness on a hillside once the splines have decided where
/// the hillside is.
/// </summary>
/// <remarks>
/// Its three Perlin stacks are drawn from one generator in sequence, so
/// <see cref="PerlinNoise.CreateLegacyForBlendedNoise"/> rather than the hashed construction.
/// <p/>
/// A parsed instance is unseeded: it holds the scale parameters and a stack built from a zero seed,
/// and <see cref="WithNewRandom"/> is what the world's random state calls to give it a real one. So
/// an instance that never goes through a visitor produces the same terrain for every seed.
/// </remarks>
public sealed class BlendedNoise : ISimpleDensityFunction {
    private readonly PerlinNoise _minLimitNoise;
    private readonly PerlinNoise _maxLimitNoise;
    private readonly PerlinNoise _mainNoise;

    private readonly double _xzScale;
    private readonly double _yScale;
    private readonly double _xzFactor;
    private readonly double _yFactor;
    private readonly double _smearScaleMultiplier;

    private readonly double _xzMultiplier;
    private readonly double _yMultiplier;
    private readonly double _maxValue;

    public BlendedNoise(RandomSource random, double xzScale, double yScale, double xzFactor,
        double yFactor, double smearScaleMultiplier) {

        _minLimitNoise = PerlinNoise.CreateLegacyForBlendedNoise(random, Range(-15, 0));
        _maxLimitNoise = PerlinNoise.CreateLegacyForBlendedNoise(random, Range(-15, 0));
        _mainNoise = PerlinNoise.CreateLegacyForBlendedNoise(random, Range(-7, 0));

        _xzScale = xzScale;
        _yScale = yScale;
        _xzFactor = xzFactor;
        _yFactor = yFactor;
        _smearScaleMultiplier = smearScaleMultiplier;

        _xzMultiplier = 684.412 * xzScale;
        _yMultiplier = 684.412 * yScale;
        _maxValue = _minLimitNoise.MaxBrokenValue(_yMultiplier);
    }

    /// <summary>What the JSON parser builds: the parameters, on a zero seed, awaiting a real one.</summary>
    public static BlendedNoise CreateUnseeded(double xzScale, double yScale, double xzFactor,
        double yFactor, double smearScaleMultiplier) {

        return new BlendedNoise(new XoroshiroRandomSource(0L), xzScale, yScale, xzFactor, yFactor,
            smearScaleMultiplier);
    }

    public BlendedNoise WithNewRandom(RandomSource terrainRandom) {
        return new BlendedNoise(terrainRandom, _xzScale, _yScale, _xzFactor, _yFactor, _smearScaleMultiplier);
    }

    public double Compute(IFunctionContext context) {
        double limitX = context.BlockX * _xzMultiplier;
        double limitY = context.BlockY * _yMultiplier;
        double limitZ = context.BlockZ * _xzMultiplier;

        double mainX = limitX / _xzFactor;
        double mainY = limitY / _yFactor;
        double mainZ = limitZ / _xzFactor;

        double limitSmear = _yMultiplier * _smearScaleMultiplier;
        double mainSmear = limitSmear / _yFactor;

        double mainNoiseValue = 0.0;
        double pow = 1.0;

        for (int i = 0; i < 8; i++) {
            ImprovedNoise? noise = _mainNoise.GetOctaveNoise(i);
            if (noise != null) {
                mainNoiseValue += noise.Noise(PerlinNoise.Wrap(mainX * pow), PerlinNoise.Wrap(mainY * pow),
                    PerlinNoise.Wrap(mainZ * pow), mainSmear * pow, mainY * pow) / pow;
            }

            pow /= 2.0;
        }

        double factor = (mainNoiseValue / 10.0 + 1.0) / 2.0;

        // A selector that has already saturated makes one of the two limit stacks irrelevant, so the
        // sixteen octaves of it are skipped. That is a shortcut vanilla takes and it changes nothing.
        bool isMax = factor >= 1.0;
        bool isMin = factor <= 0.0;

        double blendMin = 0.0;
        double blendMax = 0.0;
        pow = 1.0;

        for (int i = 0; i < 16; i++) {
            double wx = PerlinNoise.Wrap(limitX * pow);
            double wy = PerlinNoise.Wrap(limitY * pow);
            double wz = PerlinNoise.Wrap(limitZ * pow);
            double yScalePow = limitSmear * pow;

            if (!isMax) {
                ImprovedNoise? minNoise = _minLimitNoise.GetOctaveNoise(i);
                if (minNoise != null) {
                    blendMin += minNoise.Noise(wx, wy, wz, yScalePow, limitY * pow) / pow;
                }
            }

            if (!isMin) {
                ImprovedNoise? maxNoise = _maxLimitNoise.GetOctaveNoise(i);
                if (maxNoise != null) {
                    blendMax += maxNoise.Noise(wx, wy, wz, yScalePow, limitY * pow) / pow;
                }
            }

            pow /= 2.0;
        }

        return Mth.ClampedLerp(factor, blendMin / 512.0, blendMax / 512.0) / 128.0;
    }

    public double MinValue => -_maxValue;

    public double MaxValue => _maxValue;

    private static int[] Range(int from, int to) {
        int[] octaves = new int[to - from + 1];
        for (int i = 0; i < octaves.Length; i++) {
            octaves[i] = from + i;
        }

        return octaves;
    }
}
