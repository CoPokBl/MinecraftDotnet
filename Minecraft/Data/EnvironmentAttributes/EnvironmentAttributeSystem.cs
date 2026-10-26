using Minecraft.Data.Timelines;
using Minecraft.Schemas.Vec;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary><c>EnvironmentAttributeLayer</c>: one thing in a level that has a say in an attribute's value.</summary>
public abstract class EnvironmentAttributeLayer<T> {
    private EnvironmentAttributeLayer() { }

    public sealed class Constant(Func<T, T> apply) : EnvironmentAttributeLayer<T> {
        public T ApplyConstant(T baseValue) => apply(baseValue);
    }

    public sealed class Positional(Func<T, Vec3<double>, SpatialAttributeInterpolator?, T> apply) : EnvironmentAttributeLayer<T> {
        public T ApplyPositional(T baseValue, Vec3<double> pos, SpatialAttributeInterpolator? biomeInterpolator) => apply(baseValue, pos, biomeInterpolator);
    }

    /// <summary>Handed the system's tick id, which a layer keeps whatever it samples by.</summary>
    public sealed class TimeBased(Func<T, int, T> apply) : EnvironmentAttributeLayer<T> {
        public T ApplyTimeBased(T baseValue, int cacheTickId) => apply(baseValue, cacheTickId);
    }
}

/// <summary>Biomes by position, as <c>BiomeManager</c> gives them to the biome layer.</summary>
public interface IEnvironmentBiomeSource {
    /// <summary><c>getNoiseBiomeAtQuart</c>.</summary>
    BakedAttributeMap NoiseBiomeAtQuart(int quartX, int quartY, int quartZ);

    /// <summary><c>BiomeManager.getBiome</c>, the zoomed biome, for <see cref="EnvironmentAttribute{TValue}.FullResolutionBiomes"/>.</summary>
    BakedAttributeMap BiomeAt(int x, int y, int z);
}

/// <summary><c>ClockManager</c>: how far each world clock has run.</summary>
public interface IClockSource {
    long TotalTicks(Minecraft.Schemas.Identifier clock);
}

/// <summary>
/// <c>EnvironmentAttributeSystem</c>: every layer a level has, per attribute, and the value they come to. A layer
/// added first is applied first, so the dimension goes under the biomes, they under the timelines and the weather.
/// </summary>
public sealed class EnvironmentAttributeSystem {
    private readonly Dictionary<IEnvironmentAttribute, object> _samplers = new(ReferenceEqualityComparer.Instance);

    private EnvironmentAttributeSystem(Dictionary<IEnvironmentAttribute, List<object>> layersByAttribute) {
        foreach ((IEnvironmentAttribute attribute, List<object> layers) in layersByAttribute) {
            _samplers[attribute] = ((ITypedEnvironmentAttribute)attribute).BakeSampler(layers);
        }
    }

    internal static ValueSampler<T> BakeLayerSampler<T>(EnvironmentAttribute<T> attribute, List<EnvironmentAttributeLayer<T>> layers) {
        T constantBaseValue = attribute.DefaultValue;
        while (layers.Count > 0 && layers[0] is EnvironmentAttributeLayer<T>.Constant constantLayer) {
            constantBaseValue = constantLayer.ApplyConstant(constantBaseValue);
            layers.RemoveAt(0);
        }
        bool isAffectedByPosition = layers.Any(layer => layer is EnvironmentAttributeLayer<T>.Positional);
        return new ValueSampler<T>(attribute, constantBaseValue, layers.ToArray(), isAffectedByPosition);
    }

    public static Builder CreateBuilder() => new();

    public void InvalidateTickCache() {
        foreach (object sampler in _samplers.Values) {
            ((IValueSampler)sampler).InvalidateTickCache();
        }
    }

    private ValueSampler<T>? GetValueSampler<T>(EnvironmentAttribute<T> attribute) => (ValueSampler<T>?)_samplers.GetValueOrDefault(attribute);

    /// <summary><c>getDimensionValue</c>: the value with every positional layer skipped.</summary>
    public T GetDimensionValue<T>(EnvironmentAttribute<T> attribute) =>
        GetValueSampler(attribute) is { } sampler ? sampler.GetDimensionValue() : attribute.DefaultValue;

    public T GetValue<T>(EnvironmentAttribute<T> attribute, Vec3<double> pos, SpatialAttributeInterpolator? biomeInterpolator = null) =>
        GetValueSampler(attribute) is { } sampler ? sampler.GetValue(pos, biomeInterpolator) : attribute.DefaultValue;

    /// <summary><c>EnvironmentAttributeReader.getValue(attribute, BlockPos)</c>: the block's centre.</summary>
    public T GetValue<T>(EnvironmentAttribute<T> attribute, int x, int y, int z) => GetValue(attribute, new Vec3<double>(x + 0.5, y + 0.5, z + 0.5));

    public sealed class Builder {
        private readonly Dictionary<IEnvironmentAttribute, List<object>> _layersByAttribute = new(ReferenceEqualityComparer.Instance);

        internal Builder() { }

