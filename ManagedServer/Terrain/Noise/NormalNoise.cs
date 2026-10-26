using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>How a <see cref="NormalNoise"/> scales its octaves, vanilla's <c>NormalNoise.Normalization</c>.</summary>
public enum NoiseNormalization {
    Disabled,
    Enabled,

    /// <summary>The pre 26.3 factor, kept upstream for packs that ask for it with <c>"legacy"</c>.</summary>
    Legacy
}

/// <summary>
/// One entry of the <c>worldgen/noise</c> registry, vanilla's <c>NormalNoise.Parameters</c>. An empty
/// <see cref="AmplitudeModifiers"/> means every octave at one.
/// </summary>
public sealed record NoiseParameters(
    double BaseAmplitude,
    int BaseOctave,
    int OctaveCount,
    NoiseNormalization Normalize,
    IReadOnlyList<double> AmplitudeModifiers) {

    public bool Equals(NoiseParameters? other) {
        return other is not null
            && BaseAmplitude.Equals(other.BaseAmplitude)
            && BaseOctave == other.BaseOctave
            && OctaveCount == other.OctaveCount
            && Normalize == other.Normalize
            && AmplitudeModifiers.SequenceEqual(other.AmplitudeModifiers);
    }

    public override int GetHashCode() {
        HashCode hash = new();
        hash.Add(BaseAmplitude);
        hash.Add(BaseOctave);
        hash.Add(OctaveCount);
        hash.Add(Normalize);
        foreach (double modifier in AmplitudeModifiers) {
            hash.Add(modifier);
        }

        return hash.ToHashCode();
    }
}

/// <summary>
/// The parameters of a named noise and the stack they build, vanilla's <c>NormalNoise</c>. Every named
/// noise in worldgen is one.
/// </summary>
/// <remarks>
/// <see cref="Create"/> forks two positional factories and adds each octave's pair interleaved, the
/// second at <c>1.0181268882175227</c> times the frequency so the two lattices never line up. The
/// normalisation factor and range are computed once from the parameters, before any seed.
/// </remarks>
public sealed class NormalNoise : IEquatable<NormalNoise> {
    private const double InputFactor = 1.0181268882175227;
    private const double TargetDeviation = 0.3333333333333333;

    private readonly List<OctaveInfo> _octaves;
    private readonly double _normalizationFactor;

    public NormalNoise(NoiseParameters parameters) {
        Parameters = parameters;
        _octaves = BuildOctaves(parameters.BaseOctave, parameters.BaseAmplitude, parameters.OctaveCount,
            parameters.Normalize != NoiseNormalization.Disabled, parameters.AmplitudeModifiers);

        double targetAmplitude = StreamSum(_octaves.Select(octave => octave.AbsAmplitude));
        double normalizationFactor = ComputeNormalizationFactor(targetAmplitude, _octaves);
        if (parameters.Normalize == NoiseNormalization.Legacy && normalizationFactor != 0.0) {
            double parityFactor = ComputeParityNormalizationFactor(parameters.BaseAmplitude, parameters.OctaveCount,
                parameters.AmplitudeModifiers);
            targetAmplitude *= parityFactor / normalizationFactor;
            normalizationFactor = parityFactor;
        }

        _normalizationFactor = normalizationFactor;
        Range = Interval.OfSymmetric((float)(targetAmplitude * TargetDeviation * 6.0));
    }

    public NoiseParameters Parameters { get; }

    public Interval Range { get; }

