using System.Numerics;

namespace ClientLib.Maths;

/// <summary>
/// The part of Apache Commons' <c>Fraction</c> that bundle weights use, with its overflow checks: a
/// result outside an int throws <see cref="ArithmeticException"/>, which <c>BundleContents</c> turns into
/// an unusable weight, so where the checks fire decides which bundles vanilla refuses.
/// </summary>
public readonly struct Fraction : IComparable<Fraction>, IEquatable<Fraction> {
    public static readonly Fraction Zero = new(0, 1);
    public static readonly Fraction One = new(1, 1);

    public int Numerator { get; }
    public int Denominator { get; }

    private Fraction(int numerator, int denominator) {
        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary><c>getFraction(int, int)</c>, which normalises the sign and does not reduce.</summary>
    public static Fraction Of(int numerator, int denominator) {
        if (denominator == 0) {
            throw new ArithmeticException("The denominator must not be zero");
        }
        if (denominator < 0) {
            if (numerator == int.MinValue || denominator == int.MinValue) {
                throw new ArithmeticException("overflow: can't negate");
            }
            numerator = -numerator;
            denominator = -denominator;
        }
        return new Fraction(numerator, denominator);
    }

    private static Fraction Reduced(int numerator, int denominator) {
        if (denominator == 0) {
            throw new ArithmeticException("The denominator must not be zero");
        }
        if (numerator == 0) {
            return Zero;
        }
        if (denominator == int.MinValue && (numerator & 1) == 0) {
            numerator /= 2;
            denominator /= 2;
        }
        if (denominator < 0) {
            if (numerator == int.MinValue || denominator == int.MinValue) {
                throw new ArithmeticException("overflow: can't negate");
            }
            numerator = -numerator;
            denominator = -denominator;
        }
        int gcd = Gcd(numerator, denominator);
        return new Fraction(numerator / gcd, denominator / gcd);
    }

    public int IntValue => Numerator / Denominator;

    public float FloatValue => (float)Numerator / Denominator;

    public Fraction Add(Fraction other) => AddSub(other, true);

    public Fraction Subtract(Fraction other) => AddSub(other, false);

    private Fraction Negate() {
        if (Numerator == int.MinValue) {
            throw new ArithmeticException("overflow: too large to negate");
        }
        return new Fraction(-Numerator, Denominator);
    }

    private Fraction AddSub(Fraction other, bool isAdd) {
        if (Numerator == 0) {
            return isAdd ? other : other.Negate();
        }
        if (other.Numerator == 0) {
            return this;
        }
        int d1 = Gcd(Denominator, other.Denominator);
        if (d1 == 1) {
            int uvp = checked(Numerator * other.Denominator);
            int upv = checked(other.Numerator * Denominator);
            return new Fraction(isAdd ? checked(uvp + upv) : checked(uvp - upv), checked(Denominator * other.Denominator));
        }
        BigInteger uvpBig = new BigInteger(Numerator) * (other.Denominator / d1);
        BigInteger upvBig = new BigInteger(other.Numerator) * (Denominator / d1);
        BigInteger t = isAdd ? uvpBig + upvBig : uvpBig - upvBig;
        int tmodd1 = (int)BigInteger.Remainder(BigInteger.Remainder(t, d1) + d1, d1);
        int d2 = tmodd1 == 0 ? d1 : Gcd(tmodd1, d1);
        BigInteger w = BigInteger.Divide(t, d2);
        if (w > int.MaxValue || w < int.MinValue) {
            throw new ArithmeticException("overflow: numerator too large after multiply");
        }
        return new Fraction((int)w, checked(Denominator / d1 * (other.Denominator / d2)));
    }

    public Fraction Multiply(Fraction other) {
        if (Numerator == 0 || other.Numerator == 0) {
            return Zero;
        }
        int d1 = Gcd(Numerator, other.Denominator);
        int d2 = Gcd(other.Numerator, Denominator);
        return Reduced(checked(Numerator / d1 * (other.Numerator / d2)), checked(Denominator / d2 * (other.Denominator / d1)));
    }

    public Fraction Multiply(int count) => Multiply(Of(count, 1));

    public Fraction Divide(Fraction other) {
        if (other.Numerator == 0) {
            throw new ArithmeticException("The fraction to divide by must not be zero");
        }
        return Multiply(other.Invert());
    }

    private Fraction Invert() {
        if (Numerator == 0) {
            throw new ArithmeticException("Unable to invert zero.");
        }
        if (Numerator == int.MinValue) {
            throw new ArithmeticException("overflow: can't negate numerator");
        }
        return Numerator < 0 ? new Fraction(-Denominator, -Numerator) : new Fraction(Denominator, Numerator);
    }

    public int CompareTo(Fraction other) {
        if (Numerator == other.Numerator && Denominator == other.Denominator) {
            return 0;
        }
        return ((long)Numerator * other.Denominator).CompareTo((long)other.Numerator * Denominator);
    }

    public bool Equals(Fraction other) => Numerator == other.Numerator && Denominator == other.Denominator;

    public override bool Equals(object? obj) => obj is Fraction other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public override string ToString() => $"{Numerator}/{Denominator}";

    private static int Gcd(int u, int v) => (int)BigInteger.GreatestCommonDivisor(u, v);
}
