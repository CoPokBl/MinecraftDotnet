namespace Minecraft.Schemas;

/// <summary>
/// Vanilla's <c>RandomSource</c>, which is <b>not</b> <see cref="Random"/>. Every cadence a mob picks,
/// every direction it strolls in and every roll a goal makes comes out of this generator, so a port
/// that reaches for <see cref="Random"/> produces a different sequence from the same seed and nothing
/// random driven can be diffed against the jar or reproduced in a test.
/// <p/>
/// This is the <c>BitRandomSource</c> half: everything is derived from <see cref="Next"/>, exactly as
/// the interface's default methods derive it. <see cref="LegacyRandomSource"/> is the generator that
/// supplies the bits.
/// </summary>
public abstract class RandomSource {
    private const float FloatMultiplier = 5.9604645E-8f;
    private const double DoubleMultiplier = 1.1102230246251565E-16;

    /// <summary>The next <paramref name="bits"/> bits of the stream, as the low bits of an int.</summary>
    public abstract int Next(int bits);

    /// <summary>Reseeds the generator, which also discards any half used gaussian pair.</summary>
    public abstract void SetSeed(long seed);

    /// <summary>A new generator seeded from this one, vanilla's <c>fork</c>.</summary>
    public abstract RandomSource Fork();

    public int NextInt() {
        return Next(32);
    }

    /// <summary>
    /// <c>BitRandomSource.nextInt(int)</c>. A power of two bound is a multiply and a shift; anything
    /// else is rejection sampled, and the loop is what keeps the distribution flat, so it cannot be
    /// replaced with a plain modulo.
    /// </summary>
    public int NextInt(int bound) {
        if (bound <= 0) {
            throw new ArgumentException("Bound must be positive", nameof(bound));
        }

        if ((bound & (bound - 1)) == 0) {
            return (int)((bound * (long)Next(31)) >> 31);
        }

        int bits, value;
        do {
            bits = Next(31);
            value = bits % bound;
        } while (bits - value + (bound - 1) < 0);

        return value;
    }

    /// <summary><c>RandomSource.nextInt(int, int)</c>: a value in [min, max).</summary>
    public int NextInt(int min, int max) {
        return min + NextInt(max - min);
    }

    /// <summary><c>RandomSource.nextIntBetweenInclusive</c>: a value in [min, max].</summary>
    public int NextIntBetweenInclusive(int min, int max) {
        return NextInt(max - min + 1) + min;
    }

    public long NextLong() {
        // Two draws, high half first. The addition rather than an or is vanilla's, and it matters:
        // the low half is signed, so a negative one borrows from the high half.
        int high = Next(32);
        int low = Next(32);
        return ((long)high << 32) + low;
    }

    public bool NextBoolean() {
        return Next(1) != 0;
    }

    public float NextFloat() {
        return Next(24) * FloatMultiplier;
    }

    public double NextDouble() {
        long bits = ((long)Next(26) << 27) + Next(27);
        return bits * DoubleMultiplier;
    }

    /// <summary>
    /// <c>MarsagliaPolarGaussian.nextGaussian</c>: the polar method, which produces two values at a
    /// time and hands the second one out on the next call. Reseeding throws the spare away, which is
    /// why <see cref="SetSeed"/> has to call <see cref="ResetGaussian"/>.
    /// </summary>
    public double NextGaussian() {
        if (_haveNextGaussian) {
            _haveNextGaussian = false;
            return _nextGaussian;
        }

        while (true) {
            double x = 2.0 * NextDouble() - 1.0;
            double y = 2.0 * NextDouble() - 1.0;
            double lengthSquared = Mth.Square(x) + Mth.Square(y);
            if (lengthSquared >= 1.0 || lengthSquared == 0.0) {
                continue;
            }

            double scale = Math.Sqrt(-2.0 * Math.Log(lengthSquared) / lengthSquared);
            _nextGaussian = y * scale;
            _haveNextGaussian = true;
            return x * scale;
        }
    }

    /// <summary><c>RandomSource.triangle</c>: a triangular distribution centred on <paramref name="centre"/>.</summary>
    public double Triangle(double centre, double spread) {
        return centre + spread * (NextDouble() - NextDouble());
    }

    /// <summary><c>RandomSource.triangle(float, float)</c>.</summary>
    public float Triangle(float centre, float spread) {
        return centre + spread * (NextFloat() - NextFloat());
    }

    /// <summary><c>RandomSource.consumeCount</c>: burn draws without using them.</summary>
    public void ConsumeCount(int count) {
        for (int i = 0; i < count; i++) {
            NextInt();
        }
    }

    private double _nextGaussian;
    private bool _haveNextGaussian;

    protected void ResetGaussian() {
        _haveNextGaussian = false;
    }
}

/// <summary>
/// <c>LegacyRandomSource</c>: the forty eight bit linear congruential generator <c>java.util.Random</c>
/// is, which is what every entity carries and what all of vanilla's non worldgen randomness comes out
/// of. The constants are the ones in the jar and must not be adjusted.
/// <p/>
/// Vanilla holds the seed in an <c>AtomicLong</c> and throws if two threads race on it. There is no
/// equivalent here: this is not thread safe and is not meant to be, since it is only ever touched from
/// the tick.
/// </summary>
public sealed class LegacyRandomSource : RandomSource {
    private const long Multiplier = 25214903917L;
    private const long Increment = 11L;
    private const long ModulusMask = 281474976710655L;  // (1 << 48) - 1

    private long _seed;

    public LegacyRandomSource(long seed) {
        SetSeed(seed);
    }

    /// <summary>A generator seeded from the platform, for anything that does not need reproducing.</summary>
    public static LegacyRandomSource Create() {
        return new LegacyRandomSource(Random.Shared.NextInt64());
    }

    public override void SetSeed(long seed) {
        // The scramble by the multiplier is part of the contract, not part of the step: two generators
        // seeded the same way agree only if this happens too.
        _seed = (seed ^ Multiplier) & ModulusMask;
        ResetGaussian();
    }

    public override int Next(int bits) {
        _seed = (_seed * Multiplier + Increment) & ModulusMask;

        // The mask keeps the seed non negative, so the sign of the shift makes no difference and this
        // matches the jar's signed one.
        return (int)(_seed >> (48 - bits));
    }

    public override RandomSource Fork() {
        return new LegacyRandomSource(NextLong());
    }
}
