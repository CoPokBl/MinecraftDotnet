using System.Numerics;
using Minecraft.Data.Timelines;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// <c>AttributeModifier</c>: how one layer changes the value the layers under it worked out. Reading a layer's
/// argument and lerping between two of them belong to the modifier, since a modifier's argument is often not
/// of the attribute's own type.
/// </summary>
public abstract class AttributeModifier<TValue> {
    public abstract EnvironmentAttributeOperation Operation { get; }

    internal abstract AttributeMapEntry<TValue> ReadEntry(EnvironmentAttribute<TValue> attribute, INbtTag argument, MinecraftRegistry registry);

    internal abstract AttributeTrack<TValue> ReadTrack(EnvironmentAttribute<TValue> attribute, IReadOnlyList<(int Ticks, INbtTag Value)> keyframes,
        EasingType easing, MinecraftRegistry registry);
}

public abstract class AttributeModifier<TValue, TArgument> : AttributeModifier<TValue> {
    public abstract TValue Apply(TValue subject, TArgument argument);

    public abstract TArgument ReadArgument(EnvironmentAttribute<TValue> attribute, INbtTag tag, MinecraftRegistry registry);

    public abstract LerpFunction<TArgument> ArgumentKeyframeLerp(EnvironmentAttribute<TValue> attribute);

    public AttributeMapEntry<TValue> Entry(TArgument argument) => new AttributeMapEntry<TValue, TArgument>(argument, this);

    internal sealed override AttributeMapEntry<TValue> ReadEntry(EnvironmentAttribute<TValue> attribute, INbtTag argument, MinecraftRegistry registry) =>
        Entry(ReadArgument(attribute, argument, registry));

    internal sealed override AttributeTrack<TValue> ReadTrack(EnvironmentAttribute<TValue> attribute, IReadOnlyList<(int Ticks, INbtTag Value)> keyframes,
        EasingType easing, MinecraftRegistry registry) =>
        new AttributeTrack<TValue, TArgument>(this,
            new KeyframeTrack<TArgument>(keyframes.Select(k => new Keyframe<TArgument>(k.Ticks, ReadArgument(attribute, k.Value, registry))).ToArray(), easing));
}

/// <summary><c>EnvironmentAttributeMap.Entry</c>: one layer's modifier and the argument it applies.</summary>
public abstract class AttributeMapEntry<TValue> {
    public abstract TValue ApplyModifier(TValue subject);
}

public sealed class AttributeMapEntry<TValue, TArgument>(TArgument argument, AttributeModifier<TValue, TArgument> modifier) : AttributeMapEntry<TValue> {
    public TArgument Argument => argument;
    public AttributeModifier<TValue, TArgument> Modifier => modifier;

    public override TValue ApplyModifier(TValue subject) => modifier.Apply(subject, argument);
}

/// <summary><c>FloatWithAlpha</c>: <c>alpha_blend</c>'s argument for a float.</summary>
public readonly record struct FloatWithAlpha(float Value, float Alpha = 1.0F) {
    /// <summary>A bare float, or <c>{value, alpha}</c> with alpha defaulting to one.</summary>
    public static FloatWithAlpha FromNbt(INbtTag tag) => tag is CompoundTag compound
        ? new FloatWithAlpha(compound["value"]!.AsFloat(), compound.Contains("alpha") ? compound["alpha"]!.AsFloat() : 1.0F)
        : new FloatWithAlpha(tag.AsFloat());

    public static FloatWithAlpha Lerp(float alpha, FloatWithAlpha from, FloatWithAlpha to) =>
        new(Mth.Lerp(alpha, from.Value, to.Value), Mth.Lerp(alpha, from.Alpha, to.Alpha));
}

/// <summary><c>ColorModifier.BlendToGray</c>: toward the colour's own grey, scaled by <paramref name="Brightness"/>.</summary>
public readonly record struct BlendToGray(float Brightness, float Factor) {
    public static BlendToGray FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new BlendToGray(compound["brightness"]!.AsFloat(), compound["factor"]!.AsFloat());
    }

    public static BlendToGray Lerp(float alpha, BlendToGray from, BlendToGray to) =>
        new(Mth.Lerp(alpha, from.Brightness, to.Brightness), Mth.Lerp(alpha, from.Factor, to.Factor));
}

/// <summary>Every modifier vanilla's <c>AttributeModifier</c> libraries hold.</summary>
public static class AttributeModifiers {
    private sealed class Simple<TValue, TArgument>(
        EnvironmentAttributeOperation operation,
        Func<TValue, TArgument, TValue> apply,
        Func<INbtTag, TArgument> read,
        LerpFunction<TArgument> lerp) : AttributeModifier<TValue, TArgument> {
        public override EnvironmentAttributeOperation Operation => operation;

        public override TValue Apply(TValue subject, TArgument argument) => apply(subject, argument);

        public override TArgument ReadArgument(EnvironmentAttribute<TValue> attribute, INbtTag tag, MinecraftRegistry registry) => read(tag);

        public override LerpFunction<TArgument> ArgumentKeyframeLerp(EnvironmentAttribute<TValue> attribute) => lerp;
    }

