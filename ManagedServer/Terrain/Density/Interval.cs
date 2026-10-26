namespace ManagedServer.Terrain.Density;

/// <summary>
/// A closed float range a density function's values are guaranteed to fall in, vanilla's
/// <c>Interval</c>.
/// </summary>
/// <remarks>
/// Not a diagnostic: <c>min</c> and <c>max</c> compile to one side when their inputs' ranges do not
/// overlap, and a short circuit compares against the other side's bound, so a range that is too narrow
/// changes values. <see cref="NaI"/> is a distinct instance and is compared by reference, as upstream.
/// </remarks>
public sealed class Interval : IEquatable<Interval> {
    public static readonly Interval NaI = new(float.NaN, float.NaN);
    public static readonly Interval Infinite = new(float.NegativeInfinity, float.PositiveInfinity);
    private static readonly Interval NegativeOneToOne = new(-1.0F, 1.0F);
    private static readonly Interval ZeroToOne = new(0.0F, 1.0F);

    private Interval(float min, float max) {
        Min = min;
        Max = max;
    }

    public float Min { get; }

    public float Max { get; }

    public bool IsNaI => ReferenceEquals(this, NaI);

    public static Interval Of(float min, float max) {
        if (max < min) {
            throw new ArgumentException($"max ({max}) < min ({min})");
        }

        if (float.IsNaN(min) || float.IsNaN(max)) {
            throw new ArgumentException($"Bounds cannot include NaN [{min}; {max}]: use Interval.NaI explicitly");
        }

        if (min == float.NegativeInfinity && max == float.PositiveInfinity) {
            return Infinite;
        }

        if (max == 1.0F) {
            if (min == 0.0F) {
                return ZeroToOne;
            }

            if (min == -1.0F) {
                return NegativeOneToOne;
            }
        }

        return new Interval(min, max);
    }

    public static Interval OfSymmetric(float range) => Of(-range, range);

    public static Interval OfExact(float value) => Of(value, value);

    public static Interval Encapsulating(IEnumerable<Interval> intervals) {
        float min = float.PositiveInfinity;
        float max = float.NegativeInfinity;
        bool any = false;

        foreach (Interval interval in intervals) {
            any = true;
            if (!interval.IsNaI) {
                min = Math.Min(interval.Min, min);
                max = Math.Max(interval.Max, max);
            }
        }

        if (!any) {
            throw new ArgumentException("At least one interval required");
        }

        return max < min ? NaI : Of(min, max);
    }

    public static Interval Encapsulating(params Interval[] intervals) => Encapsulating((IEnumerable<Interval>)intervals);

    public static Interval Encapsulating(float first, float second) {
        if (float.IsNaN(first) && float.IsNaN(second)) {
            return NaI;
        }

        if (float.IsNaN(first)) {
            return OfExact(second);
        }

        return float.IsNaN(second) ? OfExact(first) : Of(Math.Min(first, second), Math.Max(first, second));
    }

    private static Interval Encapsulating(Interval first, float second) {
        if (float.IsNaN(second)) {
            return first;
        }

        return first.IsNaI ? OfExact(second) : Of(Math.Min(first.Min, second), Math.Max(first.Max, second));
    }

    public static Interval Add(Interval left, Interval right) {
        float min = left.Min + right.Min;
        float max = left.Max + right.Max;
        return !float.IsNaN(min) && !float.IsNaN(max) ? Of(min, max) : NaI;
    }

    public static Interval Sub(Interval left, Interval right) {
        float min = left.Min - right.Max;
        float max = left.Max - right.Min;
        return !float.IsNaN(min) && !float.IsNaN(max) ? Of(min, max) : NaI;
    }

    public static Interval Mul(Interval left, Interval right) {
        if (left.IsNaI || right.IsNaI) {
            return NaI;
        }

        float minMin = MulBound(left.Min, right.Min);
        float minMax = MulBound(left.Min, right.Max);
        float maxMin = MulBound(left.Max, right.Min);
        float maxMax = MulBound(left.Max, right.Max);
        return Of(Math.Min(Math.Min(minMin, minMax), Math.Min(maxMin, maxMax)),
            Math.Max(Math.Max(minMin, minMax), Math.Max(maxMin, maxMax)));
    }

    /// <summary>Zero times an infinite bound is zero rather than NaN.</summary>
    private static float MulBound(float left, float right) {
        return left != 0.0F && right != 0.0F ? left * right : 0.0F;
    }

    public static Interval Reciprocal(Interval input) {
        if (input.IsNaI || (input.Min == 0.0F && input.Max == 0.0F)) {
            return NaI;
        }

        if (!input.Contains(0.0F)) {
            return Of(1.0F / input.Max, 1.0F / input.Min);
        }

        if (input.Max == 0.0F) {
            return Of(float.NegativeInfinity, 1.0F / input.Min);
        }

        return input.Min == 0.0F ? Of(1.0F / input.Max, float.PositiveInfinity) : Infinite;
    }

    public static Interval Div(Interval left, Interval right) => Mul(left, Reciprocal(right));

