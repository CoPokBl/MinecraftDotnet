using System.Numerics;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// <c>AttributeType</c>: how an attribute's values are read, which modifiers they take, and the four ways they are
/// lerped. <see cref="KeyframeLerp"/> runs between a timeline's keyframes, <see cref="StateChangeLerp"/> into the
/// weather's layers, <see cref="SpatialLerp"/> across the biomes round the camera and <see cref="PartialTickLerp"/>
/// from one tick's value to the next.
/// </summary>
public sealed class AttributeType<T> {
    public Identifier Identifier { get; }
    public EnvironmentAttributeValueKind Kind { get; }
    public IReadOnlyDictionary<EnvironmentAttributeOperation, AttributeModifier<T>> ModifierLibrary { get; }
    public LerpFunction<T> KeyframeLerp { get; }
    public LerpFunction<T> StateChangeLerp { get; }
    public LerpFunction<T> SpatialLerp { get; }
    public LerpFunction<T> PartialTickLerp { get; }
    private readonly Func<EnvironmentAttributeValue, T> _fromValue;

    private AttributeType(Identifier identifier, EnvironmentAttributeValueKind kind, Func<EnvironmentAttributeValue, T> fromValue,
        IReadOnlyDictionary<EnvironmentAttributeOperation, AttributeModifier<T>> library, LerpFunction<T> keyframeLerp, LerpFunction<T> stateChangeLerp,
        LerpFunction<T> spatialLerp, LerpFunction<T> partialTickLerp) {
        Identifier = identifier;
        Kind = kind;
        _fromValue = fromValue;
        ModifierLibrary = library;
        KeyframeLerp = keyframeLerp;
        StateChangeLerp = stateChangeLerp;
        SpatialLerp = spatialLerp;
        PartialTickLerp = partialTickLerp;
    }

    /// <summary><c>AttributeType.ofInterpolated</c>.</summary>
    public static AttributeType<T> Interpolated(Identifier identifier, EnvironmentAttributeValueKind kind, Func<EnvironmentAttributeValue, T> fromValue,
        IReadOnlyDictionary<EnvironmentAttributeOperation, AttributeModifier<T>> library, LerpFunction<T> lerp, LerpFunction<T>? partialTickLerp = null) =>
        new(identifier, kind, fromValue, library, lerp, lerp, lerp, partialTickLerp ?? lerp);

    /// <summary><c>AttributeType.ofNotInterpolated</c>: each lerp a step, at a different point for each.</summary>
    public static AttributeType<T> NotInterpolated(Identifier identifier, EnvironmentAttributeValueKind kind, Func<EnvironmentAttributeValue, T> fromValue,
        IReadOnlyDictionary<EnvironmentAttributeOperation, AttributeModifier<T>>? library = null) =>
        new(identifier, kind, fromValue, library ?? AttributeModifiers.Library<T>(), LerpFunctions.Step<T>(1.0F), LerpFunctions.Step<T>(0.0F),
            LerpFunctions.Step<T>(0.5F), LerpFunctions.Step<T>(0.0F));

    public T FromValue(EnvironmentAttributeValue value) => _fromValue(value);

    /// <summary>A value as the attribute's codec reads one.</summary>
    public T Read(INbtTag tag, MinecraftRegistry registry) => _fromValue(EnvironmentAttributeValue.FromNbt(Kind, tag, registry));

    public override string ToString() => Identifier.ToString();
}

/// <summary><c>AttributeTypes</c>. The generated attributes name these, so a type new upstream is a compile error.</summary>
public static class AttributeTypes {
    public static readonly AttributeType<bool> Boolean = AttributeType<bool>.NotInterpolated("minecraft:boolean", EnvironmentAttributeValueKind.Boolean,
        value => ((EnvironmentAttributeValue.Boolean)value).Value,
        AttributeModifiers.Library(AttributeModifiers.And, AttributeModifiers.Nand, AttributeModifiers.Or, AttributeModifiers.Nor, AttributeModifiers.Xor,
            AttributeModifiers.Xnor));

    public static readonly AttributeType<TriState> TriState = AttributeType<TriState>.NotInterpolated("minecraft:tri_state",
        EnvironmentAttributeValueKind.TriState, value => ((EnvironmentAttributeValue.TriStateValue)value).Value);

    private static readonly IReadOnlyDictionary<EnvironmentAttributeOperation, AttributeModifier<float>> FloatLibrary = AttributeModifiers.Library(
        AttributeModifiers.FloatAlphaBlend, AttributeModifiers.FloatAdd, AttributeModifiers.FloatSubtract, AttributeModifiers.FloatMultiply,
        AttributeModifiers.FloatMinimum, AttributeModifiers.FloatMaximum);

