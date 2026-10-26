using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>Vanilla's <c>UnaryFunction.Type</c>.</summary>
public enum UnaryType {
    Abs,
    Square,
    Cube,
    Sqrt,
    HalfNegative,
    QuarterNegative,
    Reciprocal,
    Negate,
    Squeeze,
    Log,
    Sign
}

/// <summary>The one argument maps, vanilla's <c>UnaryFunction</c>. All float.</summary>
public sealed record UnaryFunction(UnaryType Type, IDensityFunction Input) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler input = Input.CompileSampler(context);
        return Type switch {
            UnaryType.HalfNegative => new LeakyReluSampler(input, 0.5F),
            UnaryType.QuarterNegative => new LeakyReluSampler(input, 0.25F),
            _ => new Sampler(Type, input)
        };
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        return ReferenceEquals(input, Input) ? this : this with { Input = input };
    }

    public Interval Range {
        get {
            Interval input = Input.Range;
            return Type switch {
                UnaryType.Abs => Interval.Abs(input),
                UnaryType.Square => Interval.Square(input),
                UnaryType.Cube => Interval.MapMonotonic(input, Mth.Cube),
                UnaryType.Sqrt => Interval.Pow(input, Interval.OfExact(0.5F)),
                UnaryType.HalfNegative => Interval.MapMonotonic(input, value => LeakyRelu(0.5F, value)),
                UnaryType.QuarterNegative => Interval.MapMonotonic(input, value => LeakyRelu(0.25F, value)),
                UnaryType.Reciprocal => Interval.Reciprocal(input),
                UnaryType.Negate => Interval.Sub(Interval.OfExact(0.0F), input),
                UnaryType.Squeeze => Interval.MapMonotonic(input, Squeeze),
                UnaryType.Log => Interval.Log(input),
                _ => Interval.Sign(input)
            };
        }
    }

    public int DomainAxes => Input.DomainAxes;

    private static float LeakyRelu(float negativeFactor, float input) => input > 0.0F ? input : input * negativeFactor;

    private static float Squeeze(float input) {
        float clamped = Mth.Clamp(input, -1.0F, 1.0F);
        return clamped / 2.0F - Mth.Cube(clamped) / 24.0F;
    }

    public static float Apply(UnaryType type, float value) {
        return type switch {
            UnaryType.Abs => Math.Abs(value),
            UnaryType.Square => value * value,
            UnaryType.Cube => Mth.Cube(value),
            UnaryType.Sqrt => Mth.Sqrt(value),
            UnaryType.HalfNegative => LeakyRelu(0.5F, value),
            UnaryType.QuarterNegative => LeakyRelu(0.25F, value),
            UnaryType.Reciprocal => 1.0F / value,
            UnaryType.Negate => -value,
            UnaryType.Squeeze => Squeeze(value),
            UnaryType.Log => (float)Math.Log(value),
            _ => JavaMath.Signum(value)
        };
    }

    /// <summary>
    /// The plain maps share one sampler here where upstream has one class each; the arithmetic per
    /// value is the same expression.
    /// </summary>
    public sealed record Sampler(UnaryType Type, IDensitySampler Input) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Apply(Type, output[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Apply(Type, Input.SampleValue(context, blockX, blockY, blockZ));
        }
    }

    private sealed record LeakyReluSampler(IDensitySampler Input, float NegativeFactor) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = LeakyRelu(NegativeFactor, output[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return LeakyRelu(NegativeFactor, Input.SampleValue(context, blockX, blockY, blockZ));
        }
    }
}

/// <summary>Vanilla's <c>RoundFunction.Type</c>.</summary>
public enum RoundType {
    Floor,
    Round,
    Ceil,
    Truncate
}

/// <summary>
/// Rounding to a multiple, vanilla's <c>RoundFunction</c>. A multiple of zero passes the input through,
/// and a constant multiple of one compiles to the integer form.
/// </summary>
public sealed record RoundFunction(RoundType Type, IDensityFunction Input, IDensityFunction Multiple) : IDensityFunction {
    /// <summary><c>Math.round(float)</c> rounds half up, not to even.</summary>
    private static float RoundToInteger(float input, RoundType type) {
        return type switch {
            RoundType.Floor => (float)Math.Floor(input),
            RoundType.Round => Mth.JavaRound(input),
            RoundType.Ceil => (float)Math.Ceiling(input),
            _ => input > 0.0F ? (float)Math.Floor(input) : (float)Math.Ceiling(input)
        };
    }