    public static Interval MinOf(Interval left, Interval right) {
        return !left.IsNaI && !right.IsNaI ? Of(Math.Min(left.Min, right.Min), Math.Min(left.Max, right.Max)) : NaI;
    }

    public static Interval MaxOf(Interval left, Interval right) {
        return !left.IsNaI && !right.IsNaI ? Of(Math.Max(left.Min, right.Min), Math.Max(left.Max, right.Max)) : NaI;
    }

    public static Interval Clamp(Interval input, float min, float max) {
        if (min > max) {
            throw new ArgumentException($"min ({min}) > max ({max})");
        }

        if (input.IsNaI) {
            return NaI;
        }

        if (input.Min >= max) {
            return Of(max, max);
        }

        return input.Max <= min ? Of(min, min) : Of(Math.Max(input.Min, min), Math.Min(input.Max, max));
    }

    public static Interval Abs(Interval input) {
        if (input.IsNaI) {
            return NaI;
        }

        float max = Math.Max(Math.Abs(input.Min), Math.Abs(input.Max));
        return input.Contains(0.0F) ? Of(0.0F, max) : Of(Math.Min(Math.Abs(input.Min), Math.Abs(input.Max)), max);
    }

    public static Interval Square(Interval input) {
        if (input.IsNaI) {
            return NaI;
        }

        float max = Math.Max(input.Min * input.Min, input.Max * input.Max);
        return input.Contains(0.0F) ? Of(0.0F, max) : Of(Math.Min(input.Min * input.Min, input.Max * input.Max), max);
    }

    public static Interval Pow(Interval baseRange, Interval exponent) {
        if (baseRange.IsNaI || exponent.IsNaI) {
            return NaI;
        }

        if (baseRange.Min == baseRange.Max) {
            return Pow(baseRange.Min, exponent);
        }

        Interval result = Encapsulating(Pow(baseRange.Min, exponent), Pow(baseRange.Max, exponent));
        if (baseRange.Contains(0.0F)) {
            if (baseRange.Max > 0.0F) {
                result = Encapsulating(result, Pow(0.0F, exponent));
            }

            if (baseRange.Min < 0.0F) {
                result = Encapsulating(result, Pow(-0.0F, exponent));
            }
        }

        return result;
    }

    private static Interval Pow(float baseValue, Interval exponent) {
        if (float.IsNaN(baseValue) || exponent.IsNaI) {
            return NaI;
        }

        if (exponent.Min == exponent.Max) {
            float value = (float)Math.Pow(baseValue, exponent.Min);
            return float.IsNaN(value) ? NaI : OfExact(value);
        }

        if (baseValue == 0.0F) {
            return Mul(PowZeroBase(exponent), OfExact(MathF.CopySign(1.0F, baseValue)));
        }

        if (baseValue == 1.0F) {
            return OfExact(1.0F);
        }

        return baseValue > 0.0F ? PowPositiveBase(baseValue, exponent) : PowNegativeBase(baseValue, exponent);
    }

    private static Interval PowPositiveBase(float baseValue, Interval exponent) {
        return float.IsFinite(exponent.Min) && float.IsFinite(exponent.Max)
            ? Encapsulating((float)Math.Pow(baseValue, exponent.Min), (float)Math.Pow(baseValue, exponent.Max))
            : PowInfiniteExponent(baseValue, exponent);
    }

    private static Interval PowZeroBase(Interval exponent) {
        if (exponent.Contains(0.0F)) {
            if (exponent.Max == 0.0F) {
                return Of(1.0F, float.PositiveInfinity);
            }

            return exponent.Min == 0.0F ? ZeroToOne : Of(0.0F, float.PositiveInfinity);
        }

        return exponent.Max < 0.0F ? OfExact(float.PositiveInfinity) : OfExact(0.0F);
    }

    private static Interval PowInfiniteExponent(float baseValue, Interval exponent) {
        if (float.IsInfinity(exponent.Min) && float.IsInfinity(exponent.Max)) {
            return Of(0.0F, float.PositiveInfinity);
        }

        if (float.IsInfinity(exponent.Min)) {
            return baseValue < 1.0F
                ? Of((float)Math.Pow(baseValue, exponent.Max), float.PositiveInfinity)
                : Of(0.0F, (float)Math.Pow(baseValue, exponent.Max));
        }

        return baseValue < 1.0F
            ? Of(0.0F, (float)Math.Pow(baseValue, exponent.Min))
            : Of((float)Math.Pow(baseValue, exponent.Min), float.PositiveInfinity);
    }

