using Minecraft.Data.Timelines;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// <c>EnvironmentAttribute</c> with its value type known, which is what everything that evaluates one works through.
/// One instance per attribute, so it compares by reference as vanilla's registry entries do.
/// </summary>
/// <param name="positional">Whether a value depends on where it is asked for; one that does not may only be asked of the dimension.</param>
/// <param name="spatiallyInterpolated">Whether the camera's value blends the biomes round it rather than taking the one it is in.</param>
/// <param name="fullResolutionBiomes">Whether the biome is the zoomed one <c>BiomeManager.getBiome</c> picks rather than the quart cell's.</param>
public sealed class EnvironmentAttribute<TValue>(
    Identifier identifier,
    AttributeType<TValue> type,
    TValue defaultValue,
    AttributeRange<TValue> range,
    bool syncable,
    bool positional,
    bool spatiallyInterpolated,
    bool fullResolutionBiomes) : IEnvironmentAttribute, ITypedEnvironmentAttribute {
    public Identifier Identifier => identifier;
    public EnvironmentAttributeValueKind ValueKind => type.Kind;
    public bool Syncable => syncable;
    public AttributeType<TValue> Type => type;
    public TValue DefaultValue => defaultValue;
    public bool Positional => positional;
    public bool SpatiallyInterpolated => spatiallyInterpolated;
    public bool FullResolutionBiomes => fullResolutionBiomes;

    public TValue Sanitize(TValue value) => range.Sanitize(value);

    /// <remarks>
    /// An entry naming a modifier this type has no such thing as is dropped, where vanilla's codec refuses the whole
    /// element it sits in; a client cannot refuse a registry the server already sent.
    /// </remarks>
    object? ITypedEnvironmentAttribute.BakeEntry(EnvironmentAttributeEntry entry, MinecraftRegistry registry) {
        try {
            return entry switch {
                EnvironmentAttributeEntry.Constant constant => AttributeModifiers.Override<TValue>().Entry(type.FromValue(constant.Value)),
                EnvironmentAttributeEntry.Modified modified when type.ModifierLibrary.TryGetValue(modified.Operation, out AttributeModifier<TValue>? modifier) =>
                    modifier.ReadEntry(this, modified.Argument, registry),
                _ => null
            };
        }
        catch (Exception e) when (e is InvalidCastException or FormatException or ArgumentException or NullReferenceException or KeyNotFoundException) {
            return null;
        }
    }

    object? ITypedEnvironmentAttribute.ReadTrack(EnvironmentAttributeOperation operation, IReadOnlyList<(int Ticks, INbtTag Value)> keyframes,
        EasingType easing, MinecraftRegistry registry) {
        if (!type.ModifierLibrary.TryGetValue(operation, out AttributeModifier<TValue>? modifier)) {
            return null;
        }
        try {
            return modifier.ReadTrack(this, keyframes, easing, registry);
        }
        catch (Exception e) when (e is InvalidCastException or FormatException or ArgumentException or NullReferenceException or KeyNotFoundException) {
            return null;
        }
    }

    void ITypedEnvironmentAttribute.AddConstantLayer(EnvironmentAttributeSystem.Builder builder, BakedAttributeMap map) {
        if (map.Get(this) is { } entry) {
            builder.AddConstantLayer(this, entry.ApplyModifier);
        }
    }

    void ITypedEnvironmentAttribute.AddBiomeLayer(EnvironmentAttributeSystem.Builder builder, IEnvironmentBiomeSource biomes) {
        builder.AddPositionalLayer(this, (baseValue, pos, biomeWeights) => {
            if (biomeWeights != null && spatiallyInterpolated) {
                return biomeWeights.ApplyAttributeLayer(this, baseValue);
            }
            BakedAttributeMap biome = fullResolutionBiomes
                ? biomes.BiomeAt(Mth.Floor(pos.X), Mth.Floor(pos.Y), Mth.Floor(pos.Z))
                : biomes.NoiseBiomeAtQuart(Mth.Floor(pos.X) >> 2, Mth.Floor(pos.Y) >> 2, Mth.Floor(pos.Z) >> 2);
            return biome.ApplyModifier(this, baseValue);
        });
    }

    void ITypedEnvironmentAttribute.AddTimelineLayer(EnvironmentAttributeSystem.Builder builder, BakedTimeline timeline, IClockSource clocks) {
        if (timeline.Track(this) is { } track) {
            builder.AddTimeBasedLayer(this, track.BakeSampler(this, timeline.Clock, timeline.PeriodTicks, clocks).ApplyTimeBased);
        }
    }

    object ITypedEnvironmentAttribute.BakeSampler(IReadOnlyList<object> layers) =>
        EnvironmentAttributeSystem.BakeLayerSampler(this, layers.Cast<EnvironmentAttributeLayer<TValue>>().ToList());

    public override string ToString() => identifier.ToString();
}

/// <summary>The operations that need an attribute's value type, reached from an untyped key.</summary>
internal interface ITypedEnvironmentAttribute {
    object? BakeEntry(EnvironmentAttributeEntry entry, MinecraftRegistry registry);

    object? ReadTrack(EnvironmentAttributeOperation operation, IReadOnlyList<(int Ticks, INbtTag Value)> keyframes, EasingType easing,
        MinecraftRegistry registry);

    void AddConstantLayer(EnvironmentAttributeSystem.Builder builder, BakedAttributeMap map);

    void AddBiomeLayer(EnvironmentAttributeSystem.Builder builder, IEnvironmentBiomeSource biomes);

    void AddTimelineLayer(EnvironmentAttributeSystem.Builder builder, BakedTimeline timeline, IClockSource clocks);

    object BakeSampler(IReadOnlyList<object> layers);
}
