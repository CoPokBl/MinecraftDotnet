using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// The samplers a generation context supplies. Nothing here sets the two blending keys: old chunks
/// are not blended, and vanilla's answer for an empty blender is the fallback.
/// </summary>
public static class DensityContextKeys {
    public static readonly SamplerContextKey<IDensitySampler> Beardifier = new("minecraft:beardifier");
    public static readonly SamplerContextKey<IDensitySampler> BlendAlpha = new("minecraft:blend_alpha");
    public static readonly SamplerContextKey<IDensitySampler> BlendOffset = new("minecraft:blend_offset");
}

/// <summary>Vanilla's <c>ConstantFunction</c>.</summary>
public sealed record ConstantFunction(float Value) : IDensityFunction {
    public static readonly ConstantFunction Zero = new(0.0F);

    public IDensitySampler CompileSampler(ICompileContext context) => new Sampler(Value);

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;

    public Interval Range => Interval.OfExact(Value);

    public int DomainAxes => DensityAxes.None;

    public sealed record Sampler(float Value) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) => output.Fill(Value);

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) => Value;
    }
}

/// <summary>The three context supplied values, vanilla's <c>SimpleDensityFunction</c>.</summary>
public sealed class SimpleDensityFunction : IDensityFunction {
    public static readonly SimpleDensityFunction BlendAlpha = new("blend_alpha", DensityContextKeys.BlendAlpha, 1.0F,
        Interval.Of(0.0F, 1.0F), DensityAxes.X | DensityAxes.Z);

    public static readonly SimpleDensityFunction BlendOffset = new("blend_offset", DensityContextKeys.BlendOffset, 0.0F,
        Interval.Infinite, DensityAxes.X | DensityAxes.Z);

    public static readonly SimpleDensityFunction Beardifier = new("beardifier", DensityContextKeys.Beardifier, 0.0F,
        Interval.Infinite, DensityAxes.All);

    private readonly SamplerContextKey<IDensitySampler> _key;
    private readonly float _fallback;

    private SimpleDensityFunction(string id, SamplerContextKey<IDensitySampler> key, float fallback, Interval range, int domainAxes) {
        Id = id;
        _key = key;
        _fallback = fallback;
        Range = range;
        DomainAxes = domainAxes;
    }

    public string Id { get; }

