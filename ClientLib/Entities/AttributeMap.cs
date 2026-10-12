using Minecraft.Data.Attributes;
using Minecraft.Data.Entities;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Attributes;

namespace ClientLib.Entities;

/// <summary>
/// An entity's attributes as the server last described them, plus whatever the client adds itself
/// (the sprinting speed modifier). Unlisted attributes read as the entity type's default.
/// </summary>
public sealed class AttributeMap(IEntityType type) {
    private readonly Dictionary<IAttribute, Instance> _instances = new();

    public double Value(IAttribute attribute) {
        return _instances.TryGetValue(attribute, out Instance? instance)
            ? instance.Value
            : Sanitize(attribute, type.DefaultAttributeValue(attribute));
    }

    public Instance GetOrCreate(IAttribute attribute) {
        if (!_instances.TryGetValue(attribute, out Instance? instance)) {
            instance = new Instance(attribute, type.DefaultAttributeValue(attribute));
            _instances[attribute] = instance;
        }
        return instance;
    }

    /// <summary><c>ClientPacketListener.handleUpdateAttributes</c>: the base and every modifier replaced.</summary>
    public void Apply(AttributeValue value) {
        Instance instance = GetOrCreate(value.Attribute);
        instance.BaseValue = value.BaseValue;
        instance.ClearModifiers();
        foreach (AttributeModifier modifier in value.Modifiers) {
            instance.AddModifier(modifier);
        }
    }

    /// <summary>
    /// <c>AttributeMap.assignAllValues</c>, or <c>assignBaseValues</c> when <paramref name="modifiers"/>
    /// is false: a respawn always keeps the bases and keeps the modifiers only when told to.
    /// </summary>
    public void CopyFrom(AttributeMap other, bool modifiers) {
        foreach ((IAttribute attribute, Instance source) in other._instances) {
            Instance instance = GetOrCreate(attribute);
            instance.BaseValue = source.BaseValue;
            if (!modifiers) {
                continue;
            }
            instance.ClearModifiers();
            foreach (AttributeModifier modifier in source.Modifiers) {
                instance.AddModifier(modifier);
            }
        }
    }

    private static double Sanitize(IAttribute attribute, double value) {
        return double.IsNaN(value) ? attribute.Min : Math.Clamp(value, attribute.Min, attribute.Max);
    }

    /// <summary>
    /// <c>AttributeInstance</c>. Vanilla keeps each operation's modifiers in a hash map, so when two
    /// share an operation the order they are folded in is the identifiers' hash order; here it is
    /// insertion order, which only moves the last bits of a sum or product of several.
    /// </summary>
    public sealed class Instance(IAttribute attribute, double baseValue) {
        private readonly List<AttributeModifier> _modifiers = [];
        private double? _cached;

        public IAttribute Attribute { get; } = attribute;

        public double BaseValue {
            get => baseValue;
            set {
                baseValue = value;
                _cached = null;
            }
        }

        public IReadOnlyList<AttributeModifier> Modifiers => _modifiers;

        public void ClearModifiers() {
            _modifiers.Clear();
            _cached = null;
        }

        public void AddModifier(AttributeModifier modifier) {
            RemoveModifier(modifier.Id);
            _modifiers.Add(modifier);
            _cached = null;
        }

        public void RemoveModifier(Identifier id) {
            int index = _modifiers.FindIndex(m => m.Id.Equals(id));
            if (index >= 0) {
                _modifiers.RemoveAt(index);
                _cached = null;
            }
        }

        public bool HasModifier(Identifier id) => _modifiers.Exists(m => m.Id.Equals(id));

        public double Value => _cached ??= Calculate();

        /// <summary><c>AttributeInstance.calculateValue</c>.</summary>
        private double Calculate() {
            double value = baseValue;
            foreach (AttributeModifier modifier in _modifiers) {
                if (modifier.Operation == AttributeOperation.Add) {
                    value += modifier.Value;
                }
            }

            double result = value;
            foreach (AttributeModifier modifier in _modifiers) {
                if (modifier.Operation == AttributeOperation.AddMultipliedBase) {
                    result += value * modifier.Value;
                }
            }
            foreach (AttributeModifier modifier in _modifiers) {
                if (modifier.Operation == AttributeOperation.AddMultipliedTotal) {
                    result *= 1.0 + modifier.Value;
                }
            }
            return Sanitize(Attribute, result);
        }
    }
}
