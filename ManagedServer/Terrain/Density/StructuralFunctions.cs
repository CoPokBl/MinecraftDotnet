using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// The first function whose threshold the input is below, else the last, vanilla's
/// <c>IntervalSelectFunction</c>. The volume path samples every function over the whole volume.
/// </summary>
public sealed record IntervalSelectFunction(IDensityFunction Input, IReadOnlyList<float> Thresholds,
    IReadOnlyList<IDensityFunction> Functions) : IDensityFunction {

    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler input = Input.CompileSampler(context);
        if (Thresholds.Count == 1) {
            return new SingleThresholdSampler(input, Thresholds[0], Functions[0].CompileSampler(context),
                Functions[^1].CompileSampler(context));
        }

        return new Sampler(input, Thresholds.ToArray(), Functions.Select(function => function.CompileSampler(context)).ToArray());
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        bool changed = false;
        IDensityFunction[] functions = new IDensityFunction[Functions.Count];
        for (int i = 0; i < functions.Length; i++) {
            functions[i] = rule.Rewrite(Functions[i]);
            changed |= !ReferenceEquals(functions[i], Functions[i]);
        }

        return ReferenceEquals(input, Input) && !changed ? this : new IntervalSelectFunction(input, Thresholds, functions);
    }

    public Interval Range => Interval.Encapsulating(Functions.Select(function => function.Range));

    public int DomainAxes {
        get {
            int axes = Input.DomainAxes;
            foreach (IDensityFunction function in Functions) {
                axes |= function.DomainAxes;
            }

            return axes;
        }
    }

    public bool Equals(IntervalSelectFunction? other) {
        return other is not null && Input.Equals(other.Input) && Thresholds.SequenceEqual(other.Thresholds)
            && Functions.SequenceEqual(other.Functions);
    }

    public override int GetHashCode() {
        HashCode hash = new();
        hash.Add(Input);
        foreach (float threshold in Thresholds) {
            hash.Add(threshold);
        }

        foreach (IDensityFunction function in Functions) {
            hash.Add(function);
        }

        return hash.ToHashCode();
    }

    private sealed class Sampler(IDensitySampler input, float[] thresholds, IDensitySampler[] samplers) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            input.SampleVolume(context, output, volume);
            ScopedDensityBuffer?[] buffers = new ScopedDensityBuffer?[samplers.Length];
            try {
                for (int i = 0; i < samplers.Length; i++) {
                    ScopedDensityBuffer buffer = context.AcquireBuffer(volume);
                    buffers[i] = buffer;
                    samplers[i].SampleVolume(context, buffer, volume);
                }

                for (int i = 0; i < output.Size; i++) {
                    output[i] = buffers[SelectSamplerIndex(output[i])]![i];
                }
            } finally {
                foreach (ScopedDensityBuffer? buffer in buffers) {
                    buffer?.Dispose();
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float value = input.SampleValue(context, blockX, blockY, blockZ);
            return samplers[SelectSamplerIndex(value)].SampleValue(context, blockX, blockY, blockZ);
        }

        private int SelectSamplerIndex(float value) {
            for (int i = 0; i < thresholds.Length; i++) {
                if (value < thresholds[i]) {
                    return i;
                }
            }

            return samplers.Length - 1;
        }
    }

    private sealed record SingleThresholdSampler(IDensitySampler Input, float Threshold, IDensitySampler IfBelow, IDensitySampler IfAbove)
        : IDensitySampler {

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            using ScopedDensityBuffer belowBuffer = context.AcquireBuffer(volume);
            IfBelow.SampleVolume(context, belowBuffer, volume);
            using ScopedDensityBuffer aboveBuffer = context.AcquireBuffer(volume);
            IfAbove.SampleVolume(context, aboveBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = output[i] < Threshold ? belowBuffer[i] : aboveBuffer[i];
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float input = Input.SampleValue(context, blockX, blockY, blockZ);
            return input < Threshold ? IfBelow.SampleValue(context, blockX, blockY, blockZ) : IfAbove.SampleValue(context, blockX, blockY, blockZ);
        }
    }
}

/// <summary>
/// A cache marker, vanilla's <c>CacheFunction</c>. It cannot be compiled itself: the compiler replaces
/// it with one shared cache per distinct input.
/// </summary>
public sealed record CacheFunction(IDensityFunction Input) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        throw new InvalidOperationException("Cannot compile cache before it has been deduplicated");
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        return ReferenceEquals(input, Input) ? this : new CacheFunction(input);
    }

    public Interval Range => Input.Range;

    public int DomainAxes => Input.DomainAxes;
}