    public IDensitySampler CompileSampler(ICompileContext context) {
        return new ContextBoundSampler(_key, new ConstantFunction.Sampler(_fallback));
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;

    public Interval Range { get; }

    public int DomainAxes { get; }

    public override string ToString() => Id;
}

/// <summary>
/// A named noise at a scale, with optional per position shifts, vanilla's <c>NoiseFunction</c>. It is
/// both <c>noise</c> and the old <c>shifted_noise</c>.
/// </summary>
/// <remarks>
/// A shift is a float added to a double coordinate, and with no <c>shift_y</c> the y coordinate is
/// <c>blockY * yScale</c> exactly. Whether the shifts are all the zero constant is decided by equality,
/// so a shift written as <c>0.0</c> in the data compiles to the unshifted sampler.
/// </remarks>
public sealed record NoiseFunction(NoiseHolder Noise, double XzScale, double YScale,
    IDensityFunction ShiftX, IDensityFunction ShiftY, IDensityFunction ShiftZ) : IDensityFunction {

    public IDensitySampler CompileSampler(ICompileContext context) {
        INoise noise = context.CreateNoiseSampler(Noise);
        if (ShiftX.Equals(ConstantFunction.Zero) && ShiftY.Equals(ConstantFunction.Zero) && ShiftZ.Equals(ConstantFunction.Zero)) {
            return new Sampler(noise, XzScale, YScale);
        }

        IDensitySampler shiftX = ShiftX.CompileSampler(context);
        IDensitySampler shiftZ = ShiftZ.CompileSampler(context);
        if (ShiftY.Equals(ConstantFunction.Zero)) {
            return new ShiftedXzSampler(shiftX, shiftZ, noise, XzScale, YScale);
        }

        return new ShiftedXyzSampler(shiftX, ShiftY.CompileSampler(context), shiftZ, noise, XzScale, YScale);
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction shiftX = rule.Rewrite(ShiftX);
        IDensityFunction shiftY = rule.Rewrite(ShiftY);
        IDensityFunction shiftZ = rule.Rewrite(ShiftZ);
        return ReferenceEquals(shiftX, ShiftX) && ReferenceEquals(shiftY, ShiftY) && ReferenceEquals(shiftZ, ShiftZ)
            ? this
            : this with { ShiftX = shiftX, ShiftY = shiftY, ShiftZ = shiftZ };
    }

    public Interval Range => Noise.Value.Range;

    public int DomainAxes {
        get {
            int axes = DensityAxes.All;
            if (YScale == 0.0) {
                axes &= ~DensityAxes.Y;
            }

            if (XzScale == 0.0) {
                axes &= ~(DensityAxes.X | DensityAxes.Z);
            }

            return axes | ShiftX.DomainAxes | ShiftY.DomainAxes | ShiftZ.DomainAxes;
        }
    }

    public sealed record Sampler(INoise Noise, double XzScale, double YScale) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            output.Fill(0.0F);
            Noise.AddToVolume(output, volume, XzScale, YScale, 1.0F);
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Noise.Get(blockX * XzScale, blockY * YScale, blockZ * XzScale);
        }
    }

    private sealed record ShiftedXyzSampler(IDensitySampler ShiftX, IDensitySampler ShiftY, IDensitySampler ShiftZ,
        INoise Noise, double XzScale, double YScale) : IDensitySampler {

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            ShiftX.SampleVolume(context, output, volume);
            using ScopedDensityBuffer shiftYBuffer = context.AcquireBuffer(volume);
            ShiftY.SampleVolume(context, shiftYBuffer, volume);
            using ScopedDensityBuffer shiftZBuffer = context.AcquireBuffer(volume);
            ShiftZ.SampleVolume(context, shiftZBuffer, volume);

            int index = 0;
            for (int z = 0; z < volume.SizeZ; z++) {
                double baseNoiseZ = volume.BlockZ(z) * XzScale;
                for (int x = 0; x < volume.SizeX; x++) {
                    double baseNoiseX = volume.BlockX(x) * XzScale;
                    for (int y = 0; y < volume.SizeY; y++) {
                        double noiseX = baseNoiseX + output[index];
                        double noiseY = volume.BlockY(y) * YScale + shiftYBuffer[index];
                        double noiseZ = baseNoiseZ + shiftZBuffer[index];
                        output[index] = Noise.Get(noiseX, noiseY, noiseZ);
                        index++;
                    }
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            double x = blockX * XzScale + ShiftX.SampleValue(context, blockX, blockY, blockZ);
            double y = blockY * YScale + ShiftY.SampleValue(context, blockX, blockY, blockZ);
            double z = blockZ * XzScale + ShiftZ.SampleValue(context, blockX, blockY, blockZ);
            return Noise.Get(x, y, z);
        }
    }

    private sealed record ShiftedXzSampler(IDensitySampler ShiftX, IDensitySampler ShiftZ,
        INoise Noise, double XzScale, double YScale) : IDensitySampler {

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            ShiftX.SampleVolume(context, output, volume);
            using ScopedDensityBuffer shiftZBuffer = context.AcquireBuffer(volume);
            ShiftZ.SampleVolume(context, shiftZBuffer, volume);

            int index = 0;
            for (int z = 0; z < volume.SizeZ; z++) {
                double baseNoiseZ = volume.BlockZ(z) * XzScale;
                for (int x = 0; x < volume.SizeX; x++) {
                    double baseNoiseX = volume.BlockX(x) * XzScale;
                    for (int y = 0; y < volume.SizeY; y++) {
                        double noiseX = baseNoiseX + output[index];
                        double noiseY = volume.BlockY(y) * YScale;
                        double noiseZ = baseNoiseZ + shiftZBuffer[index];
                        output[index] = Noise.Get(noiseX, noiseY, noiseZ);
                        index++;
                    }
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            double x = blockX * XzScale + ShiftX.SampleValue(context, blockX, blockY, blockZ);
            double y = blockY * YScale;
            double z = blockZ * XzScale + ShiftZ.SampleValue(context, blockX, blockY, blockZ);
            return Noise.Get(x, y, z);
        }
    }
}

/// <summary>
/// The end's outer islands, vanilla's <c>EndIslandFunction</c>. The central island is not here: the
/// data adds it with a per block <c>distance_to_point</c>.
/// </summary>
public sealed record EndIslandFunction : IDensityFunction {
    private const float IslandThreshold = -0.9F;

    public IDensitySampler CompileSampler(ICompileContext context) {
        RandomSource islandRandom = context.CreateEndIslandRandom();
        islandRandom.ConsumeCount(17292);
        return new Sampler(new SimplexNoise(islandRandom, true));
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;

    public Interval Range => Interval.Of(-0.84375F, 0.5625F);

    public int DomainAxes => DensityAxes.X | DensityAxes.Z;

    private static float GetHeightValue(SimplexNoise islandNoise, int sectionX, int sectionZ) {
        int chunkX = sectionX / 2;
        int chunkZ = sectionZ / 2;
        int subSectionX = sectionX % 2;
        int subSectionZ = sectionZ % 2;
        float doffs = -100.0F;

        for (int xo = -12; xo <= 12; xo++) {
            for (int zo = -12; zo <= 12; zo++) {
                long totalChunkX = chunkX + xo;
                long totalChunkZ = chunkZ + zo;
                if (totalChunkX * totalChunkX + totalChunkZ * totalChunkZ > 4096L
                    && islandNoise.Get(totalChunkX, totalChunkZ) < IslandThreshold) {
                    float islandSize = (Math.Abs((float)totalChunkX) * 3439.0F + Math.Abs((float)totalChunkZ) * 147.0F) % 13.0F + 9.0F;
                    float xd = subSectionX - xo * 2;
                    float zd = subSectionZ - zo * 2;
                    float newDoffs = 100.0F - Mth.Sqrt(xd * xd + zd * zd) * islandSize;
                    newDoffs = Mth.Clamp(newDoffs, -100.0F, 80.0F);
                    doffs = Math.Max(doffs, newDoffs);
                }
            }
        }

        return doffs;
    }

    private sealed record Sampler(SimplexNoise IslandNoise) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            for (int z = 0; z < volume.SizeZ; z++) {
                int blockZ = volume.BlockZ(z);
                for (int x = 0; x < volume.SizeX; x++) {
                    float value = SampleValue(context, volume.BlockX(x), 0, blockZ);
                    output.SetRange(volume.IndexUnchecked(x, 0, z), volume.SizeY, value);
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return (GetHeightValue(IslandNoise, blockX / 8, blockZ / 8) - 8.0F) / 128.0F;
        }
    }
}

/// <summary>How <see cref="DistanceToPointFunction"/> measures, vanilla's <c>DistanceMetric</c>.</summary>
public enum DistanceMetric {
    Euclidean,
    EuclideanSquared,
    Manhattan,
    Chebyshev
}

/// <summary>Vanilla's <c>DistanceToPointFunction</c>. The deltas are ints narrowed to float.</summary>
public sealed record DistanceToPointFunction(int PointX, int PointY, int PointZ, DistanceMetric Metric) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) => new Sampler(PointX, PointY, PointZ, Metric);

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;

    public Interval Range => Interval.Of(0.0F, float.PositiveInfinity);

    public int DomainAxes => DensityAxes.All;

    public static float Compute(DistanceMetric metric, float deltaX, float deltaY, float deltaZ) {
        return metric switch {
            DistanceMetric.Euclidean => Mth.Length(deltaX, deltaY, deltaZ),
            DistanceMetric.EuclideanSquared => Mth.LengthSquared(deltaX, deltaY, deltaZ),
            DistanceMetric.Manhattan => Math.Abs(deltaX) + Math.Abs(deltaY) + Math.Abs(deltaZ),
            _ => Math.Max(Math.Max(Math.Abs(deltaX), Math.Abs(deltaY)), Math.Abs(deltaZ))
        };
    }

    private sealed record Sampler(int X, int Y, int Z, DistanceMetric Metric) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            IDensitySampler.SampleVolumeNaive(context, output, volume, this);
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Compute(Metric, X - blockX, Y - blockY, Z - blockZ);
        }
    }
}