    private static float Apply(RoundType type, float input, float multiple) {
        return multiple == 0.0F ? input : RoundToInteger(input / multiple, type) * multiple;
    }

    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler input = Input.CompileSampler(context);
        if (Multiple is ConstantFunction { Value: 1.0F }) {
            return new IntegerMultipleSampler(Type, input);
        }

        return new Sampler(Type, input, Multiple.CompileSampler(context));
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        IDensityFunction multiple = rule.Rewrite(Multiple);
        return ReferenceEquals(input, Input) && ReferenceEquals(multiple, Multiple) ? this : this with { Input = input, Multiple = multiple };
    }

    public Interval Range {
        get {
            Interval multipleRange = Multiple.Range;
            return Interval.Mul(Interval.MapMonotonic(Interval.Div(Input.Range, multipleRange), value => RoundToInteger(value, Type)),
                multipleRange);
        }
    }

    public int DomainAxes => Input.DomainAxes | Multiple.DomainAxes;

    private sealed record IntegerMultipleSampler(RoundType Type, IDensitySampler Input) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = RoundToInteger(output[i], Type);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return RoundToInteger(Input.SampleValue(context, blockX, blockY, blockZ), Type);
        }
    }

    private sealed record Sampler(RoundType Type, IDensitySampler Input, IDensitySampler Multiple) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            using ScopedDensityBuffer multipleBuffer = context.AcquireBuffer(volume);
            Multiple.SampleVolume(context, multipleBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Apply(Type, output[i], multipleBuffer[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float input = Input.SampleValue(context, blockX, blockY, blockZ);
            float multiple = Multiple.SampleValue(context, blockX, blockY, blockZ);
            return Apply(Type, input, multiple);
        }
    }
}

/// <summary>
/// Vanilla's <c>PowFunction</c>. A constant exponent of magnitude a half, one, two or three compiles to
/// the matching map, under a reciprocal when it is negative; anything else goes through double
/// <c>Math.pow</c>.
/// </summary>
public sealed record PowFunction(IDensityFunction Base, IDensityFunction Exponent) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler baseSampler = Base.CompileSampler(context);
        IDensitySampler exponent = Exponent.CompileSampler(context);
        if (Base is ConstantFunction constantBase) {
            return new ConstBaseSampler(constantBase.Value, exponent);
        }

        if (Exponent is ConstantFunction constantExponent) {
            return CompileConstExponent(baseSampler, constantExponent.Value);
        }

        return new Sampler(baseSampler, exponent);
    }

    private static IDensitySampler CompileConstExponent(IDensitySampler baseSampler, float exponent) {
        float absExponent = Math.Abs(exponent);
        IDensitySampler special;
        if (absExponent == 0.5F) {
            special = new UnaryFunction.Sampler(UnaryType.Sqrt, baseSampler);
        } else if (absExponent == 1.0F) {
            special = baseSampler;
        } else if (absExponent == 2.0F) {
            special = new UnaryFunction.Sampler(UnaryType.Square, baseSampler);
        } else if (absExponent == 3.0F) {
            special = new UnaryFunction.Sampler(UnaryType.Cube, baseSampler);
        } else {
            return new ConstExponentSampler(baseSampler, exponent);
        }

        return exponent >= 0.0F ? special : new UnaryFunction.Sampler(UnaryType.Reciprocal, special);
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction baseFunction = rule.Rewrite(Base);
        IDensityFunction exponent = rule.Rewrite(Exponent);
        return ReferenceEquals(baseFunction, Base) && ReferenceEquals(exponent, Exponent) ? this : new PowFunction(baseFunction, exponent);
    }

    public Interval Range => Interval.Pow(Base.Range, Exponent.Range);

    public int DomainAxes => Base.DomainAxes | Exponent.DomainAxes;

    private sealed record ConstBaseSampler(double Base, IDensitySampler Exponent) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Exponent.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = (float)Math.Pow(Base, output[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return (float)Math.Pow(Base, Exponent.SampleValue(context, blockX, blockY, blockZ));
        }
    }

    private sealed record ConstExponentSampler(IDensitySampler Base, double Exponent) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Base.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = (float)Math.Pow(output[i], Exponent);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return (float)Math.Pow(Base.SampleValue(context, blockX, blockY, blockZ), Exponent);
        }
    }

    private sealed record Sampler(IDensitySampler Base, IDensitySampler Exponent) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Base.SampleVolume(context, output, volume);
            using ScopedDensityBuffer exponentBuffer = context.AcquireBuffer(volume);
            Exponent.SampleVolume(context, exponentBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = (float)Math.Pow(output[i], exponentBuffer[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return (float)Math.Pow(Base.SampleValue(context, blockX, blockY, blockZ), Exponent.SampleValue(context, blockX, blockY, blockZ));
        }
    }
}