    public static readonly AttributeType<float> Float = AttributeType<float>.Interpolated("minecraft:float", EnvironmentAttributeValueKind.Float,
        value => ((EnvironmentAttributeValue.Float)value).Value, FloatLibrary, LerpFunctions.Float);

    /// <summary>A float lerped straight between keyframes, biomes and weather, but the short way round from tick to tick.</summary>
    public static readonly AttributeType<float> AngleDegrees = AttributeType<float>.Interpolated("minecraft:angle_degrees",
        EnvironmentAttributeValueKind.Float, value => ((EnvironmentAttributeValue.Float)value).Value, FloatLibrary, LerpFunctions.Float,
        LerpFunctions.Degrees(90.0F));

    public static readonly AttributeType<Vector3> RgbColor = AttributeType<Vector3>.Interpolated("minecraft:rgb_color",
        EnvironmentAttributeValueKind.RgbColor, value => ArgbVectors.FromRgb24(((EnvironmentAttributeValue.RgbColor)value).Value),
        AttributeModifiers.Library(AttributeModifiers.AlphaBlendRgb, AttributeModifiers.AddRgb, AttributeModifiers.SubtractRgb, AttributeModifiers.MultiplyRgb,
            AttributeModifiers.BlendToGrayRgb), LerpFunctions.ColorVec3);

    public static readonly AttributeType<Vector4> ArgbColor = AttributeType<Vector4>.Interpolated("minecraft:argb_color",
        EnvironmentAttributeValueKind.ArgbColor, value => ArgbVectors.FromArgb32(((EnvironmentAttributeValue.ArgbColor)value).Value),
        AttributeModifiers.Library(AttributeModifiers.AlphaBlendArgb, AttributeModifiers.AddArgb, AttributeModifiers.SubtractArgb,
            AttributeModifiers.MultiplyArgb, AttributeModifiers.BlendToGrayArgb), LerpFunctions.ColorVec4);

    public static readonly AttributeType<MoonPhase> MoonPhase = AttributeType<MoonPhase>.NotInterpolated("minecraft:moon_phase",
        EnvironmentAttributeValueKind.MoonPhase, value => ((EnvironmentAttributeValue.MoonPhaseValue)value).Value);

    public static readonly AttributeType<Identifier> Activity = AttributeType<Identifier>.NotInterpolated("minecraft:activity",
        EnvironmentAttributeValueKind.Activity, value => ((EnvironmentAttributeValue.Activity)value).Value);

    public static readonly AttributeType<BedRule> BedRule = AttributeType<BedRule>.NotInterpolated("minecraft:bed_rule",
        EnvironmentAttributeValueKind.BedRule, value => ((EnvironmentAttributeValue.Bed)value).Value);

    public static readonly AttributeType<ParticleValue> Particle = AttributeType<ParticleValue>.NotInterpolated("minecraft:particle",
        EnvironmentAttributeValueKind.Particle, value => ((EnvironmentAttributeValue.Particle)value).Value);

    public static readonly AttributeType<IReadOnlyList<AmbientParticle>> AmbientParticles = AttributeType<IReadOnlyList<AmbientParticle>>.Interpolated(
        "minecraft:ambient_particles", EnvironmentAttributeValueKind.AmbientParticles,
        value => ((EnvironmentAttributeValue.AmbientParticles)value).Values,
        AttributeModifiers.Library(AttributeModifiers.Append<AmbientParticle>()),
        LerpFunctions.ListCrossFade<AmbientParticle>((particle, alpha) => particle with { Probability = particle.Probability * alpha }));

    public static readonly AttributeType<BackgroundMusic> BackgroundMusic = AttributeType<BackgroundMusic>.NotInterpolated("minecraft:background_music",
        EnvironmentAttributeValueKind.BackgroundMusic, value => ((EnvironmentAttributeValue.Music)value).Value);

    public static readonly AttributeType<AmbientSounds> AmbientSounds = AttributeType<AmbientSounds>.NotInterpolated("minecraft:ambient_sounds",
        EnvironmentAttributeValueKind.AmbientSounds, value => ((EnvironmentAttributeValue.Sounds)value).Value);

    public static readonly AttributeType<INbtTag> MobSpawnSettings = AttributeType<INbtTag>.NotInterpolated("minecraft:mob_spawn_settings",
        EnvironmentAttributeValueKind.MobSpawnSettings, value => ((EnvironmentAttributeValue.MobSpawns)value).Value,
        AttributeModifiers.Library(AttributeModifiers.Overlay));
}
