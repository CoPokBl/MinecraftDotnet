using Minecraft.Schemas;

namespace Minecraft.Data.Loot;

/// <summary>
/// Vanilla's <c>NumberProvider</c>. Only the three the block tables use are here; the rest
/// (scoreboard values, storage, enchantment levels) need a world or a scoreboard and no block table
/// asks for one, so <c>LootTableCodeGen</c> fails the build rather than letting one through.
/// </summary>
public interface INumberProvider {
    public float GetFloat(LootContext context);

    /// <summary>
    /// <c>NumberProvider.getInt</c>, which is <c>Math.round</c> and not a truncation or a floor. See
    /// <see cref="Mth.JavaRound"/> for why that cannot be <see cref="Math.Round(double)"/>.
    /// </summary>
    public int GetInt(LootContext context) {
        return Mth.JavaRound(GetFloat(context));
    }
}

/// <summary><c>ConstantValue</c>.</summary>
public sealed record ConstantValue(float Value) : INumberProvider {
    public float GetFloat(LootContext context) {
        return Value;
    }
}

/// <summary>
/// <c>UniformGenerator</c>. Inclusive at both ends for the int form, because it goes through
/// <c>Mth.nextInt</c> rather than <c>RandomSource.nextInt(min, max)</c>.
/// </summary>
public sealed record UniformGenerator(INumberProvider Min, INumberProvider Max) : INumberProvider {
    public float GetFloat(LootContext context) {
        return Mth.NextFloat(context.Random, Min.GetFloat(context), Max.GetFloat(context));
    }

    public int GetInt(LootContext context) {
        return Mth.NextInt(context.Random, Min.GetInt(context), Max.GetInt(context));
    }
}

/// <summary>
/// <c>BinomialDistributionGenerator</c>: n trials at probability p. Its float form is its int form,
/// not the other way round, so the rounding in <see cref="INumberProvider.GetInt"/> never applies.
/// </summary>
public sealed record BinomialDistributionGenerator(INumberProvider N, INumberProvider P) : INumberProvider {
    public float GetFloat(LootContext context) {
        return GetInt(context);
    }

    public int GetInt(LootContext context) {
        int n = N.GetInt(context);
        float p = P.GetFloat(context);
        int result = 0;

        for (int i = 0; i < n; i++) {
            if (context.Random.NextFloat() < p) {
                result++;
            }
        }

        return result;
    }
}

/// <summary>
/// <c>IntRange</c>, the pair of optional bounds <c>limit_count</c> clamps with. Either end may be
/// absent, which is a one sided clamp rather than a bound of zero.
/// </summary>
public sealed record IntRange(INumberProvider? Min, INumberProvider? Max) {
    public int Clamp(LootContext context, int value) {
        if (Min != null && value < Min.GetInt(context)) {
            value = Min.GetInt(context);
        }

        if (Max != null && value > Max.GetInt(context)) {
            value = Max.GetInt(context);
        }

        return value;
    }
}
