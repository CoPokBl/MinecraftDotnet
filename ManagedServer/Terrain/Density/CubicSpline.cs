using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// A float valued function of some coordinate, along with the range it can produce. Vanilla's
/// <c>ToFloatFunction</c> / <c>BoundedFloatFunction</c>.
/// </summary>
/// <remarks>
/// The bounds are what let a spline compute its own range without sampling, which is what the density
/// function tree's range propagation is built on.
/// </remarks>
public interface IBoundedFloatFunction<in TPoint> {
    float Apply(TPoint point);

    float MinValue { get; }

    float MaxValue { get; }
}

/// <summary>
/// Vanilla's <c>CubicSpline</c>: a piecewise cubic Hermite curve whose knot values are themselves
/// splines, so the whole thing nests.
/// </summary>
/// <remarks>
/// This is how the overworld's shape is described. Continentalness picks a curve over erosion, which
/// picks a curve over ridges, and the result is the terrain's offset, factor or jaggedness. Beyond the
/// first and last knot the curve is <b>extended linearly</b> along the end derivative rather than
/// clamped, which is what stops a plateau forming at the extremes of the climate noise.
/// <p/>
/// Everything here is <b>float</b>, as upstream. The values feed a double density function tree, and
/// widening early changes where a slope crosses zero.
/// </remarks>
public abstract class CubicSpline<TCoordinate, TPoint> where TCoordinate : IBoundedFloatFunction<TPoint> {
    public abstract float MinValue { get; }

    public abstract float MaxValue { get; }

    public abstract float Sample(TPoint point);

    /// <summary>Rebuilds the spline with every coordinate replaced, which is how a visitor reaches into one.</summary>
    public abstract CubicSpline<TCoordinate, TPoint> MapCoordinates(Func<TCoordinate, TCoordinate> mapper);

    public static CubicSpline<TCoordinate, TPoint> Constant(float value) {
        return new ConstantSpline(value);
    }

    /// <summary>A knot: where it is on the coordinate, what it evaluates to, and the slope through it.</summary>
    public readonly record struct Point(float Location, CubicSpline<TCoordinate, TPoint> Value, float Derivative);

    private sealed class ConstantSpline(float value) : CubicSpline<TCoordinate, TPoint> {
        public override float MinValue => value;
        public override float MaxValue => value;

        public override float Sample(TPoint point) => value;

        public override CubicSpline<TCoordinate, TPoint> MapCoordinates(Func<TCoordinate, TCoordinate> mapper) {
            return this;
        }
    }

    public static CubicSpline<TCoordinate, TPoint> Multipoint(TCoordinate coordinate, IReadOnlyList<Point> points) {
        return new MultipointSpline(coordinate, points);
    }

    private sealed class MultipointSpline : CubicSpline<TCoordinate, TPoint> {
        private readonly TCoordinate _coordinate;
        private readonly float[] _locations;
        private readonly CubicSpline<TCoordinate, TPoint>[] _values;
        private readonly float[] _derivatives;

        public MultipointSpline(TCoordinate coordinate, IReadOnlyList<Point> points) {
            if (points.Count == 0) {
                throw new ArgumentException("Cannot create a multipoint spline with no points", nameof(points));
            }

            _coordinate = coordinate;
            _locations = new float[points.Count];
            _values = new CubicSpline<TCoordinate, TPoint>[points.Count];
            _derivatives = new float[points.Count];

            for (int i = 0; i < points.Count; i++) {
                _locations[i] = points[i].Location;
                _values[i] = points[i].Value;
                _derivatives[i] = points[i].Derivative;
            }

            (MinValue, MaxValue) = ComputeRange();
        }

        public override float MinValue { get; }

        public override float MaxValue { get; }