/// <summary>
/// Vanilla's <c>BlendDensityFunction</c>. Without a blender in the context it is the identity, which
/// is always the case here.
/// </summary>
public sealed record BlendDensityFunction(IDensityFunction Input) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) => Input.CompileSampler(context);

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        return ReferenceEquals(input, Input) ? this : new BlendDensityFunction(input);
    }

    public Interval Range => Input.Range;

    public int DomainAxes => Input.DomainAxes;
}

/// <summary>
/// Trilinear interpolation between samples on a cell grid, vanilla's <c>InterpolatedFunction</c>.
/// </summary>
/// <remarks>
/// The volume path lerps along z, then x, then walks y by adding a step, which is a different
/// rounding from the point path's <c>lerp3</c>. The point path on a cell corner returns the input
/// directly and elsewhere samples the eight corners as a 2x2x2 volume, so a cache under it sees that
/// volume, not points.
/// </remarks>
public sealed record InterpolatedFunction(IDensityFunction Input, int CellSizeXz, int CellSizeY) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        return new Sampler(Input.CompileSampler(context), CellSizeXz, CellSizeY, 1.0F / CellSizeXz, 1.0F / CellSizeY);
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        return ReferenceEquals(input, Input) ? this : this with { Input = input };
    }

    public Interval Range => Input.Range;

    public int DomainAxes => Input.DomainAxes;

    private sealed record Sampler(IDensitySampler Input, int CellSizeXz, int CellSizeY, float CellSizeXzInv, float CellSizeYInv)
        : IDensitySampler {

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            if ((volume.StepBlockX == CellSizeXz || volume.SizeX == 1)
                && (volume.StepBlockY == CellSizeY || volume.SizeY == 1)
                && (volume.StepBlockZ == CellSizeXz || volume.SizeZ == 1)
                && Mth.FloorMod(volume.MinBlockX, CellSizeXz) == 0
                && Mth.FloorMod(volume.MinBlockY, CellSizeY) == 0
                && Mth.FloorMod(volume.MinBlockZ, CellSizeXz) == 0) {
                Input.SampleVolume(context, output, volume);
            } else if (volume.StepBlockX == 1 && volume.StepBlockY == 1 && volume.StepBlockZ == 1) {
                SampleWithBlockStep(context, output, volume);
            } else {
                SampleWithNonBlockStep(context, output, volume);
            }
        }

        private void SampleWithNonBlockStep(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            DensityVolume blockVolume = new(volume.SizeX * volume.StepBlockX, volume.SizeY * volume.StepBlockY, volume.SizeZ * volume.StepBlockZ,
                volume.MinBlockX, volume.MinBlockY, volume.MinBlockZ);
            using ScopedDensityBuffer blockBuffer = context.AcquireBuffer(blockVolume);
            SampleWithBlockStep(context, blockBuffer, blockVolume);

            for (int z = 0; z < volume.SizeZ; z++) {
                for (int x = 0; x < volume.SizeX; x++) {
                    for (int y = 0; y < volume.SizeY; y++) {
                        output[volume.IndexUnchecked(x, y, z)] =
                            blockBuffer[blockVolume.IndexUnchecked(x * volume.StepBlockX, y * volume.StepBlockY, z * volume.StepBlockZ)];
                    }
                }
            }
        }

        private void SampleWithBlockStep(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            int minCellX = Mth.FloorDiv(volume.MinBlockX, CellSizeXz);
            int minCellY = Mth.FloorDiv(volume.MinBlockY, CellSizeY);
            int minCellZ = Mth.FloorDiv(volume.MinBlockZ, CellSizeXz);
            int maxCellX = Mth.FloorDiv(volume.MaxBlockX, CellSizeXz);
            int maxCellY = Mth.FloorDiv(volume.MaxBlockY, CellSizeY);
            int maxCellZ = Mth.FloorDiv(volume.MaxBlockZ, CellSizeXz);
            int cellCountX = maxCellX - minCellX + 1;
            int cellCountY = maxCellY - minCellY + 1;
            int cellCountZ = maxCellZ - minCellZ + 1;
            DensityVolume cellVolume = new(
                Mth.FloorMod(volume.MaxBlockX, CellSizeXz) == 0 ? cellCountX : cellCountX + 1,
                Mth.FloorMod(volume.MaxBlockY, CellSizeY) == 0 ? cellCountY : cellCountY + 1,
                Mth.FloorMod(volume.MaxBlockZ, CellSizeXz) == 0 ? cellCountZ : cellCountZ + 1,
                minCellX * CellSizeXz, minCellY * CellSizeY, minCellZ * CellSizeXz,
                CellSizeXz, CellSizeY, CellSizeXz);

            using ScopedDensityBuffer cellBuffer = context.AcquireBuffer(cellVolume);
            Input.SampleVolume(context, cellBuffer, cellVolume);

            for (int cellZ = 0; cellZ < cellCountZ; cellZ++) {
                int nextCellZ = Math.Min(cellZ + 1, cellVolume.SizeZ - 1);
                for (int cellX = 0; cellX < cellCountX; cellX++) {
                    int nextCellX = Math.Min(cellX + 1, cellVolume.SizeX - 1);
                    float v000 = cellBuffer[cellVolume.IndexUnchecked(cellX, 0, cellZ)];
                    float v100 = cellBuffer[cellVolume.IndexUnchecked(nextCellX, 0, cellZ)];
                    float v001 = cellBuffer[cellVolume.IndexUnchecked(cellX, 0, nextCellZ)];
                    float v101 = cellBuffer[cellVolume.IndexUnchecked(nextCellX, 0, nextCellZ)];

                    for (int cellY = 0; cellY < cellCountY; cellY++) {
                        int nextCellY = Math.Min(cellY + 1, cellVolume.SizeY - 1);
                        float v010 = cellBuffer[cellVolume.IndexUnchecked(cellX, nextCellY, cellZ)];
                        float v110 = cellBuffer[cellVolume.IndexUnchecked(nextCellX, nextCellY, cellZ)];
                        float v011 = cellBuffer[cellVolume.IndexUnchecked(cellX, nextCellY, nextCellZ)];
                        float v111 = cellBuffer[cellVolume.IndexUnchecked(nextCellX, nextCellY, nextCellZ)];
                        FillCell(output, volume, cellVolume, cellX, cellY, cellZ, v000, v100, v010, v110, v001, v101, v011, v111);
                        v000 = v010;
                        v100 = v110;
                        v001 = v011;
                        v101 = v111;
                    }
                }
            }
        }

        private void FillCell(DensityBuffer output, DensityVolume outputVolume, DensityVolume cellVolume, int cellX, int cellY, int cellZ,
            float v000, float v100, float v010, float v110, float v001, float v101, float v011, float v111) {

            int cellOutputX = cellVolume.BlockX(cellX) - outputVolume.MinBlockX;
            int cellOutputY = cellVolume.BlockY(cellY) - outputVolume.MinBlockY;
            int cellOutputZ = cellVolume.BlockZ(cellZ) - outputVolume.MinBlockZ;
            int x0 = Math.Max(0, -cellOutputX);
            int y0 = Math.Max(0, -cellOutputY);
            int z0 = Math.Max(0, -cellOutputZ);
            int x1 = Math.Min(CellSizeXz, outputVolume.SizeX - cellOutputX) - 1;
            int y1 = Math.Min(CellSizeY, outputVolume.SizeY - cellOutputY) - 1;
            int z1 = Math.Min(CellSizeXz, outputVolume.SizeZ - cellOutputZ) - 1;

            for (int z = z0; z <= z1; z++) {
                int outputZ = cellOutputZ + z;
                float alphaZ = z * CellSizeXzInv;
                float v00 = Mth.Lerp(alphaZ, v000, v001);
                float v01 = Mth.Lerp(alphaZ, v010, v011);
                float v10 = Mth.Lerp(alphaZ, v100, v101);
                float v11 = Mth.Lerp(alphaZ, v110, v111);

                for (int x = x0; x <= x1; x++) {
                    int outputX = cellOutputX + x;
                    float alphaX = x * CellSizeXzInv;
                    float bottom = Mth.Lerp(alphaX, v00, v10);
                    float top = Mth.Lerp(alphaX, v01, v11);
                    float valueStep = (top - bottom) * CellSizeYInv;
                    float value = bottom + valueStep * y0;
                    int outputIndex = outputVolume.IndexUnchecked(outputX, cellOutputY + y0, outputZ);

                    for (int y = y0; y <= y1; y++) {
                        output[outputIndex++] = value;
                        value += valueStep;
                    }
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            int xInCell = Mth.FloorMod(blockX, CellSizeXz);
            int yInCell = Mth.FloorMod(blockY, CellSizeY);
            int zInCell = Mth.FloorMod(blockZ, CellSizeXz);
            if (xInCell == 0 && yInCell == 0 && zInCell == 0) {
                return Input.SampleValue(context, blockX, blockY, blockZ);
            }

            DensityVolume volume = new(2, 2, 2, blockX - xInCell, blockY - yInCell, blockZ - zInCell, CellSizeXz, CellSizeY, CellSizeXz);
            using ScopedDensityBuffer inputBuffer = context.AcquireBuffer(volume);
            Input.SampleVolume(context, inputBuffer, volume);
            return Mth.Lerp3(
                (float)xInCell / CellSizeXz, (float)yInCell / CellSizeY, (float)zInCell / CellSizeXz,
                inputBuffer[volume.IndexUnchecked(0, 0, 0)], inputBuffer[volume.IndexUnchecked(1, 0, 0)],
                inputBuffer[volume.IndexUnchecked(0, 1, 0)], inputBuffer[volume.IndexUnchecked(1, 1, 0)],
                inputBuffer[volume.IndexUnchecked(0, 0, 1)], inputBuffer[volume.IndexUnchecked(1, 0, 1)],
                inputBuffer[volume.IndexUnchecked(0, 1, 1)], inputBuffer[volume.IndexUnchecked(1, 1, 1)]);
        }
    }
}

