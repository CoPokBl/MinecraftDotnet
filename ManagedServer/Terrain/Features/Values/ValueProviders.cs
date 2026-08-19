using Minecraft.Schemas;

namespace ManagedServer.Terrain.Features.Values;

/// <summary>
/// <c>IntProvider</c>: a number a feature draws rather than a constant one.
/// </summary>
/// <remarks>
/// <see cref="MinInclusive"/> and <see cref="MaxInclusive"/> are vanilla's validation bounds rather
/// than a hint. Nothing here reads them at generation time; they exist so a provider that cannot
/// produce a legal value is rejected when the datapack is parsed rather than producing a block
/// somewhere it should never be.
/// </remarks>
public interface IIntProvider {
    int Sample(RandomSource random);

    int MinInclusive { get; }

    int MaxInclusive { get; }
}

/// <summary><c>FloatProvider</c>.</summary>
public interface IFloatProvider {
    float Sample(RandomSource random);

    float Min { get; }

    float Max { get; }
}

/// <summary>Every <c>IntProvider</c> in the vanilla data.</summary>
public static class IntProviders {
    /// <summary><c>ConstantInt</c>.</summary>
    public sealed record Constant(int Value) : IIntProvider {
        public int Sample(RandomSource random) => Value;
        public int MinInclusive => Value;
        public int MaxInclusive => Value;
    }

    /// <summary><c>UniformInt</c>: flat over the closed range.</summary>
    public sealed record Uniform(int MinInclusive, int MaxInclusive) : IIntProvider {
        public int Sample(RandomSource random) {
            return random.NextIntBetweenInclusive(MinInclusive, MaxInclusive);
        }
    }

    /// <summary>
    /// <c>BiasedToBottomInt</c>: two nested draws, so low values are far more likely than high ones.
    /// </summary>
    public sealed record BiasedToBottom(int MinInclusive, int MaxInclusive) : IIntProvider {
        public int Sample(RandomSource random) {
            return MinInclusive + random.NextInt(random.NextInt(MaxInclusive - MinInclusive + 1) + 1);
        }
    }

    /// <summary><c>ClampedInt</c>.</summary>
    public sealed record Clamped(IIntProvider Source, int Low, int High) : IIntProvider {
        public int Sample(RandomSource random) => Mth.Clamp(Source.Sample(random), Low, High);

        public int MinInclusive => Math.Max(Low, Source.MinInclusive);
        public int MaxInclusive => Math.Min(High, Source.MaxInclusive);
    }

    /// <summary><c>ClampedNormalInt</c>: a gaussian, clamped, then truncated towards zero.</summary>
    /// <remarks>
    /// The cast is vanilla's and is a truncation rather than a round, so the distribution is not
    /// symmetric about the mean once it crosses zero.
    /// </remarks>
    public sealed record ClampedNormal(float Mean, float Deviation, int MinInclusive, int MaxInclusive)
        : IIntProvider {

        public int Sample(RandomSource random) {
            return (int)Mth.Clamp(Normal(random, Mean, Deviation), MinInclusive, MaxInclusive);
        }
    }

    /// <summary>
    /// <c>TrapezoidInt</c>: flat across a plateau in the middle and falling off linearly either side.
    /// </summary>
    /// <remarks>
    /// The three branches are vanilla's and are not one formula: a symmetric triangle is two draws of
    /// the same bound subtracted, a full plateau is a plain uniform, and only the general case is the
    /// sum of two ranges.
    /// </remarks>
    public sealed record Trapezoid(int MinInclusive, int MaxInclusive, int Plateau) : IIntProvider {
        public int Sample(RandomSource random) {
            if (Plateau == 0 && MaxInclusive == -MinInclusive) {
                return random.NextInt(MaxInclusive + 1) - random.NextInt(MaxInclusive + 1);
            }

            int range = MaxInclusive - MinInclusive;
            if (Plateau == range) {
                return random.NextIntBetweenInclusive(MinInclusive, MaxInclusive);
            }

            int plateauStart = (range - Plateau) / 2;
            int plateauEnd = range - plateauStart;
            return MinInclusive + random.NextIntBetweenInclusive(0, plateauEnd)
                + random.NextIntBetweenInclusive(0, plateauStart);
        }
    }

    /// <summary><c>WeightedListInt</c>: pick a provider by weight, then sample it.</summary>
    public sealed class WeightedList(WeightedList<IIntProvider> distribution) : IIntProvider {
        public int Sample(RandomSource random) => distribution.GetRandomOrThrow(random).Sample(random);

        public int MinInclusive { get; } = distribution.Values.Min(v => v.MinInclusive);
        public int MaxInclusive { get; } = distribution.Values.Max(v => v.MaxInclusive);
    }

    /// <summary><c>Mth.normal</c>, which is shared with the float providers.</summary>
    internal static float Normal(RandomSource random, float mean, float deviation) {
        return mean + (float)random.NextGaussian() * deviation;
    }
}

/// <summary>Every <c>FloatProvider</c> in the vanilla data.</summary>
public static class FloatProviders {
    /// <summary><c>ConstantFloat</c>.</summary>
    public sealed record Constant(float Value) : IFloatProvider {
        public float Sample(RandomSource random) => Value;
        public float Min => Value;
        public float Max => Value;
    }

    /// <summary><c>UniformFloat</c>.</summary>
    public sealed record Uniform(float Min, float Max) : IFloatProvider {
        public float Sample(RandomSource random) => Mth.RandomBetween(random, Min, Max);
    }

    /// <summary><c>ClampedNormalFloat</c>.</summary>
    public sealed record ClampedNormal(float Mean, float Deviation, float Min, float Max) : IFloatProvider {
        public float Sample(RandomSource random) {
            return Mth.Clamp(IntProviders.Normal(random, Mean, Deviation), Min, Max);
        }
    }

    /// <summary>
    /// <c>TrapezoidFloat</c>. Unlike the int form this has no special cases: it is always the sum of
    /// two scaled draws.
    /// </summary>
    public sealed record Trapezoid(float Min, float Max, float Plateau) : IFloatProvider {
        public float Sample(RandomSource random) {
            float range = Max - Min;
            float plateauStart = (range - Plateau) / 2.0f;
            float plateauEnd = range - plateauStart;
            return Min + random.NextFloat() * plateauEnd + random.NextFloat() * plateauStart;
        }
    }
}
