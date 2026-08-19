using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>The four commutative two argument nodes, vanilla's <c>TwoArgumentSimpleFunction.Type</c>.</summary>
public enum TwoArgumentType {
    Add,
    Mul,
    Min,
    Max
}

/// <summary>The per value maps, vanilla's <c>Mapped.Type</c>.</summary>
public enum MappedType {
    Abs,
    Square,
    Cube,
    HalfNegative,
    QuarterNegative,
    Invert,
    Squeeze
}

/// <summary>
/// What a marker asks the chunk to do with the function under it, vanilla's <c>Marker.Type</c>.
/// </summary>
/// <remarks>
/// A marker computes exactly what it wraps. It only means anything once a chunk's visitor has replaced
/// it with the matching cache or interpolator, which is what makes a tree that samples the same noise
/// from twenty places affordable.
/// </remarks>
public enum MarkerType {
    Interpolated,
    FlatCache,
    Cache2D,
    CacheOnce,
    CacheAllInCell,
    BlendDensity
}

/// <summary>
/// A node carrying a <see cref="MarkerType"/>, either the plain marker or whatever a chunk swapped in
/// for it. Vanilla's <c>MarkerOrMarked</c>.
/// </summary>
public interface IMarkerOrMarked : IDensityFunction {
    MarkerType Type { get; }

    IDensityFunction Wrapped { get; }

    IDensityFunction IDensityFunction.MapChildren(IDensityFunctionVisitor visitor) {
        return new DensityFunctions.Marker(Type, visitor.Apply(Wrapped));
    }
}

/// <summary>
/// Every node type of vanilla's density function tree, and the factories that build them.
/// </summary>
/// <remarks>
/// The factories are not conveniences: <see cref="TwoArgument"/> and
/// <see cref="DensityFunctions.Mapped.Create"/> compute the node's value range from its arguments' and
/// pick a specialised implementation, so constructing a node directly produces one with a wrong range.
/// Building the tree through them is what the JSON parser and the router both do.
/// </remarks>
public static class DensityFunctions {
    /// <summary>The range a JSON constant is allowed in, and the sentinel an unbounded range clamps to.</summary>
    public const double MaxReasonableNoiseValue = 1000000.0;

    public static IDensityFunction Zero { get; } = new Constant(0.0);

    public static IDensityFunction Of(double value) => new Constant(value);

    public static IDensityFunction Interpolated(IDensityFunction function) =>
        new Marker(MarkerType.Interpolated, function);

    public static IDensityFunction FlatCache(IDensityFunction function) =>
        new Marker(MarkerType.FlatCache, function);

    public static IDensityFunction Cache2D(IDensityFunction function) =>
        new Marker(MarkerType.Cache2D, function);

    public static IDensityFunction CacheOnce(IDensityFunction function) =>
        new Marker(MarkerType.CacheOnce, function);

    public static IDensityFunction CacheAllInCell(IDensityFunction function) =>
        new Marker(MarkerType.CacheAllInCell, function);

    public static IDensityFunction BlendDensity(IDensityFunction function) =>
        new Marker(MarkerType.BlendDensity, function);

    public static IDensityFunction Add(IDensityFunction a, IDensityFunction b) =>
        TwoArgument(TwoArgumentType.Add, a, b);

    public static IDensityFunction Mul(IDensityFunction a, IDensityFunction b) =>
        TwoArgument(TwoArgumentType.Mul, a, b);

    public static IDensityFunction Min(IDensityFunction a, IDensityFunction b) =>
        TwoArgument(TwoArgumentType.Min, a, b);

    public static IDensityFunction Max(IDensityFunction a, IDensityFunction b) =>
        TwoArgument(TwoArgumentType.Max, a, b);