/// <summary>
/// The input with one coordinate pinned, vanilla's <c>SliceFunction</c>. A slice of x over a slice of
/// z, in either order, compiles to one sampler pinning both.
/// </summary>
public sealed record SliceFunction(Axis Axis, int Coordinate, IDensityFunction Input) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        if (Input is SliceFunction inner
            && ((Axis == Axis.X && inner.Axis == Axis.Z) || (Axis == Axis.Z && inner.Axis == Axis.X))) {
            int x = Axis == Axis.X ? Coordinate : inner.Coordinate;
            int z = Axis == Axis.X ? inner.Coordinate : Coordinate;
            return new XzSampler(inner.Input.CompileSampler(context), x, z);
        }

        IDensitySampler input = Input.CompileSampler(context);
        return Axis switch {
            Axis.X => new XSampler(input, Coordinate),
            Axis.Y => new YSampler(input, Coordinate),
            _ => new ZSampler(input, Coordinate)
        };
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        return ReferenceEquals(input, Input) ? this : this with { Input = input };
    }

    public Interval Range => Input.Range;

    public int DomainAxes => Input.DomainAxes & ~DensityAxes.From(Axis);

    private sealed record XSampler(IDensitySampler Input, int X) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            if (volume.SizeX == 1 && volume.MinBlockX == X) {
                Input.SampleVolume(context, output, volume);
                return;
            }

            DensityVolume inputVolume = new(1, volume.SizeY, volume.SizeZ, X, volume.MinBlockY, volume.MinBlockZ,
                volume.StepBlockX, volume.StepBlockY, volume.StepBlockZ);
            using ScopedDensityBuffer inputBuffer = context.AcquireBuffer(inputVolume);
            Input.SampleVolume(context, inputBuffer, inputVolume);
            int index = 0;
            for (int z = 0; z < volume.SizeZ; z++) {
                for (int x = 0; x < volume.SizeX; x++) {
                    for (int y = 0; y < volume.SizeY; y++) {
                        output[index++] = inputBuffer[inputVolume.IndexUnchecked(0, y, z)];
                    }
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Input.SampleValue(context, X, blockY, blockZ);
        }
    }

    private sealed record XzSampler(IDensitySampler Input, int X, int Z) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            if (volume.SizeX == 1 && volume.SizeZ == 1 && volume.MinBlockX == X && volume.MinBlockZ == Z) {
                Input.SampleVolume(context, output, volume);
                return;
            }

            DensityVolume inputVolume = new(1, volume.SizeY, 1, X, volume.MinBlockY, Z,
                volume.StepBlockX, volume.StepBlockY, volume.StepBlockZ);
            using ScopedDensityBuffer inputBuffer = context.AcquireBuffer(inputVolume);
            Input.SampleVolume(context, inputBuffer, inputVolume);
            for (int y = 0; y < volume.SizeY; y++) {
                float value = inputBuffer[inputVolume.IndexUnchecked(0, y, 0)];
                int index = volume.IndexUnchecked(0, y, 0);
                for (int z = 0; z < volume.SizeZ; z++) {
                    for (int x = 0; x < volume.SizeX; x++) {
                        output[index] = value;
                        index += volume.SizeY;
                    }
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Input.SampleValue(context, X, blockY, Z);
        }
    }

    public sealed record YSampler(IDensitySampler Input, int Y) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            if (volume.SizeY == 1 && volume.MinBlockY == Y) {
                Input.SampleVolume(context, output, volume);
                return;
            }

            DensityVolume inputVolume = new(volume.SizeX, 1, volume.SizeZ, volume.MinBlockX, Y, volume.MinBlockZ,
                volume.StepBlockX, volume.StepBlockY, volume.StepBlockZ);
            using ScopedDensityBuffer inputBuffer = context.AcquireBuffer(inputVolume);
            Input.SampleVolume(context, inputBuffer, inputVolume);
            for (int z = 0; z < volume.SizeZ; z++) {
                for (int x = 0; x < volume.SizeX; x++) {
                    output.SetRange(volume.IndexUnchecked(x, 0, z), volume.SizeY, inputBuffer[inputVolume.IndexUnchecked(x, 0, z)]);
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Input.SampleValue(context, blockX, Y, blockZ);
        }
    }

    private sealed record ZSampler(IDensitySampler Input, int Z) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            if (volume.SizeZ == 1 && volume.MinBlockZ == Z) {
                Input.SampleVolume(context, output, volume);
                return;
            }

            DensityVolume inputVolume = new(volume.SizeX, volume.SizeY, 1, volume.MinBlockX, volume.MinBlockY, Z,
                volume.StepBlockX, volume.StepBlockY, volume.StepBlockZ);
            using ScopedDensityBuffer inputBuffer = context.AcquireBuffer(inputVolume);
            Input.SampleVolume(context, inputBuffer, inputVolume);
            int index = 0;
            for (int z = 0; z < volume.SizeZ; z++) {
                for (int x = 0; x < volume.SizeX; x++) {
                    for (int y = 0; y < volume.SizeY; y++) {
                        output[index++] = inputBuffer[inputVolume.IndexUnchecked(x, y, 0)];
                    }
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Input.SampleValue(context, blockX, blockY, Z);
        }
    }
}

