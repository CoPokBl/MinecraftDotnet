using Minecraft.Schemas.Vec;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// <c>EnvironmentAttributeProbe</c>: the camera's view of the attributes. The biomes round it are weighed once a
/// tick, and each value asked for is held for the tick and lerped from the last tick's by the partial tick, so a
/// value only moves a tick after it changes. An attribute nobody asked for in a tick is forgotten.
/// </summary>
public sealed class EnvironmentAttributeProbe {
    private readonly Dictionary<IEnvironmentAttribute, object> _valueProbes = new(ReferenceEqualityComparer.Instance);
    private readonly List<IEnvironmentAttribute> _expired = [];
    private EnvironmentAttributeSystem? _level;
    private Vec3<double>? _position;
    private readonly SpatialAttributeInterpolator _biomeInterpolator = new();

    public void Reset() {
        _level = null;
        _position = null;
        _biomeInterpolator.Clear();
        _valueProbes.Clear();
    }

    /// <param name="level">The level's attributes.</param>
    /// <param name="biomes">The level's biomes, which the interpolator is filled from.</param>
    public void Tick(EnvironmentAttributeSystem level, IEnvironmentBiomeSource biomes, Vec3<double> position) {
        _level = level;
        _position = position;
        foreach ((IEnvironmentAttribute attribute, object probe) in _valueProbes) {
            if (((IValueProbe)probe).Tick()) {
                _expired.Add(attribute);
            }
        }
        foreach (IEnvironmentAttribute attribute in _expired) {
            _valueProbes.Remove(attribute);
        }
        _expired.Clear();
        _biomeInterpolator.Clear();
        GaussianSampler.Sample(new Vec3<double>(position.X * 0.25, position.Y * 0.25, position.Z * 0.25), biomes.NoiseBiomeAtQuart,
            (weight, biome) => _biomeInterpolator.Accumulate(weight, biome));
    }

    public T GetValue<T>(EnvironmentAttribute<T> attribute, float partialTicks) {
        if (!_valueProbes.TryGetValue(attribute, out object? probe)) {
            probe = new ValueProbe<T>(this, attribute);
            _valueProbes[attribute] = probe;
        }
        return ((ValueProbe<T>)probe).Get(attribute, partialTicks);
    }

    private T GetValueFromLevel<T>(EnvironmentAttribute<T> attribute) =>
        _level != null && _position is { } position ? _level.GetValue(attribute, position, _biomeInterpolator) : attribute.DefaultValue;

    private interface IValueProbe {
        /// <returns>True when nothing asked for the value this tick, and the probe can go.</returns>
        bool Tick();
    }

    private sealed class ValueProbe<T> : IValueProbe {
        private readonly EnvironmentAttributeProbe _owner;
        private T _lastValue;
        private T _newValue;
        private bool _hasNewValue;

        public ValueProbe(EnvironmentAttributeProbe owner, EnvironmentAttribute<T> attribute) {
            _owner = owner;
            T value = owner.GetValueFromLevel(attribute);
            _lastValue = value;
            _newValue = value;
            _hasNewValue = true;
        }

        public bool Tick() {
            if (!_hasNewValue) {
                return true;
            }
            _lastValue = _newValue;
            _hasNewValue = false;
            return false;
        }

        public T Get(EnvironmentAttribute<T> attribute, float partialTicks) {
            if (!_hasNewValue) {
                _newValue = _owner.GetValueFromLevel(attribute);
                _hasNewValue = true;
            }
            return attribute.Type.PartialTickLerp(partialTicks, _lastValue, _newValue);
        }
    }
}