/// <summary>Vanilla's <c>ClampFunction</c>.</summary>
public sealed record ClampFunction(IDensityFunction Input, float Min, float Max) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) => new Sampler(Input.CompileSampler(context), Min, Max);

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        return ReferenceEquals(input, Input) ? this : this with { Input = input };
    }

    public Interval Range => Interval.Clamp(Input.Range, Min, Max);

    public int DomainAxes => Input.DomainAxes;

    public sealed record Sampler(IDensitySampler Input, float Min, float Max) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Mth.Clamp(output[i], Min, Max);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Mth.Clamp(Input.SampleValue(context, blockX, blockY, blockZ), Min, Max);
        }
    }
}

/// <summary>
/// Vanilla's <c>LerpFunction</c>. An alpha of exactly zero or one takes that side without evaluating
/// the other on the point path; the volume path evaluates all three.
/// </summary>
public sealed record LerpFunction(IDensityFunction Alpha, IDensityFunction First, IDensityFunction Second) : IDensityFunction {
    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler alpha = Alpha.CompileSampler(context);
        IDensitySampler first = First.CompileSampler(context);
        IDensitySampler second = Second.CompileSampler(context);
        if (First is ConstantFunction constantFirst) {
            return new ConstFirstSampler(alpha, constantFirst.Value, second);
        }

        if (Second is ConstantFunction constantSecond) {
            return new ConstSecondSampler(alpha, first, constantSecond.Value);
        }