    /// <summary>
    /// Builds a two argument node, working out its range and collapsing a constant argument into the
    /// cheaper <see cref="MulOrAdd"/> form.
    /// </summary>
    /// <remarks>
    /// The multiply range is not <c>min1 * min2</c> to <c>max1 * max2</c>: a range straddling zero
    /// makes the extremes come from the cross products, which is why the sign cases are spelled out.
    /// </remarks>
    public static IDensityFunction TwoArgument(TwoArgumentType type, IDensityFunction argument1,
        IDensityFunction argument2) {

        double min1 = argument1.MinValue;
        double min2 = argument2.MinValue;
        double max1 = argument1.MaxValue;
        double max2 = argument2.MaxValue;

        double minValue = type switch {
            TwoArgumentType.Add => min1 + min2,
            TwoArgumentType.Mul => min1 > 0.0 && min2 > 0.0
                ? min1 * min2
                : max1 < 0.0 && max2 < 0.0 ? max1 * max2 : Math.Min(min1 * max2, max1 * min2),
            TwoArgumentType.Min => Math.Min(min1, min2),
            TwoArgumentType.Max => Math.Max(min1, min2),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

        double maxValue = type switch {
            TwoArgumentType.Add => max1 + max2,
            TwoArgumentType.Mul => min1 > 0.0 && min2 > 0.0
                ? max1 * max2
                : max1 < 0.0 && max2 < 0.0 ? min1 * min2 : Math.Max(min1 * min2, max1 * max2),
            TwoArgumentType.Min => Math.Min(max1, max2),
            TwoArgumentType.Max => Math.Max(max1, max2),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

        if (type is TwoArgumentType.Mul or TwoArgumentType.Add) {
            if (argument1 is Constant c1) {
                return new MulOrAdd(type, argument2, minValue, maxValue, c1.Value);
            }

            if (argument2 is Constant c2) {
                return new MulOrAdd(type, argument1, minValue, maxValue, c2.Value);
            }
        }

        return new Ap2(type, argument1, argument2, minValue, maxValue);
    }

    /// <summary>Maps a unit range noise onto <paramref name="min"/>..<paramref name="max"/>.</summary>
    public static IDensityFunction MapFromUnitTo(IDensityFunction function, double min, double max) {
        double middle = (min + max) * 0.5;
        double factor = (max - min) * 0.5;
        return Add(Of(middle), Mul(Of(factor), function));
    }

    /// <summary>
    /// The two argument nodes in their general form: neither argument is a constant.
    /// </summary>
    /// <remarks>
    /// The short circuits are vanilla's and are not just speed. A <c>mul</c> whose first argument is
    /// zero never evaluates the second, and a <c>min</c> already below the second's floor never
    /// evaluates it either, which is what keeps the cave noise off the hot path over open sky.
    /// </remarks>
    internal sealed class Ap2(TwoArgumentType type, IDensityFunction argument1, IDensityFunction argument2,
        double minValue, double maxValue) : IDensityFunction {

        public TwoArgumentType Type => type;
        public IDensityFunction Argument1 => argument1;
        public IDensityFunction Argument2 => argument2;

        public double MinValue => minValue;
        public double MaxValue => maxValue;

        public double Compute(IFunctionContext context) {
            double v1 = argument1.Compute(context);
            return type switch {
                TwoArgumentType.Add => v1 + argument2.Compute(context),
                TwoArgumentType.Mul => v1 == 0.0 ? 0.0 : v1 * argument2.Compute(context),
                TwoArgumentType.Min => v1 < argument2.MinValue ? v1 : Math.Min(v1, argument2.Compute(context)),
                TwoArgumentType.Max => v1 > argument2.MaxValue ? v1 : Math.Max(v1, argument2.Compute(context)),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void FillArray(double[] output, IContextProvider provider) {
            argument1.FillArray(output, provider);

            switch (type) {
                case TwoArgumentType.Add: {
                    // The only case that fills the second argument in bulk too, since every element
                    // needs it. The others may skip elements, so they sample per position.
                    double[] second = new double[output.Length];
                    argument2.FillArray(second, provider);
                    for (int i = 0; i < output.Length; i++) {
                        output[i] += second[i];
                    }

                    break;
                }

                case TwoArgumentType.Mul: {
                    for (int i = 0; i < output.Length; i++) {
                        double v = output[i];
                        output[i] = v == 0.0 ? 0.0 : v * argument2.Compute(provider.ForIndex(i));
                    }

                    break;
                }

                case TwoArgumentType.Min: {
                    double min = argument2.MinValue;
                    for (int i = 0; i < output.Length; i++) {
                        double v = output[i];
                        output[i] = v < min ? v : Math.Min(v, argument2.Compute(provider.ForIndex(i)));
                    }

                    break;
                }

                case TwoArgumentType.Max: {
                    double max = argument2.MaxValue;
                    for (int i = 0; i < output.Length; i++) {
                        double v = output[i];
                        output[i] = v > max ? v : Math.Max(v, argument2.Compute(provider.ForIndex(i)));
                    }

                    break;
                }
            }
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return TwoArgument(type, visitor.Apply(argument1), visitor.Apply(argument2));
        }
    }

    /// <summary>
    /// An add or a multiply by a constant. Worth its own node because it drops a whole
    /// <see cref="Compute"/> dispatch per sample and the tree is full of them.
    /// </summary>
    internal sealed class MulOrAdd(TwoArgumentType type, IDensityFunction input, double minValue,
        double maxValue, double argument) : PureTransformer {

        public override IDensityFunction Input => input;

        public double Argument => argument;

        public override double MinValue => minValue;
        public override double MaxValue => maxValue;

        public override double Transform(double value) {
            return type == TwoArgumentType.Mul ? value * argument : value + argument;
        }

        public override IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            IDensityFunction mapped = visitor.Apply(input);
            double min = mapped.MinValue;
            double max = mapped.MaxValue;

            double newMin;
            double newMax;
            if (type == TwoArgumentType.Add) {
                newMin = min + argument;
                newMax = max + argument;
            } else if (argument >= 0.0) {
                newMin = min * argument;
                newMax = max * argument;
            } else {
                // A negative factor swaps the ends of the range.
                newMin = max * argument;
                newMax = min * argument;
            }

            return new MulOrAdd(type, mapped, newMin, newMax, argument);
        }
    }

    /// <summary>A fixed value. Recognised by name in <see cref="TwoArgument"/>, so it is not interchangeable.</summary>
    internal sealed class Constant(double value) : ISimpleDensityFunction {
        public double Value => value;

        public double Compute(IFunctionContext context) => value;

        public void FillArray(double[] output, IContextProvider provider) {
            Array.Fill(output, value);
        }

        public double MinValue => value;
        public double MaxValue => value;
    }

    /// <summary>
    /// <c>blend_alpha</c>. Terrain blending against an old world is not implemented, and vanilla's own
    /// value outside a blending region is one, so this is the whole of it.
    /// </summary>
    internal sealed class BlendAlpha : ISimpleDensityFunction {
        public static readonly BlendAlpha Instance = new();

        public double Compute(IFunctionContext context) => 1.0;

        public void FillArray(double[] output, IContextProvider provider) => Array.Fill(output, 1.0);

        public double MinValue => 1.0;
        public double MaxValue => 1.0;
    }

    /// <summary><c>blend_offset</c>, zero outside a blending region. See <see cref="BlendAlpha"/>.</summary>
    internal sealed class BlendOffset : ISimpleDensityFunction {
        public static readonly BlendOffset Instance = new();

        public double Compute(IFunctionContext context) => 0.0;

        public void FillArray(double[] output, IContextProvider provider) => Array.Fill(output, 0.0);

        public double MinValue => 0.0;
        public double MaxValue => 0.0;
    }

    /// <summary>
    /// <c>beardifier</c>: the term that flattens ground under a structure. Structures are not
    /// generated here, so it contributes nothing, which is also its value everywhere no structure is.
    /// </summary>
    internal sealed class Beardifier : ISimpleDensityFunction {
        public static readonly Beardifier Instance = new();

        public double Compute(IFunctionContext context) => 0.0;

        public void FillArray(double[] output, IContextProvider provider) => Array.Fill(output, 0.0);

        public double MinValue => 0.0;
        public double MaxValue => 0.0;
    }

    /// <summary>
    /// A request for caching or interpolation, which on its own is a pass through. See
    /// <see cref="MarkerType"/>.
    /// </summary>
    public sealed class Marker(MarkerType type, IDensityFunction wrapped) : IMarkerOrMarked {
        public MarkerType Type => type;
        public IDensityFunction Wrapped => wrapped;

        public double Compute(IFunctionContext context) => wrapped.Compute(context);

        public void FillArray(double[] output, IContextProvider provider) {
            wrapped.FillArray(output, provider);
        }

        /// <summary>
        /// Unbounded for <c>blend_density</c> alone: blending can move a value outside what the
        /// function under it can produce, so nothing above may assume the wrapped range.
        /// </summary>
        public double MinValue => type == MarkerType.BlendDensity
            ? double.NegativeInfinity
            : wrapped.MinValue;

        public double MaxValue => type == MarkerType.BlendDensity
            ? double.PositiveInfinity
            : wrapped.MaxValue;
    }

    /// <summary>A named noise sampled at a scaled position.</summary>
    internal sealed class Noise(NoiseHolder noise, double xzScale, double yScale) : IDensityFunction {
        public NoiseHolder Holder => noise;

        public double Compute(IFunctionContext context) {
            return noise.GetValue(context.BlockX * xzScale, context.BlockY * yScale, context.BlockZ * xzScale);
        }

        public void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new Noise(visitor.VisitNoise(noise), xzScale, yScale);
        }

        public double MinValue => -MaxValue;
        public double MaxValue => noise.MaxValue;
    }

    /// <summary>
    /// Noise sampled at a position three other functions have displaced, which is how the climate
    /// noises get their warped, non grid aligned shape.
    /// </summary>
    internal sealed class ShiftedNoise(IDensityFunction shiftX, IDensityFunction shiftY,
        IDensityFunction shiftZ, double xzScale, double yScale, NoiseHolder noise) : IDensityFunction {

        public double Compute(IFunctionContext context) {
            double x = context.BlockX * xzScale + shiftX.Compute(context);
            double y = context.BlockY * yScale + shiftY.Compute(context);
            double z = context.BlockZ * xzScale + shiftZ.Compute(context);
            return noise.GetValue(x, y, z);
        }

        public void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new ShiftedNoise(visitor.Apply(shiftX), visitor.Apply(shiftY), visitor.Apply(shiftZ),
                xzScale, yScale, visitor.VisitNoise(noise));
        }

        public double MinValue => -MaxValue;
        public double MaxValue => noise.MaxValue;
    }

    /// <summary>
    /// The three displacement nodes, vanilla's <c>ShiftNoise</c>. All sample at a quarter scale and
    /// multiply by four; they differ only in which coordinates they feed in and in what order.
    /// </summary>
    internal abstract class ShiftNoise(NoiseHolder offsetNoise) : IDensityFunction {
        protected NoiseHolder OffsetNoise => offsetNoise;

        protected double ComputeShift(double localX, double localY, double localZ) {
            return offsetNoise.GetValue(localX * 0.25, localY * 0.25, localZ * 0.25) * 4.0;
        }

        public abstract double Compute(IFunctionContext context);

        public void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }

        public abstract IDensityFunction MapChildren(IDensityFunctionVisitor visitor);

        public double MinValue => -MaxValue;
        public double MaxValue => offsetNoise.MaxValue * 4.0;
    }