        /// <summary><c>addDimensionLayer</c>, or any other map applied everywhere.</summary>
        public Builder AddConstantLayer(BakedAttributeMap attributeMap) {
            foreach (IEnvironmentAttribute attribute in attributeMap.Keys) {
                ((ITypedEnvironmentAttribute)attribute).AddConstantLayer(this, attributeMap);
            }
            return this;
        }

        /// <summary>
        /// <c>addBiomeLayer</c>: a positional layer for every attribute any biome sets, reading whichever biome the
        /// position is in, or the camera's blend of them where the attribute is spatially interpolated.
        /// </summary>
        public Builder AddBiomeLayer(IEnumerable<BakedAttributeMap> allBiomes, IEnvironmentBiomeSource biomes) {
            HashSet<IEnvironmentAttribute> seen = new(ReferenceEqualityComparer.Instance);
            foreach (BakedAttributeMap biome in allBiomes) {
                foreach (IEnvironmentAttribute attribute in biome.Keys) {
                    if (seen.Add(attribute)) {
                        ((ITypedEnvironmentAttribute)attribute).AddBiomeLayer(this, biomes);
                    }
                }
            }
            return this;
        }

        /// <summary><c>addTimelineLayer</c>: each of the timeline's tracks sampled on its clock.</summary>
        public Builder AddTimelineLayer(BakedTimeline timeline, IClockSource clocks) {
            foreach (IEnvironmentAttribute attribute in timeline.Attributes) {
                ((ITypedEnvironmentAttribute)attribute).AddTimelineLayer(this, timeline, clocks);
            }
            return this;
        }

        public Builder AddConstantLayer<T>(EnvironmentAttribute<T> attribute, Func<T, T> layer) =>
            AddLayer(attribute, new EnvironmentAttributeLayer<T>.Constant(layer));

        public Builder AddTimeBasedLayer<T>(EnvironmentAttribute<T> attribute, Func<T, int, T> layer) =>
            AddLayer(attribute, new EnvironmentAttributeLayer<T>.TimeBased(layer));

        public Builder AddPositionalLayer<T>(EnvironmentAttribute<T> attribute, Func<T, Vec3<double>, SpatialAttributeInterpolator?, T> layer) =>
            AddLayer(attribute, new EnvironmentAttributeLayer<T>.Positional(layer));

        private Builder AddLayer<T>(EnvironmentAttribute<T> attribute, EnvironmentAttributeLayer<T> layer) {
            if (!_layersByAttribute.TryGetValue(attribute, out List<object>? layers)) {
                layers = [];
                _layersByAttribute[attribute] = layers;
            }
            layers.Add(layer);
            return this;
        }

        public EnvironmentAttributeSystem Build() => new(_layersByAttribute);
    }

    private interface IValueSampler {
        void InvalidateTickCache();
    }

    internal sealed class ValueSampler<T>(EnvironmentAttribute<T> attribute, T baseValue, EnvironmentAttributeLayer<T>[] layers, bool isAffectedByPosition)
        : IValueSampler {
        private T _cachedTickValue = default!;
        private bool _hasCachedTickValue;
        private int _cacheTickId;

        public void InvalidateTickCache() {
            _hasCachedTickValue = false;
            _cacheTickId++;
        }

        public T GetDimensionValue() {
            if (!_hasCachedTickValue) {
                _cachedTickValue = ComputeValueNotPositional();
                _hasCachedTickValue = true;
            }
            return _cachedTickValue;
        }

        public T GetValue(Vec3<double> pos, SpatialAttributeInterpolator? biomeInterpolator) =>
            !isAffectedByPosition ? GetDimensionValue() : ComputeValuePositional(pos, biomeInterpolator);

        private T ComputeValuePositional(Vec3<double> pos, SpatialAttributeInterpolator? biomeInterpolator) {
            T result = baseValue;
            foreach (EnvironmentAttributeLayer<T> layer in layers) {
                result = layer switch {
                    EnvironmentAttributeLayer<T>.Constant constantLayer => constantLayer.ApplyConstant(result),
                    EnvironmentAttributeLayer<T>.TimeBased timeBasedLayer => timeBasedLayer.ApplyTimeBased(result, _cacheTickId),
                    EnvironmentAttributeLayer<T>.Positional positionalLayer => positionalLayer.ApplyPositional(result, pos, biomeInterpolator),
                    _ => throw new InvalidOperationException()
                };
            }
            return attribute.Sanitize(result);
        }

        private T ComputeValueNotPositional() {
            T result = baseValue;
            foreach (EnvironmentAttributeLayer<T> layer in layers) {
                result = layer switch {
                    EnvironmentAttributeLayer<T>.Constant constantLayer => constantLayer.ApplyConstant(result),
                    EnvironmentAttributeLayer<T>.TimeBased timeBasedLayer => timeBasedLayer.ApplyTimeBased(result, _cacheTickId),
                    EnvironmentAttributeLayer<T>.Positional => result,
                    _ => throw new InvalidOperationException()
                };
            }
            return attribute.Sanitize(result);
        }
    }
}