    /// <summary>
    /// <c>NormalNoise.createParity</c>: parameters whose normalisation reproduces the pre 26.3 factor
    /// for an old style first octave and amplitude list. What the code built noises are made from.
    /// </summary>
    public static NormalNoise CreateParity(int firstOctave, IReadOnlyList<double> amplitudes) {
        if (amplitudes.Count == 0) {
            throw new ArgumentException("Need at least 1 amplitude");
        }

        List<OctaveInfo> octaves = BuildOctaves(firstOctave, 1.0, amplitudes.Count, true, amplitudes);
        double targetAmplitude = StreamSum(octaves.Select(octave => octave.AbsAmplitude));
        double newFactor = ComputeNormalizationFactor(targetAmplitude, octaves);
        double baseAmplitude = newFactor == 0.0
            ? 1.0
            : ComputeParityNormalizationFactor(1.0, amplitudes.Count, amplitudes) / newFactor;

        double[] modifiers = amplitudes.Any(modifier => modifier != 1.0) ? amplitudes.ToArray() : [];
        return new NormalNoise(new NoiseParameters(baseAmplitude, firstOctave, amplitudes.Count, NoiseNormalization.Enabled, modifiers));
    }

    private static List<OctaveInfo> BuildOctaves(int baseOctave, double baseAmplitude, int octaveCount, bool normalize,
        IReadOnlyList<double> amplitudeModifiers) {

        double frequency = Math.Pow(2.0, baseOctave);
        double amplitude = baseAmplitude;
        if (normalize) {
            amplitude = baseAmplitude * (Math.Pow(0.5, -(octaveCount - 1)) / (Math.Pow(0.5, -octaveCount) - 1.0));
        }

        List<OctaveInfo> octaves = new(octaveCount);
        for (int i = 0; i < octaveCount; i++) {
            double modifier = AmplitudeModifier(amplitudeModifiers, i);
            if (modifier != 0.0) {
                octaves.Add(new OctaveInfo(baseOctave + i, frequency, amplitude * modifier));
            }

            frequency *= 2.0;
            amplitude *= 0.5;
        }

        return octaves;
    }

    private static double AmplitudeModifier(IReadOnlyList<double> amplitudeModifiers, int index) {
        return amplitudeModifiers.Count == 0 ? 1.0 : amplitudeModifiers[index];
    }

    private static double ComputeNormalizationFactor(double targetAmplitude, List<OctaveInfo> octaves) {
        double variance = 0.0;
        foreach (OctaveInfo octave in octaves) {
            double layerDeviation = PerlinNoise.StandardDeviation * octave.AbsAmplitude;
            variance += layerDeviation * layerDeviation;
        }

        double inputDeviation = Math.Sqrt(variance);
        if (inputDeviation == 0.0) {
            return 0.0;
        }

        double inputSumDeviation = inputDeviation * Math.Sqrt(2.0);
        return targetAmplitude * TargetDeviation / inputSumDeviation;
    }

    private static double ComputeParityNormalizationFactor(double baseAmplitude, int octaveCount, IReadOnlyList<double> amplitudeModifiers) {
        int minOctave = int.MaxValue;
        int maxOctave = int.MinValue;
        for (int i = 0; i < octaveCount; i++) {
            if (AmplitudeModifier(amplitudeModifiers, i) != 0.0) {
                minOctave = Math.Min(minOctave, i);
                maxOctave = Math.Max(maxOctave, i);
            }
        }

        return baseAmplitude * 0.5 * TargetDeviation / (0.1 * (1.0 + 1.0 / (maxOctave - minOctave + 1)));
    }

    /// <summary>
    /// <c>DoubleStream.sum</c>, which is Kahan compensated and not a plain loop. The compensation moves
    /// the last bit of the target amplitude, and with it the noise's range.
    /// </summary>
    private static double StreamSum(IEnumerable<double> values) {
        double sum = 0.0;
        double compensation = 0.0;
        double simpleSum = 0.0;
        foreach (double value in values) {
            double tmp = value - compensation;
            double velvel = sum + tmp;
            compensation = velvel - sum - tmp;
            sum = velvel;
            simpleSum += value;
        }

        double result = sum - compensation;
        return double.IsNaN(result) && double.IsInfinity(simpleSum) ? simpleSum : result;
    }

