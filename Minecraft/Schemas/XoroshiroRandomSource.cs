using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Minecraft.Schemas;

/// <summary>
/// <c>Xoroshiro128PlusPlus</c>: the 128 bit generator every modern worldgen decision comes out of.
/// </summary>
/// <remarks>
/// An all zero state is a fixed point for this algorithm, so the constructor replaces it with the two
/// ratio constants. Without that a seed of zero produces zeros forever.
/// </remarks>
public sealed class Xoroshiro128PlusPlus {
    private long _seedLo;
    private long _seedHi;

    public Xoroshiro128PlusPlus(long seedLo, long seedHi) {
        _seedLo = seedLo;
        _seedHi = seedHi;

        if ((_seedLo | _seedHi) == 0L) {
            _seedLo = RandomSupport.GoldenRatio64;
            _seedHi = RandomSupport.SilverRatio64;
        }
    }

    public Xoroshiro128PlusPlus(Seed128Bit seed) : this(seed.Lo, seed.Hi) { }

    public long NextLong() {
        long s0 = _seedLo;
        long s1 = _seedHi;
        long result = RotateLeft(s0 + s1, 17) + s0;

        s1 ^= s0;
        _seedLo = RotateLeft(s0, 49) ^ s1 ^ (s1 << 21);
        _seedHi = RotateLeft(s1, 28);
        return result;
    }

    private static long RotateLeft(long value, int bits) {
        return (long)BitOperations.RotateLeft((ulong)value, bits);
    }
}

/// <summary>A 128 bit seed, vanilla's <c>RandomSupport.Seed128bit</c>.</summary>
public readonly record struct Seed128Bit(long Lo, long Hi) {
    public Seed128Bit Xor(long lo, long hi) => new(Lo ^ lo, Hi ^ hi);

    public Seed128Bit Mixed() => new(RandomSupport.MixStafford13(Lo), RandomSupport.MixStafford13(Hi));
}

/// <summary>Vanilla's <c>RandomSupport</c>: how a 64 bit world seed becomes a 128 bit one.</summary>
public static class RandomSupport {
    public const long GoldenRatio64 = -7046029254386353131L;
    public const long SilverRatio64 = 7640891576956012809L;

    /// <summary>The Stafford variant 13 mix. Every shift is unsigned, so the operand has to be.</summary>
    public static long MixStafford13(long z) {
        ulong value = (ulong)z;
        value = (value ^ (value >> 30)) * 13787848793156543929UL;   // -4658895280553007687 as unsigned
        value = (value ^ (value >> 27)) * 10723151780598845931UL;   // -7723592293110705685 as unsigned
        return (long)(value ^ (value >> 31));
    }

    public static Seed128Bit UpgradeSeedTo128BitUnmixed(long legacySeed) {
        long lo = legacySeed ^ SilverRatio64;
        return new Seed128Bit(lo, lo + GoldenRatio64);
    }

    public static Seed128Bit UpgradeSeedTo128Bit(long legacySeed) {
        return UpgradeSeedTo128BitUnmixed(legacySeed).Mixed();
    }

    /// <summary>
    /// The MD5 of a name, split big endian into two longs. This is how a noise octave and a surface
    /// rule get their generator, so it has to be MD5 and it has to be read in this order.
    /// </summary>
    public static Seed128Bit SeedFromHashOf(string input) {
        byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(input));
        return new Seed128Bit(FromBytes(hash, 0), FromBytes(hash, 8));
    }

    private static long FromBytes(byte[] bytes, int offset) {
        long value = 0;
        for (int i = 0; i < 8; i++) {
            value = (value << 8) | bytes[offset + i];
        }

        return value;
    }
}

/// <summary>
/// <c>XoroshiroRandomSource</c>. Not a <c>BitRandomSource</c>: it draws a whole long at a time and
/// derives everything from that, so every method here overrides rather than falling back to
/// <see cref="RandomSource.Next"/>.
/// </summary>
/// <remarks>
/// <see cref="NextFloat"/> narrows its draw to a float before scaling and <see cref="NextDouble"/>
/// does not, which is what the two unit constants below are: one <c>float</c>, one <c>double</c>.
/// Widening the float path or narrowing the double one moves every noise offset in the game by about
/// a part in ten million, which is enough to generate a different world while looking identical.
/// </remarks>
public sealed class XoroshiroRandomSource : RandomSource {
    private const float FloatUnit = 5.9604645E-8f;
    private const double DoubleUnit = 1.1102230246251565E-16;