    /// <summary><c>shift</c>: displaced by all three coordinates.</summary>
    internal sealed class Shift(NoiseHolder offsetNoise) : ShiftNoise(offsetNoise) {
        public override double Compute(IFunctionContext context) {
            return ComputeShift(context.BlockX, context.BlockY, context.BlockZ);
        }

        public override IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new Shift(visitor.VisitNoise(OffsetNoise));
        }
    }

    /// <summary><c>shift_a</c>: the horizontal plane, with y pinned to zero.</summary>
    internal sealed class ShiftA(NoiseHolder offsetNoise) : ShiftNoise(offsetNoise) {
        public override double Compute(IFunctionContext context) {
            return ComputeShift(context.BlockX, 0.0, context.BlockZ);
        }

        public override IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new ShiftA(visitor.VisitNoise(OffsetNoise));
        }
    }

    /// <summary>
    /// <c>shift_b</c>: the same plane read as <c>(z, x, 0)</c>. The rotation is what makes the x and z
    /// displacements independent while sharing one noise.
    /// </summary>
    internal sealed class ShiftB(NoiseHolder offsetNoise) : ShiftNoise(offsetNoise) {
        public override double Compute(IFunctionContext context) {
            return ComputeShift(context.BlockZ, context.BlockX, 0.0);
        }

        public override IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new ShiftB(visitor.VisitNoise(OffsetNoise));
        }
    }

    /// <summary>A node computing its value from its single input and nothing else.</summary>
    internal abstract class PureTransformer : IDensityFunction {
        public abstract IDensityFunction Input { get; }

        public abstract double Transform(double value);

        public double Compute(IFunctionContext context) => Transform(Input.Compute(context));

        public void FillArray(double[] output, IContextProvider provider) {
            Input.FillArray(output, provider);
            for (int i = 0; i < output.Length; i++) {
                output[i] = Transform(output[i]);
            }
        }

        public abstract IDensityFunction MapChildren(IDensityFunctionVisitor visitor);

        public abstract double MinValue { get; }
        public abstract double MaxValue { get; }
    }

    internal sealed class Clamp(IDensityFunction input, double min, double max) : PureTransformer {
        public override IDensityFunction Input => input;

        public override double Transform(double value) => Mth.Clamp(value, min, max);

        public override IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new Clamp(visitor.Apply(input), min, max);
        }

        public override double MinValue => min;
        public override double MaxValue => max;
    }

    /// <summary>One of the seven per value maps, with the range each one implies.</summary>
    internal sealed class Mapped : PureTransformer {
        private readonly MappedType _type;
        private readonly IDensityFunction _input;
        private readonly double _minValue;
        private readonly double _maxValue;

        private Mapped(MappedType type, IDensityFunction input, double minValue, double maxValue) {
            _type = type;
            _input = input;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        /// <summary>
        /// Works out the mapped range, which is not simply the map of the two ends. <c>invert</c> over
        /// a range straddling zero is unbounded, and <c>abs</c> and <c>square</c> have their minimum
        /// at zero rather than at either end.
        /// </summary>
        public static IDensityFunction Create(MappedType type, IDensityFunction input) {
            double minValue = input.MinValue;
            double maxValue = input.MaxValue;
            double minImage = Apply(type, minValue);
            double maxImage = Apply(type, maxValue);

            if (type == MappedType.Invert) {
                return minValue < 0.0 && maxValue > 0.0
                    ? new Mapped(type, input, double.NegativeInfinity, double.PositiveInfinity)
                    : new Mapped(type, input, maxImage, minImage);
            }

            if (type is MappedType.Abs or MappedType.Square) {
                return new Mapped(type, input, Math.Max(0.0, minValue), Math.Max(minImage, maxImage));
            }

            return new Mapped(type, input, minImage, maxImage);
        }

        private static double Apply(MappedType type, double value) {
            return type switch {
                MappedType.Abs => Math.Abs(value),
                MappedType.Square => value * value,
                MappedType.Cube => value * value * value,
                MappedType.HalfNegative => value > 0.0 ? value : value * 0.5,
                MappedType.QuarterNegative => value > 0.0 ? value : value * 0.25,
                MappedType.Invert => 1.0 / value,
                MappedType.Squeeze => Squeeze(value),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        /// <summary>A soft clamp: the first two terms of a sine, which flattens the extremes smoothly.</summary>
        private static double Squeeze(double value) {
            double c = Mth.Clamp(value, -1.0, 1.0);
            return c / 2.0 - c * c * c / 24.0;
        }

        public override IDensityFunction Input => _input;

        public override double Transform(double value) => Apply(_type, value);

        public override IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return Create(_type, visitor.Apply(_input));
        }

        public override double MinValue => _minValue;
        public override double MaxValue => _maxValue;
    }

    /// <summary>
    /// One function inside a range of the input and another outside it. The range is <b>half open</b>,
    /// min inclusive and max exclusive.
    /// </summary>
    internal sealed class RangeChoice(IDensityFunction input, double minInclusive, double maxExclusive,
        IDensityFunction whenInRange, IDensityFunction whenOutOfRange) : IDensityFunction {

        public double Compute(IFunctionContext context) {
            double value = input.Compute(context);
            return value >= minInclusive && value < maxExclusive
                ? whenInRange.Compute(context)
                : whenOutOfRange.Compute(context);
        }

        public void FillArray(double[] output, IContextProvider provider) {
            input.FillArray(output, provider);
            for (int i = 0; i < output.Length; i++) {
                double v = output[i];
                output[i] = v >= minInclusive && v < maxExclusive
                    ? whenInRange.Compute(provider.ForIndex(i))
                    : whenOutOfRange.Compute(provider.ForIndex(i));
            }
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new RangeChoice(visitor.Apply(input), minInclusive, maxExclusive,
                visitor.Apply(whenInRange), visitor.Apply(whenOutOfRange));
        }

        public double MinValue => Math.Min(whenInRange.MinValue, whenOutOfRange.MinValue);
        public double MaxValue => Math.Max(whenInRange.MaxValue, whenOutOfRange.MaxValue);
    }

    /// <summary>
    /// Picks from a list of functions by where the input falls among the thresholds. There is always
    /// one more function than threshold: the last one covers everything above the last threshold.
    /// </summary>
    internal sealed class IntervalSelect : IDensityFunction {
        private readonly IDensityFunction _input;
        private readonly double[] _thresholds;
        private readonly IDensityFunction[] _functions;

        public IntervalSelect(IDensityFunction input, IReadOnlyList<double> thresholds,
            IReadOnlyList<IDensityFunction> functions) {

            if (thresholds.Count != functions.Count - 1) {
                throw new ArgumentException(
                    $"Expected {functions.Count - 1} thresholds for {functions.Count} functions, " +
                    $"got {thresholds.Count}.", nameof(thresholds));
            }

            for (int i = 1; i < thresholds.Count; i++) {
                if (thresholds[i] < thresholds[i - 1]) {
                    throw new ArgumentException("Threshold values must be ordered from smallest to largest",
                        nameof(thresholds));
                }
            }

            _input = input;
            _thresholds = thresholds.ToArray();
            _functions = functions.ToArray();
        }

        private double Select(IFunctionContext context, double value) {
            for (int i = 0; i < _thresholds.Length; i++) {
                if (value < _thresholds[i]) {
                    return _functions[i].Compute(context);
                }
            }

            return _functions[^1].Compute(context);
        }

        public double Compute(IFunctionContext context) => Select(context, _input.Compute(context));

        public void FillArray(double[] output, IContextProvider provider) {
            _input.FillArray(output, provider);
            for (int i = 0; i < output.Length; i++) {
                output[i] = Select(provider.ForIndex(i), output[i]);
            }
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            IDensityFunction[] mapped = new IDensityFunction[_functions.Length];
            for (int i = 0; i < mapped.Length; i++) {
                mapped[i] = visitor.Apply(_functions[i]);
            }

            return new IntervalSelect(visitor.Apply(_input), _thresholds, mapped);
        }

        public double MinValue {
            get {
                double min = double.MaxValue;
                foreach (IDensityFunction function in _functions) {
                    min = Math.Min(function.MinValue, min);
                }

                return min;
            }
        }

        public double MaxValue {
            get {
                double max = -double.MaxValue;
                foreach (IDensityFunction function in _functions) {
                    max = Math.Max(function.MaxValue, max);
                }

                return max;
            }
        }
    }

    /// <summary>A linear ramp in y between two heights, flat outside them.</summary>
    internal sealed class YClampedGradient(int fromY, int toY, double fromValue, double toValue)
        : ISimpleDensityFunction {

        public double Compute(IFunctionContext context) {
            return Mth.ClampedMap(context.BlockY, fromY, toY, fromValue, toValue);
        }

        public double MinValue => Math.Min(fromValue, toValue);
        public double MaxValue => Math.Max(fromValue, toValue);
    }

    /// <summary>
    /// The coordinate of a <see cref="SplineFunction"/>: another density function read as a float.
    /// </summary>
    public sealed record SplineCoordinate(IDensityFunction Function) : IBoundedFloatFunction<IFunctionContext> {
        public float Apply(IFunctionContext point) => (float)Function.Compute(point);

        public float MinValue => (float)Function.MinValue;

        public float MaxValue => (float)Function.MaxValue;

        public SplineCoordinate MapChildren(IDensityFunctionVisitor visitor) {
            return new SplineCoordinate(visitor.Apply(Function));
        }
    }

    /// <summary>
    /// A <see cref="CubicSpline{TCoordinate,TPoint}"/> read as a density function. This is where the
    /// overworld's continent, erosion and ridge curves live.
    /// </summary>
    internal sealed class SplineFunction(CubicSpline<SplineCoordinate, IFunctionContext> spline)
        : IDensityFunction {

        public double Compute(IFunctionContext context) => spline.Sample(context);

        public void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new SplineFunction(spline.MapCoordinates(c => c.MapChildren(visitor)));
        }

        public double MinValue => spline.MinValue;
        public double MaxValue => spline.MaxValue;
    }

    /// <summary>
    /// <c>end_islands</c>: the end's floating island field, sampled from simplex noise on an eight
    /// block grid.
    /// </summary>
    /// <remarks>
    /// Seeded from a fixed sequence rather than the world seed, so every world's end looks the same,
    /// which is vanilla. The 17292 burnt draws are what put the generator where the original code
    /// left it.
    /// </remarks>
    internal sealed class EndIslands : ISimpleDensityFunction {
        private readonly SimplexNoise _islandNoise;

        public EndIslands(long seed) {
            RandomSource random = new LegacyRandomSource(seed);
            random.ConsumeCount(17292);
            _islandNoise = new SimplexNoise(random);
        }

        public double Compute(IFunctionContext context) {
            return (HeightValue(_islandNoise, context.BlockX / 8, context.BlockZ / 8) - 8.0) / 128.0;
        }

        private static float HeightValue(SimplexNoise islandNoise, int sectionX, int sectionZ) {
            int chunkX = sectionX / 2;
            int chunkZ = sectionZ / 2;
            int subSectionX = sectionX % 2;
            int subSectionZ = sectionZ % 2;

            float distance = 100.0f - Mth.Sqrt(sectionX * sectionX + sectionZ * sectionZ) * 8.0f;
            distance = Mth.Clamp(distance, -100.0f, 80.0f);

            for (int xo = -12; xo <= 12; xo++) {
                for (int zo = -12; zo <= 12; zo++) {
                    long totalChunkX = chunkX + xo;
                    long totalChunkZ = chunkZ + zo;

                    // Inside 4096 square chunks is the main island, which is flat and not sampled.
                    if (totalChunkX * totalChunkX + totalChunkZ * totalChunkZ <= 4096L
                        || islandNoise.GetValue(totalChunkX, totalChunkZ) >= -0.9f) {
                        continue;
                    }

                    float islandSize = (Math.Abs((float)totalChunkX) * 3439.0f
                        + Math.Abs((float)totalChunkZ) * 147.0f) % 13.0f + 9.0f;
                    float xd = subSectionX - xo * 2;
                    float zd = subSectionZ - zo * 2;

                    float local = Mth.Clamp(100.0f - Mth.Sqrt(xd * xd + zd * zd) * islandSize, -100.0f, 80.0f);
                    distance = Math.Max(distance, local);
                }
            }

            return distance;
        }

        public double MinValue => -0.84375;
        public double MaxValue => 0.5625;
    }

    /// <summary>
    /// Walks down a column in cell sized steps and reports the first height whose density is solid,
    /// vanilla's <c>find_top_surface</c>.
    /// </summary>
    /// <remarks>
    /// The starting height is floored to a whole cell, so the answer is a cell boundary rather than a
    /// block. Sampling per block would make it exact and much more expensive, and everything reading
    /// it treats it as an estimate.
    /// </remarks>
    internal sealed class FindTopSurface(IDensityFunction density, IDensityFunction upperBound,
        int lowerBound, int cellHeight) : IDensityFunction {

        public double Compute(IFunctionContext context) {
            int topY = Mth.Floor(upperBound.Compute(context) / cellHeight) * cellHeight;
            if (topY <= lowerBound) {
                return lowerBound;
            }

            for (int blockY = topY; blockY >= lowerBound; blockY -= cellHeight) {
                if (density.Compute(new SinglePointContext(context.BlockX, blockY, context.BlockZ)) > 0.0) {
                    return blockY;
                }
            }

            return lowerBound;
        }

        public void FillArray(double[] output, IContextProvider provider) {
            provider.FillAllDirectly(output, this);
        }

        public IDensityFunction MapChildren(IDensityFunctionVisitor visitor) {
            return new FindTopSurface(visitor.Apply(density), visitor.Apply(upperBound), lowerBound, cellHeight);
        }

        public double MinValue => lowerBound;
        public double MaxValue => Math.Max(lowerBound, upperBound.MaxValue);
    }
}
