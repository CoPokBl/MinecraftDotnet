using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// <c>SpatialAttributeInterpolator</c>: the biomes round a point and their weights, which a spatially interpolated
/// attribute is blended over. Biomes are told apart by their attribute map's identity and kept in the order first
/// seen, which is the order the lerp runs in.
/// </summary>
public sealed class SpatialAttributeInterpolator {
    private readonly List<(BakedAttributeMap Source, double Weight)> _weightsBySource = [];

    public void Clear() => _weightsBySource.Clear();

    public SpatialAttributeInterpolator Accumulate(double weight, BakedAttributeMap attributes) {
        for (int i = 0; i < _weightsBySource.Count; i++) {
            if (ReferenceEquals(_weightsBySource[i].Source, attributes)) {
                _weightsBySource[i] = (attributes, _weightsBySource[i].Weight + weight);
                return this;
            }
        }
        _weightsBySource.Add((attributes, weight));
        return this;
    }

    public T ApplyAttributeLayer<T>(EnvironmentAttribute<T> attribute, T baseValue) {
        if (_weightsBySource.Count == 0) {
            return baseValue;
        }
        if (_weightsBySource.Count == 1) {
            return _weightsBySource[0].Source.ApplyModifier(attribute, baseValue);
        }
        LerpFunction<T> lerp = attribute.Type.SpatialLerp;
        T resultValue = default!;
        bool first = true;
        double accumulatedWeight = 0.0;
        foreach ((BakedAttributeMap sourceAttributes, double sourceWeight) in _weightsBySource) {
            T sourceValue = sourceAttributes.ApplyModifier(attribute, baseValue);
            accumulatedWeight += sourceWeight;
            if (first) {
                resultValue = sourceValue;
                first = false;
            }
            else {
                float relativeFraction = (float)(sourceWeight / accumulatedWeight);
                resultValue = lerp(relativeFraction, resultValue, sourceValue);
            }
        }
        return resultValue;
    }
}

/// <summary><c>GaussianSampler</c>: a six by six by six kernel round a point in quart cells, weighted by where in its cell the point is.</summary>
public static class GaussianSampler {
    private static readonly double[] GaussianSampleKernel = [0.0, 1.0, 4.0, 6.0, 4.0, 1.0, 0.0];

    public static void Sample<TValue>(Vec3<double> position, Func<int, int, int, TValue> sampler, Action<double, TValue> accumulator) {
        double px = position.X - 0.5, py = position.Y - 0.5, pz = position.Z - 0.5;
        int integralX = Mth.Floor(px);
        int integralY = Mth.Floor(py);
        int integralZ = Mth.Floor(pz);
        double relativeX = px - integralX;
        double relativeY = py - integralY;
        double relativeZ = pz - integralZ;
        for (int z = 0; z < 6; z++) {
            double weightZ = Mth.Lerp(relativeZ, GaussianSampleKernel[z + 1], GaussianSampleKernel[z]);
            int sampleZ = integralZ - 2 + z;
            for (int x = 0; x < 6; x++) {
                double weightX = Mth.Lerp(relativeX, GaussianSampleKernel[x + 1], GaussianSampleKernel[x]);
                int sampleX = integralX - 2 + x;
                for (int y = 0; y < 6; y++) {
                    double weightY = Mth.Lerp(relativeY, GaussianSampleKernel[y + 1], GaussianSampleKernel[y]);
                    int sampleY = integralY - 2 + y;
                    double sampleWeight = weightX * weightY * weightZ;
                    accumulator(sampleWeight, sampler(sampleX, sampleY, sampleZ));
                }
            }
        }
    }
}
