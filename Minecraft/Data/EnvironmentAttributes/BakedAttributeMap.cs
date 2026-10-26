using System.Runtime.CompilerServices;
using Minecraft.Registry;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// An <see cref="EnvironmentAttributeMap"/> with every entry read into its attribute's own types, which is the form
/// vanilla's map holds after its codec has run. Biomes are told apart by which of these they hold, so one is made
/// per map and kept with it.
/// </summary>
public sealed class BakedAttributeMap {
    private static readonly ConditionalWeakTable<EnvironmentAttributeMap, BakedAttributeMap> Baked = new();

    private readonly Dictionary<IEnvironmentAttribute, object> _entries;

    public static readonly BakedAttributeMap Empty = new(new Dictionary<IEnvironmentAttribute, object>());

    private BakedAttributeMap(Dictionary<IEnvironmentAttribute, object> entries) {
        _entries = entries;
    }

    public static BakedAttributeMap Of(EnvironmentAttributeMap map, MinecraftRegistry registry) =>
        Baked.GetValue(map, source => Bake(source, registry));

    private static BakedAttributeMap Bake(EnvironmentAttributeMap map, MinecraftRegistry registry) {
        Dictionary<IEnvironmentAttribute, object> entries = new(ReferenceEqualityComparer.Instance);
        foreach ((IEnvironmentAttribute attribute, EnvironmentAttributeEntry entry) in map.Entries) {
            if (attribute is ITypedEnvironmentAttribute typed && typed.BakeEntry(entry, registry) is { } baked) {
                entries[attribute] = baked;
            }
        }
        return new BakedAttributeMap(entries);
    }

    /// <summary>A map built in code, as <c>WeatherAttributes</c>' are.</summary>
    public static BakedAttributeMap Build(Action<Builder> build) {
        Builder builder = new();
        build(builder);
        return new BakedAttributeMap(builder.Entries);
    }

    public IEnumerable<IEnvironmentAttribute> Keys => _entries.Keys;

    public bool Contains(IEnvironmentAttribute attribute) => _entries.ContainsKey(attribute);

    public AttributeMapEntry<T>? Get<T>(EnvironmentAttribute<T> attribute) => (AttributeMapEntry<T>?)_entries.GetValueOrDefault(attribute);

    public T ApplyModifier<T>(EnvironmentAttribute<T> attribute, T baseValue) =>
        _entries.TryGetValue(attribute, out object? entry) ? ((AttributeMapEntry<T>)entry).ApplyModifier(baseValue) : baseValue;

    public sealed class Builder {
        internal readonly Dictionary<IEnvironmentAttribute, object> Entries = new(ReferenceEqualityComparer.Instance);

        public Builder Modify<TValue, TArgument>(EnvironmentAttribute<TValue> attribute, AttributeModifier<TValue, TArgument> modifier, TArgument argument) {
            Entries[attribute] = modifier.Entry(argument);
            return this;
        }

        public Builder Set<T>(EnvironmentAttribute<T> attribute, T value) => Modify(attribute, AttributeModifiers.Override<T>(), value);
    }
}
