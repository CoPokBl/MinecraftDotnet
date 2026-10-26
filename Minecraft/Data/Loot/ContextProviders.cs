using Minecraft.Schemas;

namespace Minecraft.Data.Loot;

/// <summary>
/// Vanilla's <c>ContextIntProvider</c>. Only the three the block tables use are here: constant,
/// uniform and binomial. The rest (arithmetic, dispatchers, scores, storage) are refused by the parser
/// rather than read as something they are not.
/// </summary>
public interface IContextIntProvider {
    /// <summary><c>getIntUnsafe</c>: may throw <see cref="ArithmeticException"/>.</summary>
    public int GetIntUnsafe(LootContext context);

    /// <summary><c>ContextIntProvider.getInt</c>: an arithmetic failure anywhere below answers zero.</summary>
    public int GetInt(LootContext context) {
        try {
            return GetIntUnsafe(context);
        }
        catch (ArithmeticException) {
            return 0;
        }
    }
}

/// <summary>
/// Vanilla's <c>ContextFloatProvider</c>, cut the same way as <see cref="IContextIntProvider"/>.
/// </summary>
public interface IContextFloatProvider {
    /// <summary><c>getFloatUnsafe</c>: may throw <see cref="ArithmeticException"/> or be non finite.</summary>
    public float GetFloatUnsafe(LootContext context);

    /// <summary><c>ContextFloatProvider.getFloat</c>: a non finite result or a failure answers zero.</summary>
    public float GetFloat(LootContext context) {
        try {
            float result = GetFloatUnsafe(context);
            if (float.IsFinite(result)) {
                return result;
            }
        }
        catch (ArithmeticException) {
        }

        return 0.0f;
    }

    /// <summary><c>ContextFloatProvider.getFloatOrThrow</c>.</summary>
    public float GetFloatOrThrow(LootContext context) {
        float value = GetFloatUnsafe(context);
        if (!float.IsFinite(value)) {
            throw new ArithmeticException($"Invalid value: {value}");
        }

        return value;
    }
}

/// <summary><c>ints.ConstantValue</c>.</summary>
public sealed record ConstantInt(int Value) : IContextIntProvider {
    public int GetIntUnsafe(LootContext context) => Value;
}

/// <summary>
/// <c>ints.UniformGenerator</c>. Inclusive at both ends, because it goes through <c>Mth.nextInt</c>
/// rather than <c>RandomSource.nextInt(min, max)</c>.
/// </summary>
public sealed record UniformInt(IContextIntProvider Min, IContextIntProvider Max) : IContextIntProvider {
    public int GetIntUnsafe(LootContext context) {
        return Mth.NextInt(context.Random, Min.GetIntUnsafe(context), Max.GetIntUnsafe(context));
    }
}

/// <summary><c>ints.BinomialDistributionGenerator</c>: n trials at probability p.</summary>
public sealed record BinomialInt(IContextIntProvider N, IContextFloatProvider P) : IContextIntProvider {
    public int GetIntUnsafe(LootContext context) {
        int n = N.GetIntUnsafe(context);
        float p = P.GetFloatOrThrow(context);
        int result = 0;
        for (int i = 0; i < n; i++) {
            if (context.Random.NextFloat() < p) {
                result++;
            }
        }

        return result;
    }
}

/// <summary><c>floats.ConstantValue</c>.</summary>
public sealed record ConstantFloat(float Value) : IContextFloatProvider {
    public float GetFloatUnsafe(LootContext context) => Value;
}

/// <summary><c>floats.UniformGenerator</c>.</summary>
public sealed record UniformFloat(IContextFloatProvider Min, IContextFloatProvider Max) : IContextFloatProvider {
    public float GetFloatUnsafe(LootContext context) {
        return Mth.NextFloat(context.Random, Min.GetFloatUnsafe(context), Max.GetFloatUnsafe(context));
    }
}

/// <summary>
/// <c>IntLimit</c>, the pair of optional bounds <c>limit_count</c> clamps with. Either end may be
/// absent, which is a one sided clamp rather than a bound of zero. Each bound is asked once per clamp,
/// minimum first, which is what <c>IntLimit.createLimiter</c> does and what matters for a bound that
/// draws.
/// </summary>
public sealed record IntLimit(IContextIntProvider? Min, IContextIntProvider? Max) {
    public int Clamp(LootContext context, int value) {
        if (Min == null) {
            return Max == null ? value : Math.Min(Max.GetInt(context), value);
        }

        int min = Min.GetInt(context);
        if (Max == null) {
            return Math.Max(min, value);
        }

        return Math.Min(Math.Max(value, min), Max.GetInt(context));
    }
}