        /// <summary>
        /// The range over the coordinate's own range, without sampling. Three parts: the linear
        /// extensions past each end, the knot values themselves, and a bound on the cubic overshoot
        /// between each pair of knots.
        /// </summary>
        private (float Min, float Max) ComputeRange() {
            int lastIndex = _locations.Length - 1;
            float minValue = float.PositiveInfinity;
            float maxValue = float.NegativeInfinity;

            float minInput = _coordinate.MinValue;
            float maxInput = _coordinate.MaxValue;

            if (minInput < _locations[0]) {
                float edge1 = LinearExtend(minInput, _locations, _values[0].MinValue, _derivatives, 0);
                float edge2 = LinearExtend(minInput, _locations, _values[0].MaxValue, _derivatives, 0);
                minValue = Math.Min(minValue, Math.Min(edge1, edge2));
                maxValue = Math.Max(maxValue, Math.Max(edge1, edge2));
            }

            if (maxInput > _locations[lastIndex]) {
                float edge1 = LinearExtend(maxInput, _locations, _values[lastIndex].MinValue, _derivatives, lastIndex);
                float edge2 = LinearExtend(maxInput, _locations, _values[lastIndex].MaxValue, _derivatives, lastIndex);
                minValue = Math.Min(minValue, Math.Min(edge1, edge2));
                maxValue = Math.Max(maxValue, Math.Max(edge1, edge2));
            }

            foreach (CubicSpline<TCoordinate, TPoint> value in _values) {
                minValue = Math.Min(minValue, value.MinValue);
                maxValue = Math.Max(maxValue, value.MaxValue);
            }

            for (int i = 0; i < lastIndex; i++) {
                float xDiff = _locations[i + 1] - _locations[i];
                float min1 = _values[i].MinValue;
                float max1 = _values[i].MaxValue;
                float min2 = _values[i + 1].MinValue;
                float max2 = _values[i + 1].MaxValue;
                float d1 = _derivatives[i];
                float d2 = _derivatives[i + 1];

                if (d1 == 0.0f && d2 == 0.0f) {
                    continue;
                }

                float p1 = d1 * xDiff;
                float p2 = d2 * xDiff;
                float minLerp1 = Math.Min(min1, min2);
                float maxLerp1 = Math.Max(max1, max2);
                float minA = p1 - max2 + min1;
                float maxA = p1 - min2 + max1;
                float minB = -p2 + min2 - max1;
                float maxB = -p2 + max2 - min1;

                minValue = Math.Min(minValue, minLerp1 + 0.25f * Math.Min(minA, minB));
                maxValue = Math.Max(maxValue, maxLerp1 + 0.25f * Math.Max(maxA, maxB));
            }

            return (minValue, maxValue);
        }

        public override float Sample(TPoint point) {
            float input = _coordinate.Apply(point);
            int start = FindIntervalStart(_locations, input);
            int lastIndex = _locations.Length - 1;

            if (start < 0) {
                return LinearExtend(input, _locations, _values[0].Sample(point), _derivatives, 0);
            }

            if (start == lastIndex) {
                return LinearExtend(input, _locations, _values[lastIndex].Sample(point), _derivatives, lastIndex);
            }

            float x1 = _locations[start];
            float x2 = _locations[start + 1];
            float t = (input - x1) / (x2 - x1);

            float y1 = _values[start].Sample(point);
            float y2 = _values[start + 1].Sample(point);

            float a = _derivatives[start] * (x2 - x1) - (y2 - y1);
            float b = -_derivatives[start + 1] * (x2 - x1) + (y2 - y1);
            return Mth.Lerp(t, y1, y2) + t * (1.0f - t) * Mth.Lerp(t, a, b);
        }

        public override CubicSpline<TCoordinate, TPoint> MapCoordinates(Func<TCoordinate, TCoordinate> mapper) {
            Point[] points = new Point[_locations.Length];
            for (int i = 0; i < points.Length; i++) {
                points[i] = new Point(_locations[i], _values[i].MapCoordinates(mapper), _derivatives[i]);
            }

            return new MultipointSpline(mapper(_coordinate), points);
        }

        private static float LinearExtend(float input, float[] locations, float value, float[] derivatives, int index) {
            float derivative = derivatives[index];
            return derivative == 0.0f ? value : value + derivative * (input - locations[index]);
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
    }
}