    private Xoroshiro128PlusPlus _generator;

    public XoroshiroRandomSource(long seed) {
        _generator = new Xoroshiro128PlusPlus(RandomSupport.UpgradeSeedTo128Bit(seed));
    }

    public XoroshiroRandomSource(long seedLo, long seedHi) {
        _generator = new Xoroshiro128PlusPlus(seedLo, seedHi);
    }

    public XoroshiroRandomSource(Seed128Bit seed) {
        _generator = new Xoroshiro128PlusPlus(seed);
    }

    public override void SetSeed(long seed) {
        _generator = new Xoroshiro128PlusPlus(RandomSupport.UpgradeSeedTo128Bit(seed));
        ResetGaussian();
    }

    public override RandomSource Fork() {
        return new XoroshiroRandomSource(_generator.NextLong(), _generator.NextLong());
    }

    public override IPositionalRandomFactory ForkPositional() {
        return new XoroshiroPositionalRandomFactory(_generator.NextLong(), _generator.NextLong());
    }

    /// <summary>
    /// Vanilla has no equivalent, since this generator is not a bit source, so there is no right
    /// answer to give: every method below draws longs and derives its own value. Throwing keeps a
    /// caller that reached for the base class's primitive from getting an invented sequence.
    /// </summary>
    public override int Next(int bits) {
        throw new NotSupportedException(
            "XoroshiroRandomSource is not a bit source; use NextInt, NextLong, NextDouble or NextFloat.");
    }

    public override int NextInt() {
        return (int)_generator.NextLong();
    }

    /// <summary>
    /// Lemire's multiply-shift, not the rejection loop the legacy source uses. The rejection branch is
    /// only entered when the low word could fall in a biased bucket, which is what keeps it flat.
    /// </summary>
    public override int NextInt(int bound) {
        if (bound <= 0) {
            throw new ArgumentException("Bound must be positive", nameof(bound));
        }

        long randomBits = (uint)NextInt();
        long multiplied = randomBits * bound;
        long fractional = multiplied & 0xFFFFFFFFL;

        if (fractional < bound) {
            // Java's remainderUnsigned over the two's complement negation, i.e. 2^32 mod bound.
            int unbiasedStart = (int)((uint)(~bound + 1) % (uint)bound);
            while (fractional < unbiasedStart) {
                randomBits = (uint)NextInt();
                multiplied = randomBits * bound;
                fractional = multiplied & 0xFFFFFFFFL;
            }
        }

        return (int)(multiplied >> 32);
    }

    public override long NextLong() {
        return _generator.NextLong();
    }

    public override bool NextBoolean() {
        return (_generator.NextLong() & 1L) != 0L;
    }

    public override float NextFloat() {
        // Narrowed to float before the multiply, which is the l2f in the jar.
        return (float)NextBits(24) * FloatUnit;
    }

    public override double NextDouble() {
        return NextBits(53) * DoubleUnit;
    }

    public override void ConsumeCount(int count) {
        for (int i = 0; i < count; i++) {
            _generator.NextLong();
        }
    }

    /// <summary>The top <paramref name="bits"/> bits of a draw, shifted down unsigned.</summary>
    private long NextBits(int bits) {
        return (long)((ulong)_generator.NextLong() >> (64 - bits));
    }
}

/// <summary>
/// <c>XoroshiroRandomSource.XoroshiroPositionalRandomFactory</c>. <see cref="FromHashOf"/> is MD5
/// rather than the string hash the legacy factory uses, which is why the two are separate types
/// rather than one parameterised by a generator.
/// </summary>
public sealed class XoroshiroPositionalRandomFactory(long seedLo, long seedHi) : IPositionalRandomFactory {
    public RandomSource At(int x, int y, int z) {
        return new XoroshiroRandomSource(Mth.GetSeed(x, y, z) ^ seedLo, seedHi);
    }

    public RandomSource FromHashOf(string name) {
        return new XoroshiroRandomSource(RandomSupport.SeedFromHashOf(name).Xor(seedLo, seedHi));
    }

    public RandomSource FromSeed(long seed) {
        return new XoroshiroRandomSource(seed ^ seedLo, seed ^ seedHi);
    }
}
