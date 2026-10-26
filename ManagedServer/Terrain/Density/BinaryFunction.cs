using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>Vanilla's <c>BinaryFunction.Type</c>.</summary>
public enum BinaryType {
    Add,
    Sub,
    Mul,
    Div,
    Min,
    Max
}

/// <summary>
/// The two argument nodes, vanilla's <c>BinaryFunction</c>.
/// </summary>
/// <remarks>
/// A constant operand compiles to a specialised sampler, and <c>x / c</c> becomes a multiplication by
/// the float reciprocal, not a division. <c>min</c> and <c>max</c> compile to one side alone when the
/// ranges cannot overlap, which upstream also logs. The point paths of <c>mul</c>, <c>div</c>, <c>min</c> and <c>max</c> skip
/// the right side when the left decides the answer; the volume paths always evaluate both, and keep
/// the other side with a comparison rather than <c>Math.Min</c>, so NaN behaves differently there.
/// </remarks>
public sealed record BinaryFunction(BinaryType Type, IDensityFunction Left, IDensityFunction Right) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler left = Left.CompileSampler(context);
        IDensitySampler right = Right.CompileSampler(context);

        switch (Type) {
            case BinaryType.Add:
                if (Left is ConstantFunction addLeft) {
                    return new ConstAddSampler(right, addLeft.Value);
                }

                if (Right is ConstantFunction addRight) {
                    return new ConstAddSampler(left, addRight.Value);
                }

                return new AddSampler(left, right);

            case BinaryType.Sub:
                if (Left is ConstantFunction subLeft) {
                    return new ConstSubSampler(subLeft.Value, right);
                }

                if (Right is ConstantFunction subRight) {
                    return new ConstAddSampler(left, -subRight.Value);
                }

                return new SubSampler(left, right);

            case BinaryType.Mul:
                if (Left is ConstantFunction mulLeft) {
                    return new ConstMulSampler(right, mulLeft.Value);
                }

                if (Right is ConstantFunction mulRight) {
                    return new ConstMulSampler(left, mulRight.Value);
                }

                return new MulSampler(left, right);

            case BinaryType.Div:
                if (Left is ConstantFunction divLeft) {
                    return new ConstDivSampler(divLeft.Value, right);
                }

                if (Right is ConstantFunction divRight) {
                    return new ConstMulSampler(left, 1.0F / divRight.Value);
                }

                return new DivSampler(left, right);

            case BinaryType.Min: {
                Interval leftRange = Left.Range;
                Interval rightRange = Right.Range;
                if (leftRange.Max < rightRange.Min) {
                    return left;
                }

                if (rightRange.Max < leftRange.Min) {
                    return right;
                }

                if (Left is ConstantFunction minLeft) {
                    return new ConstMinSampler(right, minLeft.Value);
                }

                if (Right is ConstantFunction minRight) {
                    return new ConstMinSampler(left, minRight.Value);
                }

                return new MinSampler(left, right, rightRange.Min);
            }

            default: {
                Interval leftRange = Left.Range;
                Interval rightRange = Right.Range;
                if (leftRange.Min > rightRange.Max) {
                    return left;
                }

                if (rightRange.Min > leftRange.Max) {
                    return right;
                }

                if (Left is ConstantFunction maxLeft) {
                    return new ConstMaxSampler(right, maxLeft.Value);
                }

                if (Right is ConstantFunction maxRight) {
                    return new ConstMaxSampler(left, maxRight.Value);
                }

                return new MaxSampler(left, right, rightRange.Max);
            }
        }
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction left = rule.Rewrite(Left);
        IDensityFunction right = rule.Rewrite(Right);
        return ReferenceEquals(left, Left) && ReferenceEquals(right, Right) ? this : this with { Left = left, Right = right };
    }

    public Interval Range {
        get {
            Interval left = Left.Range;
            Interval right = Right.Range;
            return Type switch {
                BinaryType.Add => Interval.Add(left, right),
                BinaryType.Sub => Interval.Sub(left, right),
                BinaryType.Mul => Interval.Mul(left, right),
                BinaryType.Div => Interval.Div(left, right),
                BinaryType.Min => Interval.MinOf(left, right),
                _ => Interval.MaxOf(left, right)
            };
        }
    }

    public int DomainAxes => Left.DomainAxes | Right.DomainAxes;

    public sealed record AddSampler(IDensitySampler Left, IDensitySampler Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            using ScopedDensityBuffer rightBuffer = context.AcquireBuffer(volume);
            Right.SampleVolume(context, rightBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output.AddTo(i, rightBuffer[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Left.SampleValue(context, blockX, blockY, blockZ) + Right.SampleValue(context, blockX, blockY, blockZ);
        }
    }

    public sealed record ConstAddSampler(IDensitySampler Left, float Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output.AddTo(i, Right);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Left.SampleValue(context, blockX, blockY, blockZ) + Right;
        }
    }

    public sealed record ConstDivSampler(float Left, IDensitySampler Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Right.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Left / output[i];
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Left / Right.SampleValue(context, blockX, blockY, blockZ);
        }
    }

    public sealed record ConstMaxSampler(IDensitySampler Left, float Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                if (Right > output[i]) {
                    output[i] = Right;
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Math.Max(Left.SampleValue(context, blockX, blockY, blockZ), Right);
        }
    }

    public sealed record ConstMinSampler(IDensitySampler Left, float Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                if (Right < output[i]) {
                    output[i] = Right;
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Math.Min(Left.SampleValue(context, blockX, blockY, blockZ), Right);
        }
    }

    public sealed record ConstMulSampler(IDensitySampler Left, float Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = output[i] * Right;
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Left.SampleValue(context, blockX, blockY, blockZ) * Right;
        }
    }

    public sealed record ConstSubSampler(float Left, IDensitySampler Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Right.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Left - output[i];
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Left - Right.SampleValue(context, blockX, blockY, blockZ);
        }
    }

    public sealed record DivSampler(IDensitySampler Left, IDensitySampler Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            using ScopedDensityBuffer rightBuffer = context.AcquireBuffer(volume);
            Right.SampleVolume(context, rightBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = output[i] / rightBuffer[i];
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float left = Left.SampleValue(context, blockX, blockY, blockZ);
            return left == 0.0F ? 0.0F : left / Right.SampleValue(context, blockX, blockY, blockZ);
        }
    }

    public sealed record MaxSampler(IDensitySampler Left, IDensitySampler Right, float RightMaxValue) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            using ScopedDensityBuffer rightBuffer = context.AcquireBuffer(volume);
            Right.SampleVolume(context, rightBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                float rightValue = rightBuffer[i];
                if (rightValue > output[i]) {
                    output[i] = rightValue;
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float left = Left.SampleValue(context, blockX, blockY, blockZ);
            return left >= RightMaxValue ? left : Math.Max(left, Right.SampleValue(context, blockX, blockY, blockZ));
        }
    }

    public sealed record MinSampler(IDensitySampler Left, IDensitySampler Right, float RightMinValue) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            using ScopedDensityBuffer rightBuffer = context.AcquireBuffer(volume);
            Right.SampleVolume(context, rightBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                float rightValue = rightBuffer[i];
                if (rightValue < output[i]) {
                    output[i] = rightValue;
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float left = Left.SampleValue(context, blockX, blockY, blockZ);
            return left <= RightMinValue ? left : Math.Min(left, Right.SampleValue(context, blockX, blockY, blockZ));
        }
    }

    public sealed record MulSampler(IDensitySampler Left, IDensitySampler Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            using ScopedDensityBuffer rightBuffer = context.AcquireBuffer(volume);
            Right.SampleVolume(context, rightBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = output[i] * rightBuffer[i];
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float left = Left.SampleValue(context, blockX, blockY, blockZ);
            return left == 0.0F ? 0.0F : left * Right.SampleValue(context, blockX, blockY, blockZ);
        }
    }

    public sealed record SubSampler(IDensitySampler Left, IDensitySampler Right) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Left.SampleVolume(context, output, volume);
            using ScopedDensityBuffer rightBuffer = context.AcquireBuffer(volume);
            Right.SampleVolume(context, rightBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output.AddTo(i, -rightBuffer[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Left.SampleValue(context, blockX, blockY, blockZ) - Right.SampleValue(context, blockX, blockY, blockZ);
        }
    }
}