    private static Interval PowNegativeBase(float baseValue, Interval exponent) {
        float exponentMinInt = (float)Math.Ceiling(exponent.Min);
        float exponentMaxInt = (float)Math.Floor(exponent.Max);
        if (exponentMaxInt < exponentMinInt) {
            return NaI;
        }

        float baseToMinInt = (float)Math.Pow(baseValue, exponentMinInt);
        float baseToMaxInt = (float)Math.Pow(baseValue, exponentMaxInt);
        Interval result = Encapsulating(baseToMinInt, baseToMaxInt);
        if (float.IsInfinity(exponentMinInt)) {
            result = Encapsulating(result, -baseToMinInt);
        } else if (exponentMinInt + 1.0F < exponentMaxInt) {
            result = Encapsulating(result, (float)Math.Pow(baseValue, exponentMinInt + 1.0F));
        }

        if (float.IsInfinity(exponentMaxInt)) {
            result = Encapsulating(result, -baseToMaxInt);
        } else if (exponentMaxInt - 1.0F > exponentMinInt) {
            result = Encapsulating(result, (float)Math.Pow(baseValue, exponentMaxInt - 1.0F));
        }

        return result;
    }

    public static Interval Log(Interval input) {
        if (input.Max < 0.0F) {
            return NaI;
        }

        Interval clippedInput = MaxOf(input, OfExact(0.0F));
        return MapMonotonic(clippedInput, x => (float)Math.Log(x));
    }

    public static Interval MapMonotonic(Interval input, Func<float, float> monotonicOp) {
        if (input.IsNaI) {
            return NaI;
        }

        float mappedMin = monotonicOp(input.Min);
        float mappedMax = monotonicOp(input.Max);
        if (float.IsNaN(mappedMin) || float.IsNaN(mappedMax)) {
            throw new InvalidOperationException("Monotonic operator should not produce NaN");
        }

        return Of(Math.Min(mappedMin, mappedMax), Math.Max(mappedMin, mappedMax));
    }

    public static Interval Lerp(Interval alpha, Interval first, Interval second) {
        return !alpha.IsNaI && !first.IsNaI && !second.IsNaI
            ? Encapsulating(
                Lerp(alpha, first.Min, second.Min), Lerp(alpha, first.Max, second.Min),
                Lerp(alpha, first.Min, second.Max), Lerp(alpha, first.Max, second.Max))
            : NaI;
    }

    public static Interval Lerp(Interval alpha, float first, float second) {
        if (alpha.IsNaI || float.IsNaN(first) || float.IsNaN(second)) {
            return NaI;
        }

        return float.IsFinite(first) && float.IsFinite(second)
            ? Encapsulating(LerpFiniteBound(alpha.Min, first, second), LerpFiniteBound(alpha.Max, first, second))
            : LerpInfiniteBounds(alpha, first, second);
    }

    private static float LerpFiniteBound(float alpha, float first, float second) {
        return first + MulBound(alpha, second - first);
    }

    private static Interval LerpInfiniteBounds(Interval alpha, float first, float second) {
        if (first == second) {
            return OfExact(first);
        }

        float newMin = LerpInfiniteBound(alpha.Min, first, second);
        float newMax = LerpInfiniteBound(alpha.Max, first, second);
        return !float.IsNaN(newMin) && !float.IsNaN(newMax) ? Encapsulating(newMin, newMax) : NaI;
    }

    private static float LerpInfiniteBound(float alpha, float first, float second) {
        float firstPart = MulBound(1.0F - alpha, first);
        float secondPart = MulBound(alpha, second);
        if (!float.IsInfinity(firstPart) || !float.IsInfinity(secondPart)) {
            return firstPart + secondPart;
        }

        if (alpha <= 0.0F) {
            return second > first ? float.NegativeInfinity : float.PositiveInfinity;
        }

        if (alpha >= 1.0F) {
            return second > first ? float.PositiveInfinity : float.NegativeInfinity;
        }

        return float.NaN;
    }

    public static Interval Sign(Interval input) {
        if (input.IsNaI) {
            return NaI;
        }

        if (input.Min == input.Max) {
            return OfExact(JavaMath.Signum(input.Min));
        }

        if (input.Contains(0.0F)) {
            if (input.Min == 0.0F) {
                return Of(0.0F, 1.0F);
            }

            return input.Max == 0.0F ? Of(-1.0F, 0.0F) : Of(-1.0F, 1.0F);
        }

        return OfExact(input.Min > 0.0F ? 1.0F : -1.0F);
    }

    public bool Contains(float value) => value >= Min && value <= Max;

    public bool Intersects(Interval other) => Min <= other.Max && Max >= other.Min;

    public bool Equals(Interval? other) {
        return ReferenceEquals(other, this) || (other is not null && Min == other.Min && Max == other.Max);
    }

    public override bool Equals(object? obj) => Equals(obj as Interval);

    public override int GetHashCode() => HashCode.Combine(Min, Max);

    public override string ToString() => IsNaI ? "[NaN]" : $"[{Min}; {Max}]";
}

/// <summary>The few <c>java.lang.Math</c> float operations whose .NET counterparts differ.</summary>
public static class JavaMath {
    /// <summary><c>Math.signum(float)</c>: NaN and both zeros come back as themselves, where <see cref="MathF.Sign"/> throws on NaN.</summary>
    public static float Signum(float value) {
        return value > 0.0F ? 1.0F : value < 0.0F ? -1.0F : value;
    }
}
