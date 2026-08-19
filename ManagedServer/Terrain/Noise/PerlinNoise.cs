using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// A stack of <see cref="ImprovedNoise"/> octaves at doubling frequencies, vanilla's <c>PerlinNoise</c>.
/// </summary>
/// <remarks>
/// Two constructions, and which one is used decides every value the noise produces:
/// <list type="bullet">
/// <item><see cref="Create(RandomSource,int,IReadOnlyList{double})"/> seeds each octave from a
/// <b>hash of its name</b> through a positional factory, so an octave's noise does not depend on how
/// many octaves came before it.</item>
/// <item><see cref="CreateLegacyForBlendedNoise"/> draws them from the generator in sequence, top
/// octave first, and burns 262 draws for each zero amplitude one. That sequence is the whole point:
/// it is what makes the old terrain noise reproduce.</item>
/// </list>
/// </remarks>
public sealed class PerlinNoise {
    private readonly ImprovedNoise?[] _noiseLevels;
    private readonly int _firstOctave;
    private readonly double[] _amplitudes;
    private readonly double _lowestFreqValueFactor;
    private readonly double _lowestFreqInputFactor;
    private readonly double _maxValue;

    /// <param name="useNewInitialization">
    /// True for the hashed per octave seeding, false for the sequential legacy one.
    /// </param>
    private PerlinNoise(RandomSource random, int firstOctave, IReadOnlyList<double> amplitudes,
        bool useNewInitialization) {

        _firstOctave = firstOctave;
        _amplitudes = amplitudes.ToArray();

        int octaves = _amplitudes.Length;
        int zeroOctaveIndex = -firstOctave;
        _noiseLevels = new ImprovedNoise[octaves];

        if (useNewInitialization) {
            IPositionalRandomFactory positional = random.ForkPositional();
            for (int i = 0; i < octaves; i++) {
                if (_amplitudes[i] != 0.0) {
                    _noiseLevels[i] = new ImprovedNoise(positional.FromHashOf($"octave_{firstOctave + i}"));
                }
            }
        } else {
            ImprovedNoise zeroOctave = new(random);
            if (zeroOctaveIndex >= 0 && zeroOctaveIndex < octaves && _amplitudes[zeroOctaveIndex] != 0.0) {
                _noiseLevels[zeroOctaveIndex] = zeroOctave;
            }

            for (int i = zeroOctaveIndex - 1; i >= 0; i--) {
                if (i < octaves && _amplitudes[i] != 0.0) {
                    _noiseLevels[i] = new ImprovedNoise(random);
                } else {
                    // An unused octave still consumes its draws, so the ones after it line up.
                    random.ConsumeCount(262);
                }
            }
        }

        _lowestFreqInputFactor = Math.Pow(2.0, -zeroOctaveIndex);
        _lowestFreqValueFactor = Math.Pow(2.0, octaves - 1) / (Math.Pow(2.0, octaves) - 1.0);
        _maxValue = EdgeValue(2.0);
    }

    /// <summary>Octaves named by index, each with amplitude one, seeded from their names.</summary>
    public static PerlinNoise Create(RandomSource random, IReadOnlyCollection<int> octaves) {
        (int firstOctave, double[] amplitudes) = MakeAmplitudes(octaves);
        return new PerlinNoise(random, firstOctave, amplitudes, true);
    }

    public static PerlinNoise Create(RandomSource random, int firstOctave, IReadOnlyList<double> amplitudes) {
        return new PerlinNoise(random, firstOctave, amplitudes, true);
    }

    /// <summary>
    /// The sequential seeding <see cref="BlendedNoise"/> needs. Deprecated upstream and kept for the
    /// one caller: its octave stream is baked into the shape of overworld terrain.
    /// </summary>
    public static PerlinNoise CreateLegacyForBlendedNoise(RandomSource random, IReadOnlyCollection<int> octaves) {
        (int firstOctave, double[] amplitudes) = MakeAmplitudes(octaves);
        return new PerlinNoise(random, firstOctave, amplitudes, false);
    }

    /// <summary>
    /// A set of octave indices becomes a dense amplitude list from the lowest to the highest, ones
    /// where an octave was asked for and zeros where it was not.
    /// </summary>
    private static (int FirstOctave, double[] Amplitudes) MakeAmplitudes(IReadOnlyCollection<int> octaveSet) {
        if (octaveSet.Count == 0) {
            throw new ArgumentException("Need some octaves", nameof(octaveSet));
        }

        int lowFreqOctaves = -octaveSet.Min();
        int highFreqOctaves = octaveSet.Max();
        int octaves = lowFreqOctaves + highFreqOctaves + 1;

        double[] amplitudes = new double[octaves];
        foreach (int octave in octaveSet) {
            amplitudes[octave + lowFreqOctaves] = 1.0;
        }

        return (-lowFreqOctaves, amplitudes);
    }

    public double MaxValue => _maxValue;

    public int FirstOctave => _firstOctave;

    public double GetValue(double x, double y, double z) {
        return GetValue(x, y, z, 0.0, 0.0);
    }

    public double GetValue(double x, double y, double z, double yScale, double yFudge) {
        double value = 0.0;
        double factor = _lowestFreqInputFactor;
        double valueFactor = _lowestFreqValueFactor;

        for (int i = 0; i < _noiseLevels.Length; i++) {
            ImprovedNoise? noise = _noiseLevels[i];
            if (noise != null) {
                // Multiplied in vanilla's order. These are doubles and multiplication is not
                // associative, so reordering the three moves the last bit of every sample.
                double sample = noise.Noise(Wrap(x * factor), Wrap(y * factor), Wrap(z * factor),
                    yScale * factor, yFudge * factor);
                value += _amplitudes[i] * sample * valueFactor;
            }

            factor *= 2.0;
            valueFactor /= 2.0;
        }

        return value;
    }

    /// <summary>
    /// <c>maxBrokenValue</c>: the bound <see cref="BlendedNoise"/> reports, computed from a sample
    /// value that the noise cannot actually reach. Kept as it is because it is what sizes that
    /// function's declared range, and a tighter bound would change what the density function tree
    /// believes about it.
    /// </summary>
    public double MaxBrokenValue(double yScale) {
        return EdgeValue(yScale + 2.0);
    }

    private double EdgeValue(double noiseValue) {
        double value = 0.0;
        double valueFactor = _lowestFreqValueFactor;

        for (int i = 0; i < _noiseLevels.Length; i++) {
            if (_noiseLevels[i] != null) {
                value += _amplitudes[i] * noiseValue * valueFactor;
            }

            valueFactor /= 2.0;
        }

        return value;
    }

    /// <summary>Octaves counted from the highest frequency down, which is how blended noise walks them.</summary>
    public ImprovedNoise? GetOctaveNoise(int i) {
        return _noiseLevels[_noiseLevels.Length - 1 - i];
    }

    /// <summary>
    /// Folds a coordinate into a range the octave's integer lattice can still resolve. Without it a
    /// position far from the origin loses precision and the noise goes flat.
    /// </summary>
    public static double Wrap(double x) {
        return x - Mth.LFloor(x / 3.3554432E7 + 0.5) * 3.3554432E7;
    }
}