/// <summary>
/// The highest cell boundary below an upper bound where the density is positive, vanilla's
/// <c>FindTopSurfaceFunction</c>. It probes with point samples, and compiles under a y slice at 0.
/// </summary>
public sealed record FindTopSurfaceFunction(IDensityFunction Density, IDensityFunction UpperBound, int LowerBound, int CellHeight)
    : IDensityFunction {

    public IDensitySampler CompileSampler(ICompileContext context) {
        Sampler sampler = new(Density.CompileSampler(context), UpperBound.CompileSampler(context), LowerBound, CellHeight);
        return new SliceFunction.YSampler(sampler, 0);
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction density = rule.Rewrite(Density);
        IDensityFunction upperBound = rule.Rewrite(UpperBound);
        return ReferenceEquals(density, Density) && ReferenceEquals(upperBound, UpperBound)
            ? this
            : this with { Density = density, UpperBound = upperBound };
    }

    public Interval Range => Interval.Of(LowerBound, Math.Max(LowerBound, UpperBound.Range.Max));

    public int DomainAxes => (Density.DomainAxes | UpperBound.DomainAxes) & ~DensityAxes.Y;

    private sealed record Sampler(IDensitySampler Density, IDensitySampler UpperBound, int LowerBound, int CellHeight) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            if (volume.SizeY != 1) {
                throw new ArgumentException($"Cannot sample with sizeY={volume.SizeY}");
            }

            UpperBound.SampleVolume(context, output, volume);
            int index = 0;
            for (int z = 0; z < volume.SizeZ; z++) {
                int blockZ = volume.BlockZ(z);
                for (int x = 0; x < volume.SizeX; x++) {
                    output[index] = FindSurfaceFrom(context, volume.BlockX(x), blockZ, output[index]);
                    index++;
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return FindSurfaceFrom(context, blockX, blockZ, UpperBound.SampleValue(context, blockX, blockY, blockZ));
        }

        private int FindSurfaceFrom(SamplerContext context, int x, int z, float upperBound) {
            int topY = Mth.Floor(upperBound / CellHeight) * CellHeight;
            if (topY <= LowerBound) {
                return LowerBound;
            }

            for (int probeY = topY; probeY >= LowerBound; probeY -= CellHeight) {
                if (Density.SampleValue(context, x, probeY, z) > 0.0F) {
                    return probeY;
                }
            }

            return LowerBound;
        }
    }
}
