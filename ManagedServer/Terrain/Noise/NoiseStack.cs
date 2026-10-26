using ManagedServer.Terrain.Density;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// A sum of noises, each at its own frequency and float amplitude, vanilla's <c>NoiseStack</c>.
/// </summary>
/// <remarks>
/// The sum is float and runs in layer order, and a <see cref="NormalNoise"/> interleaves its two
/// halves octave by octave, so both the order of <see cref="Builder.Add"/> calls and the float
/// accumulation are part of every value.
/// </remarks>
public sealed class NoiseStack : INoise {
    private readonly Layer[] _layers;

    private NoiseStack(Layer[] layers) {
        _layers = layers;
        Interval range = Interval.OfExact(0.0F);
        foreach (Layer layer in layers) {
            range = Interval.Add(range, Interval.Mul(layer.Noise.Range, Interval.OfExact(layer.Amplitude)));
        }

        Range = range;
    }

    public static Builder CreateBuilder() => new();

    public Interval Range { get; }

    public int LayerCount => _layers.Length;

    public INoise GetLayer(int index) => _layers[index].Noise;

    public float Get(double x, double y, double z) {
        float value = 0.0F;
        foreach (Layer layer in _layers) {
            double frequency = layer.Frequency;
            value += layer.Amplitude * layer.Noise.Get(x * frequency, y * frequency, z * frequency);
        }

        return value;
    }

    public float Get(double x, double y) {
        float value = 0.0F;
        foreach (Layer layer in _layers) {
            double frequency = layer.Frequency;
            value += layer.Amplitude * layer.Noise.Get(x * frequency, y * frequency);
        }

        return value;
    }

    public void AddToVolume(DensityBuffer buffer, DensityVolume volume, double xzScale, double yScale, float amplitude) {
        foreach (Layer layer in _layers) {
            double frequency = layer.Frequency;
            layer.Noise.AddToVolume(buffer, volume, xzScale * frequency, yScale * frequency, amplitude * layer.Amplitude);
        }
    }

    private readonly record struct Layer(INoise Noise, double Frequency, float Amplitude);

    public sealed class Builder {
        private readonly List<Layer> _layers = [];

        public Builder Add(INoise noise, double frequency, float amplitude) {
            _layers.Add(new Layer(noise, frequency, amplitude));
            return this;
        }

        /// <summary>Adds every layer of <paramref name="stack"/>, its frequency and amplitude scaled.</summary>
        public Builder AddStack(NoiseStack stack, double frequency, float amplitude) {
            foreach (Layer layer in stack._layers) {
                _layers.Add(new Layer(layer.Noise, layer.Frequency * frequency, layer.Amplitude * amplitude));
            }

            return this;
        }

        public NoiseStack Build() => new(_layers.ToArray());
    }
}