/// <summary>How <see cref="GradientFunction"/> continues past its range, vanilla's <c>TilingMode</c>.</summary>
public enum TilingMode {
    ClampToEdge,
    Repeat,
    MirroredRepeat
}

/// <summary>
/// A linear ramp along one axis, vanilla's <c>GradientFunction</c>, which <c>y_clamped_gradient</c>
/// became. It is <c>from + d * factor</c> with a float factor, not a lerp, so intermediate values differ
/// in the low bits from the 26.2 node.
/// </summary>
public sealed record GradientFunction(Axis Axis, TilingMode Tiling, int FromCoordinate, int ToCoordinate,
    float FromValue, float ToValue) : IDensityFunction {

    public IDensitySampler CompileSampler(ICompileContext context) {
        int coordinateRange = ToCoordinate - FromCoordinate;
        float coordinateFactor = (ToValue - FromValue) / coordinateRange;
        return Tiling switch {
            TilingMode.ClampToEdge => new Sampler(Axis, coordinate => {
                int relative = Mth.Clamp(coordinate, Math.Min(FromCoordinate, ToCoordinate), Math.Max(FromCoordinate, ToCoordinate)) - FromCoordinate;
                return FromValue + relative * coordinateFactor;
            }),
            TilingMode.Repeat => new Sampler(Axis, coordinate => {
                int relative = coordinate - FromCoordinate;
                return FromValue + Mth.FloorMod(relative, coordinateRange) * coordinateFactor;
            }),
            _ => new Sampler(Axis, coordinate => {
                int relative = coordinate - FromCoordinate;
                int tileIndex = Mth.FloorDiv(relative, coordinateRange);
                int local = relative - tileIndex * coordinateRange;
                return (tileIndex & 1) == 0
                    ? FromValue + local * coordinateFactor
                    : FromValue + (coordinateRange - local) * coordinateFactor;
            })
        };
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;

    public Interval Range => Interval.Encapsulating(FromValue, ToValue);

    public int DomainAxes => DensityAxes.From(Axis);

    private sealed class Sampler(Axis axis, Func<int, float> compute) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            switch (axis) {
                case Axis.X:
                    for (int x = 0; x < volume.SizeX; x++) {
                        float value = compute(volume.BlockX(x));
                        for (int z = 0; z < volume.SizeZ; z++) {
                            output.SetRange(volume.IndexUnchecked(x, 0, z), volume.SizeY, value);
                        }
                    }

                    break;
                case Axis.Y:
                    for (int y = 0; y < volume.SizeY; y++) {
                        float value = compute(volume.BlockY(y));
                        for (int z = 0; z < volume.SizeZ; z++) {
                            for (int x = 0; x < volume.SizeX; x++) {
                                output[volume.IndexUnchecked(x, y, z)] = value;
                            }
                        }
                    }

                    break;
                default:
                    for (int z = 0; z < volume.SizeZ; z++) {
                        output.SetRange(volume.IndexUnchecked(0, 0, z), volume.SizeX * volume.SizeY, compute(volume.BlockZ(z)));
                    }

                    break;
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return compute(axis.Choose(blockX, blockY, blockZ));
        }
    }
}