    public INoise Create(RandomSource random) {
        IPositionalRandomFactory firstRandom = random.ForkPositional();
        IPositionalRandomFactory secondRandom = random.ForkPositional();
        NoiseStack.Builder stack = NoiseStack.CreateBuilder();

        foreach (OctaveInfo octave in _octaves) {
            string octaveSeed = octave.Seed;
            float valueFactor = (float)(_normalizationFactor * octave.Amplitude);
            stack.Add(new PerlinNoise(firstRandom.FromHashOf(octaveSeed)), octave.Frequency, valueFactor);
            stack.Add(new PerlinNoise(secondRandom.FromHashOf(octaveSeed)), octave.Frequency * InputFactor, valueFactor);
        }

        return stack.Build();
    }

    /// <summary>
    /// The nether biome noises, which keep the sequentially drawn octaves of the pre 1.18 generator.
    /// Deprecated upstream and kept for those two.
    /// </summary>
    public INoise CreateForLegacyNetherBiome(RandomSource random) {
        IReadOnlyList<double> amplitudes = Parameters.AmplitudeModifiers;
        if (amplitudes.Count == 0) {
            amplitudes = Enumerable.Repeat(1.0, Parameters.OctaveCount).ToArray();
        }

        NoiseStack first = LegacyFbmInitializer.CreateForLegacyNetherBiome(random, Parameters.BaseOctave, amplitudes);
        NoiseStack second = LegacyFbmInitializer.CreateForLegacyNetherBiome(random, Parameters.BaseOctave, amplitudes);
        float valueFactor = (float)(_normalizationFactor * Parameters.BaseAmplitude);
        return NoiseStack.CreateBuilder()
            .AddStack(first, 1.0, valueFactor)
            .AddStack(second, InputFactor, valueFactor)
            .Build();
    }

    public bool Equals(NormalNoise? other) => other is not null && Parameters.Equals(other.Parameters);

    public override bool Equals(object? obj) => Equals(obj as NormalNoise);

    public override int GetHashCode() => Parameters.GetHashCode();

    private readonly record struct OctaveInfo(int OctaveIndex, double Frequency, double Amplitude) {
        public string Seed => $"octave_{OctaveIndex}";

        public double AbsAmplitude => Math.Abs(Amplitude);
    }
}

/// <summary>
/// The sequential octave construction of the pre 1.18 generator, vanilla's <c>LegacyFbmInitializer</c>:
/// top octave first, 262 draws burned for each one skipped.
/// </summary>
public static class LegacyFbmInitializer {
    public static NoiseStack CreateForLegacyNetherBiome(RandomSource random, int firstOctave, IReadOnlyList<double> amplitudes) {
        int octaves = amplitudes.Count;
        int zeroOctaveIndex = -firstOctave;
        PerlinNoise?[] noiseLevels = new PerlinNoise?[octaves];
        PerlinNoise zeroOctave = new(random);
        if (zeroOctaveIndex >= 0 && zeroOctaveIndex < octaves && amplitudes[zeroOctaveIndex] != 0.0) {
            noiseLevels[zeroOctaveIndex] = zeroOctave;
        }

        for (int i = zeroOctaveIndex - 1; i >= 0; i--) {
            if (i < octaves && amplitudes[i] != 0.0) {
                noiseLevels[i] = new PerlinNoise(random);
            } else {
                random.ConsumeCount(262);
            }
        }

        if (noiseLevels.Count(noise => noise != null) != amplitudes.Count(amplitude => amplitude != 0.0)) {
            throw new InvalidOperationException("Failed to create correct number of noise levels for given non-zero amplitudes");
        }

        if (zeroOctaveIndex < octaves - 1) {
            throw new ArgumentException("Positive octaves are temporarily disabled");
        }

        double factor = Math.Pow(2.0, -zeroOctaveIndex);
        double valueFactor = Math.Pow(2.0, octaves - 1) / (Math.Pow(2.0, octaves) - 1.0);
        NoiseStack.Builder stack = NoiseStack.CreateBuilder();
        for (int i = 0; i < noiseLevels.Length; i++) {
            if (noiseLevels[i] is { } noise) {
                stack.Add(noise, factor, (float)(valueFactor * amplitudes[i]));
            }

            factor *= 2.0;
            valueFactor /= 2.0;
        }

        return stack.Build();
    }
}
