using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// The amplitudes and first octave a <see cref="NormalNoise"/> is built from, vanilla's
/// <c>NormalNoise.NoiseParameters</c>. One per entry in the <c>worldgen/noise</c> registry.
/// </summary>
public sealed record NoiseParameters(int FirstOctave, IReadOnlyList<double> Amplitudes);

/// <summary>
/// Two Perlin stacks summed at slightly different frequencies and rescaled to a roughly normal
/// distribution, vanilla's <c>NormalNoise</c>. Every named noise in worldgen is one of these.
/// </summary>
/// <remarks>
/// The second stack is sampled at <c>1.0181268882175227</c> times the coordinates, an irrational
/// enough ratio that the two never line up and reinforce, which is what removes the grid artefacts a
/// single stack has.
/// </remarks>
public sealed class NormalNoise {
    private const double InputFactor = 1.0181268882175227;

    private readonly double _valueFactor;
    private readonly PerlinNoise _first;
    private readonly PerlinNoise _second;
    private readonly double _maxValue;

    private NormalNoise(RandomSource random, NoiseParameters parameters) {
        Parameters = parameters;

        // Both stacks come off the same generator in order, so the second is not a copy of the first.
        _first = PerlinNoise.Create(random, parameters.FirstOctave, parameters.Amplitudes);
        _second = PerlinNoise.Create(random, parameters.FirstOctave, parameters.Amplitudes);

        int minOctave = int.MaxValue;
        int maxOctave = int.MinValue;
        for (int i = 0; i < parameters.Amplitudes.Count; i++) {
            if (parameters.Amplitudes[i] != 0.0) {
                minOctave = Math.Min(minOctave, i);
                maxOctave = Math.Max(maxOctave, i);
            }
        }

        _valueFactor = 0.16666666666666666 / ExpectedDeviation(maxOctave - minOctave);
        _maxValue = (_first.MaxValue + _second.MaxValue) * _valueFactor;
    }

    public static NormalNoise Create(RandomSource random, NoiseParameters parameters) {
        return new NormalNoise(random, parameters);
    }

    public NoiseParameters Parameters { get; }

    public double MaxValue => _maxValue;

    private static double ExpectedDeviation(int octaveSpan) {
        return 0.1 * (1.0 + 1.0 / (octaveSpan + 1));
    }

    public double GetValue(double x, double y, double z) {
        return (_first.GetValue(x, y, z)
            + _second.GetValue(x * InputFactor, y * InputFactor, z * InputFactor)) * _valueFactor;
    }
}