/// <summary>
/// The coordinate offsets the climate noises are sampled through, vanilla's <c>ShiftNoiseFunction</c>:
/// four times a noise at a quarter of the coordinates. <c>shift_b</c> reads x as its y and z as its x.
/// </summary>
public sealed record ShiftNoiseFunction(ShiftNoiseFunction.ShiftKind Kind, NoiseHolder OffsetNoise) : IDensityFunction {
    public enum ShiftKind {
        Shift,
        ShiftA,
        ShiftB
    }

    public IDensitySampler CompileSampler(ICompileContext context) {
        INoise noise = context.CreateNoiseSampler(OffsetNoise);
        return Kind switch {
            ShiftKind.Shift => new BinaryFunction.ConstMulSampler(new NoiseFunction.Sampler(noise, 0.25, 0.25), 4.0F),
            ShiftKind.ShiftA => new BinaryFunction.ConstMulSampler(new NoiseFunction.Sampler(noise, 0.25, 0.0), 4.0F),
            _ => new ShiftBSampler(noise)
        };
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this with { };

    public Interval Range => Interval.Mul(OffsetNoise.Value.Range, Interval.OfExact(4.0F));

    public int DomainAxes => Kind == ShiftKind.Shift ? DensityAxes.All : DensityAxes.X | DensityAxes.Z;

    private sealed record ShiftBSampler(INoise Noise) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            DensityVolume transposed = new(volume.SizeZ, volume.SizeX, 1, volume.MinBlockZ, volume.MinBlockX, 0,
                volume.StepBlockZ, volume.StepBlockX, 1);
            using ScopedDensityBuffer transposedBuffer = context.AcquireBuffer(transposed);
            transposedBuffer.Fill(0.0F);
            Noise.AddToVolume(transposedBuffer, transposed, 0.25, 0.25, 4.0F);

            for (int z = 0; z < volume.SizeZ; z++) {
                for (int x = 0; x < volume.SizeX; x++) {
                    float value = transposedBuffer[transposed.IndexUnchecked(z, x, 0)];
                    output.SetRange(volume.IndexUnchecked(x, 0, z), volume.SizeY, value);
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Noise.Get(blockZ * 0.25, blockX * 0.25, 0.0) * 4.0F;
        }
    }
}
