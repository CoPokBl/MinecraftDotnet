using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// A float valued function of some input, along with the range it can produce. Vanilla's
/// <c>BoundedFloatFunction</c>.
/// </summary>
public interface IBoundedFloatFunction<in TPoint> {
    float Apply(TPoint point);

    Interval Range { get; }
}

/// <summary>
/// Vanilla's <c>CubicSpline</c>: a piecewise cubic Hermite curve whose knot values are themselves
/// splines, so the whole thing nests.
/// </summary>
/// <remarks>
/// Beyond the first and last knot the curve is extended linearly along the end derivative rather than
/// clamped. Equality is structural, because a spline is part of a density function's identity.
/// </remarks>
public abstract class CubicSpline<TCoordinate> where TCoordinate : notnull {
    public abstract Interval RangeOf(Func<TCoordinate, Interval> coordinateRange);

    public abstract void ForEachCoordinate(Action<TCoordinate> consumer);

    public abstract CubicSpline<TResult> MapCoordinates<TResult>(Func<TCoordinate, TResult> mapper) where TResult : notnull;

    /// <summary>Evaluates with each coordinate turned into a value by <paramref name="coordinateValue"/>.</summary>
    public abstract float Apply(Func<TCoordinate, float> coordinateValue);

    public static CubicSpline<TCoordinate> Constant(float value) => new ConstantSpline(value);

    public static CubicSpline<TCoordinate> Multipoint(TCoordinate coordinate, float[] locations,
        IReadOnlyList<CubicSpline<TCoordinate>> values, float[] derivatives) {
        return new MultipointSpline(coordinate, locations, values.ToArray(), derivatives);
    }

    private sealed class ConstantSpline(float value) : CubicSpline<TCoordinate> {
        public override Interval RangeOf(Func<TCoordinate, Interval> coordinateRange) => Interval.OfExact(value);

        public override void ForEachCoordinate(Action<TCoordinate> consumer) { }

        public override CubicSpline<TResult> MapCoordinates<TResult>(Func<TCoordinate, TResult> mapper) {
            return CubicSpline<TResult>.Constant(value);
        }

        public override float Apply(Func<TCoordinate, float> coordinateValue) => value;

        public override bool Equals(object? obj) => obj is ConstantSpline other && other.Value.Equals(value);

        public override int GetHashCode() => value.GetHashCode();

        private float Value => value;
    }

    private sealed class MultipointSpline : CubicSpline<TCoordinate> {
        private readonly TCoordinate _coordinate;
        private readonly float[] _locations;
        private readonly CubicSpline<TCoordinate>[] _values;
        private readonly float[] _derivatives;

        public MultipointSpline(TCoordinate coordinate, float[] locations, CubicSpline<TCoordinate>[] values, float[] derivatives) {
            if (locations.Length != values.Length || locations.Length != derivatives.Length) {
                throw new ArgumentException("All lengths must be equal");
            }

            if (locations.Length == 0) {
                throw new ArgumentException("Cannot create a multipoint spline with no points");
            }

            _coordinate = coordinate;
            _locations = locations;
            _values = values;
            _derivatives = derivatives;
        }

