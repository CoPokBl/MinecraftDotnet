using System.Numerics;
using Minecraft.Schemas;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary><c>LerpFunction</c>: a value part way from one to another.</summary>
public delegate T LerpFunction<T>(float alpha, T from, T to);

public static class LerpFunctions {
    public static readonly LerpFunction<float> Float = Mth.Lerp;

    public static readonly LerpFunction<Vector3> ColorVec3 = ArgbVectors.SrgbLerp;

    public static readonly LerpFunction<Vector4> ColorVec4 = ArgbVectors.SrgbLerp;

    /// <summary><c>LerpFunction.ofDegrees</c>: the short way round, or straight to the target past <paramref name="maxDelta"/>.</summary>
    public static LerpFunction<float> Degrees(float maxDelta) => (alpha, from, to) => {
        float delta = Mth.WrapDegrees(to - from);
        return Math.Abs(delta) >= maxDelta ? to : from + alpha * delta;
    };

    public static LerpFunction<T> Step<T>(float threshold) => (alpha, from, to) => alpha >= threshold ? to : from;

    /// <summary><c>LerpFunction.ofConstant</c>, which is a step at one.</summary>
    public static LerpFunction<T> Constant<T>() => Step<T>(1.0F);

    /// <summary><c>LerpFunction.ofListCrossFade</c>: both lists at once, each element scaled by its side's share.</summary>
    public static LerpFunction<IReadOnlyList<T>> ListCrossFade<T>(Func<T, float, T> scaler) => (alpha, from, to) => {
        if (alpha == 0.0F) {
            return from;
        }
        if (alpha == 1.0F) {
            return to;
        }
        List<T> result = new(from.Count + to.Count);
        foreach (T element in from) {
            result.Add(scaler(element, 1.0F - alpha));
        }
        foreach (T element in to) {
            result.Add(scaler(element, alpha));
        }
        return result;
    };
}

/// <summary><c>AttributeRange</c>: what a computed value is clamped into.</summary>
public abstract class AttributeRange<T> {
    public static readonly AttributeRange<T> Any = new AnyRange();

    public abstract T Sanitize(T value);

    private sealed class AnyRange : AttributeRange<T> {
        public override T Sanitize(T value) => value;
    }
}

public static class AttributeRange {
    public static AttributeRange<float> OfFloat(float min, float max) => new FloatRange(min, max);

    private sealed class FloatRange(float min, float max) : AttributeRange<float> {
        public override float Sanitize(float value) => value >= min && value <= max ? value : value < min ? min : Math.Min(value, max);
    }
}