        return new Sampler(alpha, first, second);
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction alpha = rule.Rewrite(Alpha);
        IDensityFunction first = rule.Rewrite(First);
        IDensityFunction second = rule.Rewrite(Second);
        return ReferenceEquals(alpha, Alpha) && ReferenceEquals(first, First) && ReferenceEquals(second, Second)
            ? this
            : new LerpFunction(alpha, first, second);
    }

    public Interval Range => Interval.Lerp(Alpha.Range, First.Range, Second.Range);

    public int DomainAxes => Alpha.DomainAxes | First.DomainAxes | Second.DomainAxes;

    private static float Choose(float alpha, float first, float second) {
        if (alpha == 0.0F) {
            return first;
        }

        return alpha == 1.0F ? second : Mth.Lerp(alpha, first, second);
    }

    public sealed record ConstFirstSampler(IDensitySampler Alpha, float First, IDensitySampler Second) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Alpha.SampleVolume(context, output, volume);
            using ScopedDensityBuffer secondBuffer = context.AcquireBuffer(volume);
            Second.SampleVolume(context, secondBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Choose(output[i], First, secondBuffer[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float alpha = Alpha.SampleValue(context, blockX, blockY, blockZ);
            if (alpha == 0.0F) {
                return First;
            }

            return alpha == 1.0F
                ? Second.SampleValue(context, blockX, blockY, blockZ)
                : Mth.Lerp(alpha, First, Second.SampleValue(context, blockX, blockY, blockZ));
        }
    }

    public sealed record ConstSecondSampler(IDensitySampler Alpha, IDensitySampler First, float Second) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Alpha.SampleVolume(context, output, volume);
            using ScopedDensityBuffer firstBuffer = context.AcquireBuffer(volume);
            First.SampleVolume(context, firstBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Choose(output[i], firstBuffer[i], Second);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float alpha = Alpha.SampleValue(context, blockX, blockY, blockZ);
            if (alpha == 0.0F) {
                return First.SampleValue(context, blockX, blockY, blockZ);
            }

            return alpha == 1.0F ? Second : Mth.Lerp(alpha, First.SampleValue(context, blockX, blockY, blockZ), Second);
        }
    }

    public sealed record Sampler(IDensitySampler Alpha, IDensitySampler First, IDensitySampler Second) : IDensitySampler {
        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Alpha.SampleVolume(context, output, volume);
            using ScopedDensityBuffer firstBuffer = context.AcquireBuffer(volume);
            First.SampleVolume(context, firstBuffer, volume);
            using ScopedDensityBuffer secondBuffer = context.AcquireBuffer(volume);
            Second.SampleVolume(context, secondBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Choose(output[i], firstBuffer[i], secondBuffer[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float alpha = Alpha.SampleValue(context, blockX, blockY, blockZ);
            if (alpha == 0.0F) {
                return First.SampleValue(context, blockX, blockY, blockZ);
            }

            return alpha == 1.0F
                ? Second.SampleValue(context, blockX, blockY, blockZ)
                : Mth.Lerp(alpha, First.SampleValue(context, blockX, blockY, blockZ), Second.SampleValue(context, blockX, blockY, blockZ));
        }
    }
}

/// <summary>
/// Vanilla's <c>RangeChoiceFunction</c>. The volume path fills from the in range side and overwrites
/// with the other wherever the input is out of range or NaN.
/// </summary>
public sealed record RangeChoiceFunction(IDensityFunction Input, float MinInclusive, float MaxExclusive,
    IDensityFunction WhenInRange, IDensityFunction WhenOutOfRange) : IDensityFunction {

    public IDensitySampler CompileSampler(ICompileContext context) {
        IDensitySampler input = Input.CompileSampler(context);
        if (WhenInRange is ConstantFunction inRange && WhenOutOfRange is ConstantFunction outOfRange) {
            return new ConstSampler(input, MinInclusive, MaxExclusive, inRange.Value, outOfRange.Value);
        }

        return new Sampler(input, MinInclusive, MaxExclusive, WhenInRange.CompileSampler(context), WhenOutOfRange.CompileSampler(context));
    }

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction input = rule.Rewrite(Input);
        IDensityFunction whenInRange = rule.Rewrite(WhenInRange);
        IDensityFunction whenOutOfRange = rule.Rewrite(WhenOutOfRange);
        return ReferenceEquals(input, Input) && ReferenceEquals(whenInRange, WhenInRange) && ReferenceEquals(whenOutOfRange, WhenOutOfRange)
            ? this
            : this with { Input = input, WhenInRange = whenInRange, WhenOutOfRange = whenOutOfRange };
    }

    public Interval Range => Interval.Encapsulating(WhenInRange.Range, WhenOutOfRange.Range);

    public int DomainAxes => Input.DomainAxes | WhenInRange.DomainAxes | WhenOutOfRange.DomainAxes;

    private sealed record ConstSampler(IDensitySampler Input, float MinInclusive, float MaxExclusive, float WhenInRange, float WhenOutOfRange)
        : IDensitySampler {

        private float Choose(float input) => input >= MinInclusive && input < MaxExclusive ? WhenInRange : WhenOutOfRange;

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            Input.SampleVolume(context, output, volume);
            for (int i = 0; i < output.Size; i++) {
                output[i] = Choose(output[i]);
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            return Choose(Input.SampleValue(context, blockX, blockY, blockZ));
        }
    }

    private sealed record Sampler(IDensitySampler Input, float MinInclusive, float MaxExclusive,
        IDensitySampler WhenInRange, IDensitySampler WhenOutOfRange) : IDensitySampler {

        public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
            WhenInRange.SampleVolume(context, output, volume);
            using ScopedDensityBuffer inputBuffer = context.AcquireBuffer(volume);
            Input.SampleVolume(context, inputBuffer, volume);
            using ScopedDensityBuffer outOfRangeBuffer = context.AcquireBuffer(volume);
            WhenOutOfRange.SampleVolume(context, outOfRangeBuffer, volume);
            for (int i = 0; i < output.Size; i++) {
                float input = inputBuffer[i];
                if (!(input >= MinInclusive) || !(input < MaxExclusive)) {
                    output[i] = outOfRangeBuffer[i];
                }
            }
        }

        public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
            float input = Input.SampleValue(context, blockX, blockY, blockZ);
            return input >= MinInclusive && input < MaxExclusive
                ? WhenInRange.SampleValue(context, blockX, blockY, blockZ)
                : WhenOutOfRange.SampleValue(context, blockX, blockY, blockZ);
        }
    }
}
