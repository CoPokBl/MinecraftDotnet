namespace ManagedServer.Terrain.Density;

/// <summary>
/// A spline over density function coordinates, vanilla's <c>SplineFunction</c>.
/// </summary>
/// <remarks>
/// Each distinct coordinate function, by equality, is sampled at most once per point, and on the
/// volume path at most once per volume and only when some position reaches it.
/// </remarks>
public sealed record SplineFunction(CubicSpline<IDensityFunction> Spline) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) => new Sampler(context, Spline);

    public Interval Range => Spline.RangeOf(coordinate => coordinate.Range);

    public int DomainAxes {
        get {
            int axes = 0;
            Spline.ForEachCoordinate(coordinate => axes |= coordinate.DomainAxes);
            return axes;
        }
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        bool changed = false;
        CubicSpline<IDensityFunction> newSpline = Spline.MapCoordinates(coordinate => {
            IDensityFunction rewritten = rule.Rewrite(coordinate);
            changed |= !ReferenceEquals(rewritten, coordinate);
            return rewritten;
        });
        return changed ? new SplineFunction(newSpline) : this;
    }

    private sealed record SamplerCoordinate(IDensitySampler Sampler, int Index);

    private sealed class Sampler : IDensitySampler {
        private readonly CubicSpline<SamplerCoordinate> _spline;
        private readonly int _coordinateCount;

        public Sampler(ICompileContext context, CubicSpline<IDensityFunction> spline) {
            Dictionary<IDensityFunction, SamplerCoordinate> coordinates = new();
            _spline = spline.MapCoordinates(function => {
                if (!coordinates.TryGetValue(function, out SamplerCoordinate? coordinate)) {
                    coordinate = new SamplerCoordinate(function.CompileSampler(context), coordinates.Count);
                    coordinates[function] = coordinate;
                }

                return coordinate;
            });
            _coordinateCount = coordinates.Count;
        }

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            ScopedDensityBuffer?[] buffers = new ScopedDensityBuffer?[_coordinateCount];
            int index = 0;
            float CoordinateValue(SamplerCoordinate coordinate) {
                ScopedDensityBuffer? buffer = buffers[coordinate.Index];
                if (buffer == null) {
                    buffer = context.AcquireBuffer(volume);
                    coordinate.Sampler.SampleVolume(context, buffer, volume);
                    buffers[coordinate.Index] = buffer;
                }

                return buffer[index];
            }

            Func<SamplerCoordinate, float> coordinateValue = CoordinateValue;
            try {
                for (; index < output.Size; index++) {
                    output[index] = _spline.Apply(coordinateValue);
                }
            } finally {
                foreach (ScopedDensityBuffer? buffer in buffers) {
                    buffer?.Dispose();
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float[] cachedValues = new float[_coordinateCount];
            Array.Fill(cachedValues, float.NaN);
            return _spline.Apply(coordinate => {
                float cached = cachedValues[coordinate.Index];
                if (!float.IsNaN(cached)) {
                    return cached;
                }

                float value = coordinate.Sampler.SampleValue(context, blockX, blockY, blockZ);
                cachedValues[coordinate.Index] = value;
                return value;
            });
        }
    }
}