    /// <summary>Takes an argument of the attribute's own type, read and lerped as its keyframes are.</summary>
    private sealed class OfValueType<TValue>(EnvironmentAttributeOperation operation, Func<TValue, TValue, TValue> apply)
        : AttributeModifier<TValue, TValue> {
        public override EnvironmentAttributeOperation Operation => operation;

        public override TValue Apply(TValue subject, TValue argument) => apply(subject, argument);

        public override TValue ReadArgument(EnvironmentAttribute<TValue> attribute, INbtTag tag, MinecraftRegistry registry) =>
            attribute.Type.Read(tag, registry);

        public override LerpFunction<TValue> ArgumentKeyframeLerp(EnvironmentAttribute<TValue> attribute) => attribute.Type.KeyframeLerp;
    }

    private static class OverrideOf<TValue> {
        public static readonly AttributeModifier<TValue, TValue> Instance =
            new OfValueType<TValue>(EnvironmentAttributeOperation.Override, (_, argument) => argument);
    }

    /// <summary><c>AttributeModifier.override</c>, which every type allows.</summary>
    public static AttributeModifier<TValue, TValue> Override<TValue>() => OverrideOf<TValue>.Instance;

    private static Simple<bool, bool> Boolean(EnvironmentAttributeOperation operation, Func<bool, bool, bool> apply) =>
        new(operation, apply, tag => tag.AsBool(), LerpFunctions.Constant<bool>());

    public static readonly AttributeModifier<bool, bool> And = Boolean(EnvironmentAttributeOperation.And, (subject, argument) => argument && subject);
    public static readonly AttributeModifier<bool, bool> Nand = Boolean(EnvironmentAttributeOperation.Nand, (subject, argument) => !argument || !subject);
    public static readonly AttributeModifier<bool, bool> Or = Boolean(EnvironmentAttributeOperation.Or, (subject, argument) => argument || subject);
    public static readonly AttributeModifier<bool, bool> Nor = Boolean(EnvironmentAttributeOperation.Nor, (subject, argument) => !argument && !subject);
    public static readonly AttributeModifier<bool, bool> Xor = Boolean(EnvironmentAttributeOperation.Xor, (subject, argument) => argument ^ subject);
    public static readonly AttributeModifier<bool, bool> Xnor = Boolean(EnvironmentAttributeOperation.Xnor, (subject, argument) => argument == subject);

    public static readonly AttributeModifier<float, FloatWithAlpha> FloatAlphaBlend = new Simple<float, FloatWithAlpha>(
        EnvironmentAttributeOperation.AlphaBlend, (subject, argument) => Mth.Lerp(argument.Alpha, subject, argument.Value), FloatWithAlpha.FromNbt,
        FloatWithAlpha.Lerp);

    private static Simple<float, float> Float(EnvironmentAttributeOperation operation, Func<float, float, float> apply) =>
        new(operation, apply, tag => tag.AsFloat(), LerpFunctions.Float);

    public static readonly AttributeModifier<float, float> FloatAdd = Float(EnvironmentAttributeOperation.Add, (subject, argument) => subject + argument);
    public static readonly AttributeModifier<float, float> FloatSubtract = Float(EnvironmentAttributeOperation.Subtract, (subject, argument) => subject - argument);
    public static readonly AttributeModifier<float, float> FloatMultiply = Float(EnvironmentAttributeOperation.Multiply, (subject, argument) => subject * argument);
    public static readonly AttributeModifier<float, float> FloatMinimum = Float(EnvironmentAttributeOperation.Minimum, Math.Min);
    public static readonly AttributeModifier<float, float> FloatMaximum = Float(EnvironmentAttributeOperation.Maximum, Math.Max);

    private static Vector3 ReadRgb(INbtTag tag) => ArgbVectors.FromRgb24(PackedColor.StringRgbFromNbt(tag));

    private static Vector4 ReadArgb(INbtTag tag) => ArgbVectors.FromArgb32(PackedColor.StringArgbFromNbt(tag));

    /// <summary><c>ColorModifier.ALPHA_BLEND_RGB</c>: an RGB colour blended with an ARGB argument.</summary>
    public static readonly AttributeModifier<Vector3, Vector4> AlphaBlendRgb = new Simple<Vector3, Vector4>(
        EnvironmentAttributeOperation.AlphaBlend, ArgbVectors.AlphaBlend, ReadArgb, LerpFunctions.ColorVec4);