        /// <summary>
        /// The range over the coordinate's own range without sampling: the linear extensions past each
        /// end, the knot values themselves, and a bound on the cubic overshoot between each pair.
        /// </summary>
        public override Interval RangeOf(Func<TCoordinate, Interval> coordinateRange) {
            int lastIndex = _locations.Length - 1;
            float minValue = float.PositiveInfinity;
            float maxValue = float.NegativeInfinity;
            Interval inputRange = coordinateRange(_coordinate);
            if (inputRange.IsNaI) {
                return inputRange;
            }

            if (inputRange.Min < _locations[0]) {
                Interval firstRange = _values[0].RangeOf(coordinateRange);
                float edge1 = LinearExtend(inputRange.Min, _locations, firstRange.Min, _derivatives, 0);
                float edge2 = LinearExtend(inputRange.Min, _locations, firstRange.Max, _derivatives, 0);
                minValue = Math.Min(minValue, Math.Min(edge1, edge2));
                maxValue = Math.Max(maxValue, Math.Max(edge1, edge2));
            }

            if (inputRange.Max > _locations[lastIndex]) {
                Interval lastRange = _values[lastIndex].RangeOf(coordinateRange);
                float edge1 = LinearExtend(inputRange.Max, _locations, lastRange.Min, _derivatives, lastIndex);
                float edge2 = LinearExtend(inputRange.Max, _locations, lastRange.Max, _derivatives, lastIndex);
                minValue = Math.Min(minValue, Math.Min(edge1, edge2));
                maxValue = Math.Max(maxValue, Math.Max(edge1, edge2));
            }

            Interval[] valueRanges = _values.Select(value => value.RangeOf(coordinateRange)).ToArray();
            foreach (Interval range in valueRanges) {
                minValue = Math.Min(minValue, range.Min);
                maxValue = Math.Max(maxValue, range.Max);
            }

            for (int i = 0; i < lastIndex; i++) {
                float xDiff = _locations[i + 1] - _locations[i];
                float min1 = valueRanges[i].Min;
                float max1 = valueRanges[i].Max;
                float min2 = valueRanges[i + 1].Min;
                float max2 = valueRanges[i + 1].Max;
                float d1 = _derivatives[i];
                float d2 = _derivatives[i + 1];
                if (d1 != 0.0F || d2 != 0.0F) {
                    float p1 = d1 * xDiff;
                    float p2 = d2 * xDiff;
                    float minLerp1 = Math.Min(min1, min2);
                    float maxLerp1 = Math.Max(max1, max2);
                    float minA = p1 - max2 + min1;
                    float maxA = p1 - min2 + max1;
                    float minB = -p2 + min2 - max1;
                    float maxB = -p2 + max2 - min1;
                    float minLerp2 = Math.Min(minA, minB);
                    float maxLerp2 = Math.Max(maxA, maxB);
                    minValue = Math.Min(minValue, minLerp1 + 0.25F * minLerp2);
                    maxValue = Math.Max(maxValue, maxLerp1 + 0.25F * maxLerp2);
                }
            }

            return Interval.Of(minValue, maxValue);
        }

        public override void ForEachCoordinate(Action<TCoordinate> consumer) {
            consumer(_coordinate);
            foreach (CubicSpline<TCoordinate> value in _values) {
                value.ForEachCoordinate(consumer);
            }
        }

        public override CubicSpline<TResult> MapCoordinates<TResult>(Func<TCoordinate, TResult> mapper) {
            return CubicSpline<TResult>.Multipoint(mapper(_coordinate), _locations,
                _values.Select(value => value.MapCoordinates(mapper)).ToArray(), _derivatives);
        }

        public override float Apply(Func<TCoordinate, float> coordinateValue) {
            float input = coordinateValue(_coordinate);
            int start = FindIntervalStart(_locations, input);
            int lastIndex = _locations.Length - 1;
            if (start < 0) {
                return LinearExtend(input, _locations, _values[0].Apply(coordinateValue), _derivatives, 0);
            }

            if (start == lastIndex) {
                return LinearExtend(input, _locations, _values[lastIndex].Apply(coordinateValue), _derivatives, lastIndex);
            }

            float x1 = _locations[start];
            float x2 = _locations[start + 1];
            float t = (input - x1) / (x2 - x1);
            float y1 = _values[start].Apply(coordinateValue);
            float y2 = _values[start + 1].Apply(coordinateValue);
            float d1 = _derivatives[start];
            float d2 = _derivatives[start + 1];
            float a = d1 * (x2 - x1) - (y2 - y1);
            float b = -d2 * (x2 - x1) + (y2 - y1);
            return Mth.Lerp(t, y1, y2) + t * (1.0F - t) * Mth.Lerp(t, a, b);
        }

        private static float LinearExtend(float input, float[] locations, float value, float[] derivatives, int index) {
            float derivative = derivatives[index];
            return derivative == 0.0F ? value : value + derivative * (input - locations[index]);
        }

        /// <summary>The last knot at or below the input, or -1 when the input is below all of them.</summary>
        private static int FindIntervalStart(float[] locations, float input) {
            int from = 0;
            int len = locations.Length;
            while (len > 0) {
                int half = len / 2;
                int middle = from + half;
                if (input < locations[middle]) {
                    len = half;
                } else {
                    from = middle + 1;
                    len -= half + 1;
                }
            }

            return from - 1;
        }

        public override bool Equals(object? obj) {
            return obj is MultipointSpline other
                && EqualityComparer<TCoordinate>.Default.Equals(_coordinate, other._coordinate)
                && _locations.AsSpan().SequenceEqual(other._locations)
                && _derivatives.AsSpan().SequenceEqual(other._derivatives)
                && _values.SequenceEqual(other._values);
        }

        public override int GetHashCode() {
            HashCode hash = new();
            hash.Add(_coordinate);
            foreach (float location in _locations) {
                hash.Add(location);
            }

            foreach (CubicSpline<TCoordinate> value in _values) {
                hash.Add(value);
            }

            return hash.ToHashCode();
        }
    }
}