    public static readonly AttributeModifier<Vector3, Vector3> AddRgb = new Simple<Vector3, Vector3>(
        EnvironmentAttributeOperation.Add, ArgbVectors.AddRgb, ReadRgb, LerpFunctions.ColorVec3);

    public static readonly AttributeModifier<Vector3, Vector3> SubtractRgb = new Simple<Vector3, Vector3>(
        EnvironmentAttributeOperation.Subtract, ArgbVectors.SubtractRgb, ReadRgb, LerpFunctions.ColorVec3);

    public static readonly AttributeModifier<Vector3, Vector3> MultiplyRgb = new Simple<Vector3, Vector3>(
        EnvironmentAttributeOperation.Multiply, ArgbVectors.Multiply, ReadRgb, LerpFunctions.ColorVec3);

    public static readonly AttributeModifier<Vector3, BlendToGray> BlendToGrayRgb = new Simple<Vector3, BlendToGray>(
        EnvironmentAttributeOperation.BlendToGray,
        (subject, argument) => ArgbVectors.SrgbLerp(argument.Factor, subject, ArgbVectors.ScaleRgb(ArgbVectors.Greyscale(subject), argument.Brightness)),
        BlendToGray.FromNbt, BlendToGray.Lerp);

    public static readonly AttributeModifier<Vector4, Vector4> AlphaBlendArgb = new Simple<Vector4, Vector4>(
        EnvironmentAttributeOperation.AlphaBlend, ArgbVectors.AlphaBlend, ReadArgb, LerpFunctions.ColorVec4);

    /// <summary><c>ColorModifier.ADD_ARGB</c>, whose argument is RGB: the alpha is left alone.</summary>
    public static readonly AttributeModifier<Vector4, Vector3> AddArgb = new Simple<Vector4, Vector3>(
        EnvironmentAttributeOperation.Add, ArgbVectors.AddRgb, ReadRgb, LerpFunctions.ColorVec3);

    public static readonly AttributeModifier<Vector4, Vector3> SubtractArgb = new Simple<Vector4, Vector3>(
        EnvironmentAttributeOperation.Subtract, ArgbVectors.SubtractRgb, ReadRgb, LerpFunctions.ColorVec3);

    public static readonly AttributeModifier<Vector4, Vector4> MultiplyArgb = new Simple<Vector4, Vector4>(
        EnvironmentAttributeOperation.Multiply, ArgbVectors.Multiply, ReadArgb, LerpFunctions.ColorVec4);

    public static readonly AttributeModifier<Vector4, BlendToGray> BlendToGrayArgb = new Simple<Vector4, BlendToGray>(
        EnvironmentAttributeOperation.BlendToGray,
        (subject, argument) => ArgbVectors.SrgbLerp(argument.Factor, subject, ArgbVectors.ScaleRgb(ArgbVectors.Greyscale(subject), argument.Brightness)),
        BlendToGray.FromNbt, BlendToGray.Lerp);

    /// <summary><c>ListModifier.append</c>.</summary>
    public static AttributeModifier<IReadOnlyList<T>, IReadOnlyList<T>> Append<T>() => AppendOf<T>.Instance;

    private static class AppendOf<T> {
        public static readonly AttributeModifier<IReadOnlyList<T>, IReadOnlyList<T>> Instance = new OfValueType<IReadOnlyList<T>>(
            EnvironmentAttributeOperation.Append,
            (subject, argument) => argument.Count == 0 ? subject : subject.Count == 0 ? argument : [..subject, ..argument]);
    }

    /// <summary>
    /// <c>MobSpawnSettingsModifier.overlay</c>, which merges two spawner tables category by category. The protocol layer
    /// keeps <c>MobSpawnSettings</c> as the tag it arrived as and spawns nothing, so the merge is not made: this answers the
    /// argument, which is the overlay's result whenever the argument defines every category and cost the subject does,
    /// as a biome's full table always does.
    /// </summary>
    public static readonly AttributeModifier<INbtTag, INbtTag> Overlay = new OfValueType<INbtTag>(
        EnvironmentAttributeOperation.Overlay, (_, argument) => argument);

    public static IReadOnlyDictionary<EnvironmentAttributeOperation, AttributeModifier<T>> Library<T>(params AttributeModifier<T>[] modifiers) {
        Dictionary<EnvironmentAttributeOperation, AttributeModifier<T>> library = new() {
            [EnvironmentAttributeOperation.Override] = Override<T>()
        };
        foreach (AttributeModifier<T> modifier in modifiers) {
            library.Add(modifier.Operation, modifier);
        }
        return library;
    }
}
